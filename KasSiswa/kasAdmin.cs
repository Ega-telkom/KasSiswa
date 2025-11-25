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
using static KasSiswa.kasAdmin;
using System.Configuration;

namespace KasSiswa
{
    public partial class kasAdmin : Form
    {
        public kasAdmin(string nama)
        {
            InitializeComponent();
            lblWelcome.Text = "Selamat datang admin bendahara: " + nama;
        }
        
        // Koneksi Database
        private string ConnString => $"Data Source={ConfigurationManager.AppSettings["DBHost"]};Initial Catalog={ConfigurationManager.AppSettings["DBName"]};Integrated Security=True;Connect Timeout=30;";
        SqlCommand cmd;
        SqlDataReader dr;

        // Kumpulan data Siswa
        public class SiswaItem
        {
            public int IdSiswa { get; set; }
            public string NamaSiswa { get; set; }
            public int NoHp { get; set; }
        }

        // Kumpulan data Tagihan
        public class TagihanItem : SiswaItem
        {
            public string IdTagihan { get; set; }
            public int JumlahTagihan { get; set; }
        }

        // Muat data Siswa
        public void loadSiswa()
        {
            List<SiswaItem> siswaItems = new List<SiswaItem>();

            using (SqlConnection con = new SqlConnection(ConnString))
            {

                string query = "SELECT id_siswa, nama_siswa, nohp FROM siswa";

                con.Open();
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    siswaItems.Add(new SiswaItem
                    {
                        IdSiswa = Convert.ToInt32(dr["id_siswa"]),
                        NamaSiswa = dr["nama_siswa"].ToString(),
                        NoHp = Convert.ToInt32(dr["nohp"])
                    });
                }
                dr.Close();
            }

            // Bind ke DataGridView
            dataGridSiswa.Rows.Clear();
            foreach (var item in siswaItems)
            {
                dataGridSiswa.Rows.Add(false, item.IdSiswa, item.NamaSiswa, item.NoHp);
            }
        }

        // Muat data Tagihan
        public void LoadTagihan()
        {
            List<TagihanItem> tagihanItems = new List<TagihanItem>();

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                string query = @"
                    SELECT t.id_tagihan, t.id_siswa, s.nama_siswa, t.tagihan
                    FROM tagihan t
                    JOIN siswa s ON t.id_siswa = s.id_siswa
                    WHERE t.lunas = 0";

                con.Open();
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tagihanItems.Add(new TagihanItem
                    {
                        IdTagihan = dr["id_tagihan"].ToString(),
                        IdSiswa = Convert.ToInt32(dr["id_siswa"]),
                        NamaSiswa = dr["nama_siswa"].ToString(),
                        JumlahTagihan = Convert.ToInt32(dr["tagihan"])
                    });
                }
                dr.Close();
            }

            // Bind ke DataGridView
            dataGridTagihan.Rows.Clear();
            foreach (var item in tagihanItems)
            {
                dataGridTagihan.Rows.Add(false, item.IdTagihan, item.IdSiswa, item.NamaSiswa, item.JumlahTagihan);
            }
        }

        // Fungsi Tagih
        public void Tagih()
        {
            int jumlahSelected = dataGridSiswa.Rows
                .Cast<DataGridViewRow>()
                .Count(row => Convert.ToBoolean(row.Cells["SelectSiswa"].Value));

            if (jumlahSelected == 0)
            {
                MessageBox.Show("Pilih minimal 1 orang!");
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                int jumlahTagihan = int.Parse(numKredit.Text); // input nominal tagihan

                if (jumlahTagihan <= 0)
                {
                    MessageBox.Show("Jumlah tagihan harus lebih dari 0.");
                    return;
                }

                con.Open();

                foreach (DataGridViewRow row in dataGridSiswa.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["SelectSiswa"].Value); // checkbox column
                    if (isSelected)
                    {
                        string idTagihan = Guid.NewGuid().ToString();
                        string idSiswa = row.Cells["IdSiswa"].Value.ToString();
                        string query = @"INSERT INTO tagihan (id_tagihan, id_siswa, tagihan) VALUES (@id_tagihan, @id_siswa, @tagihan)";
                        using (cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id_tagihan", idTagihan);
                            cmd.Parameters.AddWithValue("@id_siswa", idSiswa);
                            cmd.Parameters.AddWithValue("@tagihan", jumlahTagihan);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                con.Close();
            }

            MessageBox.Show("Menagih sebanyak " + jumlahSelected + " siswa");
            LoadTagihan(); // refresh table to show unpaid only
        }

        // Fungsi Lunas
        public void Lunas()
        {
            int jumlahSelected = dataGridTagihan.Rows
                .Cast<DataGridViewRow>()
                .Count(row => Convert.ToBoolean(row.Cells["SelectTagihan"].Value));

            if (jumlahSelected == 0) {
                MessageBox.Show("Pilih minimal 1 orang!");
                return;
            }

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();

                foreach (DataGridViewRow row in dataGridTagihan.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["SelectTagihan"].Value); // checkbox column
                    if (isSelected)
                    {
                        string idTagihan = row.Cells["IdTagihan"].Value.ToString();
                        string query = "UPDATE tagihan SET lunas = 1 WHERE id_tagihan = @id_tagihan";

                        using (cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id_tagihan", idTagihan);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                con.Close();
            }

            MessageBox.Show("Melunasi sebanyak " + jumlahSelected + " siswa");
            LoadTagihan(); // refresh table to show unpaid only
        }

        private void kasAdmin_Load(object sender, EventArgs e)
        {
            loadSiswa();
            LoadTagihan();
        }

        // Tombol Refresh
        //
        private void btnRefreshSiswa_Click(object sender, EventArgs e)
        {
            loadSiswa();
        }

        private void btnRefreshTagihan_Click(object sender, EventArgs e)
        {
            LoadTagihan();
        }

        // Tombol Tagih/Lunas
        //
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
