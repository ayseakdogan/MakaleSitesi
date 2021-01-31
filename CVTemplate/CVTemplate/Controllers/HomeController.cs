using CVTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CVTemplate.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.lstDeneyim = db.Deneyim.ToList();
                at.lstEgitim = db.Egitim.ToList();
                at.lstBeceriYetenek = db.BeceriYetenek.ToList();
                at.lstBlog = db.Blog.ToList();
                at.secResim = db.Resimler.Where(x => x.resimNo == 1).FirstOrDefault();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.orderedDil= db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }
        }
        public ActionResult Skills()
        {
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.lstDilBilgi = db.DilBilgi.ToList();
                at.lstBlog = db.Blog.ToList();
                at.secResim = db.Resimler.Where(x => x.resimNo == 1).FirstOrDefault();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }
        }
        public ActionResult Project()
        {
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.lstProje = db.Proje.ToList();
                at.lstProjeCategory = db.ProjeCategory.ToList();
                at.secResim = db.Resimler.Where(x => x.resimNo == 1).FirstOrDefault();
                at.projeResim = db.Resimler.Where(x => x.resimNo == 2).FirstOrDefault();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.lstBlog = db.Blog.ToList();
                at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }
        }
        public ActionResult PortfolioFull()
        {
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();

                at.lstKisi = db.Kisi.ToList();
                at.lstProje = db.Proje.ToList();
                at.lstProjeCategory = db.ProjeCategory.ToList();
                at.secResim = db.Resimler.Where(x => x.resimNo == 2).FirstOrDefault();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.lstBlog = db.Blog.ToList();
                at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }
        }
        public ActionResult Contact()
        {
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.secResim = db.Resimler.Where(x => x.resimNo == 1).FirstOrDefault();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.lstBlog = db.Blog.ToList();
                at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }
        }
        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string name = form["ad"].ToString();
                    string email = form["email"].ToString();
                    string mesaj = form["mesaj"].ToString();

                    var senderEmail = new MailAddress("akdoganaysem@gmail.com", "");
                    var receivereEmail = new MailAddress("akdoganaysem@gmail.com", "Receiver");
                    var password = "******";
                    var body = mesaj;
                    string content = "<html> <table border='1'> ";
                    content += "<tr>";
                    content += "<th> Ad-Soyad </th> <td>" + name + "</td></tr>";
                    content += "<tr><th> Mail </th><td>" + email + "</td></tr>";
                    content += "<tr> <th> Mesaj </th><td>" + mesaj + "</td>";
                    content += "</tr>";
                    content += "</table> </html>";
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receivereEmail)
                    {
                        Subject = "CV Maili",
                        Body = content
                    })

                    {
                        mess.IsBodyHtml = true;
                        smtp.Send(mess);
                    }
                    using (ModelDB db = new ModelDB())
                    {
                        AllTables at = new AllTables();

                        at.lstKisi = db.Kisi.ToList();
                        at.lstKategoriler = db.Kategoriler.ToList();
                        at.lstBlog = db.Blog.ToList();
                        at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                        return View(at);
                    }

                }
            }
            catch (Exception)
            {

                ViewBag.Error = "Mail Gönderilirken bir problem yaşandı";
            }
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.lstBlog = db.Blog.ToList();
                at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }

        }
        public ActionResult References()
        {
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.lstReferans = db.Referans.ToList();
                at.secResim = db.Resimler.Where(x => x.resimNo == 1).FirstOrDefault();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.lstBlog = db.Blog.ToList();
                at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }
        }
        public ActionResult Blog()
        {
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.lstBlog = db.Blog.ToList();
                at.secResim = db.Resimler.Where(x => x.resimNo == 3).FirstOrDefault();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.lstBlog = db.Blog.ToList();
                at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }
        }
        public ActionResult BlogFullPost(string id)
        {
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.secResim = db.Resimler.Where(x => x.resimNo == 1).FirstOrDefault();
                at.lstBlog = db.Blog.Where(x1=>x1.tip==id).ToList();
                at.secKategori = db.Kategoriler.Where(x2 => x2.tip == id).FirstOrDefault();
                at.lstKategoriler = db.Kategoriler.ToList();
                at.orderedDil = db.DilBilgi.OrderByDescending(x => x.yuzdesi).ToList();
                return View(at);
            }
        }
    }

    public class AllTables
    {
        public Kategoriler secKategori = new Kategoriler();
        public Resimler secResim = new Resimler();
        public Resimler projeResim = new Resimler();
        public Resimler blogResim = new Resimler();
        public List<Kisi> lstKisi = new List<Kisi>();
        public List<Referans> lstReferans = new List<Referans>();
        public List<Proje> lstProje = new List<Proje>();
        public Proje secilenProje = new Proje();
        public List<ProjeCategory> lstProjeCategory = new List<ProjeCategory>();
        public ProjeCategory secilenProjeKategori = new ProjeCategory();
        public List<Egitim> lstEgitim = new List<Egitim>();
        public List<Kategoriler> lstKategoriler = new List<Kategoriler>();
        public List<Blog> lstBlog = new List<Blog>();
        public Blog secilenBlog = new Blog();
        public List<DilBilgi> lstDilBilgi = new List<DilBilgi>();
        public List<Deneyim> lstDeneyim = new List<Deneyim>();
        public List<BeceriYetenek> lstBeceriYetenek = new List<BeceriYetenek>();
        public List<DilBilgi> orderedDil = new List<DilBilgi>();
    }
}