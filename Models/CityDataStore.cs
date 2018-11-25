using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication12.Models
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore();
        public List<City> Cities { get; set; }
        public CityDataStore()
        {
            Cities = new List<City>()
            {
                new City { id=1, Name ="Jaipur", Description = "Best City" },
                  new City { id=2, Name ="Jaipur1", Description = "Best City1" },
                    new City { id=3, Name ="Jaipur2", Description = "Best City2" }
            };

        }
    }
}
