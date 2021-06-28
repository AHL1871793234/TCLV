using IOA.IRepository;
using IOA.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOA.Web.Controllers
{
    public class LogController : Controller
    {
        ILoginLogRepository loginLog;

        public LogController(ILoginLogRepository _loginLog)
        {
            loginLog = _loginLog;
        }

        //显示登录日志信息表
        public IActionResult LoginLog()
        {
            return View();
        }
        //显示登录日志方法
        public IActionResult LoginLogIndex()
        {
            List<LoginLog> loginLogs = loginLog.Show("select * from LoginLog", "");

            return Ok(new { code = 0, msg = "", count = loginLogs.Count, data = loginLogs });
        }
    }
}
