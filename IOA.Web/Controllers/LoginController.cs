using IOA.Common;
using IOA.IRepository;
using IOA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOA.Web.Controllers
{
    public class LoginController : Controller
    {
        ILoginRepository login;

        public LoginController(ILoginRepository _login)
        {
            login = _login;
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
            try
            {
                if (code.ToLower() == HttpContext.Session.GetString("Code").ToLower())
                {
                    UserModel user = login.LookingFor(userName, userPwd);
                    if (user != null)
                    {
                        HttpContext.Session.SetInt32("UserId", user.UserId);
                        HttpContext.Session.SetString("UserName", user.UserName);

                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw;
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
        //忘记密码，找回密码视图
        public IActionResult PassWord()
        {
            return View();
        }
        //忘记密码，根据用户名，设置新密码【修改密码】
        public int UpdPassWord(string userName,string userPwd,string code)
        {
            string sql = "update UserModel set  UserPwd=@userPwd where UserName=@userName";
            int hang = login.ZSG(sql, new { @userPwd = userPwd, @userName = userName });
            if (hang>0)
            {
                return 1;
            }
            return 0;
        }
        #endregion

    }
}
