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
    public class MenuViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Menu Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Menu cannot be above 50 or below 2 characters")]
        public string Name { get; set; }
    }
}
