using IOA.IRepository;
using IOA.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOA.Web.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : Controller
    {
        IUserRepository user;

        public UserController(IUserRepository _user)
        {
            user = _user;
        }

        #region  显示员工/用户信息
        //显示用户/员工视图
        public IActionResult Index()
        {
            return View();
        }
        //显示用户/员工方法
        public IActionResult UserIndex(string userName = "", int page = 1, int limit = 5)
        {
            List<UserModel> data = user.Show("select * from UserModel", "");

            if (!string.IsNullOrEmpty(userName))
            {
                data = data.Where(x => x.UserName.Contains(userName)).ToList();
            }
            else
            {
                data = data.ToList();
            }

            var pageData = data.Skip(limit * (page - 1)).Take(limit).ToList();

            return Ok(new { code = 0, msg = "", count = data.Count, data = pageData });
        }
        #endregion

        //添加用户视图
        public IActionResult CreateUser()
        {
            return View();
        }
        //添加用户方法
        public IActionResult AddUser()
        {
            return View();
        }

    }
}
