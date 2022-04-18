using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.Data.SqlClient;

namespace FormEatCleanShop
{
    public partial class PrintProduct : Form
    {
        public PrintProduct()
        {
            InitializeComponent();
        }

        private void PrintProduct_Load(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load("D:\\Admin\\Documents\\FormEatCleanShop\\EatCleanShop\\FormEatCleanShop\\CrystalReportProduct.rpt");
            //report.RecordSelectionFormula = "{tbl_detailOrder.price}";
            crystalReportViewerProduct.ReportSource = report;
            crystalReportViewerProduct.RefreshReport();
        }

        private void btCategory_Click(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load("D:\\Admin\\Documents\\FormEatCleanShop\\EatCleanShop\\FormEatCleanShop\\CrystalReportProduct.rpt");

            string constr = ConfigurationManager.ConnectionStrings["organic_shop"].ConnectionString;
            SqlConnection sp = new SqlConnection(constr);
            sp.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sp;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = @"select_product_by_category";
            cmd.Parameters.AddWithValue("@tenloai", txtCategory.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            CrystalReportProductByCategory category = new CrystalReportProductByCategory();
            category.SetDataSource(dataTable);
            crystalReportViewerProduct.ReportSource = category;
            crystalReportViewerProduct.Refresh();
        }
    }
}
