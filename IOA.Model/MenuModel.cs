using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Model
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class MenuModel
    {
        private int _menuid;////菜单ID
        private string _menuname;//菜单名称(非空)
        private int _menuparentid;//上级菜单ID（非空）
        private string _menulink;//菜单链接地址（可空）
        private int _menustate;//状态（0停用 1启用 默认1）

        #region //角色ID MenuId
        /// <summary>
        /// //菜单ID
        /// </summary>
        public int MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }
        #endregion

        #region 菜单名称(非空) MenuName
        /// <summary>
        /// //菜单名称(非空)
        /// </summary>
        public string MenuName
        {
            get { return _menuname; }
            set { _menuname = value; }
        }
        #endregion

        #region 菜单名称(非空) MenuParentID
        /// <summary>
        /// 上级菜单ID（非空）
        /// </summary>
        public int MenuParentID
        {
            get { return _menuparentid; }
            set { _menuparentid = value; }
        }
        #endregion

        #region 菜单链接地址（可空） MenuLink
        /// <summary>
        /// //菜单链接地址（可空）
        /// </summary>
        public string MenuLink
        {
            get { return _menulink; }
            set { _menulink = value; }
        }
        #endregion

        #region 状态（0停用 1启用 默认1） MenuState
        /// <summary>
        /// //状态（0停用 1启用 默认1）
        /// </summary>
        public int MenuState
        {
            get { return _menustate; }
            set { _menustate = value; }
        }
        #endregion

    }
}
