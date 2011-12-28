using System;
using System.Collections.Generic;
using System.Web;
using Quartz;
using Quartz.Impl;
using Common.Logging;
using System.Threading;

namespace Ex01
{
    public class SimpleExample
    {
        public void Run()
        {
            ILog log = LogManager.GetLogger(typeof(SimpleExample));

            log.Info("------- Initializing ----------------------");

            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sched = sf.GetScheduler();

            log.Info("------- Initialization Complete -----------");

            log.Info("------- Scheduling Jobs -------------------");

            DateTime runTime = TriggerUtils.GetEvenMinuteDate(DateTime.UtcNow);
            JobDetail job = new JobDetail("job1", "group1", typeof(HelloJob));

            SimpleTrigger trigger = new SimpleTrigger("trigger1", "group1", runTime);
            sched.ScheduleJob(job, trigger);

            sched.Start();

            log.Info("------- Started Scheduler -----------------");

            // wait long enough so that the scheduler as an opportunity to 
            // run the job!
            log.Info("------- Waiting 90 seconds... -------------");

            // wait 90 seconds to show jobs
            Thread.Sleep(90 * 1000);

            // shut down the scheduler
            log.Info("------- Shutting Down ---------------------");
            sched.Shutdown(true);
            log.Info("------- Shutdown Complete -----------------");
        }
    }
}