using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CateringApplication.DAL.EntityModels;
using CateringApplication.Core.Models;

namespace CateringApplication.Core
{
    public class BootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Town, TownViewModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.TownID));
            Mapper.CreateMap<Restaurant, RestaurantViewModel>().
                ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.RestaurantID));
            Mapper.CreateMap<Food, FoodViewModel>().
                ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.FoodID));
            Mapper.CreateMap<Menu, MenuViewModel>().
                ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.MenuID));

            // reverse - do I need this???
            Mapper.CreateMap<TownViewModel, Town>().
                ForMember(dest => dest.TownID, opt => opt.MapFrom(src => src.ID));
            Mapper.CreateMap<RestaurantViewModel, Restaurant>().
                ForMember(dest => dest.RestaurantID, opt => opt.MapFrom(src => src.ID));
            Mapper.CreateMap<FoodViewModel, Food>().
                ForMember(dest => dest.FoodID, opt => opt.MapFrom(src => src.ID));
            Mapper.CreateMap<MenuViewModel, Menu>().
                ForMember(dest => dest.MenuID, opt => opt.MapFrom(src => src.ID));
        }
    }
}
