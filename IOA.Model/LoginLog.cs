using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Model
{
    /// <summary>
    /// 登录日志表
    /// </summary>
    public class LoginLog
    {
        /// <summary>
        /// Id
        /// </summary>
        public int LoginId { get; set; }
        /// <summary>
        /// 日志编号
        /// </summary>
        public string LoginNo { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginDate { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 登录类型
        /// </summary>
        public string LoginStatus { get; set; }
        /// <summary>
        /// 终端类型
        /// </summary>
        public string LoginTerminal { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP { get; set; }
        /// <summary>
        /// MAC地址
        /// </summary>
        public string LoginMAC { get; set; }


    }
}
