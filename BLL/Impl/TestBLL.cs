using Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Impl
{
    /// <summary>
    /// 测试类，不继承IDependency 
    /// </summary>
    public class TestBLL
    {
        public readonly IUserDao _userDao;

        public TestBLL(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public string SayHi(string name)
        {
            return _userDao.SayHi(name);
        }
     
    }
}
