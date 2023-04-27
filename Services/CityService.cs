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
    public class CityService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        readonly SqlConnection conn;

        public CityService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public CityModel Insert(CityModel city)
        {
            new CityRepository().Insert(city);

            return city;
        }

        public bool Update(CityModel city)
        {
            return new CityRepository().Update(city);
        }

        public bool Delete(int id)
        {
            return new CityRepository().Delete(id);
        }

        public List<CityModel> FindAll()
        {
            return new CityRepository().FindAll();
        }

        public CityModel FindById(int id)
        {
            return new CityRepository().FindById(id);
        }
    }
}
