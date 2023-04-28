using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IPackageRepository
    {
        PackageModel Insert(PackageModel package);

        bool Update(PackageModel package);

        bool Delete(int id);

        List<PackageModel> FindAll();

        PackageModel FindById(int id);
    }
}
