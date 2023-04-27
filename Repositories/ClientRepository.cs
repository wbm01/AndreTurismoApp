using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Repositories
{
    public class ClientRepository:IClientRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        public bool Delete(int id)
        {
                using (var db = new SqlConnection(_conn))
                {
                    db.Execute(ClientModel.DELETE, new { Id_Client = id });
                }

                return true;
        }

        public List<ClientModel> FindAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                var result = db.Query<ClientModel, AddressModel, CityModel, ClientModel>(
                    ClientModel.GETALL,
                    (client, address, city) =>
                    {
                        client.Id_Address_Client = address;
                        client.Id_Address_Client.Id_City_Address = city;
                        return client;

                    },splitOn: "Id_Address, Id_City");
              
                return (List<ClientModel>)result;
            }
        }

        public ClientModel FindById(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var result = db.Query<ClientModel, AddressModel, CityModel, ClientModel>(
                   ClientModel.GETALL,
                   (client, address, city) =>
                   {
                       client.Id_Address_Client = address;
                       client.Id_Address_Client.Id_City_Address = city;
                       return client;

                   }, splitOn: "Id_Address, Id_City");

                return result.First();
            }
        }

        public ClientModel Insert(ClientModel client)
        {
                var id = 0;
                using (var db = new SqlConnection(_conn))
                {
                    id = db.ExecuteScalar<int>(ClientModel.INSERT, new
                    {
                        @Name_Client = client.Name_Client,
                        @Phone = client.Phone,
                        @Id_Address_Client = client.Id_Address_Client.Id_Address,
                        @DtRegister_Client = client.DtRegister_Client
                    });
                }

                client.Id_Client = id;

                return client;
        }

        public bool Update(ClientModel client)
        {
                using (var db = new SqlConnection(_conn))
                {
                    db.Execute(ClientModel.UPDATE, client);
                }
                return true;
        }
    }
}

