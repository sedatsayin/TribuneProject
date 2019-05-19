using Boreass.Models;
using Boreass.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Boreass.Controllers
{
    public class TablesController : Controller
    {
        public IActionResult Index()
        {
            List<StationModel> stationsList = new List<StationModel>();
            try
            {
                using (sedatContext db = new sedatContext())
                {
                    db.Stations.ToList().ForEach(x => stationsList.Add(new StationModel()
                    {
                        Id = x.Id,
                        AreaId = x.AreaId,
                        Name = x.Name,
                        StartDate = x.StartDate.GetValueOrDefault().ToString("dd.MM.yyyy"),
                        score = x.Score.GetValueOrDefault()
                    }));
                    foreach (var item in stationsList)
                    {
                        item.VillageName = db.Areas.FirstOrDefault(x => x.Id == item.AreaId).Name;
                        item.TribuneCount = db.Tribunes.Count(x => x.StationId == item.Id);
                    }
                }
            }
            catch
            {
                throw;
            }
            return View(stationsList);
        }
    }
}