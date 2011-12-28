using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Quartz;
using Quartz.Impl;

namespace Ex01
{
    public class Global : System.Web.HttpApplication
    {
        IScheduler sched;
        protected void Application_Start(object sender, EventArgs e)
        {
            ISchedulerFactory sf = new StdSchedulerFactory();


            DateTime runTime = TriggerUtils.GetEvenMinuteDate(DateTime.UtcNow);
            JobDetail job = new JobDetail("job1", "group1", typeof(HelloJob));
            sched = sf.GetScheduler();
            SimpleTrigger trigger = new SimpleTrigger("trigger1", "group1", runTime);
            sched.ScheduleJob(job, trigger);
 
            sched.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (sched != null)
            {
                sched.Shutdown();
            }
        }
    }
}