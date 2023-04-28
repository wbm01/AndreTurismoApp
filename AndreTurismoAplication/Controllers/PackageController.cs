using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace AndreTurismoAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private ClientService _clientService;
        private AddressService _addressService;
        private CityService _cityService;
        private TicketService _ticketService;
        private PackageService _packageService;
        private HotelService _hotelService;

        public PackageController()
        {
            _clientService = new ClientService();
            _addressService = new AddressService();
            _cityService = new CityService();
            _ticketService = new TicketService();
            _packageService = new PackageService();
            _hotelService = new HotelService();
        }


        [HttpPost(Name = "InsertPackage")]
        public PackageModel Insert(PackageModel package)
        {
            package.Id_Hotel_Package = (package.Id_Hotel_Package.Id_Hotel == 0) ? _hotelService.Insert(package.Id_Hotel_Package) : _hotelService.FindById(package.Id_Hotel_Package.Id_Hotel);

            package.Id_Ticket_Package = (package.Id_Ticket_Package.Id_Ticket == 0) ? _ticketService.Insert(package.Id_Ticket_Package) : _ticketService.FindById(package.Id_Ticket_Package.Id_Ticket);

            package.Id_Client_Package = (package.Id_Client_Package.Id_Client == 0) ? _clientService.Insert(package.Id_Client_Package) : _clientService.FindById(package.Id_Client_Package.Id_Client);


            return _packageService.Insert(package);
        }


        [HttpPut(Name = "UpdatePackage")]
        public bool Update(PackageModel package)
        {

            return _packageService.Update(package);
        }

        [HttpDelete(Name = "DeletePackage")]
        public bool Delete(int id)
        {

            return _packageService.Delete(id);
        }

        [HttpGet(Name = "GetPackage")]
        public List<PackageModel> FindAll()
        {
            return _packageService.FindAll();
        }

        [HttpGet("{id}", Name = "GetPackageId")]
        public ActionResult<PackageModel> FindById(int id)
        {

            return _packageService.FindById(id);

        }
    }
}
