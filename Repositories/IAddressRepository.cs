using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IAddressRepository
    {
        AddressModel Insert(AddressModel address);

        bool Update(AddressModel address);

        bool Delete(int id);

        List<AddressModel> FindAll();

        AddressModel FindById(int id);
    }
}
