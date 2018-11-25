using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    public class AllCitiesController : Controller
    {
        [HttpGet]
        public JsonResult GetAllCities1()
        {
            //return new JsonResult(new List<object> {

            //    new { id=1, name = "Jaipur" },
            //      new { id=2, name = "Jaipur1" },
            //        new { id=3, name = "Jaipur2" }
            //});
            return new JsonResult(CityDataStore.Current.Cities);
        }
        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {

            return new JsonResult(CityDataStore.Current.Cities.FirstOrDefault(x => x.id == id));
        }

    }


}
