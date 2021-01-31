using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evde28kasim.admin
{
    public partial class makaleEkle : System.Web.UI.Page
    {
        private Color green;
        private readonly Color red;

        protected void Page_Load(object sender, EventArgs e)
        {
            KategoriDoldur();
        }

        private void KategoriDoldur()
        {
            if (!IsPostBack)
            {
                using (SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString))
                {
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("spKATEGORILISTEGETIR", baglan);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    drpKategoriListe.DataSource = okuyucu;
                    drpKategoriListe.DataTextField = "KATEGORIAD";
                    drpKategoriListe.DataValueField = "ID";
                    drpKategoriListe.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString))
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("spMAKALEEKLE", baglan);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                // @BASLIK,@KISAYAZI,@YAZI,@RESIMYOL,@KATEGORIID
                komut.Parameters.AddWithValue("@BASLIK", txtBaslik.Text);
                komut.Parameters.AddWithValue("@KISAYAZI", txtKisaYazi.Text);
                komut.Parameters.AddWithValue("@YAZI", txtYazi.Text);
                komut.Parameters.AddWithValue("@KATEGORIID", drpKategoriListe.SelectedValue);
                if (flResimYukle.HasFile)
                {

                    string dosyaAd = "/resimler/" + Guid.NewGuid().ToString() + "-" + flResimYukle.FileName;

                    flResimYukle.SaveAs(Server.MapPath(dosyaAd));
                    // doysa boyutu ve dosya extension doğrumu kontrılü yapalım

                    komut.Parameters.AddWithValue("@RESIMYOL", dosyaAd);
                    int sonuc = komut.ExecuteNonQuery();
                    lblSonuc.Text = "Makaleniz kaydedildi ";
                    lblSonuc.BackColor = System.Drawing.Color.Green;

                }
                else
                {
                    lblSonuc.Text = "Dosya Seçmediniz";
                    lblSonuc.BackColor = System.Drawing.Color.Red;
                }

            }
        }
    }
}