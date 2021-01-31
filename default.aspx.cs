using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace evde28kasim
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataGetir();
            }

        }

        private void DataGetir()
        {
            // bağlantı nesnesi 
            // ConfigurationManager -> web.config belgesindeki bağlantı yoluna ulaşmamızı sağlayacak
            // using -> kullanım bitince açık bağlantıyı kapatacak
            using (SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString))
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("spMAKALE", baglan);
                komut.CommandType = CommandType.StoredProcedure;
                SqlDataReader okuyucu = komut.ExecuteReader();

                rptMakaleler.DataSource = okuyucu;
                rptMakaleler.DataBind();


            }
        }

        protected void lnkMakaleGoster_Click(object sender, EventArgs e)
        {
            string gelenid = ((LinkButton)sender).CommandName;

            Response.Redirect("makaleGoster.aspx?ID=" + gelenid);

        }
    }
}