using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CateringApplication.DAL;
using CateringApplication.DAL.Interfaces;
using CateringApplication.DAL.EntityModels;
using CateringApplication.Core.Interfaces;
using CateringApplication.Core.Models;
using CateringApplication.Core.Mapping;

namespace CateringApplication.Core
{
    public class RestaurantService : IRestaurantService
    {
        // initialize UnitOfWork
        private IUnitOfWork _unitOfWork;

        public RestaurantService()
            : this(new UnitOfWork())
        {
        }

        public RestaurantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RestaurantViewModel GetByID(object id)
        {
            RestaurantViewModel restaurantView;
            Restaurant restaurant = _unitOfWork.RestaurantRepository.GetByID(id);

            restaurantView = restaurant.ConvertToRestaurantView();

            return restaurantView;
        }

        public RestaurantListViewModel GetAllInTown(int townID)
        {
            IEnumerable<Restaurant> restaurants = _unitOfWork.RestaurantRepository.Get(filter: r => r.TownID == townID);

            RestaurantListViewModel restaurantListView = new RestaurantListViewModel();

            restaurantListView.Restaurants = restaurants.ConvertToRestaurantListView();

            // good way to access super category object ???
            Town town = _unitOfWork.TownRepository.GetByID(townID);
            restaurantListView.TownName = town.Name;

            return restaurantListView;

        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _unitOfWork.RestaurantRepository.Get();
        }

        public bool Insert(RestaurantViewModel restaurant)
        {
            Restaurant domainRestaurant = restaurant.ConvertToDomain();

            try
            {
                _unitOfWork.RestaurantRepository.Insert(domainRestaurant);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Delete(object id)
        {
            try
            {
                _unitOfWork.RestaurantRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Update(RestaurantViewModel restaurantToUpdate)
        {
            Restaurant domainRestaurantToUpdate = restaurantToUpdate.ConvertToDomain();

            try
            {
                _unitOfWork.RestaurantRepository.Update(domainRestaurantToUpdate);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int GetTownIDForRestaurantID(int id)
        {
            RestaurantViewModel viewModel = this.GetByID(id);

            return viewModel.TownID;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        // perform validation of town
        protected bool ValidateRestaurant(Restaurant restaurantToValidate)
        {
            return true;
        }
    }
}
