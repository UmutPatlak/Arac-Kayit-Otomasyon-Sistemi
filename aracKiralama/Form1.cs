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
using System.IO;

namespace aracKiralama
{
    public partial class Form1 : Form
    {
        public Form1()
        {


            InitializeComponent();
        }

        static string baglantiyolu = @"Data Source=DESKTOP-HGGVOAC\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlConnection baglanti = new SqlConnection(baglantiyolu);
        SqlDataReader okuyucu;

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadData(); 
            groupboxOGS.Visible = false;
            groupboxHGS.Visible = false;



            txtKayitSubesi2.Visible = false;
            txtMarka2.Visible = false;
            txtPlaka2.Visible = false;
            txtKayitSubesi2.Text = string.Empty;
            txtKayitSubesi2.ReadOnly = true;

            txtMarka2.Text = string.Empty;
            txtMarka2.ReadOnly = true;

            txtPlaka2.Text = string.Empty;
            txtPlaka2.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            using ( OpenFileDialog open = new OpenFileDialog()){

                open.Filter = "Imange Files |*.jpg;*.jpeg;*.png;*.bmp";
                if(open.ShowDialog()== DialogResult.OK)
                {
                    string imagePath = open.FileName;
                    textPath.Text = imagePath;
                    pictureResim.Image = Image.FromFile(imagePath);


                }
             }
            LoadData();


        }


        public void InsertImage(string filepath) {

            byte[] imageData = File.ReadAllBytes(filepath);

                string islem = "INSERT INTO ARAC(RESIM) VALUES('"+textIsim.Text + "' @RESIM)";
            SqlCommand komut = new SqlCommand(islem, baglanti);
            komut.Parameters.AddWithValue("@RESIM" ,imageData);
            baglanti.Open();
            MessageBox.Show("baglanti acildi ");
            komut.ExecuteNonQuery(); 





        } 

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
          
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtMarka2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex += 1;
            }
            else
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex += 1;
            }
            else
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex -= 1;
            }
            else
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex -= 1;
            }
            else // İlk sekmedeyken en sona git
            {
                tabControl1.SelectedIndex = tabControl1.TabCount - 1;
            }

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboKayit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {





            txtPlaka2.Text = textPlaka.Text;

            txtKayitSubesi2.Text = comboKayit.Text;
            txtMarka2.Text = textMarka1.Text;

            txtKayitSubesi2.Visible = true;
            txtMarka2.Visible = true;
            txtPlaka2.Visible = true;

            try
            {
                string islem = "INSERT INTO ARACICOZELLIKLER(SESDUZENI,FRENSISTEMI,VITESTURU,LASTIKEBATI,BEYGIRGUCU,SILINDIRSAYISI,SILINDIRHACMI,YAKITKAPASITESI,RENK,YEDEKANAHTAR,DOSEME,UZAKTANKUMANDA,ALARM,YAGMURSENSOR,SISFARI,DERIDOSEME,SUNROOF,CELIKJANT,MERKEZIKILIT) " +
                               "VALUES(@SESDUZENI,@FRENSISTEMI,@VITESTURU,@LASTIKEBATI,@BEYGIRGUCU,@SILINDIRSAYISI,@SILINDIRHACMI,@YAKITKAPASITESI,@RENK,@YEDEKANAHTAR,@DOSEME,@UZAKTANKUMANDA,@ALARM,@YAGMURSENSOR,@SISFARI,@DERIDOSEME,@SUNROOF,@CELIKJANT,@MERKEZIKILIT)";
              SqlCommand  komut = new SqlCommand(islem, baglanti);

                komut.Parameters.AddWithValue("@SESDUZENI", txtSesDuzeni.Text);
                komut.Parameters.AddWithValue("@FRENSISTEMI", comboFrenSistem.GetItemText(comboFrenSistem.SelectedItem));
                komut.Parameters.AddWithValue("@VITESTURU", comboVitesTuru.GetItemText(comboVitesTuru.SelectedItem));
                komut.Parameters.AddWithValue("@LASTIKEBATI", textLastikEbati.Text);
                komut.Parameters.AddWithValue("@BEYGIRGUCU", textBeygirGucu.Text);
                komut.Parameters.AddWithValue("@SILINDIRSAYISI", textSilindirSayi.Text);
                komut.Parameters.AddWithValue("@SILINDIRHACMI", textSilindirHacmi.Text);
                komut.Parameters.AddWithValue("@YAKITKAPASITESI", textYakitKapasitesi.Text);
                komut.Parameters.AddWithValue("@RENK", textRenk.Text);
                komut.Parameters.AddWithValue("@YEDEKANAHTAR", checkYedekAnahtar.Checked);
                komut.Parameters.AddWithValue("@DOSEME", textDoseme.Text);
                komut.Parameters.AddWithValue("@UZAKTANKUMANDA", checkUzaktanKumanda.Checked);
                komut.Parameters.AddWithValue("@ALARM", checkAlarm.Checked);
                komut.Parameters.AddWithValue("@YAGMURSENSOR", checkYagmur.Checked);
                komut.Parameters.AddWithValue("@SISFARI", checkSisFari.Checked);
                komut.Parameters.AddWithValue("@DERIDOSEME", checkDeriDoseme.Checked);
                komut.Parameters.AddWithValue("@SUNROOF", checkSunroof.Checked);
                komut.Parameters.AddWithValue("@CELIKJANT", checkcelikJant.Checked);
                komut.Parameters.AddWithValue("@MERKEZIKILIT", checkmerkeziKilit.Checked);


                string islem2 = "INSERT INTO KONUM(KAYITSUBESI,ARACINYERI)" +
                    "VALUES(@KAYITSUBESI,@ARACINYERI)";
                SqlCommand komut2 = new SqlCommand(islem2, baglanti);
                 komut2.Parameters.AddWithValue("@KAYITSUBESI",textAracinYeri.Text);
                 komut2.Parameters.AddWithValue("@ARACINYERI", comboKayit.GetItemText(comboKayit.SelectedItem));


                string islem3 = "INSERT INTO AKTIFLIKDURUMU(AKTIFLIKPASIFLIKDURUMU) VALUES " +
                    "(@AKTIFLIKPASIFLIKDURUMU)";
                SqlCommand komut3 = new SqlCommand(islem3, baglanti);
                string aktiflikDurumu;
                if (radioAktif.Checked)
                {
                    aktiflikDurumu = "AKTIF";
                }
                
                
                else {
                    aktiflikDurumu = "PASIF"; 
                } 


                    komut3.Parameters.AddWithValue("@AKTIFLIKPASIFLIKDURUMU", aktiflikDurumu);



                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                MessageBox.Show("Bağlantı açıldı");
                komut.ExecuteNonQuery();
                komut2.ExecuteNonQuery();
                komut3.ExecuteNonQuery(); 

                MessageBox.Show("Eklendi.");
                baglanti.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}");
            }
        }


        private void textModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textMarka_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtKayitSubesi2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            groupboxOGS.Visible = !groupboxOGS.Visible;


        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {


        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void pictureResim_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            InsertImage(textPath.Text);
            MessageBox.Show("basariyla yuklendi");
        }


        private void LoadData( ) {

        
        }
    }
}
