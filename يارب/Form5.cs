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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
          ft.jt.Close();
            //label1.Text = ft.xname;
            DataTable dt = new DataTable();
           ft.jt.Open();
            SqlCommand cmd = new SqlCommand("select * from [Authores]", ft.jt);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            ft.jt.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into [Authores] values (@xid,@xFirst_name,@xLast_name,@xEducation,@xEmail)", ft.jt);
            ft.jt.Open();
            cmd.Parameters.AddWithValue("@xid", textBox1.Text);
            cmd.Parameters.AddWithValue("@xFirst_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@xLast_name", textBox3.Text);
            cmd.Parameters.AddWithValue("@xEducation", textBox4.Text);
            cmd.Parameters.AddWithValue("@xEmail", textBox5.Text);
            int x = cmd.ExecuteNonQuery();
            MessageBox.Show("table row effect =" + x);
            Form5_Load(button1, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
          ft.jt.Close();
            SqlCommand cmd = new SqlCommand("delete from [Authores] where id=" + textBox1.Text, ft.jt);
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
            Form5_Load(button2, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Authores] SET [First_name]=@y,[Last_name]=@n,[Education]=@m, [Email]=@z where [id]=@x", ft.jt);
            ft.jt.Open();
            cmd.Parameters.AddWithValue("@x", textBox1.Text);
            cmd.Parameters.AddWithValue("@y", textBox2.Text);
            cmd.Parameters.AddWithValue("@n", textBox3.Text);
            cmd.Parameters.AddWithValue("@m", textBox4.Text);
            cmd.Parameters.AddWithValue("@z", textBox5.Text);

            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                MessageBox.Show("تمت العملية بنجاح");
            }
            else
            {
                MessageBox.Show("حدث خطا ما");
            }
            Form5_Load(button3, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.Show();
            this.Hide();
        }
    }
}
