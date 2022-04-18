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
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Show();
            this.Hide();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadProduct();
        }
        private void LoadCategory()
        {
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from tbl_categoryProduct", sp);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            cbCategory.DataSource = dt;
            cbCategory.DisplayMember = "name_categoryProduct";
            cbCategory.ValueMember = "id_categoryProduct";
            sqlDataAdapter.Dispose();
        }
        private void LoadProduct()
        {
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from viewProduct", sp);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            gvProduct.DataSource = dt;
            sqlDataAdapter.Dispose();
        }

        private void gvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID_product.Text = gvProduct.CurrentRow.Cells["ID"].Value.ToString();
            txtName_product.Text = gvProduct.CurrentRow.Cells["Name Product"].Value.ToString();
            cbCategory.Text = gvProduct.CurrentRow.Cells["Category"].Value.ToString();
            date_create.Text = gvProduct.CurrentRow.Cells["Date"].Value.ToString();
            txtAmount.Text = gvProduct.CurrentRow.Cells["Amount"].Value.ToString();
            txtPrice.Text = gvProduct.CurrentRow.Cells["Price"].Value.ToString();
            txtDescription.Text = gvProduct.CurrentRow.Cells["Description"].Value.ToString();
        }
        private static bool checkmasp(string id_product)
        {
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            string sql = "select * from tbl_product where id_product='" + id_product + "'";
            sp.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sp;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sp.Close();
                return true;
            }
            else
            {
                sp.Close();
                return false;
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            string masp = txtID_product.Text;
            if (checkmasp(masp))
            {
                MessageBox.Show("Id already exist!", "Notification");
                return;
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sp;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = @"add_sp";
                cmd.Parameters.AddWithValue("@masp", txtID_product.Text);
                cmd.Parameters.AddWithValue("@tensp", txtName_product.Text);
                cmd.Parameters.AddWithValue("@maloai", cbCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@ngaythem", DateTime.Parse(date_create.Text));
                cmd.Parameters.AddWithValue("@soluong", int.Parse(txtAmount.Text));
                cmd.Parameters.AddWithValue("@gia", int.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@mota", txtDescription.Text);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Add success!", "Notification");
                    LoadProduct();
                    LoadCategory();
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (gvProduct.Rows.Count <= 0)
                return;
            if (MessageBox.Show("Do you want update this product?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sp;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = @"capnhat_sp";
            cmd.Parameters.AddWithValue("@masp", txtID_product.Text);
            cmd.Parameters.AddWithValue("@tensp", txtName_product.Text);
            cmd.Parameters.AddWithValue("@maloai", cbCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@ngaynhap", DateTime.Parse(date_create.Text));
            cmd.Parameters.AddWithValue("@soluong", int.Parse(txtAmount.Text));
            cmd.Parameters.AddWithValue("@gia", int.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@mota", txtDescription.Text);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Update success!");
                LoadProduct();
            }
            else
            {
                MessageBox.Show("Error!");

            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (gvProduct.Rows.Count <= 0)
                return;
            if (MessageBox.Show("Do you want delete this product?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sp;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = @"xoa_sp";
            cmd.Parameters.AddWithValue("@masp", txtID_product.Text);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Delete success!");
                LoadProduct();
            }
            else
            {
                MessageBox.Show("Error!");

            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            string tensp = txtName_product.Text;
            DateTime date = DateTime.Parse(date_create.Text);
            string sql = "select * from tbl_product where name_product='" + tensp + "'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, sp);
            DataTable data = new DataTable();
            ad.Fill(data);
            if (data.Rows.Count > 0)
            {
                gvProduct.DataSource = data;
            }
            else
            {
                MessageBox.Show("Nothing!");
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            PrintProduct print = new PrintProduct();
            print.Show();
        }

        private void FormProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want close Form?", "Notification",
               MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true; //không đóng forrm nữa
        }
    }
}
