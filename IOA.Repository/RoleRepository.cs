using IOA.Model;
using IOA.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Repository
{
    /// <summary>
    /// 角色类  调用公共类 并调用角色接口
    /// </summary>
    public class RoleRepository:BaseRepositroy<RoleModel>,IRoleRepository
    {
    }
}
