using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boreass.Models;
using Boreass.Models.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace Boreass.Controllers
{
    public class BolgelerController : Controller
    {
        public IActionResult AkdenizBolgesi()
        {
            return View();
        }
        public IActionResult DoguAnadoluBolgesi()
        {
            return View();
        }
        public IActionResult EgeBolgesi()
        {           
            return View();
        }
        public IActionResult GuneydoguAnadoluBolgesi()
        {
            return View();
        }
        public IActionResult IcAnadoluBolgesi()
        {
            return View();
        }
        public IActionResult KaradenizBolgesi()
        {
            return View();
        }
        public IActionResult MarmaraBolgesi()
        {
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