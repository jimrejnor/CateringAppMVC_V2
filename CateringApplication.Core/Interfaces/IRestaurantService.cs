using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CateringApplication.DAL.EntityModels;
using CateringApplication.Core.Models;

namespace CateringApplication.Core.Interfaces
{
    public interface IRestaurantService
    {
        RestaurantViewModel GetByID(object id);
        RestaurantListViewModel GetAllInTown(int townID);
        IEnumerable<Restaurant> GetAll();

        bool Insert(RestaurantViewModel town);
        bool Delete(object id);
        bool Update(RestaurantViewModel restaurantToUpdate);

        // Gets TownID of Town where currently selected Restaurant is
        int GetTownIDForRestaurantID(int id);

        void Dispose();
    }
}
