namespace KasSiswa
{
    partial class kasAdmin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numKredit = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLunas = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnRefreshSiswa = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefreshTagihan = new System.Windows.Forms.Button();
            this.dataGridTagihan = new System.Windows.Forms.DataGridView();
            this.SelectTagihan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdTagihan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSiswaTagihan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSiswaTagihan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tagihan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kassiswaDataSet = new KasSiswa.kassiswaDataSet();
            this.tagihanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tagihanTableAdapter = new KasSiswa.kassiswaDataSetTableAdapters.tagihanTableAdapter();
            this.dataGridSiswa = new System.Windows.Forms.DataGridView();
            this.SelectSiswa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdSiswa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaSiswa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numKredit)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTagihan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kassiswaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagihanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSiswa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. Pilih siswa yang ingin ditagih:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tagih";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rp.";
            // 
            // numKredit
            // 
            this.numKredit.Location = new System.Drawing.Point(65, 81);
            this.numKredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numKredit.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numKredit.Name = "numKredit";
            this.numKredit.Size = new System.Drawing.Size(228, 26);
            this.numKredit.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numKredit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(44, 622);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(331, 178);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. Tagih Siswa-siswa";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 116);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Tagih";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnTagih_Click);
            // 
            // btnLunas
            // 
            this.btnLunas.Location = new System.Drawing.Point(628, 622);
            this.btnLunas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLunas.Name = "btnLunas";
            this.btnLunas.Size = new System.Drawing.Size(127, 29);
            this.btnLunas.TabIndex = 13;
            this.btnLunas.Text = "Lunaskan";
            this.btnLunas.UseVisualStyleBackColor = true;
            this.btnLunas.Click += new System.EventHandler(this.btnLunas_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(40, 11);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(187, 20);
            this.lblWelcome.TabIndex = 13;
            this.lblWelcome.Text = "Selamat datang <admin>";
            // 
            // btnRefreshSiswa
            // 
            this.btnRefreshSiswa.Location = new System.Drawing.Point(520, 44);
            this.btnRefreshSiswa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefreshSiswa.Name = "btnRefreshSiswa";
            this.btnRefreshSiswa.Size = new System.Drawing.Size(84, 29);
            this.btnRefreshSiswa.TabIndex = 14;
            this.btnRefreshSiswa.Text = "Refresh";
            this.btnRefreshSiswa.UseVisualStyleBackColor = true;
            this.btnRefreshSiswa.Click += new System.EventHandler(this.btnRefreshSiswa_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(624, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Pilih siswa yang sudah lunas:";
            // 
            // btnRefreshTagihan
            // 
            this.btnRefreshTagihan.Location = new System.Drawing.Point(1182, 46);
            this.btnRefreshTagihan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefreshTagihan.Name = "btnRefreshTagihan";
            this.btnRefreshTagihan.Size = new System.Drawing.Size(84, 29);
            this.btnRefreshTagihan.TabIndex = 17;
            this.btnRefreshTagihan.Text = "Refresh";
            this.btnRefreshTagihan.UseVisualStyleBackColor = true;
            this.btnRefreshTagihan.Click += new System.EventHandler(this.btnRefreshTagihan_Click);
            // 
            // dataGridTagihan
            // 
            this.dataGridTagihan.AllowUserToAddRows = false;
            this.dataGridTagihan.AllowUserToDeleteRows = false;
            this.dataGridTagihan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTagihan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectTagihan,
            this.IdTagihan,
            this.IdSiswaTagihan,
            this.NamaSiswaTagihan,
            this.Tagihan});
            this.dataGridTagihan.Location = new System.Drawing.Point(628, 89);
            this.dataGridTagihan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridTagihan.Name = "dataGridTagihan";
            this.dataGridTagihan.RowHeadersWidth = 51;
            this.dataGridTagihan.RowTemplate.Height = 24;
            this.dataGridTagihan.Size = new System.Drawing.Size(639, 502);
            this.dataGridTagihan.TabIndex = 18;
            // 
            // SelectTagihan
            // 
            this.SelectTagihan.HeaderText = "PIlih";
            this.SelectTagihan.MinimumWidth = 6;
            this.SelectTagihan.Name = "SelectTagihan";
            this.SelectTagihan.Width = 50;
            // 
            // IdTagihan
            // 
            this.IdTagihan.HeaderText = "ID Tagihan";
            this.IdTagihan.MinimumWidth = 6;
            this.IdTagihan.Name = "IdTagihan";
            this.IdTagihan.Visible = false;
            this.IdTagihan.Width = 125;
            // 
            // IdSiswaTagihan
            // 
            this.IdSiswaTagihan.HeaderText = "ID";
            this.IdSiswaTagihan.MinimumWidth = 6;
            this.IdSiswaTagihan.Name = "IdSiswaTagihan";
            this.IdSiswaTagihan.Width = 50;
            // 
            // NamaSiswaTagihan
            // 
            this.NamaSiswaTagihan.HeaderText = "Nama Siswa";
            this.NamaSiswaTagihan.MinimumWidth = 6;
            this.NamaSiswaTagihan.Name = "NamaSiswaTagihan";
            this.NamaSiswaTagihan.ReadOnly = true;
            this.NamaSiswaTagihan.Width = 125;
            // 
            // Tagihan
            // 
            dataGridViewCellStyle1.Format = "\'Rp\'#,##0";
            dataGridViewCellStyle1.NullValue = null;
            this.Tagihan.DefaultCellStyle = dataGridViewCellStyle1;
            this.Tagihan.HeaderText = "Tagihan";
            this.Tagihan.MinimumWidth = 6;
            this.Tagihan.Name = "Tagihan";
            this.Tagihan.Width = 125;
            // 
            // kassiswaDataSet
            // 
            this.kassiswaDataSet.DataSetName = "kassiswaDataSet";
            this.kassiswaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tagihanBindingSource
            // 
            this.tagihanBindingSource.DataMember = "tagihan";
            this.tagihanBindingSource.DataSource = this.kassiswaDataSet;
            // 
            // tagihanTableAdapter
            // 
            this.tagihanTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridSiswa
            // 
            this.dataGridSiswa.AllowUserToAddRows = false;
            this.dataGridSiswa.AllowUserToDeleteRows = false;
            this.dataGridSiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSiswa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectSiswa,
            this.IdSiswa,
            this.NamaSiswa});
            this.dataGridSiswa.Location = new System.Drawing.Point(44, 89);
            this.dataGridSiswa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridSiswa.Name = "dataGridSiswa";
            this.dataGridSiswa.RowHeadersWidth = 51;
            this.dataGridSiswa.RowTemplate.Height = 24;
            this.dataGridSiswa.Size = new System.Drawing.Size(560, 502);
            this.dataGridSiswa.TabIndex = 13;
            // 
            // SelectSiswa
            // 
            this.SelectSiswa.HeaderText = "Select";
            this.SelectSiswa.MinimumWidth = 6;
            this.SelectSiswa.Name = "SelectSiswa";
            this.SelectSiswa.Width = 50;
            // 
            // IdSiswa
            // 
            this.IdSiswa.HeaderText = "ID";
            this.IdSiswa.MinimumWidth = 6;
            this.IdSiswa.Name = "IdSiswa";
            this.IdSiswa.ReadOnly = true;
            this.IdSiswa.Width = 50;
            // 
            // NamaSiswa
            // 
            this.NamaSiswa.HeaderText = "Nama Siswa";
            this.NamaSiswa.MinimumWidth = 6;
            this.NamaSiswa.Name = "NamaSiswa";
            this.NamaSiswa.ReadOnly = true;
            this.NamaSiswa.Width = 125;
            // 
            // kasAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 815);
            this.Controls.Add(this.dataGridSiswa);
            this.Controls.Add(this.dataGridTagihan);
            this.Controls.Add(this.btnLunas);
            this.Controls.Add(this.btnRefreshTagihan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRefreshSiswa);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "kasAdmin";
            this.Text = "kasAdmin";
            this.Load += new System.EventHandler(this.kasAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numKredit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTagihan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kassiswaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagihanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSiswa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numKredit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLunas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnRefreshSiswa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefreshTagihan;
        private System.Windows.Forms.DataGridView dataGridTagihan;
        private kassiswaDataSet kassiswaDataSet;
        private System.Windows.Forms.BindingSource tagihanBindingSource;
        private kassiswaDataSetTableAdapters.tagihanTableAdapter tagihanTableAdapter;
        private System.Windows.Forms.DataGridView dataGridSiswa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectSiswa;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSiswa;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSiswa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectTagihan;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTagihan;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSiswaTagihan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaSiswaTagihan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tagihan;
    }
}