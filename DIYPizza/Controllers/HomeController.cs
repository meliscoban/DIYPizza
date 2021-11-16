using DIYPizza.Models;
using DIYPizza.Models.Data;
using DIYPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DIYPizza.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Secim> secimler = _context.Malzemeler.Select(m => new Secim() { MalzemeId = m.Id, MalzemeAd = m.Ad, SeciliMi = false }).ToList();

            return View(secimler);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(List<Secim> secimler)
        {
            if (secimler.Count(x => x.SeciliMi) < 2)
            {
                ModelState.AddModelError("", "En az 2 adet malzeme seçmeniz gerekmektedir.");
            }

            if (ModelState.IsValid)
            {
                var secilenler = secimler.Where(x => x.SeciliMi).ToList();
                TempData["SecilenMalzemeler"] = JsonSerializer.Serialize(secilenler);
                return RedirectToAction("Siparis");
            }

            return View(secimler);
        }

        public IActionResult Siparis()
        {
            //string json = (string)TempData["SecilenMalzemeler"];
            //List<Secim> secimler = JsonSerializer.Deserialize<List<Secim>>(json);
            List<Secim> secimler = JsonSerializer.Deserialize<List<Secim>>((string)TempData["SecilenMalzemeler"]);
            return View(secimler);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
