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
    public class TicketService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\source\repos\AndreTurismoAplication\Banco de Dados\DBTurismo.mdf";
        readonly SqlConnection conn;

        public TicketService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public TicketModel Insert(TicketModel ticket)
        {
            new TicketRepository().Insert(ticket);

            return ticket;
        }

        public bool Update(TicketModel ticket)
        {
            return new TicketRepository().Update(ticket);
        }

        public bool Delete(int id)
        {
            return new TicketRepository().Delete(id);
        }

        public List<TicketModel> FindAll()
        {
            return new TicketRepository().FindAll();
        }

        public TicketModel FindById(int id)
        {
            return new TicketRepository().FindById(id);
        }
    }
}
