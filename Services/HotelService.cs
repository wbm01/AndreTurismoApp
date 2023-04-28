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
    public class HotelService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        readonly SqlConnection conn;

        public HotelService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public HotelModel Insert(HotelModel hotel)
        {
            new HotelRepository().Insert(hotel);

            return hotel;
        }

        public bool Update(HotelModel hotel)
        {
            return new HotelRepository().Update(hotel);
        }

        public bool Delete(int id)
        {
            return new HotelRepository().Delete(id);
        }

        public List<HotelModel> FindAll()
        {
            return new HotelRepository().FindAll();
        }

        public HotelModel FindById(int id)
        {
            return new HotelRepository().FindById(id);
        }
    }
}
