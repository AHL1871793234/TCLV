using IOA.IRepository;
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

        public IActionResult Index()
        {
            return View();
        }


    }
}
