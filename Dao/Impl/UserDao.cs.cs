using System;
using System.Collections.Generic;
using System.Text;

namespace Dao.Impl
{
    public class UserDao : IUserDao
    {
        public string SayHi(string name)
        {
            return "早上," + name;
        }
    }
}
