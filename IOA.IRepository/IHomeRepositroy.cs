using IOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.IRepository
{
    /// <summary>
    /// 主菜单接口
    /// </summary>
    public interface IHomeRepositroy : IBaseRepositroy<MenuModel>
    {

        //获取用户获取左侧菜单
        List<MenuModel> leftData(int? userId, int parentID = 0);

    }
}
