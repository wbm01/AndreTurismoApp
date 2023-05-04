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
    public class PackageRepository:IPackageRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        public bool Delete(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Execute(PackageModel.DELETE, new { Id_Package = id });
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

        public List<PackageModel> FindAll()
        {
            var results = new List<PackageModel>();
            using (var db = new SqlConnection(_conn))
            {
                results = db.Query<PackageModel, HotelModel, AddressModel, CityModel, TicketModel, ClientModel, PackageModel>(PackageModel.GETALL,
                    (package, hotel, addressHotel, cityHotel, ticket, client) =>
                    {

                        package.Id_Hotel_Package = hotel;
                        package.Id_Hotel_Package.Id_Address_Hotel = addressHotel;
                        package.Id_Hotel_Package.Id_Address_Hotel.Id_City_Address = cityHotel;
                        package.Id_Ticket_Package = ticket;
                        package.Id_Client_Package = client;
                        
                        return package;
                    },
                    splitOn: "Id_Hotel, Id_Address, Id_City, Id_Ticket, Id_Client").ToList();
            }
            return results;
        }


        public PackageModel FindById(int id)
        {
            var results = new List<PackageModel>();
            using (var db = new SqlConnection(_conn))
            {
                results = db.Query<PackageModel, HotelModel, AddressModel, CityModel, TicketModel, ClientModel, PackageModel>(PackageModel.GETALL,
                    (package, hotel, addressHotel, cityHotel, ticket, client) =>
                    {

                        package.Id_Hotel_Package = hotel;
                        package.Id_Hotel_Package.Id_Address_Hotel = addressHotel;
                        package.Id_Hotel_Package.Id_Address_Hotel.Id_City_Address = cityHotel;
                        package.Id_Ticket_Package = ticket;
                        package.Id_Client_Package = client;

                        return package;
                    },
                    splitOn: "Id_Hotel, Id_Address, Id_City, Id_Ticket, Id_Client").ToList();
            }
            return results.First();
        }

        public PackageModel Insert(PackageModel package)
        {
            var id = 0;
            using (var db = new SqlConnection(_conn))
            {
                id = db.ExecuteScalar<int>(PackageModel.INSERT, new
                {
                    @Id_Hotel_Package = package.Id_Hotel_Package.Id_Hotel,
                    @Id_Ticket_Package = package.Id_Ticket_Package.Id_Ticket,
                    @Dt_Register_Package = DateTime.Now,
                    @Package_Value = package.Package_Value,
                    @Id_Client_Package = package.Id_Client_Package.Id_Client,
                });
            }

            package.Id_Package = id;

            return package;
        }


        public bool Update(PackageModel package)
        {
            var status = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Execute(PackageModel.UPDATE, new
                {
                    @Id_Package = package.Id_Package,
                    @Id_Hotel_Package = package.Id_Hotel_Package.Id_Hotel,
                    @Id_Ticket_Package = package.Id_Ticket_Package.Id_Ticket,
                    @Dt_Register_Package = DateTime.Now,
                    @Package_Value = package.Package_Value,
                    @Id_Client_Package = package.Id_Client_Package.Id_Client,

                });
                return status;
            }

        }
    }
}
