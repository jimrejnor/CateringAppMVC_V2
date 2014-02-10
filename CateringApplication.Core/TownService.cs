using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CateringApplication.Core.Models;
using CateringApplication.Core.Mapping;
using CateringApplication.DAL;
using CateringApplication.DAL.Interfaces;
using CateringApplication.DAL.EntityModels;
using CateringApplication.Core.Interfaces;
using AutoMapper;

namespace CateringApplication.Core
{
    public class TownService : ITownService
    {
        // initialize UnitOfWork
        private IUnitOfWork _unitOfWork;

        public TownService()
            : this(new UnitOfWork())
        {
        }

        public TownService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TownViewModel GetByID(object id)
        {
            TownViewModel townView;
            Town town = _unitOfWork.TownRepository.GetByID(id);

            townView = town.ConvertToTownView();

            return townView;
        }

        public TownListViewModel GetAll()
        {
            IEnumerable<Town> towns = _unitOfWork.TownRepository.Get();
            TownListViewModel townListView = new TownListViewModel();

            townListView.Towns = towns.ConvertToTownListView();

            return townListView;
        }

        public bool Insert(TownViewModel town)
        {
            Town domainTown = town.ConvertToDomain();

            try
            {
                _unitOfWork.TownRepository.Insert(domainTown);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Delete(object id)
        {
            try
            {
                _unitOfWork.TownRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Update(TownViewModel townToUpdate)
        {
            Town domainTownToUpdate = townToUpdate.ConvertToDomain();

            try
            {
                _unitOfWork.TownRepository.Update(domainTownToUpdate);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        } 

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        // perform validation of town
        protected bool ValidateTown(Town townToValidate)
        {
            var towns = _unitOfWork.TownRepository.Get(
                                 filter: t => t.Name == townToValidate.Name);

            if (towns.Count() == 0)
                return true;
            else
                return false;
        }
    }
}
