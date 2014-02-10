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
    public static class RestaurantMapperExtensionMethods
    {
        public static RestaurantViewModel ConvertToRestaurantView(this Restaurant restaurant)
        {
            return Mapper.Map<Restaurant, RestaurantViewModel>(restaurant);
        }

        public static IEnumerable<RestaurantViewModel> ConvertToRestaurantListView(this IEnumerable<Restaurant> restaurants)
        {
            return Mapper.Map<IEnumerable<Restaurant>, IEnumerable<RestaurantViewModel>>(restaurants);
        }

        // ------------------------- BACK TO DOMAIN -------------------------------

        public static Restaurant ConvertToDomain(this RestaurantViewModel restaurant)
        {
            return Mapper.Map<RestaurantViewModel, Restaurant>(restaurant);
        }
    }
}
