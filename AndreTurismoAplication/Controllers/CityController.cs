using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Xml.Linq;

namespace TurismoComDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController:ControllerBase
    {
        
        private CityService _cityService;

        public CityController()
        {
            _cityService = new CityService();
        }

        [HttpPost(Name = "InsertCity")]
        public CityModel Insert(CityModel city)
        {
            return _cityService.Insert(city);
        }

        [HttpPut(Name = "UpdateCity")]
        public bool Update(CityModel city)
        {      
            return _cityService.Update(city);
        }

        [HttpDelete(Name = "DeleteCity")]
        public bool Delete(int id)
        {           
            return _cityService.Delete(id);
        }

        [HttpGet(Name = "GetCity")]
        public List<CityModel> FindAll()
        {
            return _cityService.FindAll();
        }

        [HttpGet("{id}", Name = "GetCityId")]
        public ActionResult<CityModel> FindById(int id)
        {

            return _cityService.FindById(id);

        }
    }
}
