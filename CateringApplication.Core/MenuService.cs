using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CateringApplication.DAL;
using CateringApplication.DAL.Interfaces;
using CateringApplication.DAL.EntityModels;
using CateringApplication.Core.Interfaces;
using CateringApplication.Core.Mapping;
using CateringApplication.Core.Models;

namespace CateringApplication.Core
{
    public class MenuService : IMenuService
    {
        // initialize UnitOfWork
        private IUnitOfWork _unitOfWork;

        public MenuService()
            : this(new UnitOfWork())
        {
        }

        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MenuViewModel GetByID(object id)
        {
            MenuViewModel menuView;
            Menu menu = _unitOfWork.MenuRepository.GetByID(id);

            menuView = menu.ConvertToMenuView();

            return menuView;
        }

        public MenuListViewModel GetAll()
        {
            IEnumerable<Menu> menus = _unitOfWork.MenuRepository.Get();
            MenuListViewModel menuListView = new MenuListViewModel();

            menuListView.Menus = menus.ConvertToMenuListView();
   
            return menuListView;
        }

        public bool Insert(MenuViewModel menu)
        {
            Menu domainMenu = menu.ConvertToDomain();

            try
            {
                _unitOfWork.MenuRepository.Insert(domainMenu);
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
                _unitOfWork.MenuRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Update(MenuViewModel menuToUpdate)
        {
            Menu domainMenu = menuToUpdate.ConvertToDomain();

            try
            {
                _unitOfWork.MenuRepository.Update(domainMenu);
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
    }
}
