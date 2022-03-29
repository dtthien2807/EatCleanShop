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
using System.Configuration;

namespace FormEatCleanShop
{
    public partial class Login : Form
    {
        public static string NameLogin = "";
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "check_login";
                cmd.Parameters.AddWithValue("@namelogin", txt_nameadmin.Text);
                cmd.Parameters.AddWithValue("@pass", txt_password.Text);
                cmd.Connection = conn;
                NameLogin = txt_nameadmin.Text;
                object kq = cmd.ExecuteScalar();
                int code = Convert.ToInt32(kq);
                if (code == 1)
                {
                    MessageBox.Show("Congratulation " + NameLogin + " login success", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else if (code == 2)
                {
                    MessageBox.Show("Incorrect account or password !!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_password.Text = "";
                    txt_nameadmin.Text = "";
                    txt_nameadmin.Focus();
                }
                else
                {
                    MessageBox.Show("Account does not exist !!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_password.Text = "";
                    txt_nameadmin.Text = "";
                    txt_nameadmin.Focus();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_nameadmin_MouseClick(object sender, MouseEventArgs e)
        {
            txt_nameadmin.SelectAll();
        }

        private void txt_password_MouseClick(object sender, MouseEventArgs e)
        {
            txt_password.SelectAll();
        }
    }
}
