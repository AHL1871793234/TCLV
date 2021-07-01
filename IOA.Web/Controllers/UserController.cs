﻿using IOA.IRepository;
using IOA.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOA.Web.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : Controller
    {
        IUserRepository user;

        public UserController(IUserRepository _user)
        {
            user = _user;
        }

        #region  显示员工/用户信息
        //显示用户/员工视图
        public IActionResult Index()
        {
            return View();
        }
        //显示用户/员工方法
        public IActionResult UserIndex(string userName = "", int page = 1, int limit = 5)
        {
            List<UserModel> data = user.Show("select * from UserModel", "");

            if (!string.IsNullOrEmpty(userName))
            {
                data = data.Where(x => x.UserName.Contains(userName)).ToList();
            }
            else
            {
                data = data.ToList();
            }

            var pageData = data.Skip(limit * (page - 1)).Take(limit).ToList();

            return Ok(new { code = 0, msg = "", count = data.Count, data = pageData });
        }
        #endregion

        //添加用户视图
        public IActionResult CreateUser()
        {
            return View();
        }
        //添加用户方法
        public int AddUser(UserModel model)
        {
            int hang = user.ZSG("Insert into UserModel values(@UserName,@UserPwd,@UserSex,@UserCard,@UserPhone,@UserNational,@UserEmail,@UserMajor,@UserJoinInDate,@UserDimissionDate,@UserDimissionCause,@UserDeleteMark,@UserIsAdmin,@UserCreateName,@UserCreateDate)", new
            {
                @UserName = model.UserName,
                @UserPwd = model.UserPwd,
                @UserSex = model.UserSex,
                @UserCard = model.UserCard,
                @UserPhone = model.UserPhone,
                @UserNational = model.UserNational,
                @UserEmail = model.UserEmail,
                @UserMajor = model.UserMajor,
                @UserJoinInDate = model.UserJoinInDate,
                @UserDimissionDate = "",
                @UserDimissionCause = "",
                @UserDeleteMark = 1,
                @UserIsAdmin = 1,
                @UserCreateName = model.UserCreateName,
                @UserCreateDate = model.UserCreateDate
            });
            if (hang>0)
            {
                return 1;
            }
            return 0;
        }
        //删除用户


    }
}
