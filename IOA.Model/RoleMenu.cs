using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Model
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    public class RoleMenu
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 角色菜单状态
        /// </summary>
        public int RoleMenuStatus { get; set; }
    }
}
