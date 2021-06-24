using IOA.Common;
using IOA.IRepository;
using IOA.Model;
using IRepositroy;
using Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Repository
{
    public class HomeRepositroy : BaseRepositroy<MenuModel>, IHomeRepositroy
    {
        //获取头部方法
        public List<MenuModel> leftData(int? userId, int parentID = 0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select d.MenuId,e.MenuName,e.MenuLink,b.UserName from UserRoles a join UserModel b on a.UserId = b.UserId join RoleModel c on c.RoleId = a.RoleId join RolesMenu d on c.RoleId = d.RoleId join MenuModel e on e.MenuId = d.MenuId");
            stringBuilder.Append(" where e.MenuParentID=@parentID and b.UserId=@userID");
            if (parentID == 1)
            {
                stringBuilder.Append(" and e.MenuName='个人中心'");
            }
            if (parentID == 4)
            {
                stringBuilder.Append(" and e.MenuName='任务管理'");
            }

            List<MenuModel> leftData = DapperHelper<MenuModel>.Query(stringBuilder.ToString(), new { @parentID = parentID, @userID = userId });
            return leftData;
        }

    }
}
