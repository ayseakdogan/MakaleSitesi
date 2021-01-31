using CVTemplate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CVTemplate.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult FileLoad(int id)
        {

            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.secResiim = db.Resimler.Where(x => x.resimNo == id).SingleOrDefault();
                return View(at);
            }
        }
              [HttpPost]
        public ActionResult FileLoad(HttpPostedFileBase file,int id)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    string path2 = "/Images/" + file.FileName;
                    using (ModelDB db = new ModelDB())
                    {
                        AllTables2 at = new AllTables2();
                        at.secResiim = db.Resimler.Where(x => x.resimNo == id).SingleOrDefault();
                        if (at.secResiim != null)
                        {
                            at.secResiim.resimYol = path2;
                            db.SaveChanges();
                        }
                        else
                        {
                            Resimler r = new Resimler();
                            r.resimYol = path2;
                            r.resimNo = id;
                            db.Resimler.Add(r);
                            db.SaveChanges();
                        }
                    }
                    file.SaveAs(path);

                    ViewBag.Message = "Resim Yüklendi.";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return RedirectToAction("FileLoad");
        }
      
        public ActionResult Index()
        {

            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.lstKisi = db.Kisi.ToList();
                at.lstDilBilgi = db.DilBilgi.ToList();
                at.lstDeneyim = db.Deneyim.ToList();
                at.lstEgitim = db.Egitim.ToList();
                at.lstBeceriYetenek = db.BeceriYetenek.ToList();
                at.secResiim = db.Resimler.Where(x => x.resimNo == 1).FirstOrDefault();
                return View(at);
            }
        }
        public ActionResult dilBil()
        {

            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.lstDilBilgi = db.DilBilgi.ToList();
                return View(at);
            }
        }
        public ActionResult deneyimBil()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();
                at.lstDeneyim = db.Deneyim.ToList();
                return View(at);
            }

        }
        public ActionResult egitimBil()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }
            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();

                at.lstEgitim = db.Egitim.ToList();

                return View(at);
            }
        }
        public ActionResult beceriBil()
        {

            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables at = new AllTables();
                at.lstKisi = db.Kisi.ToList();

                at.lstBeceriYetenek = db.BeceriYetenek.ToList();
                return View(at);
            }
        }
        public ActionResult Projeler(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.lstProjeCategory = db.ProjeCategory.ToList();
                at.secilenProjeKategori = db.ProjeCategory.Where(x => x.id == id).FirstOrDefault();
                at.lstProje = db.Proje.Where(x => x.CategoryID == id).ToList();
                at.secResiim = db.Resimler.Where(x => x.resimNo == 2).FirstOrDefault();
                return View(at);
            }
        }
        public ActionResult Referanslar()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.lstReferans = db.Referans.ToList();
                return View(at);
            }
        }
        public ActionResult Blog()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.lstKategori = db.Kategoriler.ToList();
                return View(at);
            }
        }
        public ActionResult BlogIncele(string id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.lstBlog = db.Blog.Where(x=> x.tip==id).ToList();
                at.secKategori = db.Kategoriler.Where(x => x.tip == id).SingleOrDefault();
                return View(at);
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Ayarlar()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.admin = db.AdminLogin.SingleOrDefault();

                return View(at);
            }

        }
        [HttpPost]
        public ActionResult Ayarlar(FormCollection form)
        {
            string kullaniciadi = form["kullaniciadi"].ToString();
            string sifre = form["sifre"].ToString();
            string sifre2 = form["sifre2"].ToString();
            if (string.Equals(sifre, sifre2))
            {
                using (ModelDB db = new ModelDB())
                {
                    AdminLogin al = db.AdminLogin.SingleOrDefault();
                    al.kullaniciadi = kullaniciadi;
                    al.sifre = sifre;

                    int sonuc = db.SaveChanges();
                    if (sonuc > 0)
                    {
                        TempData["Result"] = "Kaydedildi";
                        TempData["Status"] = "success";
                    }
                }
            }
            else
            {
                TempData["Result"] = "Şifreler birbiri ile aynı olmak zorundadır.";
                TempData["Status"] = "danger";
            }
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.admin = db.AdminLogin.SingleOrDefault();

                return View(at);
            }
        }
        public ActionResult Cikis()
        {

            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            Session.Remove("ActiveUser");

            Session.Clear();

            return RedirectToAction("Login", "Admin");
        }
        [HttpPost]

        public ActionResult Login(string kullaniciadi, string sifre)
        {
            using (ModelDB db = new ModelDB())
            {
                AdminLogin al = db.AdminLogin.FirstOrDefault();
                if (kullaniciadi == al.kullaniciadi && sifre == al.sifre)
                {
                    Session.Add("ActiveUser", kullaniciadi);
                    return RedirectToAction("Index", "Admin");
                }
            }
            TempData["LoginMessage"] = "Kullanıcı adı veya şifre yanlış!";

            return View();
        }
        public ActionResult ProjeKategori()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.secResiim = db.Resimler.Where(x => x.resimNo == 2).SingleOrDefault();
                at.lstProjeCategory = db.ProjeCategory.ToList();
                return View(at);
            }
        }

        public ActionResult KisiGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.tekkisi = db.Kisi.Where(x => x.id == id).SingleOrDefault();
                at.secResiim = db.Resimler.Where(x => x.resimNo == 1).SingleOrDefault();
                return View(at);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult KisiGuncelle(FormCollection form, int id)
        {
            string ad = form["ad"].ToString();
            string soyad = form["soyad"].ToString();
            string meslek = form["meslek"].ToString();
            string telefon = form["telefon"].ToString();
            string mail = form["mail"].ToString();
            string adres = form["adres"].ToString();
            string ozetBilgi = form["ozetBilgi"].ToString();

            using (ModelDB db = new ModelDB())
            {
                Kisi p = db.Kisi.Where(x => x.id == id).SingleOrDefault();
                p.ad = ad;
                p.soyad = soyad;
                p.meslek = meslek;
                p.telefon = telefon;
                p.mail = mail;
                p.adress = adres;
                p.ozetBilgi = ozetBilgi;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult DilGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                DilBilgi dil = db.DilBilgi.Where(x => x.id == id).SingleOrDefault();
                return View(dil);
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult DilGuncelle(FormCollection form, int id)
        {
            string konuadi = form["konuadi"].ToString();
            int yuzde = Convert.ToInt16(form["yuzde"].ToString());
            using (ModelDB db = new ModelDB())
            {
                DilBilgi d = db.DilBilgi.Where(x => x.id == id).SingleOrDefault();
                d.konuİsmi = konuadi;
                d.yuzdesi = yuzde;
                db.SaveChanges();
            }
            return RedirectToAction("dilBil");
        }
        public ActionResult DilSil(int? id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }
            using (ModelDB db = new ModelDB())
            {
                DilBilgi dil = db.DilBilgi.Where(x => x.id == id).SingleOrDefault();
                return View(dil);
            }
        }
        [HttpPost, ActionName("DilSil")]
        public ActionResult SilOk(int? id)
        {
            DilBilgi dil = new DilBilgi();

            using (ModelDB db = new ModelDB())
            {
                dil = db.DilBilgi.Where(x => x.id == id).FirstOrDefault();
                db.DilBilgi.Remove(dil);
                db.SaveChanges();
            }
            return RedirectToAction("dilBil", "Admin");
        }
        public ActionResult YeniDil()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {
                at.lstDilBilgi = db.DilBilgi.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniDil(FormCollection form)
        {
            string dil = form["konuismi"].ToString();
            int yuzde = Convert.ToInt16(form["yuzde"].ToString());
            DilBilgi d = new DilBilgi();
            using (ModelDB db = new ModelDB())
            {
                d.konuİsmi = dil;
                d.yuzdesi = yuzde;
                db.DilBilgi.Add(d);
                db.SaveChanges();
            }
            return RedirectToAction("dilBil");
        }
        public ActionResult DeneyimGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Deneyim deneyim = db.Deneyim.Where(x => x.id == id).SingleOrDefault();
                return View(deneyim);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DeneyimGuncelle(FormCollection form, int id)
        {
            string gorevyeri = form["gorevyeri"].ToString();
            string gorev = form["gorev"].ToString();
            string gorevyili = form["gorevyili"].ToString();

            using (ModelDB db = new ModelDB())
            {
                Deneyim d = db.Deneyim.Where(x => x.id == id).SingleOrDefault();
                d.görev = gorev;
                d.calismaYili = gorevyili;
                d.calismaYeri = gorevyeri;
                db.SaveChanges();
            }
            return RedirectToAction("deneyimBil");
        }
        public ActionResult DeneyimSil(int? id)
        {
             if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Deneyim deneyim = db.Deneyim.Where(x => x.id == id).SingleOrDefault();
                return View(deneyim);
            }
        }
        [HttpPost, ActionName("DeneyimSil")]
        public ActionResult DeneyimSilOk(int? id)
        {
            Deneyim deneyim = new Deneyim();

            using (ModelDB db = new ModelDB())
            {
                deneyim = db.Deneyim.Where(x => x.id == id).FirstOrDefault();
                db.Deneyim.Remove(deneyim);
                db.SaveChanges();
            }
            return RedirectToAction("deneyimBil", "Admin");
        }
        public ActionResult YeniDeneyim()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {
                at.lstDeneyim = db.Deneyim.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniDeneyim(FormCollection form)
        {
            string gorevyeri = form["gorevyeri"].ToString();
            string gorev = form["gorev"].ToString();
            string gorevyili = form["gorevyili"].ToString();

            Deneyim d = new Deneyim();
            using (ModelDB db = new ModelDB())
            {
                d.calismaYeri = gorevyeri;
                d.calismaYili = gorevyili;
                d.görev = gorev;
                db.Deneyim.Add(d);
                db.SaveChanges();
            }
            return RedirectToAction("deneyimBil");
        }
        public ActionResult EgitimGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Egitim egitim = db.Egitim.Where(x => x.id == id).SingleOrDefault();
                return View(egitim);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EgitimGuncelle(FormCollection form, int id)
        {
            string uni = form["universite"].ToString();
            string bolum = form["bolum"].ToString();
            string yili = form["egitimyili"].ToString();
            string aciklama = form["aciklama"].ToString();

            using (ModelDB db = new ModelDB())
            {
                Egitim e = db.Egitim.Where(x => x.id == id).SingleOrDefault();
                e.Universite = uni;
                e.Bolum = bolum;
                e.egitimYili = yili;
                e.Aciklama = aciklama;
                db.SaveChanges();
            }
            return RedirectToAction("egitimBil");
        }
        public ActionResult EgitimSil(int? id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Egitim egitim = db.Egitim.Where(x => x.id == id).SingleOrDefault();
                return View(egitim);
            }
        }
        [HttpPost, ActionName("EgitimSil")]
        public ActionResult EgitimSilOk(int? id)
        {
            Egitim egitim = new Egitim();

            using (ModelDB db = new ModelDB())
            {
                egitim = db.Egitim.Where(x => x.id == id).FirstOrDefault();
                db.Egitim.Remove(egitim);
                db.SaveChanges();
            }
            return RedirectToAction("egitimBil", "Admin");
        }
        public ActionResult YeniEgitim()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {
                at.lstEgitim = db.Egitim.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniEgitim(FormCollection form)
        {
            string uni = form["universite"].ToString();
            string bolum = form["bolum"].ToString();
            string yili = form["egitimyili"].ToString();
            string aciklama = form["aciklama"].ToString();

            Egitim e = new Egitim();
            using (ModelDB db = new ModelDB())
            {

                e.Universite = uni;
                e.Bolum = bolum;
                e.egitimYili = yili;
                e.Aciklama = aciklama;
                db.Egitim.Add(e);
                db.SaveChanges();
            }
            return RedirectToAction("egitimBil");
        }
        public ActionResult BeceriGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                BeceriYetenek beceri = db.BeceriYetenek.Where(x => x.id == id).SingleOrDefault();
                return View(beceri);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BeceriGuncelle(FormCollection form, int id)
        {
            string baslik = form["baslik"].ToString();

            string aciklama = form["aciklama"].ToString();

            using (ModelDB db = new ModelDB())
            {
                BeceriYetenek b = db.BeceriYetenek.Where(x => x.id == id).SingleOrDefault();
                b.baslik = baslik;
                b.aciklama = aciklama;
                db.SaveChanges();
            }
            return RedirectToAction("beceriBil");
        }
        public ActionResult BeceriSil(int? id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                BeceriYetenek beceri = db.BeceriYetenek.Where(x => x.id == id).SingleOrDefault();
                return View(beceri);
            }
        }
        [HttpPost, ActionName("BeceriSil")]
        public ActionResult BeceriSilOk(int? id)
        {
            BeceriYetenek beceri = new BeceriYetenek();

            using (ModelDB db = new ModelDB())
            {
                beceri = db.BeceriYetenek.Where(x => x.id == id).FirstOrDefault();
                db.BeceriYetenek.Remove(beceri);
                db.SaveChanges();
            }
            return RedirectToAction("beceriBil", "Admin");
        }
        public ActionResult YeniBeceri()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {
                at.lstBeceriYetenek = db.BeceriYetenek.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniBeceri(FormCollection form)
        {
            string baslik = form["baslik"].ToString();

            string aciklama = form["aciklama"].ToString();

            BeceriYetenek b = new BeceriYetenek();
            using (ModelDB db = new ModelDB())
            {
                b.baslik = baslik;
                b.aciklama = aciklama;
                db.BeceriYetenek.Add(b);
                db.SaveChanges();
            }
            return RedirectToAction("beceriBil");
        }
        public ActionResult YeniProje(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {

                at.lstProjeCategory = db.ProjeCategory.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniProje(FormCollection form,int id)
        {
            string projebaslik = form["projebaslik"].ToString();
            string projeyili = form["projeyili"].ToString();
            string projelink = form["projelink"].ToString();
            string aciklama = form["aciklama"].ToString();
            Proje p = new Proje();
            using (ModelDB db = new ModelDB())
            {
                p.altBaslik = projebaslik;
                p.aciklama = aciklama;
                p.projeYili = projeyili;
                p.projeLinki = projelink;
                p.CategoryID = id;
                db.Proje.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("projeler", new { id= id });
        }
        public ActionResult ProjeGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {
                Proje p = db.Proje.Where(x => x.id == id).SingleOrDefault();

                at.secilenProje = p;
                at.secilenProjeKategori.categoryNo = p.CategoryID;
                at.lstProjeCategory = db.ProjeCategory.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProjeGuncelle(FormCollection form, int id)
        {
            int projekategori = Convert.ToInt32(form["projekategori"].ToString());
            string projebaslik = form["projebaslik"].ToString();
            string projeyili = form["projeyili"].ToString();
            string projelink = form["projelink"].ToString();
            string aciklama = form["aciklama"].ToString();

            using (ModelDB db = new ModelDB())
            {
                Proje p = db.Proje.Where(x => x.id == id).SingleOrDefault();
                p.altBaslik = projebaslik;
                p.aciklama = aciklama;
                p.projeYili = projeyili;
                p.projeLinki = projelink;
                p.CategoryID = projekategori;
                db.SaveChanges();
            }
            return RedirectToAction("projeler", new { id = projekategori });
        }
        public ActionResult ProjeSil(int? id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.secilenProje = db.Proje.Where(x => x.id == id).SingleOrDefault();
                at.secilenProjeKategori = db.ProjeCategory.Where(x => x.categoryNo == at.secilenProje.CategoryID).FirstOrDefault();
              
                return View(at);
            }
        }
        [HttpPost, ActionName("ProjeSil")]
        public ActionResult ProjeSilOk(int id)
        {
          
            Proje p = new Proje();
            int categoryid;
            using (ModelDB db = new ModelDB())
            {
                p = db.Proje.Where(x => x.id == id).FirstOrDefault();
                categoryid = (int)p.CategoryID;
                db.Proje.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Projeler", "Admin", new { id = categoryid });
        }
        public ActionResult YeniReferans()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {

                at.lstReferans = db.Referans.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniReferans(FormCollection form)
        {
            string refad = form["refad"].ToString();
            string refsoyad = form["refsoyad"].ToString();
            string sirket = form["sirket"].ToString();
            string telefon = form["telefon"].ToString();
            string gorev = form["gorev"].ToString();
            Referans r = new Referans();
            using (ModelDB db = new ModelDB())
            {
                r.refAd = refad;
                r.refSoyad = refsoyad;
                r.refSirket = sirket;
                r.refTelefon = telefon;
                r.refGorev = gorev;
                db.Referans.Add(r);
                db.SaveChanges();
            }
            return RedirectToAction("referanslar");
        }
        public ActionResult ReferansGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Referans referans = db.Referans.Where(x => x.id == id).SingleOrDefault();
                return View(referans);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ReferansGuncelle(FormCollection form, int id)
        {
            string refad = form["refad"].ToString();
            string refsoyad = form["refsoyad"].ToString();
            string sirket = form["sirket"].ToString();
            string telefon = form["telefon"].ToString();
            string gorev = form["gorev"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Referans r = db.Referans.Where(x => x.id == id).SingleOrDefault();
                r.refAd = refad;
                r.refSoyad = refsoyad;
                r.refSirket = sirket;
                r.refTelefon = telefon;
                r.refGorev = gorev;

                db.SaveChanges();
            }
            return RedirectToAction("referanslar");
        }
        public ActionResult ReferansSil(int? id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Referans refe = db.Referans.Where(x => x.id == id).SingleOrDefault();
                return View(refe);
            }
        }
        [HttpPost, ActionName("ReferansSil")]
        public ActionResult ReferansSilOk(int? id)
        {
            Referans refe = new Referans();

            using (ModelDB db = new ModelDB())
            {
                refe = db.Referans.Where(x => x.id == id).FirstOrDefault();
                db.Referans.Remove(refe);
                db.SaveChanges();
            }
            return RedirectToAction("referanslar", "Admin");
        }
        public ActionResult YeniBlog()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {

                at.lstKategori = db.Kategoriler.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniBlog(FormCollection form)
        {
            string kategoriBaslik = form["kategoriBaslik"].ToString();
            string tip = form["tip"].ToString();
            Kategoriler kt = new Kategoriler();
            using (ModelDB db = new ModelDB())
            {
                kt.tip = tip;
                kt.KategoriBaslik = kategoriBaslik;
                kt.KategoriLink = "/Home/BlogFullPost/" + tip;
                db.Kategoriler.Add(kt);
                db.SaveChanges();
            }
            return RedirectToAction("blog");
        }
        public ActionResult YeniIcerikBlog(string id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {
                at.lstKategori = db.Kategoriler.ToList();
                at.lstBlog = db.Blog.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniIcerikBlog(FormCollection form, string id)
        {
            string baslik = form["baslik"].ToString();

            string icerik = form["icerik"].ToString();
            Blog bl = new Blog();
            using (ModelDB db = new ModelDB())
            {
                bl.baslik = baslik;
                bl.icerik = icerik;
                bl.tip = id;
                db.Blog.Add(bl);
                db.SaveChanges();
            }
            return RedirectToAction("blogIncele", new { id = id });
        }

        public ActionResult BlogIcerikGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                AllTables2 at = new AllTables2();
                at.secilenBlog = db.Blog.Where(x => x.id == id).SingleOrDefault();
                at.lstKategori = db.Kategoriler.Where(x=> x.tip!="0").ToList();
                at.secKategori=db.Kategoriler.Where(x => x.tip == at.secilenBlog.tip).SingleOrDefault();
                return View(at);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogIcerikGuncelle(FormCollection form, int id)
        {
            string baslik = form["baslik"].ToString();
            string icerik = form["icerik"].ToString();
            string tip = form["tip"].ToString();
            
            using (ModelDB db = new ModelDB())
            {
                Blog b = db.Blog.Where(x => x.id == id).SingleOrDefault();
                b.baslik = baslik;
                b.icerik = icerik;
                b.tip = tip;
                db.SaveChanges();
            }
            return RedirectToAction("blogIncele", new { id = tip });
        }
        public ActionResult BlogGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Kategoriler kategori = db.Kategoriler.Where(x => x.id == id).SingleOrDefault();
                return View(kategori);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogGuncelle(FormCollection form, int id)
        {
            string baslik = form["baslik"].ToString();
           
            using (ModelDB db = new ModelDB())
            {
                Kategoriler k = db.Kategoriler.Where(x => x.id == id).SingleOrDefault();
                k.KategoriBaslik = baslik;
                db.SaveChanges();
            }
            return RedirectToAction("blog");
        }
        public ActionResult BlogIcerikSil(int? id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Blog blog = db.Blog.Where(x => x.id == id).SingleOrDefault();
                return View(blog);
            }
        }
        [HttpPost, ActionName("BlogIcerikSil")]
        public ActionResult BlogIcerikSilOk(int? id)
        {
            Blog blog = new Blog();
            string tip = "";
            using (ModelDB db = new ModelDB())
            {
                blog = db.Blog.Where(x => x.id == id).FirstOrDefault();
                tip = blog.tip;
                db.Blog.Remove(blog);
                db.SaveChanges();
            }
            return RedirectToAction("blogIncele", new { id = tip });
        }
        public ActionResult BlogSil(int? id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                Kategoriler kt = db.Kategoriler.Where(x => x.id == id).SingleOrDefault();
                return View(kt);
            }
        }
        [HttpPost, ActionName("BlogSil")]
        public ActionResult BlogSilOk(int? id)
        {
            Kategoriler kt = new Kategoriler();
            List<Blog> blist = new List<Blog>();
            using (ModelDB db = new ModelDB())
            {
                kt = db.Kategoriler.Where(x => x.id == id).FirstOrDefault();
                foreach (var item in db.Blog.Where(x2 => x2.tip == kt.tip).ToList())
                {
                    db.Blog.Remove(item);
                }
                db.Kategoriler.Remove(kt);
                db.SaveChanges();
            }
            return RedirectToAction("blog", "Admin");
        }
        public ActionResult YeniProjeKategori()
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            AllTables2 at = new AllTables2();
            using (ModelDB db = new ModelDB())
            {
                at.lstProjeCategory = db.ProjeCategory.ToList();
            }
            return View(at);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniProjeKategori(FormCollection form)
        {
            string baslik = form["baslik"].ToString();
            ProjeCategory pc = new ProjeCategory();
            using (ModelDB db = new ModelDB())
            {
                pc.baslik = baslik;
                db.ProjeCategory.Add(pc);
                db.SaveChanges();
            }
            return RedirectToAction("ProjeKategori");
        }
        public ActionResult ProjeKategoriGuncelle(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                ProjeCategory pc = db.ProjeCategory.Where(x => x.id == id).SingleOrDefault();
                return View(pc);
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProjeKategoriGuncelle(FormCollection form, int id)
        {
            string baslik = form["baslik"].ToString();
            using (ModelDB db = new ModelDB())
            {
                ProjeCategory pc = db.ProjeCategory.Where(x => x.id == id).SingleOrDefault();
                pc.baslik = baslik;
                db.SaveChanges();
            }
            return RedirectToAction("ProjeKategori");
        }
        public ActionResult ProjeKategoriSil(int? id)
        {
            if (Session["ActiveUser"] != null)
            {
                ViewBag.UserName = Session["ActiveUser"].ToString();
            }
            else
            {
                return RedirectToAction("login");
            }

            ViewBag.UserName = Session["ActiveUser"].ToString();
            using (ModelDB db = new ModelDB())
            {
                ProjeCategory pc = db.ProjeCategory.Where(x => x.id == id).SingleOrDefault();
                return View(pc);
            }
        }
        [HttpPost, ActionName("ProjeKategoriSil")]
        public ActionResult ProjeKategoriSilOk(int? id)
        {
            ProjeCategory pc = new ProjeCategory();
            Proje pr = new Proje();
            using (ModelDB db = new ModelDB())
            {
                pc = db.ProjeCategory.Where(x => x.id == id).FirstOrDefault();
                foreach (var item in db.Proje.Where(x => x.CategoryID == id).ToList())
                {

                    db.Proje.Remove(item);
                }
              
                db.ProjeCategory.Remove(pc);
                db.SaveChanges();
            }
            return RedirectToAction("ProjeKategori", "Admin");
        }
        public class AllTables2
        {
            public List<Kategoriler> lstKategori = new List<Kategoriler>();
            public Kategoriler secKategori = new Kategoriler();
            public AdminLogin admin = new AdminLogin();
            public Resimler secResiim = new Resimler();
            public List<Resimler> lstResimler = new List<Resimler>();
            public List<Kisi> lstKisi = new List<Kisi>();
            public Kisi tekkisi = new Kisi();
            public List<Referans> lstReferans = new List<Referans>();
            public List<Proje> lstProje = new List<Proje>();
            public Proje secilenProje = new Proje();
            public List<ProjeCategory> lstProjeCategory = new List<ProjeCategory>();
            public ProjeCategory secilenProjeKategori = new ProjeCategory();
            public List<Egitim> lstEgitim = new List<Egitim>();
           
            public List<Blog> lstBlog = new List<Blog>();
            public Blog secilenBlog = new Blog();
            public List<DilBilgi> lstDilBilgi = new List<DilBilgi>();
            public List<Deneyim> lstDeneyim = new List<Deneyim>();
            public List<BeceriYetenek> lstBeceriYetenek = new List<BeceriYetenek>();
        }
    }
}
