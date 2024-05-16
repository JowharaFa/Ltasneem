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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("select * from [users]", ft.jt);
                ft.jt.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["username"].ToString() == textBox1.Text && dr["password"].ToString() == textBox2.Text)
                    {

                        ft.xname = dr.GetValue(1).ToString();

                        Form3 f2 = new Form3();
                        f2.Show();
                        this.Hide();
                        break;

                    }
                    else
                    {
                        MessageBox.Show("There are some error in user name or password");
                    }
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.ToString());
            }

            finally
            {
                ft.jt.Close();
            }
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.SaddleBrown;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SaddleBrown;
        }
    }
}
