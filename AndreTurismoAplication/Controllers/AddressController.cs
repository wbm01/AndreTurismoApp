using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Models;
using Services;

namespace TurismoComDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressService _addressService;
        private CityService _cityService;

        public AddressController()
        {
            _addressService = new AddressService();
            _cityService = new CityService();
        }


        [HttpPost("cep", Name = "InsertAddress")]
        public AddressModel Insert(AddressModel address)
        {

            address.Id_City_Address = (address.Id_City_Address.Id_City == 0) ? _cityService.Insert(address.Id_City_Address) : _cityService.FindById(address.Id_City_Address.Id_City);

            return _addressService.Insert(address);
        }

        [HttpPut(Name = "UpdateAddress")]
        public bool Update(AddressModel address)
        {


            return _addressService.Update(address);
        }

        [HttpDelete(Name = "DeleteAddress")]
        public bool Delete(int id)
        {

            return _addressService.Delete(id);
        }

        [HttpGet(Name = "GetAddress")]
        public List<AddressModel> FindAll()
        {

            return _addressService.FindAll();
        }

        [HttpGet("{id}", Name = "GetAddressId")]
        public ActionResult<AddressModel> FindById(int id)
        {

            return _addressService.FindById(id);

        }
    }
}
