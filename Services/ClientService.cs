using System.Data.SqlClient;
using System.Net;
using Models;
using Repositories;

namespace Services
{
    public class ClientService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        readonly SqlConnection conn;

        public ClientService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public ClientModel Insert(ClientModel client)
        {
            new ClientRepository().Insert(client);

            return client;
        }

        public bool Update(ClientModel client)
        {
            return new ClientRepository().Update(client);
        }

        public bool Delete(int id)
        {
            return new ClientRepository().Delete(id);
        }

        public List<ClientModel> FindAll()
        {
            return new ClientRepository().FindAll();
        }

        public ClientModel FindById(int id)
        {
            return new ClientRepository().FindById(id);
        }
    }
}