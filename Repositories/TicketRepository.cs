using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Repositories
{
    public class TicketRepository:ITicketRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        public bool Delete(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Execute(TicketModel.DELETE, new { Id_Ticket = id });
            }

            return true;
        }

        /*public List<TicketModel> FindAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                var tickets = db.Query<TicketModel>(TicketModel.GETALL, new[]
                {
                    typeof(TicketModel),
                    typeof(AddressModel),
                    typeof(CityModel),
                    typeof(AddressModel),
                    typeof(CityModel),
                    typeof(ClientModel),
                    typeof(AddressModel),
                    typeof(CityModel)
                },
                obj =>
                {
                    TicketModel ticket = obj[0] as TicketModel;
                    AddressModel addressSource = obj[1] as AddressModel;
                    CityModel citySource = obj[2] as CityModel;
                    AddressModel addressDestiny = obj[3] as AddressModel;
                    CityModel cityDestiny = obj[4] as CityModel;
                    ClientModel client = obj[5] as ClientModel;
                    AddressModel addressClient = obj[6] as AddressModel;
                    CityModel cityClient = obj[7] as CityModel;

                    ticket = ticket;
                    ticket.Id_Address_Origin = addressSource;
                    ticket.Id_Address_Origin.Id_City_Address = citySource;
                    ticket.Id_Address_Destiny = addressDestiny;
                    ticket.Id_Address_Destiny.Id_City_Address = cityDestiny;
                    ticket.Id_Client_Ticket = client;
                    ticket.Id_Client_Ticket.Id_Address_Client = addressClient;
                    ticket.Id_Client_Ticket.Id_Address_Client.Id_City_Address = cityClient;

                    return ticket;
                });

                return (List<TicketModel>)tickets;
            }
        }*/

        public List<TicketModel> FindAll()
        {
            var results = new List<TicketModel>();
            using (var db = new SqlConnection(_conn))
            {
                results = db.Query<TicketModel, AddressModel, CityModel, AddressModel, CityModel, ClientModel, TicketModel>(TicketModel.GETALL,
                    (ticket, origin, cityOrigin, destination, cityDestination, client) =>
                    {

                        ticket.Id_Address_Origin = origin;
                        ticket.Id_Address_Origin.Id_City_Address = cityOrigin;
                        ticket.Id_Address_Destiny = destination;
                        ticket.Id_Address_Destiny.Id_City_Address = cityDestination;
                        ticket.Id_Client_Ticket = client;
                        return ticket;
                    },
                    splitOn: "Id_Address, Id_City, Id_Address, Id_City, Id_Client, Id_Address, Id_City").ToList();
            }
            return results;
        }


        public TicketModel FindById(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var ticketLst = db.Query<TicketModel>(TicketModel.GETALL);

                return ticketLst.First();
            }
        }

        public TicketModel Insert(TicketModel ticket)
        {
            var id = 0;
            using (var db = new SqlConnection(_conn))
            {
                id = db.ExecuteScalar<int>(TicketModel.INSERT, new
                {
                    @Id_Address_Origin = ticket.Id_Address_Origin.Id_Address,
                    @Id_Address_Destiny = ticket.Id_Address_Destiny.Id_Address,
                    @Id_Client_Ticket = ticket.Id_Client_Ticket.Id_Client,
                    @DtTicket = ticket.DtTicket,
                    @Ticket_Value = ticket.Ticket_Value,
                });
            }

            ticket.Id_Ticket = id;

            return ticket;
        }


        public bool Update(TicketModel ticket)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(TicketModel.UPDATE, new
                {
                    @Id_Ticket = ticket.Id_Ticket,
                    @Id_Address_Origin = ticket.Id_Address_Origin.Id_Address,
                    @Id_Address_Destiny = ticket.Id_Address_Destiny.Id_Address,
                    @Id_Client_Ticket = ticket.Id_Client_Ticket.Id_Client,
                    @DtTicket = ticket.DtTicket,
                    @Ticket_Value = ticket.Ticket_Value,

                });
                    return status;
            }

        }
    }
}
