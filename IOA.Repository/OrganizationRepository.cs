using IOA.IRepository;
using IOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Repository
{
    /// <summary>
    /// 组织架构类  调用公共类并调用组织架构接口
    /// </summary>
    public class OrganizationRepository:BaseRepositroy<Organization>, IOrganizationRepository
    {

    }
}
