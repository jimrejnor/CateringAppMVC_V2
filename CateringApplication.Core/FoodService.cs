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
using CateringApplication.Core.Mapping;
using CateringApplication.Core.Models;

namespace CateringApplication.Core
{
    public class FoodService : IFoodService
    {
        // initialize UnitOfWork
        private IUnitOfWork _unitOfWork;

        public FoodService()
            : this(new UnitOfWork())
        {
        }

        public FoodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public FoodViewModel GetByID(object id)
        {
            FoodViewModel foodView;
            Food food = _unitOfWork.FoodRepository.GetByID(id);

            foodView = food.ConvertToFoodView();

            return foodView;
        }

        public FoodListViewModel GetAllInRestaurant(int restaurantID)
        {
            IEnumerable<Food> foods = _unitOfWork.FoodRepository.Get(filter: f => f.RestaurantID == restaurantID);
            FoodListViewModel foodListView = new FoodListViewModel();

            foodListView.Foods = foods.ConvertToFoodListView();

            // good way to access super category name????
            Restaurant restaurant = _unitOfWork.RestaurantRepository.GetByID(restaurantID);
            foodListView.RestaurantName = restaurant.Name;

            foodListView.Menus = new List<Menu>();
            foreach (FoodViewModel food in foodListView.Foods)
            {
                if (!foodListView.Menus.Contains(food.Menu))
                {
                    foodListView.Menus.Add(food.Menu);
                }
            }
   
            return foodListView;
        }

        public IEnumerable<Food> GetAll()
        {
            return _unitOfWork.FoodRepository.Get();
        }

        public bool Insert(FoodViewModel food)
        {
            Food domainFood = food.ConvertToDomain();

            try
            {
                _unitOfWork.FoodRepository.Insert(domainFood);
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
                _unitOfWork.FoodRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Update(FoodViewModel foodToUpdate)
        {
            Food domainFood = foodToUpdate.ConvertToDomain();

            try
            {
                _unitOfWork.FoodRepository.Update(domainFood);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            return _unitOfWork.MenuRepository.Get();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        // perform validation of town
        protected bool ValidateFood(Food foodToValidate)
        {
            return true;
        }
    }
}
