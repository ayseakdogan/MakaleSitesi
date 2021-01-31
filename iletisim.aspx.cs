using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evde28kasim
{
    public partial class iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("sizinAdresiniz");
            mesaj.Subject = txtKonu.Text;
            mesaj.To.Add("sizinAdresiniz");
            mesaj.IsBodyHtml = true;
            mesaj.Body = "size mail gönderdi   " + txtEmail.Text + "<br/>" + "  mailin konusu:  " + txtKonu.Text + "<br/>" + "mailin mesajı:  " + txtMesaj.Text;
            SmtpClient postaci = new SmtpClient();
            postaci.Credentials = new NetworkCredential("sizinAdresiniz", "sizinŞİfreniz");
            postaci.EnableSsl = true;
            postaci.Host = "smtp.gmail.com";
            postaci.Port = 587;
            postaci.Send(mesaj);



        }
    }
}