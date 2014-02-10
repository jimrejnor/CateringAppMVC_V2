using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.DAL.EntityModels;

namespace CateringApplication.DAL.Interfaces
{
    public interface IFoodRepository : IGenericRepository<Food>
    {
    }
}