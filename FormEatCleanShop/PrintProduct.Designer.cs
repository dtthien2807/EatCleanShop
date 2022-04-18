namespace FormEatCleanShop
{
    partial class PrintProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewerProduct = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.btCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewerProduct
            // 
            this.crystalReportViewerProduct.ActiveViewIndex = -1;
            this.crystalReportViewerProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerProduct.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewerProduct.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewerProduct.Name = "crystalReportViewerProduct";
            this.crystalReportViewerProduct.Size = new System.Drawing.Size(800, 450);
            this.crystalReportViewerProduct.TabIndex = 0;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(352, 31);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(100, 20);
            this.txtCategory.TabIndex = 1;
            // 
            // btCategory
            // 
            this.btCategory.Location = new System.Drawing.Point(458, 31);
            this.btCategory.Name = "btCategory";
            this.btCategory.Size = new System.Drawing.Size(75, 23);
            this.btCategory.TabIndex = 2;
            this.btCategory.Text = "Category";
            this.btCategory.UseVisualStyleBackColor = true;
            this.btCategory.Click += new System.EventHandler(this.btCategory_Click);
            // 
            // PrintProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.crystalReportViewerProduct);
            this.Name = "PrintProduct";
            this.Text = "PrintProduct";
            this.Load += new System.EventHandler(this.PrintProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerProduct;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Button btCategory;
    }
}