using IOA.Model;
using IRepositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.IRepository
{
    public interface IHomeRepositroy : IBaseRepositroy<MenuModel>
    {

        //获取用户获取左侧菜单
        List<MenuModel> leftData(int? userId, int parentID = 0);

    }
}
