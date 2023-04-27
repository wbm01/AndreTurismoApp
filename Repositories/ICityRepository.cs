using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface ICityRepository
    {
        CityModel Insert(CityModel city);

        bool Update(CityModel city);

        bool Delete(int id);

        List<CityModel> FindAll();

        CityModel FindById(int id);
    }
}
