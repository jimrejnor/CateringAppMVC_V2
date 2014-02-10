using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CateringApplication.Core.Models
{
    public class RestaurantViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Restaurant name can't be above 50 or below 2 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Address can't be above 50 or below 2 characters")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public int TownID { get; set; }
    }
}
