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
    public class MenuListViewModel
    {
        public IEnumerable<MenuViewModel> Menus { get; set; }
    }
}
