using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace Backup
{
    partial class BackupService : ServiceBase
    {
        Timer timer = new Timer(); // name space(using System.Timers;)  
        public BackupService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //WriteToFile();
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 25000; //number in milisecinds  
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            //WriteToFile();
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {

            WriteToFile();

        }

        public void WriteToFile()
        {

            //backup

        }
    }
}
