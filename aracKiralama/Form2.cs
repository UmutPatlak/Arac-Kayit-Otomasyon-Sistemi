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


namespace aracKiralama
{
    public partial class Form2: Form
    {

        public Form2()
        {
        


        InitializeComponent();
        }
       
        static string baglantiyolu = @"Data Source=DESKTOP-HGGVOAC\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlConnection baglanti = new SqlConnection(baglantiyolu);


        private void button2_Click(object sender, EventArgs e)
        {


            try {
                string islem = "INSERT INTO MARKA(MARKASI,TURU,TIPI,MODELI) , " +
                    "VALUES(@MARKASI,@TURU,@TIPI,@MODELI)";
                SqlCommand komut = new SqlCommand(islem,baglanti);

                komut.Parameters.AddWithValue("@MARKASI", comboMarka2.GetItemText(comboMarka2.SelectedIndex));
                komut.Parameters.AddWithValue("@TURU", comboTur2.GetItemText(comboTip2.SelectedIndex));
                komut.Parameters.AddWithValue("@TIPI", comboTip2.GetItemText(comboTip2.SelectedIndex));
                komut.Parameters.AddWithValue("@MODELI", comboModel2.GetItemText(comboModel2.SelectedIndex)); 

                if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            MessageBox.Show("Bağlantı açıldı");
            komut.ExecuteNonQuery();
            MessageBox.Show("Eklendi.");
            baglanti.Close();
        }
            catch (SqlException ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}");
            }

}

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
