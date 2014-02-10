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
    public static class MenuMapperExtensionMethods
    {
        public static MenuViewModel ConvertToMenuView(this Menu menu)
        {
            return Mapper.Map<Menu, MenuViewModel>(menu);
        }

        public static IEnumerable<MenuViewModel> ConvertToMenuListView(this IEnumerable<Menu> menus)
        {
            return Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(menus);
        }

        // ------------------------- BACK TO DOMAIN -------------------------------

        public static Menu ConvertToDomain(this MenuViewModel menu)
        {
            return Mapper.Map<MenuViewModel, Menu>(menu);
        }
    }
}
