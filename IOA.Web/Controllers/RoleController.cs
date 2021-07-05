using IOA.Common;
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

        #region  显示角色信息
        //显示角色视图
        public IActionResult Index()
        {
            return View();
        }
        //显示角色信息方法
        public IActionResult RoleIndex(int page = 1, int limit = 5, string roleName = "")
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
        #endregion

        #region  拼接角色树形图



        #endregion


        //添加角色视图
        public IActionResult CreateRole()
        {
            return View();
        }

        //添加角色方法
        public int AddRole(RoleModel model)
        {
            int hang = role.ZSG("Insert into RoleModel values(@RoleName,@RoleMsg,@RoleState,@RoleCreateName,@RoleCreateDate )", new
            {
                @RoleName = model.RoleName,
                @RoleMsg = model.RoleMsg,
                @RoleState = model.RoleState,
                @RoleCreateName = model.RoleCreateName,
                @RoleCreateDate = model.RoleCreateDate
            });

            return hang;
        }
        //删除角色信息
        public int DelRole(string id)
        {
            //定义字符数组保存截取之后的Id
            string[] strId = id.Split(',');
            //定义标识符
            int hang = 0;
            //循环执行删除
            foreach (var item in strId)
            {
                hang = role.ZSG("delete from RoleModel where RoleId  in (@ID)", new { @ID = item });
            }
            //返回1成功0失败
            return hang;
        }
        //反填角色视图
        public IActionResult EditRole(int id)
        {
            ViewBag.RoleId = id;
            return View();
        }
        //反填角色信息方法
        public IActionResult EditRoleIndex(int id)
        {
            RoleModel roleMenu = DapperHelper<RoleModel>.QueryFirst("select * from RoleModel where RoleId=@ID", new { @ID = id });
            return Ok(roleMenu);
        }
        //修改角色信息
        public int UpdRole(RoleModel model)
        {
            int hang = role.ZSG("update RoleModel set RoleName=@RoleName,RoleMsg=@RoleMsg,RoleState=@RoleState,RoleCreateName=@RoleCreateName,RoleCreateDate=@RoleCreateDate where  RoleId=@RoleId", new
            {
                @RoleName = model.RoleName,
                @RoleMsg = model.RoleMsg,
                @RoleState = model.RoleState,
                @RoleCreateName = model.RoleCreateName,
                @RoleCreateDate = model.RoleCreateDate,
                @RoleId = model.RoleId
            });
            return hang;
        }
    }
}
