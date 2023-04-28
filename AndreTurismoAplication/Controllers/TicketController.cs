using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace AndreTurismoAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ClientService _clientService;
        private AddressService _addressService;
        private CityService _cityService;
        private TicketService _ticketService;

        public TicketController()
        {
            _clientService = new ClientService();
            _addressService = new AddressService();
            _cityService = new CityService();
            _ticketService = new TicketService();
        }


        [HttpPost(Name = "InsertTicket")]
        public TicketModel Insert(TicketModel ticket)
        {
            ticket.Id_Address_Origin.Id_City_Address = (ticket.Id_Address_Origin.Id_City_Address.Id_City == 0) ? _cityService.Insert(ticket.Id_Address_Origin.Id_City_Address) : _cityService.FindById(ticket.Id_Address_Origin.Id_City_Address.Id_City);
            ticket.Id_Address_Origin = (ticket.Id_Address_Origin.Id_Address == 0) ? _addressService.Insert(ticket.Id_Address_Origin) : _addressService.FindById(ticket.Id_Address_Origin.Id_Address);

            ticket.Id_Address_Destiny.Id_City_Address = (ticket.Id_Address_Destiny.Id_City_Address.Id_City == 0) ? _cityService.Insert(ticket.Id_Address_Destiny.Id_City_Address) : _cityService.FindById(ticket.Id_Address_Destiny.Id_City_Address.Id_City);
            ticket.Id_Address_Destiny = (ticket.Id_Address_Destiny.Id_Address == 0) ? _addressService.Insert(ticket.Id_Address_Destiny) : _addressService.FindById(ticket.Id_Address_Destiny.Id_Address);

            ticket.Id_Client_Ticket = (ticket.Id_Client_Ticket.Id_Client == 0) ? _clientService.Insert(ticket.Id_Client_Ticket) : _clientService.FindById(ticket.Id_Client_Ticket.Id_Client);


            return _ticketService.Insert(ticket);
        }


        [HttpPut(Name = "UpdateTicket")]
        public bool Update(TicketModel ticket)
        {

            return _ticketService.Update(ticket);
        }

        [HttpDelete(Name = "DeleteTicket")]
        public bool Delete(int id)
        {

            return _ticketService.Delete(id);
        }

        [HttpGet(Name = "GetTicket")]
        public List<TicketModel> FindAll()
        {
            return _ticketService.FindAll();
        }

        [HttpGet("{id}", Name = "GetTicketId")]
        public ActionResult<TicketModel> FindById(int id)
        {

            return _ticketService.FindById(id);

        }
    }
}
