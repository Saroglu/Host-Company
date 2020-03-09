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
        [Authorize]
        public ActionResult Create(int id, int? musteriId, string domainAdi, string bayiAdi, DateTime domainBasTarihi,
            DateTime domainBitisTarihi, DateTime hostingBasTarihi, DateTime hostingBitisTarihi, string panelVeFtp)
        {
            if (ModelState.IsValid)
            {

                Urun urun = new Urun
                {
                    Id = id,
                    MusteriId=musteriId,
                    DomainAdi = domainAdi,
                    BayiAdi = bayiAdi,
                    DomainBasTarihi = domainBasTarihi,
                    DomainBitisTarihi = domainBitisTarihi,
                    HostingBasTarihi = hostingBasTarihi,
                    HostingBitisTarihi = hostingBitisTarihi,
                    PanelFtpBilgi = panelVeFtp
                };
                _context.Urunler.Add(urun);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("UrunListele");
        }
    }
}
