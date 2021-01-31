using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evde28kasim.admin
{
    public partial class rolYonetimi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RolleriBagla();
                KullanicilariBagla();
            }

        }
        public void RolleriBagla()
        {
            SqlDataAdapter da = new SqlDataAdapter("select RoleName from aspnet_Roles", ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Roller");
            lstRoller.DataSource = ds;
            lstRoller.DataTextField = "RoleName";
            lstRoller.DataValueField = "RoleName";
            lstRoller.DataBind();
        }
        public void KullanicilariBagla()
        {
            SqlDataAdapter da = new SqlDataAdapter("select UserName from aspnet_users", ConfigurationManager.ConnectionStrings["baglantim"].ConnectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Kullanicilar");
            lstUyeler.DataSource = ds;
            lstUyeler.DataTextField = "UserName";
            lstUyeler.DataValueField = "UserName";
            lstUyeler.DataBind();
        }

        protected void btnROlEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Roles.RoleExists(txtRolAd.Text))
                {
                    Roles.CreateRole(txtRolAd.Text);
                    KullanicilariBagla();
                    RolleriBagla();
                    lblSonuc.Text = "Rol oluşturuldu";
                }
                else
                {
                    lblSonuc.Text = "Bu rol zaten var";
                }
            }
            catch (Exception ex)
            {
                lblSonuc.Text = ex.Message;
            }

        }

        protected void btnRoleKullaniciEkle_Click(object sender, EventArgs e)
        {
            // sonuc etiketinin içini boşalt
            lblSonuc.Text = "";
            try
            {
                // bu kullanıcı zaten bu roldemi
                if (!Roles.IsUserInRole(lstUyeler.SelectedItem.Text))
                {
                    Roles.AddUserToRole(lstUyeler.SelectedItem.Text, lstRoller.SelectedItem.Text);
                    KullanicilariBagla();
                    RolleriBagla();
                    lblSonuc.Text = "Kullanıcı role atandı";
                }
                else
                {
                    lblSonuc.Text = "Kullanıcı zaten bu rolde ";
                }
            }
            catch (Exception ex)
            {
                lblSonuc.Text = ex.Message;
            }

        }
    }
}