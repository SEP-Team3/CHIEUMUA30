namespace Prototype_SEP_Team3.Admin
{
    partial class GUI_Admin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstCTDT = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnTaoCTDT = new System.Windows.Forms.ToolStripMenuItem();
            this.qUẢNLÝTÀIKHOẢNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.lstCTDT)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(400, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "QUẢN LÝ CHƯƠNG TRÌNH ĐÀO TẠO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(838, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tìm kiếm";
            // 
            // lstCTDT
            // 
            this.lstCTDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lstCTDT.Location = new System.Drawing.Point(53, 150);
            this.lstCTDT.Name = "lstCTDT";
            this.lstCTDT.Size = new System.Drawing.Size(1155, 404);
            this.lstCTDT.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(913, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(282, 24);
            this.textBox1.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTaoCTDT,
            this.qUẢNLÝTÀIKHOẢNToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnTaoCTDT
            // 
            this.btnTaoCTDT.Name = "btnTaoCTDT";
            this.btnTaoCTDT.Size = new System.Drawing.Size(190, 20);
            this.btnTaoCTDT.Text = "TẠO CHƯƠNG TRÌNH ĐÀO TẠO";
            this.btnTaoCTDT.Click += new System.EventHandler(this.btnTaoCTDT_Click);
            // 
            // qUẢNLÝTÀIKHOẢNToolStripMenuItem
            // 
            this.qUẢNLÝTÀIKHOẢNToolStripMenuItem.Name = "qUẢNLÝTÀIKHOẢNToolStripMenuItem";
            this.qUẢNLÝTÀIKHOẢNToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.qUẢNLÝTÀIKHOẢNToolStripMenuItem.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // GUI_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 587);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstCTDT);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_Admin";
            ((System.ComponentModel.ISupportInitialize)(this.lstCTDT)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView lstCTDT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnTaoCTDT;
        private System.Windows.Forms.ToolStripMenuItem qUẢNLÝTÀIKHOẢNToolStripMenuItem;
    }
}