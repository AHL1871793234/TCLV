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
        public IActionResult LoginLogIndex(string userName="",int page=1,int limit=5)
        {
            List<LoginLog> loginLogs = loginLog.Show("select * from LoginLog", "");
            //查询语句  根据用户名进行查询
            if (!string.IsNullOrEmpty(userName))
            {
                loginLogs = loginLogs.Where(x => x.LoginName.Contains(userName)).ToList();
            }
            else
            {
                loginLogs = loginLogs.ToList();
            }
            //分页
            var pageData = loginLogs.Skip(limit * (page - 1)).Take(limit).ToList();

            return Ok(new { code = 0, msg = "", count = loginLogs.Count, data = pageData });
        }



    }
}
