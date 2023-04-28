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
    public class PackageService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        readonly SqlConnection conn;

        public PackageService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public PackageModel Insert(PackageModel package)
        {
            new PackageRepository().Insert(package);

            return package;
        }

        public bool Update(PackageModel package)
        {
            return new PackageRepository().Update(package);
        }

        public bool Delete(int id)
        {
            return new PackageRepository().Delete(id);
        }

        public List<PackageModel> FindAll()
        {
            return new PackageRepository().FindAll();
        }

        public PackageModel FindById(int id)
        {
            return new PackageRepository().FindById(id);
        }
    }
}
