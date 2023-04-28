using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface ITicketRepository
    {
        TicketModel Insert(TicketModel ticket);

        bool Update(TicketModel ticket);

        bool Delete(int id);

        List<TicketModel> FindAll();

        TicketModel FindById(int id);
    }
}
