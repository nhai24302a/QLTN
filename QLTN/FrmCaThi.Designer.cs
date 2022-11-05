
namespace QLTN
{
    partial class FrmCaThi
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btnaddnew = new System.Windows.Forms.Button();
            this.txtTGKT = new System.Windows.Forms.TextBox();
            this.txtTGBD = new System.Windows.Forms.TextBox();
            this.txtNgayThi = new System.Windows.Forms.TextBox();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.txtTenCa = new System.Windows.Forms.TextBox();
            this.txtMaCa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.MaCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(132)))), ((int)(((byte)(200)))));
            this.label2.Font = new System.Drawing.Font("Cambria", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-7, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1019, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ca thi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnupdate);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btnedit);
            this.panel1.Controls.Add(this.btnaddnew);
            this.panel1.Controls.Add(this.txtTGKT);
            this.panel1.Controls.Add(this.txtTGBD);
            this.panel1.Controls.Add(this.txtNgayThi);
            this.panel1.Controls.Add(this.txtMaMon);
            this.panel1.Controls.Add(this.txtTenCa);
            this.panel1.Controls.Add(this.txtMaCa);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 494);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 288);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.White;
            this.btnupdate.Enabled = false;
            this.btnupdate.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(132)))), ((int)(((byte)(253)))));
            this.btnupdate.Location = new System.Drawing.Point(708, 185);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(88, 34);
            this.btnupdate.TabIndex = 20;
            this.btnupdate.Text = "Cập nhật";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.White;
            this.btndelete.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(132)))), ((int)(((byte)(253)))));
            this.btndelete.Location = new System.Drawing.Point(534, 185);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(88, 34);
            this.btndelete.TabIndex = 19;
            this.btndelete.Text = "Xóa";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.White;
            this.btnedit.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(132)))), ((int)(((byte)(253)))));
            this.btnedit.Location = new System.Drawing.Point(367, 185);
            this.btnedit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(88, 34);
            this.btnedit.TabIndex = 18;
            this.btnedit.Text = "Sửa";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnaddnew
            // 
            this.btnaddnew.BackColor = System.Drawing.Color.White;
            this.btnaddnew.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddnew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(132)))), ((int)(((byte)(253)))));
            this.btnaddnew.Location = new System.Drawing.Point(204, 185);
            this.btnaddnew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnaddnew.Name = "btnaddnew";
            this.btnaddnew.Size = new System.Drawing.Size(88, 34);
            this.btnaddnew.TabIndex = 17;
            this.btnaddnew.Text = "Thêm";
            this.btnaddnew.UseVisualStyleBackColor = false;
            this.btnaddnew.Click += new System.EventHandler(this.btnaddnew_Click);
            // 
            // txtTGKT
            // 
            this.txtTGKT.Location = new System.Drawing.Point(631, 117);
            this.txtTGKT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTGKT.Name = "txtTGKT";
            this.txtTGKT.Size = new System.Drawing.Size(201, 22);
            this.txtTGKT.TabIndex = 11;
            // 
            // txtTGBD
            // 
            this.txtTGBD.Location = new System.Drawing.Point(631, 71);
            this.txtTGBD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTGBD.Name = "txtTGBD";
            this.txtTGBD.Size = new System.Drawing.Size(201, 22);
            this.txtTGBD.TabIndex = 10;
            // 
            // txtNgayThi
            // 
            this.txtNgayThi.Location = new System.Drawing.Point(631, 25);
            this.txtNgayThi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgayThi.Name = "txtNgayThi";
            this.txtNgayThi.Size = new System.Drawing.Size(201, 22);
            this.txtNgayThi.TabIndex = 9;
            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(171, 117);
            this.txtMaMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(201, 22);
            this.txtMaMon.TabIndex = 8;
            // 
            // txtTenCa
            // 
            this.txtTenCa.Location = new System.Drawing.Point(171, 71);
            this.txtTenCa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.Size = new System.Drawing.Size(201, 22);
            this.txtTenCa.TabIndex = 7;
            // 
            // txtMaCa
            // 
            this.txtMaCa.Location = new System.Drawing.Point(171, 25);
            this.txtMaCa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaCa.Name = "txtMaCa";
            this.txtMaCa.Size = new System.Drawing.Size(201, 22);
            this.txtMaCa.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(473, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian bắt đầu:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(473, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Thời gian bắt đầu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(473, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ngày thi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã môn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên ca thi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã ca thi:";
            // 
            // grdData
            // 
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCa,
            this.MaMon,
            this.TenCa,
            this.TGBD,
            this.TGKT,
            this.NgayThi});
            this.grdData.Location = new System.Drawing.Point(1, 48);
            this.grdData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdData.Name = "grdData";
            this.grdData.RowHeadersWidth = 51;
            this.grdData.RowTemplate.Height = 24;
            this.grdData.Size = new System.Drawing.Size(1003, 439);
            this.grdData.TabIndex = 3;
            this.grdData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MaCa
            // 
            this.MaCa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MaCa.DataPropertyName = "MaCa";
            this.MaCa.HeaderText = "Mã ca";
            this.MaCa.MinimumWidth = 6;
            this.MaCa.Name = "MaCa";
            this.MaCa.Width = 75;
            // 
            // MaMon
            // 
            this.MaMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MaMon.DataPropertyName = "MaMon";
            this.MaMon.HeaderText = "Mã môn";
            this.MaMon.MinimumWidth = 6;
            this.MaMon.Name = "MaMon";
            this.MaMon.Width = 87;
            // 
            // TenCa
            // 
            this.TenCa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TenCa.DataPropertyName = "TenCa";
            this.TenCa.HeaderText = "Tên ca";
            this.TenCa.MinimumWidth = 6;
            this.TenCa.Name = "TenCa";
            this.TenCa.Width = 81;
            // 
            // TGBD
            // 
            this.TGBD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TGBD.DataPropertyName = "TGBD";
            this.TGBD.HeaderText = "TG bắt đầu";
            this.TGBD.MinimumWidth = 6;
            this.TGBD.Name = "TGBD";
            this.TGBD.Width = 109;
            // 
            // TGKT
            // 
            this.TGKT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TGKT.DataPropertyName = "TGKT";
            this.TGKT.HeaderText = "TG kết thúc";
            this.TGKT.MinimumWidth = 6;
            this.TGKT.Name = "TGKT";
            this.TGKT.Width = 111;
            // 
            // NgayThi
            // 
            this.NgayThi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NgayThi.DataPropertyName = "NgayThi";
            this.NgayThi.HeaderText = "Ngày Thi";
            this.NgayThi.MinimumWidth = 6;
            this.NgayThi.Name = "NgayThi";
            this.NgayThi.Width = 94;
            // 
            // FrmCaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 750);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCaThi";
            this.Text = "FrmCaThi";
            this.Load += new System.EventHandler(this.FrmCaThi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTGKT;
        private System.Windows.Forms.TextBox txtTGBD;
        private System.Windows.Forms.TextBox txtNgayThi;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.TextBox txtTenCa;
        private System.Windows.Forms.TextBox txtMaCa;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btnaddnew;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThi;
    }
}