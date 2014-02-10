using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CateringApplication.DAL.EntityModels;
using CateringApplication.Core.Models;

namespace CateringApplication.Core.Mapping
{
    public static class FoodMapperExtensionMethods
    {
        public static FoodViewModel ConvertToFoodView(this Food food)
        {
            return Mapper.Map<Food, FoodViewModel>(food);
        }

        public static IEnumerable<FoodViewModel> ConvertToFoodListView(this IEnumerable<Food> foods)
        {
            return Mapper.Map<IEnumerable<Food>, IEnumerable<FoodViewModel>>(foods);
        }

        // ------------------------- BACK TO DOMAIN -------------------------------

        public static Food ConvertToDomain(this FoodViewModel food)
        {
            return Mapper.Map<FoodViewModel, Food>(food);
        }
    }
}
