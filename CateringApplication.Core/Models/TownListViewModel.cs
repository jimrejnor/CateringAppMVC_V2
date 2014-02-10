using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringApplication.Core.Models
{
    public class TownListViewModel
    {
        public IEnumerable<TownViewModel> Towns { get; set; }
    }
}
