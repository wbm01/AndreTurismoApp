using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Xml.Linq;

namespace AndreTurismoAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController
    {
        private AddressService _addressService;
        private CityService _cityService;
        private HotelService _hotelService;

        public HotelController()
        {
            _addressService = new AddressService();
            _cityService = new CityService();
            _hotelService = new HotelService();
        }


        [HttpPost(Name = "InsertHotel")]
        public HotelModel Insert(HotelModel hotel)
        {
            hotel.Id_Address_Hotel.Id_City_Address = (hotel.Id_Address_Hotel.Id_City_Address.Id_City == 0) ? _cityService.Insert(hotel.Id_Address_Hotel.Id_City_Address) : _cityService.FindById(hotel.Id_Address_Hotel.Id_City_Address.Id_City);

            hotel.Id_Address_Hotel = (hotel.Id_Address_Hotel.Id_Address == 0) ? _addressService.Insert(hotel.Id_Address_Hotel) : _addressService.FindById(hotel.Id_Address_Hotel.Id_Address);

            return _hotelService.Insert(hotel);
        }


        [HttpPut(Name = "UpdateHotel")]
        public bool Update(HotelModel hotel)
        {

            return _hotelService.Update(hotel);
        }

        [HttpDelete(Name = "DeleteHotel")]
        public bool Delete(int id)
        {

            return _hotelService.Delete(id);
        }

        [HttpGet(Name = "GetHotel")]
        public List<HotelModel> FindAll()
        {
            return _hotelService.FindAll();
        }

        [HttpGet("{id}", Name = "GetHotelId")]
        public ActionResult<HotelModel> FindById(int id)
        {

            return _hotelService.FindById(id);

        }
    }
}
