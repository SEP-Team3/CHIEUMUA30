namespace Prototype_SEP_Team3
{
    partial class GUI_Chinh_GV
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
            this.lblDangXuat = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lstMainCTDT = new System.Windows.Forms.DataGridView();
            this.txtSearchCTDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstMainDCCT = new System.Windows.Forms.DataGridView();
            this.txtSearchDCCT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.lstMainCTDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMainDCCT)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDangXuat
            // 
            this.lblDangXuat.AutoSize = true;
            this.lblDangXuat.Location = new System.Drawing.Point(1160, 20);
            this.lblDangXuat.Name = "lblDangXuat";
            this.lblDangXuat.Size = new System.Drawing.Size(56, 13);
            this.lblDangXuat.TabIndex = 23;
            this.lblDangXuat.TabStop = true;
            this.lblDangXuat.Text = "Đăng xuất";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(358, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tìm kiếm";
            // 
            // lstMainCTDT
            // 
            this.lstMainCTDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstMainCTDT.Location = new System.Drawing.Point(6, 73);
            this.lstMainCTDT.Name = "lstMainCTDT";
            this.lstMainCTDT.Size = new System.Drawing.Size(1205, 379);
            this.lstMainCTDT.TabIndex = 21;
            this.lstMainCTDT.DoubleClick += new System.EventHandler(this.lstMainCTDT_DoubleClick);
            // 
            // txtSearchCTDT
            // 
            this.txtSearchCTDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCTDT.Location = new System.Drawing.Point(433, 16);
            this.txtSearchCTDT.Name = "txtSearchCTDT";
            this.txtSearchCTDT.Size = new System.Drawing.Size(367, 24);
            this.txtSearchCTDT.TabIndex = 20;
            this.txtSearchCTDT.TextChanged += new System.EventHandler(this.txtSearchCTDT_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(470, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "DANH SÁCH CHƯƠNG TRÌNH ĐÀO TẠO";
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(1026, 603);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(186, 45);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "XUẤT FILE WORD";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(315, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "PHẦN MỀM QUẢN LÝ CHƯƠNG TRÌNH ĐÀO TẠO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(365, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Tìm kiếm";
            // 
            // lstMainDCCT
            // 
            this.lstMainDCCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstMainDCCT.Location = new System.Drawing.Point(6, 75);
            this.lstMainDCCT.Name = "lstMainDCCT";
            this.lstMainDCCT.Size = new System.Drawing.Size(1205, 377);
            this.lstMainDCCT.TabIndex = 26;
            // 
            // txtSearchDCCT
            // 
            this.txtSearchDCCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchDCCT.Location = new System.Drawing.Point(440, 15);
            this.txtSearchDCCT.Name = "txtSearchDCCT";
            this.txtSearchDCCT.Size = new System.Drawing.Size(382, 24);
            this.txtSearchDCCT.TabIndex = 25;
            this.txtSearchDCCT.TextChanged += new System.EventHandler(this.txtSearchDCCT_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(485, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "DANH SÁCH ĐỀ CƯƠNG CHI TIẾT";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1225, 484);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstMainCTDT);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtSearchCTDT);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1217, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CHƯƠNG TRÌNH ĐÀO TẠO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstMainDCCT);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtSearchDCCT);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1217, 458);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ĐỀ CƯƠNG CHI TIẾT";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GUI_Chinh_GV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 660);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblDangXuat);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.Name = "GUI_Chinh_GV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_Chinh_GV";
            ((System.ComponentModel.ISupportInitialize)(this.lstMainCTDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstMainDCCT)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblDangXuat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView lstMainCTDT;
        private System.Windows.Forms.TextBox txtSearchCTDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView lstMainDCCT;
        private System.Windows.Forms.TextBox txtSearchDCCT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}