using System;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace evde28kasim
{
    public partial class makaleGoster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                string gelenid = Request.QueryString["ID"];
                using (SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString))
                {
                    baglan.Open();
                    SqlCommand komut = new SqlCommand("spIDYEMAKALEGETIR", baglan);
                    komut.CommandType = CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@ID", gelenid);
                    SqlDataReader oku = komut.ExecuteReader();

                    while (oku.Read())
                    {
                        lblMakaleBaslik.Text = oku["BASLIK"].ToString();
                        lblKisaYazi.Text = oku["KISAYAZI"].ToString();
                        ImgMakaleResim.ImageUrl = oku["RESIMYOL"].ToString();
                        lblKategori.Text = oku["KATEGORIAD"].ToString();
                        lblYazi.Text = oku["YAZI"].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }
    }
}
