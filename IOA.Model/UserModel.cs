using System;

namespace IOA.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserModel
    {
        private int _userid;  //用户工号
        private string _username;  //用户真实姓名（非空）
        private string _userpwd;//用户登录密码（非空）
        private string _usersex;//用户真实姓名（非空）
        private string _usercard;//用户身份证（非空）
        private string _userphone;//用户手机号（非空）
        private string _usernational;//用户民族（可以为空）
        private string _useremail;//用户邮箱（非空）
        private string _usermajor;//用户专业（可以为空）
        private DateTime _userjoinindate;//用户入职日期（默认当前时间）
        private DateTime _userdimissiondate;//用户离职日期（默认为空）
        private string _userdimissioncause;//用户离职原因(默认为空)
        private int _userdeletemark;//删除标记(1未删 0已除 默认为1)
        private int _userisadmin;//是否系统管理员（默认为0）
        private string _usercreatename;//添加人（默认当前用户）
        private DateTime _usercreatedate=DateTime.Now;//添加日期 （当前时间）

        #region 用户工号 UserId
        /// <summary>
        /// 用户工号
        /// </summary>
        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        #endregion

        #region  用户真实姓名（非空） UserName

        /// <summary>
        /// 用户真实姓名（非空） UserName
        /// </summary>
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        #endregion

        #region  用户登录密码（非空） UserPwd
        /// <summary>
        /// //用户登录密码（非空）
        /// </summary>
        public string UserPwd
        {
            get { return _userpwd; }
            set { _userpwd = value; }
        }
        #endregion

        #region  用户真实姓名（非空） UserSex
        /// <summary>
        /// //用户性别（非空）
        /// </summary>
        public string UserSex
        {
            get { return _usersex; }
            set { _usersex = value; }
        }
        #endregion

        #region  用户身份证（非空） UserCard
        /// <summary>
        /// //用户身份证（非空）
        /// </summary>
        public string UserCard
        {
            get { return _usercard; }
            set { _usercard = value; }
        }
        #endregion

        #region  用户手机号（非空） UserPhone
        /// <summary>
        /// //用户手机号（非空）
        /// </summary>
        public string UserPhone
        {
            get { return _userphone; }
            set { _userphone = value; }
        }

        #endregion

        #region  用户民族（可以为空） UserNational
        /// <summary>
        /// //用户民族（可以为空）
        /// </summary>
        public string UserNational
        {
            get { return _usernational; }
            set { _usernational = value; }
        }

        #endregion

        #region  用户邮箱（非空） UserEmail
        /// <summary>
        /// //用户邮箱（非空）
        /// </summary>
        public string UserEmail
        {
            get { return _useremail; }
            set { _useremail = value; }
        }

        #endregion

        #region  用户专业（可以为空） UserMajor
        /// <summary>
        /// //用户专业（可以为空）
        /// </summary>
        public string UserMajor
        {
            get { return _usermajor; }
            set { _usermajor = value; }
        }

        #endregion

        #region  用户入职日期（默认当前时间） UserJoinInDate
        /// <summary>
        /// //用户入职日期（默认当前时间）
        /// </summary>
        public DateTime UserJoinInDate
        {
            get { return _userjoinindate; }
            set { _userjoinindate = value; }
        }

        #endregion

        #region  用户离职日期（默认为空） UserDimissionDate
        /// <summary>
        /// //用户离职日期（默认为空）
        /// </summary>
        public DateTime UserDimissionDate
        {
            get { return _userdimissiondate; }
            set { _userdimissiondate = value; }
        }

        #endregion

        #region  用户离职原因(默认为空) UserDimissionCause
        /// <summary>
        /// //用户离职原因(默认为空)
        /// </summary>
        public string UserDimissionCause
        {
            get { return _userdimissioncause; }
            set { _userdimissioncause = value; }
        }

        #endregion

        #region  删除标记(1未删 0已除 默认为1) UserDeleteMark
        /// <summary>
        /// //删除标记(1未删 0已除 默认为1)
        /// </summary>
        public int UserDeleteMark
        {
            get { return _userdeletemark; }
            set { _userdeletemark = value; }
        }

        #endregion

        #region  是否系统管理员（默认为0） UserIsAdmin
        /// <summary>
        /// //是否系统管理员（默认为0）
        /// </summary>
        public int UserIsAdmin
        {
            get { return _userisadmin; }
            set { _userisadmin = value; }
        }

        #endregion

        #region  添加人（默认当前用户） UserCreateName
        /// <summary>
        /// //添加人（默认当前用户）
        /// </summary>
        public string UserCreateName
        {
            get { return _usercreatename; }
            set { _usercreatename = value; }
        }

        #endregion

        #region  添加日期 （当前时间） UserCreateDate
        /// <summary>
        /// //添加日期 （当前时间）
        /// </summary>
        public DateTime UserCreateDate
        {
            get { return _usercreatedate; }
            set { _usercreatedate = value; }
        }
        #endregion

    }
}
