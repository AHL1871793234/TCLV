﻿using IOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.IRepository
{
  public   interface ILoginRepository: IBaseRepositroy<UserModel>
    {
        //数据库查登录名称 和密码
        UserModel LookingFor(string userName, string userPwd);

    }
}
