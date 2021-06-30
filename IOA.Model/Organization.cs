using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Model
{
    /// <summary>
    /// 组织架构表
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// 组织架构
        /// </summary>
        public int OrganizationId { get; set; }
        /// <summary>
        /// 组织架构名称
        /// </summary>
        public string OrganizationName { get; set; }
        /// <summary>
        /// 组织架构上级Id
        /// </summary>
        public int OrganizationParentId { get; set; }
        /// <summary>
        /// 组织架构状态
        /// </summary>
        public int OrganizationStatus { get; set; }
        /// <summary>
        /// 每个部门人数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
