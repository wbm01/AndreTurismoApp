using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Repositories
{
    public class AddressRepository:IAddressRepository
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        public bool Delete(int id)
        {
            try
            {
                using (var db = new SqlConnection(_conn))
                {
                    db.Execute(AddressModel.DELETE, new { Id_Address = id });
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AddressModel> FindAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                var a = db.Query<AddressModel, CityModel, AddressModel>(
                    AddressModel.GETALL,
                    (address, city) =>
                {
                    address.Id_City_Address = city;
                    return address;

                }, splitOn: "Id_City");
             

                return (List<AddressModel>)a;
            }
        }

        public AddressModel FindById(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var a = db.Query<AddressModel, CityModel, AddressModel>(
                    AddressModel.GETALL,
                    (address, city) =>
                    {
                        address.Id_City_Address = city;
                        return address;

                    }, splitOn: "Id_City");


                return a.First();
            }
        }

        public AddressModel Insert(AddressModel address)
        {
            var id = 0;

                using (var db = new SqlConnection(_conn))
                {
                    id = db.ExecuteScalar<int>(AddressModel.INSERT, new
                    {
                        @Street = address.Street,
                        @Number = address.Number,
                        @Neighborhood = address.Neighborhood,
                        @Cep = address.Cep,
                        @Complement = address.Complement,
                        @Id_City_Address = address.Id_City_Address.Id_City,
                        @DtRegister_Address = address.DtRegister_Address,
                    });       
                }

                address.Id_Address = id;

                return address;
        }

        public bool Update(AddressModel address)
        {
            try
            {
                using (var db = new SqlConnection(_conn))
                {
                    //db.Open();

                    db.Execute(AddressModel.UPDATE,address);
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
