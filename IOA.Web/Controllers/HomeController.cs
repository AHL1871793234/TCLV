using IOA.Common;
using IOA.IRepository;
using IOA.Model;
using IOA.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Web.Controllers
{
    /// <summary>
    /// 主页控制器  【框架】
    /// </summary>
    public class HomeController : Controller
    {
        public readonly IHomeRepositroy _ihomeRepositroy;

        public HomeController(IHomeRepositroy ihomeRepositroy)
        {
            _ihomeRepositroy = ihomeRepositroy;
        }

        #region   递归拼接
        public IActionResult Index1(int parentID)
        {
            //获取左侧菜单栏
            List<MenuModel> left = _ihomeRepositroy.leftData(parentID);
            StringBuilder leftData = new StringBuilder();
            foreach (var item in left)
            {
                leftData.Append("<li data-name = 'home' class='layui-nav-item layui-nav-itemed'>");
                leftData.Append($"<a href = 'javascript:;'  lay-direction = '2' >");
                leftData.Append($"<cite>{item.MenuName}</cite></a>");
                LeftNext(leftData, item.MenuId);
                leftData.Append("</li>");
            }
            ViewBag.LeftMenu = leftData.ToString();
            return View();
        }
        public void LeftNext(StringBuilder leftData, int parentID)
        {
            List<MenuModel> left = _ihomeRepositroy.leftData(parentID);
            StringBuilder Data = new StringBuilder();
            foreach (var item in left)
            {
                StringBuilder NextData = new StringBuilder();
                NextData.Append("<dl class='layui-nav-child'>");
                if (item.MenuLink == null || item.MenuLink == "")
                {
                    item.MenuLink = "javascript:;";
                }
                NextData.Append($"<dd><a lay-href='{item.MenuLink}'>{item.MenuName}</a>");
                LeftNext(NextData, item.MenuId);
                NextData.Append("</dd></dl>");
                Data.Append(NextData);

            }
            leftData.Append(Data);
        }
        #endregion


        #region foreach拼接
        public IActionResult Index(int parentID)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            //获取全部菜单
            List<MenuModel> leftNext = _ihomeRepositroy.Show("select * from MenuModel");
            //获取左侧菜单栏
            List<MenuModel> left = _ihomeRepositroy.leftData(userId,parentID);
            //定义字符串拼接
            StringBuilder leftData = new StringBuilder();
            foreach (var item in left)//一级
            {
                leftData.Append("<li data-name = 'home' class='layui-nav-item layui-nav-itemed'>");
                leftData.Append($"<a href = 'javascript:;'  lay-direction = '2' >");
                leftData.Append($"<cite>{item.MenuName}</cite></a>");
                foreach (var itemNext in leftNext)//二级
                {
                    if (itemNext.MenuParentID.Equals(item.MenuId))
                    {
                        leftData.Append("<dl class='layui-nav-child'>");
                        leftData.Append("<dd class='layui-nav-itemed'>");
                        leftData.Append($"<a href ='javascript:;'>{itemNext.MenuName}</a>");
                        foreach (var itemNext2 in leftNext)//三级
                        {
                            if (itemNext2.MenuParentID.Equals(itemNext.MenuId))
                            {
                                leftData.Append("<dl class='layui-nav-child'>");
                                if (itemNext2.MenuLink == null || itemNext2.MenuLink == "")
                                {
                                    itemNext2.MenuLink = "javascript:;";
                                }
                                leftData.Append($"<dd><a lay-href='{itemNext2.MenuLink}'>{itemNext2.MenuName}</a>");
                                foreach (var itemNext3 in leftNext)//四级
                                {
                                    if (itemNext3.MenuParentID.Equals(itemNext2.MenuId))
                                    {
                                        leftData.Append("<dl class='layui-nav-child'>");
                                        if (itemNext3.MenuLink == null || itemNext3.MenuLink == "")
                                        {
                                            itemNext3.MenuLink = "javascript:;";
                                        }
                                        leftData.Append($"<dd><a lay-href='{itemNext3.MenuLink}'>{itemNext3.MenuName}</a>");
                                        leftData.Append("</dd></dl>");

                                    }
                                }
                                leftData.Append("</dd></dl>");
                            }
                        }
                        leftData.Append("</dd></dl>");
                    }
                }
                leftData.Append("</li>");
            }
            ViewBag.LeftMenu = leftData.ToString();
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
        #endregion


        public IActionResult Show()
        {
            return View();
        }


    }
}
