using Dao.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao
{
    public interface IUserDao : IDependency
    {
        string SayHi(string name);
    }
}
