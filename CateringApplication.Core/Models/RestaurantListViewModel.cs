using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CateringApplication.Core.Models
{
    public class RestaurantListViewModel
    {
        public IEnumerable<RestaurantViewModel> Restaurants { get; set; }

        [DisplayName("Town")]
        public string TownName { get; set; }
    }
}
