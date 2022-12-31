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

namespace PersonelKayit
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=OMER\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            cmbCities.Text = "";
            mtxtMoney.Text = "";
            txtJob.Text = "";
            radioMaried.Checked = false;
            radioSingle.Checked = false;
            txtName.Focus();

        }
        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);

            komut.Parameters.AddWithValue("@p1", txtName.Text);
            komut.Parameters.AddWithValue("@p2", txtSurname.Text);
            komut.Parameters.AddWithValue("@p3", cmbCities.Text);
            komut.Parameters.AddWithValue("@p4", mtxtMoney.Text);
            komut.Parameters.AddWithValue("@p5", txtJob.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void radioMaried_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMaried.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSingle.Checked == true)
            {
                label8.Text = "False";
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbCities.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mtxtMoney.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtJob.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();


        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioMaried.Checked = true;
            }
            else if (label8.Text == "False")
            {
                radioSingle.Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil= new SqlCommand("Delete from Tbl_Personel Where Perid @k1");
            komutsil.Parameters.AddWithValue("@k1",txtId.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4, PerDurum=@a5, PerMeslek=@a6 where Perid=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1",txtName.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtSurname.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmbCities.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mtxtMoney.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtJob.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtId.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellendi.");
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            Frmİstatistik fr=new Frmİstatistik();
            fr.Show();
        }

        private void btnGraphic_Click(object sender, EventArgs e)
        {
            FrmGrafik frg= new FrmGrafik();
            frg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRaporlama frr = new FrmRaporlama();
            frr.Show();
        }
    }
}
