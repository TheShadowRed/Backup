using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Timers;

namespace Backup
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        Timer timer = new Timer(); // name space(using System.Timers;)  
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
