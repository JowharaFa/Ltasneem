using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace يارب
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("insert into [Genres] values (@xid,@xname)", ft.jt);
            ft.jt.Open();
            cmd.Parameters.AddWithValue("@xid", textBox1.Text);
            cmd.Parameters.AddWithValue("@xname", textBox2.Text);
            int x = cmd.ExecuteNonQuery();
            MessageBox.Show("table row effect =" + x);
            Form6_Load(button1, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            ft.jt.Close();
            //label1.Text = ft.xname;
            DataTable dt = new DataTable();
            ft.jt.Open();
            SqlCommand cmd = new SqlCommand("select * from [Genres]", ft.jt);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            ft.jt.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ft.jt.Close();
            SqlCommand cmd = new SqlCommand("delete from [Genres] where id=" + textBox1.Text, ft.jt);
            ft.jt.Open();
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                MessageBox.Show("تمت عملية الحذف بنجاح");
            }
            else
            {
                MessageBox.Show("هناك حدث خطأ ما");
            }
            ft.jt.Close();
            Form6_Load(button2, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Genres] SET [name]=@y where [id]=@x", ft.jt);
            ft.jt.Open();
            cmd.Parameters.AddWithValue("@x", textBox1.Text);
            cmd.Parameters.AddWithValue("@y", textBox2.Text);
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                MessageBox.Show("تمت العملية بنجاح");
            }
            else
            {
                MessageBox.Show("حدث خطا ما");
            }
            Form6_Load(button3, e);
        }
    }
}
