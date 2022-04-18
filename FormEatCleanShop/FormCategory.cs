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
    public partial class FormCategory : Form
    {
        public FormCategory()
        {
            InitializeComponent();
        }

        private void FormCategory_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }
        private void LoadCategory()
        {
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from viewCategory", sp);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            gvCategory.DataSource = dt;
            sqlDataAdapter.Dispose();
        }

        private void gvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNameCategory.Text = gvCategory.CurrentRow.Cells["Category"].Value.ToString();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sp;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = @"them_loai";
            cmd.Parameters.AddWithValue("@tenloai", txtNameCategory.Text);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Add success!", "Notification");
                LoadCategory();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (gvCategory.Rows.Count <= 0)
                return;
            if (MessageBox.Show("Do you want delete this category?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sp;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = @"xoa_loai";
            cmd.Parameters.AddWithValue("@tenloai", txtNameCategory.Text);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Delete success!");
                LoadCategory();
            }
            else
            {
                MessageBox.Show("Error!");

            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Show();
            this.Hide();
        }
    }
}
