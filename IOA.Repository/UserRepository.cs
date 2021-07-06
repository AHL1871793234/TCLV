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
    /// 用户类  调用类  调用用户接口
    /// </summary>
    public class UserRepository:BaseRepositroy<UserModel>,IUserRepository
    {

    }
}
