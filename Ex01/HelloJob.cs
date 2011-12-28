using System;
using System.Collections.Generic;
using System.Web;
using Quartz;
using Common.Logging;

namespace Ex01
{
    public class HelloJob : IJob
    {
        private static ILog _log = LogManager.GetLogger(typeof(HelloJob));

        public void Execute(JobExecutionContext context)
        {
            // Say Hello to the World and display the date/time
            _log.Info(string.Format("Hello World! - {0}", System.DateTime.Now.ToString("r")));

            //HttpContext.Current.Response.Write(string.Format("Hello World! - {0}", System.DateTime.Now.ToString("r")));
        }
    }
}