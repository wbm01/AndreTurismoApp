using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Services
{
    public class AddressService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        readonly SqlConnection conn;

        public AddressService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public AddressModel Insert(AddressModel address)
        {
            new AddressRepository().Insert(address);

            return address;
        }

        public bool Update(AddressModel address)
        {
            return new AddressRepository().Update(address);
        }

        public bool Delete(int id)
        {
            return new AddressRepository().Delete(id);
        }

        public List<AddressModel> FindAll()
        {
            return new AddressRepository().FindAll();
        }

        public AddressModel FindById(int id)
        {
            return new AddressRepository().FindById(id);
        }
    }
}
