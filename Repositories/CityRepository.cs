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
    public class CityRepository:ICityRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        public bool Delete(int id)
        {
            try
            {
                using (var db = new SqlConnection(_conn))
                {
                    db.Execute(CityModel.DELETE, new { Id_City = id });
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CityModel> FindAll()
        {
            List<CityModel> list = new List<CityModel>();
            using (var db = new SqlConnection(_conn))
            {
                var city = db.Query<CityModel>(CityModel.GETALL);
                list = (List<CityModel>)city;
            }
            return list;
        }

        public CityModel FindById(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var city = db.QueryFirstOrDefault<CityModel>(CityModel.GETID, new {@Id_City = id});

                return (CityModel)city;
            }
        }

        public CityModel Insert(CityModel city)
        {
                var id = 0;

                using (var db = new SqlConnection(_conn))
                {
                  id = db.ExecuteScalar<int>(CityModel.INSERT, city);
                    
                }
                city.Id_City = id;

                return city;
        }

        public bool Update(CityModel city)
        {
            try
            {
                using (var db = new SqlConnection(_conn))
                {
                    //db.Open();
                    db.Execute(CityModel.UPDATE, city);
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
