using IOA.IRepository;
using IOA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IOA.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        public readonly IHomeRepositroy _ihomeRepositroy;

        public HomeApiController(IHomeRepositroy ihomeRepositroy)
        {
            _ihomeRepositroy = ihomeRepositroy;
        }

        #region   递归拼接
        [HttpGet]
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
            return Ok(leftData.ToString());
        }
        [HttpGet]
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
        [HttpGet]
        public IActionResult Index(int parentID)
        {
            //int? userId = HttpContext.Session.GetInt32("UserId");

            int? userId = 1;

            //获取全部菜单
            List <MenuModel> leftNext = _ihomeRepositroy.Show("select * from MenuModel");
            //获取左侧菜单栏
            List<MenuModel> left = _ihomeRepositroy.leftData(userId, parentID);
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
            //string UserName = HttpContext.Session.GetString("UserName");

            return Ok(leftData.ToString());
        }
        #endregion
    }
}
