using IOA.Common;
using IOA.IRepository;
using IOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Repository
{
    /// <summary>
    /// 菜单类  调用公共类和菜单接口
    /// </summary>
    public class MenuRepository:BaseRepositroy<MenuModel>,IMenuRepository
    {
        public bool EditMenu(int roleId,int menuId)
        {
            List<MenuModel> menuModels = DapperHelper<MenuModel>.Query("select * from RolesMenu join RoleModel on RoleModel.RoleId=RolesMenu.RoleId join MenuModel on MenuModel.MenuId=RolesMenu.MenuId where RoleModel.RoleId=@roleId and MenuModel.MenuId=@menuId and RolesMenu.RoleMenuStatus=1 and MenuModel.MenuParentID !=0", new { @roleId = roleId, @menuId = menuId });

            int hang = menuModels.Count;

            if (hang>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
