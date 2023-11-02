using OgrenciNotMvccc.Models.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvccc.Controllers
{
    public class DefaultController : Controller
    {
        DbMvcOkulEntitiesNew db = new DbMvcOkulEntitiesNew();
        // GET: Default
        public ActionResult Index()// Burası Ana Sayfa Nuuul Geliyor Şu An!!! İlerleyen zamanda LINQ Eklenecek!!!!!
        {
            return View();
        }

        // Ögrencilerin Bilgilerini Getir
        public ActionResult OgrenciListesi()
        {
            var gerStudents = db.TBLOGRENCILER.Where(s => s.Aktifmi == true).ToList();// Ogrenci bilgisini listele
            return View(gerStudents);
        }

        // Derlers için
        public ActionResult TumDersler() // Tüm Dersleri Listeler
        {
            var getLessons = db.TBLDERSLER.Where(akjemal => akjemal.Aktifmi == true).ToList();
            return View(getLessons);
        }

        // Kulüpler için
        public ActionResult Kulupler() //Kulüpleri listeler
        {
            var getLessons = db.TBLKULUPLER.Where(akjemal => akjemal.Aktifmi == true).ToList();
            return View(getLessons);

        }
        //Sınav Notları İçin
        public ActionResult Sınavlar() // Sınavlar listesi
        {
            var getLessons = db.TBLNOTLAR.Where(g => g.Aktifmi == true).ToList();
            var getDAta = db.TBLNOTLAR.Where(g => g.Aktifmi == true).Take(5).ToList(); // Bu Kod Sadece İlk 5 veriyi GEtirir
            var getDAta2 = db.TBLNOTLAR.Where(g => g.Aktifmi == true).Take(5).OrderByDescending(k => k.NOTID).ToList(); // Bu Kod Sadece Son 5 veriyi GEtirir
            var getDAta3 = db.TBLNOTLAR.Where(g => g.Aktifmi == true).OrderByDescending(k => k.NOTID).Skip(3).Take(5).ToList(); // Bu ilk 3 veriyi atla sonra  Sadece Son 5 veriyi GEtirir

            return View(getLessons);
        }

        // Klupler Silme işlemi !!!
        public ActionResult Sil(int Id)
        {
            var Kulupler = db.TBLKULUPLER.Find(Id);
            Kulupler.Aktifmi = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Dersleri Siler 
        public ActionResult SilDersler(int Id)
        {
            var examps = db.TBLDERSLER.Find(Id);
            examps.Aktifmi = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Kayıtlı Olan Öğrencileri Siler!!!
        public ActionResult SilOgrenci(int Id)
        {
            var OgrenciListesi = db.TBLOGRENCILER.Find(Id);
            OgrenciListesi.Aktifmi = false;
            //  db.TBLOGRENCILER.Remove(OgrenciListesi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // var Olan Notları Siler ID Ye Göre!!
        public ActionResult SilNotlar(int Id)
        {
            var notlar = db.TBLNOTLAR.Find(Id);
            notlar.Aktifmi = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Ekle Kısmı
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            p.Aktifmi = true;
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Ogrenci Ekleme
        [HttpGet]
        public ActionResult YeniOgrenci()// Ekleme Kısmında 2 Tane ActionResult Açılmalı bunun 1. Bu şekilde Boş gelmeli GET Kısmı
        {
            public ActionResult SelectCategory()
            {

                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

                items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

                items.Add(new SelectListItem { Text = "Atatürk İnkilap", Value = "2"});

                items.Add(new SelectListItem { Text = "Coğafya", Value = "3" });

                ViewBag.DersAd = items;

                return View();

            }
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER o)// 2. Kısımı ise POST Yani verini eklendigi yer Burada işlem Yapılmalı! hata YeniOgrencinin 2 gezek eklenmesimi
        {
            o.Aktifmi = true;
            db.TBLOGRENCILER.Add(o);
            db.SaveChanges();
            return RedirectToAction("OgrenciListesi", "Default");
        }

        //Kulup ekleme

        [HttpGet]
        public ActionResult YeniKulüp()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult YeniKulüp (TBLKULUPLER ku)
        {
            ku.Aktifmi = true;
            db.TBLKULUPLER.Add(ku);
            db.SaveChanges();   
            return RedirectToAction("Kulupler","Default");   
        }
        [HttpGet]
        public ActionResult YeniSınav() 
        { 
            return View();
        }
        [HttpPost]
        public ActionResult YeniSınav(TBLNOTLAR S) 
        { 
            S.Aktifmi = true;   
            db.TBLNOTLAR.Add(S);
            db.SaveChanges();
            return RedirectToAction("Sınavlar", "Default");
        }
    }
}