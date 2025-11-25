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

namespace KasSiswa
{
    public partial class Login : Form
    {
        // Koneksi Database dan inisialisasi hal-hal
        private string ConnString => $"Data Source={ConfigurationManager.AppSettings["DBHost"]};Initial Catalog={ConfigurationManager.AppSettings["DBName"]};Integrated Security=True;Connect Timeout=30;";

        SqlCommand cmd;
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        public void onLogin()
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                string query = "SELECT * FROM bendahara WHERE username = @username AND password = @password";
                cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Ambil username dari database
                    string nama = dr["username"].ToString();

                    // Tampilkan form kasAdmin dan pass data nama
                    kasAdmin formKasAdmin = new kasAdmin(nama);
                    formKasAdmin.Show();
                    MessageBox.Show("HALO ADMIN");

                    // Sembunyikan Login pada saat berhasil
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dr.Close();
                con.Close();

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            onLogin();
        }

        // Event pada saat menekan tombol Enter di txtPassword
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                onLogin();
                e.SuppressKeyPress = true;
            }
        }
    }
}
