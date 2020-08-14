using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dao.Base.Impl
{
    /// <summary>
    /// 本地日志
    /// </summary>
    public class LocalLog : ILocalLog
    {
        private static log4net.ILog _log;
        private static log4net.ILog log
        {
            get
            {
                if (_log == null)
                {
                    var repository = LogManager.CreateRepository("Log");
                    string path = AppDomain.CurrentDomain.BaseDirectory + @"\log4net.config";
                    log4net.Config.XmlConfigurator.Configure(repository, new FileInfo(path));
                    _log = LogManager.GetLogger(repository.Name, "log"); //log 对应文件log4net.config <logger name="log">
                }
                return _log;
            }
        }

        static LocalLog()
        {

        }

        public void Info(object message, Exception exception = null)
        {
            if (exception==null)
                log.Info(message);
            else
                log.Info(message, exception);
        }


        public void Error(Exception exception, object message = null)
        {
            if (exception == null)
                log.Error(message);
            else
                log.Error(message, exception);
        }

    }
}
