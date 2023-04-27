using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IClientRepository
    {
        ClientModel Insert(ClientModel client);

        bool Update(ClientModel client);

        bool Delete(int id);

        List<ClientModel> FindAll();

        ClientModel FindById(int id);
    }
}
