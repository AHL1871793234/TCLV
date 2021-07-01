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
    /// <summary>
    /// 组织架构控制器
    /// </summary>
    public class OrganizationController : Controller
    {
        IOrganizationRepository organization;

        public OrganizationController(IOrganizationRepository _organization)
        {
            organization = _organization;
        }

        //显示组织架构信息视图
        public IActionResult Index(int oid = -1)
        {
            HttpContext.Session.SetInt32("ID", oid);
            return View();
        }


        //显示组织架构信息
        public IActionResult OrganizationIndex(int oid = -1,int page = 1, int limit = 5)
        {

            List<Organization> organizations = organization.Show("Select OrganizationId,OrganizationName,count(*) as TotalCount from Organization where OrganizationParentId!=0 group by OrganizationId,OrganizationName", "");

            if (HttpContext.Session.GetInt32("ID") != -1)
            {
                organizations = organizations.Where(x => x.OrganizationId == HttpContext.Session.GetInt32("ID")).ToList();
            }
            else if (oid != -1)
            {
                organizations = organizations.Where(x => x.OrganizationId ==oid).ToList();
            }
            else 
            {
                organizations = organizations.ToList();
            }

            var pageData = organizations.Skip(limit * (page - 1)).Take(limit).ToList();

            return Ok(new { code = 0, msg = "", count = organizations.Count, data = pageData });
        }




    }
}
