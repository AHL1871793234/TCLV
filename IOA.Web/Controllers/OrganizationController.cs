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
        public IActionResult Index()
        {
            return View();
        }


        //显示组织架构信息
        public IActionResult OrganizationIndex(int page = 1, int limit = 5)
        {

            List<Organization> organizations = organization.Show("Select OrganizationId,OrganizationName,count(*) as TotalCount from Organization where OrganizationParentId!=0 group by OrganizationId,OrganizationName", "");

            var pageData = organizations.Skip(limit * (page - 1)).Take(limit).ToList();

            return Ok(new { code = 0, msg = "", count = organizations.Count, data = pageData });
        }




    }
}
