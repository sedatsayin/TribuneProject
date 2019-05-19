using Microsoft.AspNetCore.Mvc;
using Boreass.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;
using Boreass.Models.DbModels;

namespace Boreass.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["Message"] = "Hoşgeldiniz";

            //try
            //{
            //    using (sedatContext sd = new sedatContext())
            //    {
            //        Areas item = sd.Areas.FirstOrDefault(x => x.Id == 2);
            //        List<Areas> item2 = sd.Areas.Where(x => x.Id > 1).ToList();
            //        List<Areas> item3 = sd.Areas.OrderByDescending(x => x.Id).ToList();
            //        string item4 = sd.Areas.FirstOrDefault(x => x.Id == 2).Name;
            //        List<Areas> item5 = new List<Areas>();
            //        sd.Areas.Where(x => x.Id > 1).OrderByDescending(z => z.Name).ToList().ForEach(x => item5.Add(x));
            //    }
            //}
            //catch
            //{
            //    throw;
            //}

            return View();
        }
        [HttpPost]
        public JsonResult SomaResult()
        {
            Earnings earnings = new Earnings()
            {
                StationId = 1
            };
            try
            {
                using (sedatContext db = new sedatContext())
                {
                    db.EarningMonthly.Where(x => x.StationId == earnings.StationId).ToList().ForEach(x => earnings.monthList.Add(new Earnings.List()
                    {
                        Earning = x.Earning.GetValueOrDefault(),
                        Month = x.Month.GetValueOrDefault()
                    }));
                }
            }
            catch
            {
                throw;
            }
            return Json(new { earnings = earnings });
        }
    }
}
