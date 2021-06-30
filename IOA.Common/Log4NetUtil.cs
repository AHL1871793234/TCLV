using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Common
{
    public class Log4NetUtil
    {
        //日志仓储(单例模式，静态变量，程序在第一次使用的时候被调用，由clr保证)
        private static ILoggerRepository loggerRepository;
        private static ILog logger;

        /// <summary>
        /// log4net 初始化
        /// </summary>
        public static void InitLog4Net()
        {
            loggerRepository = loggerRepository ?? LogManager.CreateRepository("myLog4net");
            Assembly assembly = Assembly.GetExecutingAssembly();
            //命名空间.文件夹名.文件名
            var xml = assembly.GetManifestResourceStream("Log4Net.log4net.xml");
            log4net.Config.XmlConfigurator.Configure(loggerRepository, xml);

            logger = LogManager.GetLogger(loggerRepository.Name, "all");

        }

        #region 将调试的信息输出，可以定位到具体的位置（解决高层封装带来的问题）
        /// <summary>
        /// 将调试的信息输出，可以定位到具体的位置（解决高层封装带来的问题）
        /// </summary>
        /// <returns></returns>
        private static string getDebugInfo()
        {
            StackTrace trace = new StackTrace(true);
            return trace.ToString();
        }
        #endregion
        public static void Debug(object message)
        {
            logger.Debug(ExeFormat(message));
        }
        public static void Error(object message)
        {
            logger.Error(ExeFormat(getDebugInfo() + message));
        }
        public static void Info(object message)
        {
            logger.Info(ExeFormat(message));
        }
        public static void Warn(object message)
        {
            logger.Warn(ExeFormat(getDebugInfo() + message));
        }

        /// <summary>
        /// 格式化日志信息
        /// </summary>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public static string ExeFormat(object logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append(DateTime.Now.ToString() + " 执行结果: " + logMessage.ToString() + " \r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }
    }
}
