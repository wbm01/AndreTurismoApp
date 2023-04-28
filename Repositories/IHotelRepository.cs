using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IHotelRepository
    {
        HotelModel Insert(HotelModel hotel);

        bool Update(HotelModel hotel);

        bool Delete(int id);

        List<HotelModel> FindAll();

        HotelModel FindById(int id);
    }
}
