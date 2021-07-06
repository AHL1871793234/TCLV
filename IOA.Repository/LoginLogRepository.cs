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
    /// 登录日志类  调用公用类和登录日志接口
    /// </summary>
    public class LoginLogRepository:BaseRepositroy<LoginLog>,ILoginLogRepository
    {

    }
}
