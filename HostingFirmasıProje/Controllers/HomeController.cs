using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HostingFirmasıProje.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using HostingFirmasıProje.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HostingFirmasıProje.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]
        public IActionResult Index()
        {
            var name = User.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();

            var urunler = _context.Urunler.ToList();

            List<int> kalanGunList = new List<int>();

            foreach (var item in urunler)
            {

                TimeSpan kalanGun = ((item.DomainBitisTarihi).GetValueOrDefault()).Subtract(DateTime.Now);
                int kalan = (int)kalanGun.TotalDays;

                kalanGunList.Add(kalan);

            }

            return View(_context.Urunler.Include("Musteri").Where(c => c.Kalan < 16).OrderBy(i => i.Kalan).ToList());
        }

        protected HostingDbContext _context;
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this._context.Dispose();
            }
        }
        public HomeController(HostingDbContext context)
        {
            _context = context;
        }

        public ActionResult UrunListele()
        {
            return View(_context.Urunler.ToList());
        }

        [HttpPost]
        public ActionResult Create(Bayi bayi, Musteri musteri,
            int id, int? musteriId, string domainAdi, string bayiAdi, DateTime domainBastarihi,
            DateTime domainBitisTarihi, DateTime hostingBasTarihi, DateTime hostingBitisTarihi, string panelveFtp)
        {
            if (ModelState.IsValid)
            {
                Bayi bayiYeni = new Bayi
                {
                    Id=bayi.Id,
                    BayiAdi=bayi.BayiAdi
                };
                _context.Bayiler.Add(bayiYeni);

                Musteri musteriYeni = new Musteri
                {
                    Id = musteri.Id,
                    MusteriAdi = musteri.MusteriAdi,
                    BayiId=musteri.BayiId
                };

                _context.Musteriler.Add(musteriYeni);

                Urun urun = new Urun
                {
                    Id = id,
                    MusteriId=musteriId,
                    DomainAdi = domainAdi,
                    BayiAdi = bayiAdi,
                    DomainBasTarihi = domainBastarihi,
                    DomainBitisTarihi = domainBitisTarihi,
                    HostingBasTarihi = hostingBasTarihi,
                    HostingBitisTarihi = hostingBitisTarihi,
                    PanelFtpBilgi = panelveFtp
                };
                _context.Urunler.Add(urun);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("UrunListele");
        }

























        //[Authorize]
        //public ActionResult New()
        //{
        //    ViewBag.Id = new SelectList(_context.Urunler.ToList(), "Id");
        //    return View(");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult New(UrunViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Urun urun = new Urun
        //        {
        //            Id=model.Id,
        //            BayiAdi= model.BayiAdi,
        //            DomainAdi=model.DomainAdi,
        //            DomainBasTarihi=model.DomainBasTarihi,
        //            DomainBitisTarihi=model.DomainBitisTarihi,
        //            HostingBasTarihi=model.HostingBasTarihi,
        //            HostingBitisTarihi=model.HostingBitisTarihi,
        //            MusteriId=model.MusteriId,
        //            Kalan=model.Kalan,
        //            PanelFtpBilgi=model.PanelFtpBilgi
        //        };
        //        _context.Urunler.Add(urun);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Id = new SelectList(_context.Urunler.ToList(), "Id");
        //    return View("Edit", new UrunViewModel());
        //}

        //[Authorize]
        //public ActionResult Edit(int id)
        //{
        //    ViewBag.Id = new SelectList(_context.Urunler.ToList(), "Id");

        //    UrunViewModel vm = _context.Urunler.Select(x => new UrunViewModel
        //    {
        //        Id = x.Id,
        //        BayiAdi = x.BayiAdi,
        //        DomainAdi = x.DomainAdi,
        //        DomainBasTarihi = x.DomainBasTarihi,
        //        DomainBitisTarihi = x.DomainBitisTarihi,
        //        HostingBasTarihi = x.HostingBasTarihi,
        //        HostingBitisTarihi = x.HostingBitisTarihi,
        //        MusteriId = x.MusteriId,
        //        PanelFtpBilgi = x.PanelFtpBilgi

        //    }).FirstOrDefault(x => x.Id == id);

        //    return View(vm);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(UrunViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Urun urun = _context.Urunler.Find(model.Id);
        //        urun.DomainAdi = model.DomainAdi;
        //        urun.BayiAdi = model.BayiAdi;
        //        urun.HostingBasTarihi = model.HostingBasTarihi;
        //        urun.HostingBitisTarihi = model.HostingBitisTarihi;
        //        urun.DomainBasTarihi = model.DomainBasTarihi;
        //        urun.DomainBitisTarihi = model.DomainBitisTarihi;
        //        urun.MusteriId = model.MusteriId;
        //        urun.PanelFtpBilgi = model.PanelFtpBilgi;

        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Id = new SelectList(_context.Urunler.ToList(), "Id");
        //    return View();
        //}
    }
}
