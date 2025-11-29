using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace KasSiswa
{
    public partial class kasAdmin : Form
    {
        // Koneksi Database
        private string ConnString => $"Data Source={ConfigurationManager.AppSettings["DBHost"]};Initial Catalog={ConfigurationManager.AppSettings["DBName"]};Integrated Security=True;Connect Timeout=30;";

        SqlDataAdapter adapterSiswa;
        SqlDataAdapter adapterTagihan;
        SqlCommandBuilder builderSiswa;
        DataTable dtSiswa;
        DataTable dtTagihan;

        public kasAdmin(string nama)
        {
            InitializeComponent();
            toolStripUser.Text = "Masuk sebagai: " + nama;
        }

        private void kasAdmin_Load(object sender, EventArgs e)
        {
            LoadSiswa();
            LoadTagihan();
            UpdateStatusBar();
            UpdateStatusTagihan();
        }

        // Load data Siswa dengan DataAdapter
        public void LoadSiswa()
        {
            try
            {
                string query = "SELECT id_siswa, no_absen, nama_siswa, nohp FROM siswa ORDER BY no_absen";
                adapterSiswa = new SqlDataAdapter(query, ConnString);
                builderSiswa = new SqlCommandBuilder(adapterSiswa);

                dtSiswa = new DataTable();
                adapterSiswa.Fill(dtSiswa);

                // Set primary key
                dtSiswa.PrimaryKey = new DataColumn[] { dtSiswa.Columns["id_siswa"] };

                // Handle new rows - generate GUID otomatis
                dtSiswa.ColumnChanging += (s, ev) =>
                {
                    if (ev.Column.ColumnName == "no_absen" || ev.Column.ColumnName == "nama_siswa")
                    {
                        if (ev.Row["id_siswa"] == DBNull.Value || string.IsNullOrEmpty(ev.Row["id_siswa"].ToString()))
                        {
                            ev.Row["id_siswa"] = Guid.NewGuid();
                        }
                    }
                };

                // Grid untuk EDIT
                dataGridSiswa.AllowUserToAddRows = true;
                dataGridSiswa.AllowUserToDeleteRows = true;
                dataGridSiswa.DataSource = dtSiswa;
                dataGridSiswa.Columns["id_siswa"].ReadOnly = true;
                dataGridSiswa.Columns["id_siswa"].Visible = false; // Hide GUID dari user
                dataGridSiswa.Columns["no_absen"].HeaderText = "No. Absen";
                dataGridSiswa.Columns["nama_siswa"].HeaderText = "Nama";
                dataGridSiswa.Columns["nohp"].HeaderText = "No. HP";

                // Grid untuk TAGIH (dengan checkbox)
                DataTable dtTagih = dtSiswa.Copy();
                DataColumn chkCol = new DataColumn("Select", typeof(bool));
                chkCol.DefaultValue = false;
                dtTagih.Columns.Add(chkCol);
                dtTagih.Columns["Select"].SetOrdinal(0);

                dataGridSiswaTagih.DataSource = dtTagih;
                dataGridSiswaTagih.Columns["Select"].ReadOnly = false;
                dataGridSiswaTagih.Columns["id_siswa"].Visible = false;
                dataGridSiswaTagih.Columns["no_absen"].HeaderText = "No. Absen";
                dataGridSiswaTagih.Columns["nama_siswa"].HeaderText = "Nama";
                dataGridSiswaTagih.Columns["nohp"].HeaderText = "No. HP";
                dataGridSiswaTagih.AllowUserToAddRows = false;
                dataGridSiswaTagih.AllowUserToDeleteRows = false;

                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load siswa: " + ex.Message);
            }
        }

        // Load data Tagihan dengan DataAdapter
        public void LoadTagihan()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    string query = @"
                        SELECT t.id_tagihan, t.id_siswa, s.no_absen, s.nama_siswa, t.tagihan
                        FROM tagihan t
                        JOIN siswa s ON t.id_siswa = s.id_siswa
                        WHERE t.lunas = 0
                        ORDER BY s.no_absen";

                    adapterTagihan = new SqlDataAdapter(query, con);

                    dtTagihan = new DataTable();
                    adapterTagihan.Fill(dtTagihan);

                    // Tambah kolom checkbox manual
                    if (!dtTagihan.Columns.Contains("Select"))
                    {
                        DataColumn chkCol = new DataColumn("Select", typeof(bool));
                        chkCol.DefaultValue = false;
                        dtTagihan.Columns.Add(chkCol);
                        dtTagihan.Columns["Select"].SetOrdinal(0);
                    }

                    dataGridTagihan.DataSource = dtTagihan;
                    dataGridTagihan.Columns["Select"].ReadOnly = false;
                    dataGridTagihan.Columns["id_tagihan"].Visible = false;
                    dataGridTagihan.Columns["id_siswa"].Visible = false;
                    dataGridTagihan.Columns["no_absen"].HeaderText = "No. Absen";
                    dataGridTagihan.Columns["no_absen"].ReadOnly = true;
                    dataGridTagihan.Columns["nama_siswa"].HeaderText = "Nama";
                    dataGridTagihan.Columns["nama_siswa"].ReadOnly = true;
                    dataGridTagihan.Columns["tagihan"].HeaderText = "Tagihan (Rp)";
                    dataGridTagihan.Columns["tagihan"].ReadOnly = true;
                    dataGridTagihan.AllowUserToAddRows = false;
                    dataGridTagihan.AllowUserToDeleteRows = false;

                    // Update status bar tagihan
                    UpdateStatusTagihan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load tagihan: " + ex.Message);
            }
        }

        // Update status bar tagihan
        private void UpdateStatusTagihan()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    con.Open();
                    string query = "SELECT COUNT(DISTINCT id_siswa) FROM tagihan WHERE lunas = 0";
                    string query1 = "SELECT COUNT(*) FROM tagihan WHERE lunas = 0";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        int count = (int)cmd.ExecuteScalar();

                        using (SqlCommand cmd2 = new SqlCommand(query1, con))
                        {
                            int count1 = (int)cmd2.ExecuteScalar();
                            toolStripTagih.Text = count.ToString() + " Siswa Belum Lunas (" + count1 + " Tagihan)";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripTagih.Text = "Error";
            }
        }

        // Save perubahan data Siswa (INSERT/UPDATE/DELETE)
        private void btnSimpanSiswa_Click(object sender, EventArgs e)
        {
            try
            {
                // Set GUID untuk row baru yang belum punya id_siswa
                foreach (DataRow row in dtSiswa.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        if (row["id_siswa"] == DBNull.Value || string.IsNullOrEmpty(row["id_siswa"].ToString()))
                        {
                            row["id_siswa"] = Guid.NewGuid();
                        }
                    }
                }

                adapterSiswa.Update(dtSiswa);
                MessageBox.Show("Data siswa berhasil disimpan!");
                LoadSiswa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error simpan siswa: " + ex.Message);
            }
        }

        // Fungsi Tagih
        public void Tagih()
        {
            var dtTagih = (DataTable)dataGridSiswaTagih.DataSource;
            var selectedRows = dtTagih.AsEnumerable()
                .Where(row => row.Field<bool>("Select"))
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Pilih minimal 1 orang!");
                return;
            }

            int jumlahTagihan = int.Parse(numKredit.Text);
            if (jumlahTagihan <= 0)
            {
                MessageBox.Show("Jumlah tagihan harus lebih dari 0.");
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                foreach (var row in selectedRows)
                {
                    Guid idTagihan = Guid.NewGuid();
                    Guid idSiswa = row.Field<Guid>("id_siswa");

                    string query = "INSERT INTO tagihan (id_tagihan, id_siswa, tagihan) VALUES (@id_tagihan, @id_siswa, @tagihan)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_tagihan", idTagihan);
                        cmd.Parameters.AddWithValue("@id_siswa", idSiswa);
                        cmd.Parameters.AddWithValue("@tagihan", jumlahTagihan);
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }

            LoadTagihan();
            MessageBox.Show($"Menagih sebanyak {selectedRows.Count} siswa");
            UpdateStatusTagihan();
        }

        // Fungsi Lunas
        public void Lunas()
        {
            var selectedRows = dtTagihan.AsEnumerable()
                .Where(row => row.Field<bool>("Select"))
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Pilih minimal 1 orang!");
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                foreach (var row in selectedRows)
                {
                    Guid idTagihan = row.Field<Guid>("id_tagihan");
                    string query = "UPDATE tagihan SET lunas = 1 WHERE id_tagihan = @id_tagihan";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_tagihan", idTagihan);
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }

            LoadTagihan();
            MessageBox.Show($"Melunasi sebanyak {selectedRows.Count} siswa");
            UpdateStatusTagihan();
        }

        // Update status bar
        private void UpdateStatusBar()
        {
            if (dtSiswa != null)
                toolStripSiswa.Text = dtSiswa.Rows.Count.ToString() + " Siswa";
        }

        // Event Handlers
        private void btnRefreshSiswa_Click(object sender, EventArgs e)
        {
            LoadSiswa();
        }

        private void btnRefreshTagihan_Click(object sender, EventArgs e)
        {
            LoadTagihan();
        }

        private void btnTagih_Click(object sender, EventArgs e)
        {
            Tagih();
        }

        private void btnLunas_Click(object sender, EventArgs e)
        {
            Lunas();
        }
    }
}