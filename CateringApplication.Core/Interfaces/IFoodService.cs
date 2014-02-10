using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CateringApplication.Core.Models;
using CateringApplication.DAL.EntityModels;

namespace CateringApplication.Core.Interfaces
{
    public interface IFoodService
    {
        FoodViewModel GetByID(object id);
        FoodListViewModel GetAllInRestaurant(int restaurantID);
        IEnumerable<Food> GetAll();

        bool Insert(FoodViewModel town);
        bool Delete(object id);
        bool Update(FoodViewModel foodToUpdate);

        IEnumerable<Menu> GetAllMenus();

        void Dispose();
    }
}
