﻿using IOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.IRepository
{
    public interface IMenuRepository:IBaseRepositroy<MenuModel>
    {
        bool EditMenu(int roleId, int menuId);
    }
}
