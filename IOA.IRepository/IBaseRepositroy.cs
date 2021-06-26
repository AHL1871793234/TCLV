using System;
using System.Collections.Generic;

namespace IOA.IRepository
{
    public interface IBaseRepositroy<T> where T:class,new()
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        List<T> Show(string sql,object param=null);
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        int ZSG(string sql, object param = null);
    }
}
