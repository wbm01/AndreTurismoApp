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
    public class HotelRepository:IHotelRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        public bool Delete(int id)
        {
            try
            {
                using (var db = new SqlConnection(_conn))
                {
                    db.Execute(HotelModel.DELETE, new { Id_Hotel = id });
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HotelModel> FindAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                var a = db.Query<HotelModel, AddressModel, CityModel, HotelModel>(
                    HotelModel.GETALL,
                    (hotel, address, city) =>
                    {
                        hotel.Id_Address_Hotel = address;
                        hotel.Id_Address_Hotel.Id_City_Address = city;
                        return hotel;

                    }, splitOn: "Id_Address, Id_City");


                return (List<HotelModel>)a;
            }
        }

        public HotelModel FindById(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var a = db.Query<HotelModel, AddressModel, CityModel, HotelModel>(
                    HotelModel.GETALL,
                    (hotel, address, city) =>
                    {
                        hotel.Id_Address_Hotel = address;
                        hotel.Id_Address_Hotel.Id_City_Address = city;
                        return hotel;

                    }, splitOn: "Id_Address, Id_City");


                return a.First();
            }
        }

        public HotelModel Insert(HotelModel hotel)
        {
            var id = 0;

            using (var db = new SqlConnection(_conn))
            {
                id = db.ExecuteScalar<int>(HotelModel.INSERT, new
                {
                    @Name_Hotel = hotel.Name_Hotel,
                    @Id_Address_Hotel = hotel.Id_Address_Hotel.Id_Address,
                    @DtRegister_Hotel = hotel.DtRegister_Hotel,
                    @Hotel_Value = hotel.Hotel_Value
                });
            }

            hotel.Id_Hotel = id;

            return hotel;
        }

        public bool Update(HotelModel hotel)
        {
            try
            {
                using (var db = new SqlConnection(_conn))
                {

                    db.Execute(HotelModel.UPDATE, hotel);
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
