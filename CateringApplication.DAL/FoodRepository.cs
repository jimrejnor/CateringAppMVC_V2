using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.DAL.EntityModels;
using CateringApplication.DAL.Interfaces;

namespace CateringApplication.DAL
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        public FoodRepository(CateringContext context)
            : base(context)
        {
            
        }
    }
}