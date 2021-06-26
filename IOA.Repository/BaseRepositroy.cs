﻿using System;
using System.Collections.Generic;
using IOA.Common;
using IOA.IRepository;

namespace IOA.Repository
{
    public class BaseRepositroy<T> : IBaseRepositroy<T> where T : class, new()
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public List<T> Show(string sql, object param = null)
        {
            List<T> data = DapperHelper<T>.Query(sql, param);
            return data;
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public int ZSG(string sql, object param = null)
        {
            int i = DapperHelper<T>.Execute(sql, param);
            return i;
        }
    }
}
