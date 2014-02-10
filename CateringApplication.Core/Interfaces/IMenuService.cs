using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CateringApplication.Core.Models;
using CateringApplication.DAL.EntityModels;

namespace CateringApplication.Core.Interfaces
{
    public interface IMenuService
    {
        MenuViewModel GetByID(object id);
        MenuListViewModel GetAll();

        bool Insert(MenuViewModel town);
        bool Delete(object id);
        bool Update(MenuViewModel foodToUpdate);

        void Dispose();
    }
}
