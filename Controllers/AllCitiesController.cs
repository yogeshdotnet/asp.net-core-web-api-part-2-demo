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
            // return new JsonResult(CityDataStore.Current.Cities);
            var temp = new JsonResult(CityDataStore.Current.Cities);
            temp.StatusCode = 200;
            return temp;

        }
        [HttpGet("{id}", Name ="GetCity")]
        public IActionResult GetCity(int id)
        {

            var returnedcity =  CityDataStore.Current.Cities.FirstOrDefault(x => x.id == id);
            if(returnedcity == null)
            {
                return NotFound();
            }
            return Ok(returnedcity);
        }
        [HttpPost]
        public IActionResult PostCity([FromBody] City item)
        {
            CityDataStore.Current.Cities.Add(item);
            return CreatedAtRoute("GetCity", new { id = item.id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult PutCity(int id , [FromBody] City item)
        {
            if(item ==null)
            {
                return BadRequest();
            }
            if(item.Name == null & item.Description == null)
            {
                return BadRequest();
            }
            var data = CityDataStore.Current.Cities.FirstOrDefault(i => i.id == id);
            if(data ==null)
            {
                return NotFound();
            }
            data.Name = item.Name;
            data.Description = item.Description;
            data.Interest = item.Interest;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var data = CityDataStore.Current.Cities.FirstOrDefault(i => i.id == id);
            if (data == null)
            {
                return NotFound();
            }
            CityDataStore.Current.Cities.Remove(data);
            return NoContent();
        }

    }


}
