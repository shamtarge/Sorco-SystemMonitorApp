using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soroco_SystemMonitorApp.Model;

namespace Soroco_SystemMonitorApp.Platform
{
    public abstract class BaseSystemMonitor : ISystemMonitor
    {
        public abstract SystemStats GetStats();

        protected double ConvertBytesToMB(long bytes) => bytes / (1024.0 * 1024.0);
    }
}
