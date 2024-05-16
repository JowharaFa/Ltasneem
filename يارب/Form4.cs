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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ft.jt.Close();
           // label1.Text = ft.xname;
            DataTable dt = new DataTable();
            ft.jt.Open();
            SqlCommand cmd = new SqlCommand("select * from [Books]", ft.jt);
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
           ft.jt.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("insert into [Books] values (@xid,@xname,@xAuthor,@xGenre,@xPublishing_house,@xPrice)", ft.jt);
            ft.jt.Open();
            cmd.Parameters.AddWithValue("@xid", textBox1.Text);
            cmd.Parameters.AddWithValue("@xname", textBox2.Text); 
            cmd.Parameters.AddWithValue("@xAuthor", textBox3.Text);
            cmd.Parameters.AddWithValue("@xGenre", textBox4.Text);
            cmd.Parameters.AddWithValue("@xPublishing_house", textBox5.Text);
            cmd.Parameters.AddWithValue("@xPrice", textBox6.Text);
            int x = cmd.ExecuteNonQuery();
            MessageBox.Show("table row effect =" + x);
            Form4_Load(button1, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ft.jt.Close();
            SqlCommand cmd = new SqlCommand("delete from [Books] where id="+textBox1.Text, ft.jt);
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
            Form4_Load(button2, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Books] SET [name]=@y,[Author]=@n,[Genre]=@m, [Publishing_house]=@z, [Price]=@o where [id]=@x", ft.jt);
            ft.jt.Open();
            cmd.Parameters.AddWithValue("@x", textBox1.Text);
            cmd.Parameters.AddWithValue("@y", textBox2.Text);
            cmd.Parameters.AddWithValue("@n", textBox3.Text);
            cmd.Parameters.AddWithValue("@m", textBox4.Text);
            cmd.Parameters.AddWithValue("@z", textBox5.Text);
            cmd.Parameters.AddWithValue("@o", textBox6.Text);
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                MessageBox.Show("تمت العملية بنجاح");
            }
            else
            {
                MessageBox.Show("حدث خطا ما");
            }
            Form4_Load(button3, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
