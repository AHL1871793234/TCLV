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
    /// 菜单控制器【功能控制器】
    /// </summary>
    public class MenuController : Controller
    {
        IMenuRepository menu;

        public MenuController(IMenuRepository _menu)
        {
            menu = _menu;
        }
        //菜单视图
        public IActionResult Index()
        {
            return View();
        }
        //拼接树形父级
        public IActionResult Trees()
        {
            List<MenuModel> data = menu.Show("select * from MenuModel", "");
            List<MenuModel> treeFather = data.Where(x => x.MenuParentID == 0).ToList();
            List<Dictionary<string, object>> treeJson = new List<Dictionary<string, object>>();
            foreach (var item in treeFather)
            {
                Dictionary<string, object> json = new Dictionary<string, object>();
                json.Add("id", item.MenuId);
                json.Add("title", item.MenuName);
                json.Add("spread", true);
                Tree_Next(data, json, item.MenuId);//调用递归完成子集拼接
                treeJson.Add(json);
            }
            return Ok(treeJson);
        }
        //递归拼接树形子集
        public void Tree_Next(List<MenuModel> data,Dictionary<string,object> json,int parentId)
        {
            List<MenuModel> treeFather = data.Where(x => x.MenuParentID == parentId).ToList();
            List<Dictionary<string, object>> treeJson = new List<Dictionary<string, object>>();
            if (treeFather.Count==0)
            {
                json.Add("children", null);
                return;
            }
            foreach (var item in treeFather)
            {
                Dictionary<string, object> json1 = new Dictionary<string, object>();
                json1.Add("id", item.MenuId);
                json1.Add("title", item.MenuName);
                json1.Add("spread", true);
                Tree_Next(data, json1, item.MenuId);//调用递归完成子集拼接
                treeJson.Add(json1);
            }
            json.Add("children", treeJson);
        }

    }
}
