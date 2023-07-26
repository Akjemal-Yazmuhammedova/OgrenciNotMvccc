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
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        // Ögrencilerin Bilgilerini Getir
        public ActionResult OgrenciListesi()
        {
            var gerStudents = db.TBLOGRENCILER.ToList();// Ogrenci bilgisini listele
            return View(gerStudents);
        }

        // Derlers için
        public ActionResult TumDersler() // Tüm Dersleri Listeler
        {
            var getLessons = db.TBLDERSLER.ToList();
            return View(getLessons);
        }

        // Kulüpler için
        public ActionResult Kulupler() //Kulüpleri listeler
        {
            var getLessons = db.TBLKULUPLER.ToList();
            return View(getLessons);

        }
        //Sınav Notları İçin
        public ActionResult Sınavlar() // Sınavlar listesi
        {
            var getLessons = db.TBLNOTLAR.ToList();
            var getDAta = db.TBLNOTLAR.Take(5).ToList(); // Bu Kod Sadece İlk 5 veriyi GEtirir
            var getDAta2 = db.TBLNOTLAR.Take(5).OrderByDescending(k=>k.NOTID).ToList(); // Bu Kod Sadece Son 5 veriyi GEtirir
            var getDAta3 = db.TBLNOTLAR.Skip(3).Take(5).OrderByDescending(k => k.NOTID).ToList(); // Bu ilk 3 veriyi atla sonra  Sadece Son 5 veriyi GEtirir

            return View(getLessons);
        }

        // Klupler Silme işlemi !!!
        public ActionResult Sil(int Id)
        {
            var Kulupler = db.TBLKULUPLER.Find(Id);
            db.TBLKULUPLER.Remove(Kulupler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Dersleri Siler 
        public ActionResult SilDersler(int Id)
        {
            var Sınavlar = db.TBLDERSLER.Find(Id);
            db.TBLDERSLER.Remove(Sınavlar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Kayıtlı Olan Öğrencileri Siler!!!
        public ActionResult SilOgrenci(int Id)
        {
            var OgrenciListesi = db.TBLOGRENCILER.Find(Id);
            db.TBLOGRENCILER.Remove(OgrenciListesi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // var Olan Notları Siler ID Ye Göre!!
        public ActionResult SilNotlar(int Id)
        {
            var Notlar = db.TBLNOTLAR.Find(Id);
            db.TBLNOTLAR.Remove(Notlar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Ekle Kısmı
        //public ActionResult Ekle(int Id)
        //{
        //    var Kulupler = db.TBLKULUPLER.Add(Id);
        //    db.TBLKULUPLER.Remove(Kulupler);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}