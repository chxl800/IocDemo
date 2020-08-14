using System;
using System.Collections.Generic;
using System.Text;

namespace Dao.Base
{
    /// <summary>
    /// 本地日志
    /// </summary>
    public interface ILocalLog : IDependency
    {
        void Info(object message, Exception exception = null);

        void Error(Exception exception, object message = null);

    }
}
