using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CateringApplication.DAL.EntityModels;

namespace CateringApplication.Core.Models
{
    public class FoodViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Food name cannot be above 50 or below 2 characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Fill in a valid currency")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [DisplayName("Menu")]
        public Menu Menu { get; set; }

        public int RestaurantID { get; set; }
        public int MenuID { get; set; }
    }
}
