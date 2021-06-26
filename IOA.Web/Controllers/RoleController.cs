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
    /// 角色控制器
    /// </summary>
    public class RoleController : Controller
    {
        IRoleRepository role;

        public RoleController(IRoleRepository _role)
        {
            role = _role;
        }

        //显示角色视图
        public IActionResult Index()
        {
            return View();
        }
        //显示角色信息方法
        public IActionResult RoleIndex(int page=1,int limit=5,string roleName="")
        {
            List<RoleModel> data = role.Show("select * from RoleModel", "");
            //条件查询
            if (!string.IsNullOrEmpty(roleName))
            {
                data = data.Where(x => x.RoleName.Contains(roleName)).ToList();
            }
            else
            {
                data = data.ToList();
            }
            //分页
            var pageData = data.Skip(limit * (page - 1)).Take(limit).ToList();

            return Ok(new { code = 0, msg = "", count = data.Count, data = pageData });
        }


    }
}
