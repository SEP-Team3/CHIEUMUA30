namespace Prototype_SEP_Team3.Admin
{
    partial class GUI_Admin_CTĐT
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
            this.label5 = new System.Windows.Forms.Label();
            this.lstCTDT = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.cbbCopyCTDT = new System.Windows.Forms.ComboBox();
            this.cbbNguoiTaoCTDT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCTDT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnBack = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSua = new System.Windows.Forms.Button();
            this.chkCopyTu = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lstCTDT)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(828, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Tìm kiếm";
            // 
            // lstCTDT
            // 
            this.lstCTDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstCTDT.Location = new System.Drawing.Point(632, 142);
            this.lstCTDT.Name = "lstCTDT";
            this.lstCTDT.Size = new System.Drawing.Size(554, 318);
            this.lstCTDT.TabIndex = 30;
            this.lstCTDT.DoubleClick += new System.EventHandler(this.lstCTDT_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(903, 110);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(283, 24);
            this.txtSearch.TabIndex = 29;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(493, 303);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(88, 35);
            this.btnCreate.TabIndex = 28;
            this.btnCreate.Text = "TẠO";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cbbCopyCTDT
            // 
            this.cbbCopyCTDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCopyCTDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCopyCTDT.FormattingEnabled = true;
            this.cbbCopyCTDT.Location = new System.Drawing.Point(221, 259);
            this.cbbCopyCTDT.Name = "cbbCopyCTDT";
            this.cbbCopyCTDT.Size = new System.Drawing.Size(360, 26);
            this.cbbCopyCTDT.TabIndex = 27;
            // 
            // cbbNguoiTaoCTDT
            // 
            this.cbbNguoiTaoCTDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNguoiTaoCTDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNguoiTaoCTDT.FormattingEnabled = true;
            this.cbbNguoiTaoCTDT.Location = new System.Drawing.Point(221, 206);
            this.cbbNguoiTaoCTDT.Name = "cbbNguoiTaoCTDT";
            this.cbbNguoiTaoCTDT.Size = new System.Drawing.Size(360, 26);
            this.cbbNguoiTaoCTDT.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Người phụ trách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Tên CTĐT";
            // 
            // txtCTDT
            // 
            this.txtCTDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCTDT.Location = new System.Drawing.Point(221, 155);
            this.txtCTDT.Name = "txtCTDT";
            this.txtCTDT.Size = new System.Drawing.Size(360, 24);
            this.txtCTDT.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(427, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 31);
            this.label1.TabIndex = 21;
            this.label1.Text = "TẠO CHƯƠNG TRÌNH ĐÀO TẠO";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBack});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnBack
            // 
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(49, 20);
            this.btnBack.Text = "BACK";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(493, 303);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 35);
            this.btnSua.TabIndex = 33;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // chkCopyTu
            // 
            this.chkCopyTu.AutoSize = true;
            this.chkCopyTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopyTu.Location = new System.Drawing.Point(12, 261);
            this.chkCopyTu.Name = "chkCopyTu";
            this.chkCopyTu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCopyTu.Size = new System.Drawing.Size(189, 22);
            this.chkCopyTu.TabIndex = 34;
            this.chkCopyTu.Text = "Copy từ CTĐT ( nếu có )";
            this.chkCopyTu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCopyTu.UseVisualStyleBackColor = true;
            this.chkCopyTu.Click += new System.EventHandler(this.chkCopyTu_Click);
            // 
            // GUI_Admin_CTĐT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 491);
            this.Controls.Add(this.chkCopyTu);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstCTDT);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbbCopyCTDT);
            this.Controls.Add(this.cbbNguoiTaoCTDT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCTDT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI_Admin_CTĐT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_Admin_CTĐT";
            ((System.ComponentModel.ISupportInitialize)(this.lstCTDT)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView lstCTDT;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cbbCopyCTDT;
        private System.Windows.Forms.ComboBox cbbNguoiTaoCTDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCTDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnBack;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.CheckBox chkCopyTu;
    }
}