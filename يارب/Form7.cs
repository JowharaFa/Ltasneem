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
    public partial class Form7 : Form
    {
        public Form7()
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
            SqlCommand cmd = new SqlCommand("insert into [Members] values (@xid,@xfirst_name,@xlast_name,@xaddress,@xphone_number,@xGender)", ft.jt);
            ft.jt.Open();
            cmd.Parameters.AddWithValue("@xid", textBox1.Text);
            cmd.Parameters.AddWithValue("@xfirst_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@xlast_name", textBox3.Text);
            cmd.Parameters.AddWithValue("@xaddress", textBox4.Text);
            cmd.Parameters.AddWithValue("@xphone_number", textBox5.Text);
            cmd.Parameters.AddWithValue("@xGender", textBox5.Text);
            int x = cmd.ExecuteNonQuery();
            MessageBox.Show("table row effect =" + x);
            Form7_Load(button1, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            ft.jt.Close();
            //label1.Text = ft.xname;
            DataTable dt = new DataTable();
            ft.jt.Open();
            SqlCommand cmd = new SqlCommand("select * from [Members]", ft.jt);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            ft.jt.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ft.jt.Close();
            SqlCommand cmd = new SqlCommand("delete from [Members] where id=" + textBox1.Text, ft.jt);
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
            Form7_Load(button2, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Members] SET [first_name]=@y,[last_name]=@n,[address]=@m, [phone_number]=@z,[Gender]=@e where [id]=@x", ft.jt);
            ft.jt.Open();
            cmd.Parameters.AddWithValue("@x", textBox1.Text);
            cmd.Parameters.AddWithValue("@y", textBox2.Text);
            cmd.Parameters.AddWithValue("@n", textBox3.Text);
            cmd.Parameters.AddWithValue("@m", textBox4.Text);
            cmd.Parameters.AddWithValue("@z", textBox5.Text);
            cmd.Parameters.AddWithValue("@e", textBox6.Text);

            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                MessageBox.Show("تمت العملية بنجاح");
            }
            else
            {
                MessageBox.Show("حدث خطا ما");
            }
            Form7_Load(button4, e);
        }
    }
}
