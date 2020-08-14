using Dao;
using Dao.Base;
using Dao.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Impl
{
    public class UserBLL : IUserBLL
    {
        public readonly IUserDao _userDao;
        public readonly UserDao _userDao2;
        public readonly ILocalLog _log;
        public UserBLL(IUserDao userDao, UserDao userDao2, ILocalLog log) {
            _userDao = userDao;
            _userDao2= userDao2;
            _log = log;
    }

        public string SayHi(string name)
        {
            _log.Info("开始SayHi=====");
            return _userDao.SayHi(name);
        }

        public string SayHi2(string name)
        {
            return _userDao2.SayHi(name);
        }
    }
}
