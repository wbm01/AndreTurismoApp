using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace TurismoComDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        
        private ClientService _clientService;
        private AddressService _addressService;
        private CityService _cityService;

        public ClientController()
        {
            _clientService = new ClientService();
            _addressService = new AddressService();
            _cityService = new CityService();
        }


        [HttpPost(Name = "InsertClient")]
        public ClientModel Insert(ClientModel client)
        {
            client.Id_Address_Client.Id_City_Address = (client.Id_Address_Client.Id_City_Address.Id_City == 0) ? _cityService.Insert(client.Id_Address_Client.Id_City_Address) : _cityService.FindById(client.Id_Address_Client.Id_City_Address.Id_City);

            client.Id_Address_Client = (client.Id_Address_Client.Id_Address == 0) ? _addressService.Insert(client.Id_Address_Client) : _addressService.FindById(client.Id_Address_Client.Id_Address);
   
            return _clientService.Insert(client);
        }


        [HttpPut(Name = "UpdateClient")]
        public bool Update(ClientModel client)
        {

            return _clientService.Update(client);
        }

        [HttpDelete(Name = "DeleteClient")]
        public bool Delete(int id)
        {

            return _clientService.Delete(id);
        }

        [HttpGet(Name = "GetClient")]
        public List<ClientModel> FindAll()
        {
            return _clientService.FindAll();
        }

        [HttpGet("{id}", Name = "GetClientId")]
        public ActionResult<ClientModel> FindById(int id)
        {

            return _clientService.FindById(id);

        }
    }
}
