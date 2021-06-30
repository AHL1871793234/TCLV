using IOA.Common;
using IOA.IRepository;
using IOA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Microsoft.Extensions.Logging;

namespace IOA.Web.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : Controller
    {
        ILoginRepository login;
        ILoginLogRepository loginLog;
        //Nlog  日志
        //Logger logger = LogManager.GetCurrentClassLogger();

        public LoginController(ILoginRepository _login, ILoginLogRepository _loginLog)
        {
            login = _login;
            loginLog = _loginLog;
        }

        //生成图片验证码
        public IActionResult CheckCode()
        {
            string code = VerificationCodeHelper.CreateValidateCode(4);
            HttpContext.Session.SetString("Code", code);
            byte[] bytes = VerificationCodeHelper.CreateValidateGraphic(code);
            return File(bytes, "image/.jpg");
        }


        #region 登录方法视图Index一
        //登录视图1
        public IActionResult Index()
        {
            return View();
        }


        //登录方法1
        public int UserRoleLogin(string userName, string userPwd, string code)
        {
            string agent = Request.Headers["User-Agent"];
            //定义生成随机数字
            Random r = new Random();
            //随即数字在100000到999999之间
            string number = r.Next(100000, 999999).ToString();

            if (code.ToLower() == HttpContext.Session.GetString("Code").ToLower() || code.ToUpper() == HttpContext.Session.GetString("Code").ToUpper())
            {
                UserModel user = login.LookingFor(userName, userPwd);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetString("UserName", user.UserName);

                    //保存登录日志
                    //logger.Debug($"HI--{user.UserName}--{DateTime.Now.ToString("yyyyMMddHHmmss")}");

                    Log4NetUtil.Info("测试日志");

                    //添加登录日志信息保存到数据库
                    DapperHelper<LoginLog>.Execute("insert into LoginLog values(@LoginNo,@LoginDate,@LoginName,@LoginStatus,@LoginTerminal,@LoginIP,@LoginMAC)",
                        new
                        {
                            @LoginNo = DateTime.Now.ToString("yyyyMMddHHmmss") + number,
                            @LoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            @LoginName = user.UserName,
                            @LoginStatus = "网页端",
                            @LoginTerminal = agent.Substring(81, 6) + "浏览器",
                            @LoginIP = GetMACIp.GetLocalIp(),       //电脑的IP地址
                            @LoginMAC = GetMACIp.GetMAC()           //电脑的MAC地址
                        });


                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region 登录方法视图Login二
        //登录视图2
        public IActionResult Login()
        {
            return View();
        }
        //登录方法2
        public int UserLogin(string userName, string userPwd)
        {
            UserModel user = login.LookingFor(userName, userPwd);
            if (user != null)
            {
                return 1;
            }
            return 0;
        }
        #endregion


        //忘记密码，找回密码视图
        public IActionResult PassWord()
        {
            return View();
        }
        //忘记密码，根据用户名，设置新密码【修改密码】
        public int UpdPassWord(string userName, string userPwd, string code)
        {
            string sql = "update UserModel set  UserPwd=@userPwd where UserName=@userName";
            int hang = login.ZSG(sql, new { @userPwd = userPwd, @userName = userName });
            if (hang > 0)
            {
                return 1;
            }
            return 0;
        }



    }
}
