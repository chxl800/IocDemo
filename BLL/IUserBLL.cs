using Dao.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IUserBLL : IDependency
    {
        string SayHi(string name);
    }
}
