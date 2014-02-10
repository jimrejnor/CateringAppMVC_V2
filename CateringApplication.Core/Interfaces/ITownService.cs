using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CateringApplication.Core.Models;
using CateringApplication.DAL.EntityModels;

namespace CateringApplication.Core.Interfaces
{
    public interface ITownService
    {
        TownViewModel GetByID(object id);
        TownListViewModel GetAll();

        bool Insert(TownViewModel town);
        bool Delete(object id);
        bool Update(TownViewModel townToUpdate);

        void Dispose();
    }
}
