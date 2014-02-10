using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CateringApplication.DAL.EntityModels;
using CateringApplication.Core.Models;

namespace CateringApplication.Core.Models
{
    public class FoodListViewModel
    {
        public IEnumerable<FoodViewModel> Foods { get; set; }

        // a list of all menus for IEnumerable<FoodViewModel> Foods
        // property without repetition 
        public List<Menu> Menus { get; set; }

        [DisplayName("Restaurant Name")]
        public string RestaurantName { get; set; }
    }
}
