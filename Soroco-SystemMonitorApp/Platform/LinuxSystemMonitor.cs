using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soroco_SystemMonitorApp.Model;

namespace Soroco_SystemMonitorApp.Platform
{
    public class LinuxSystemMonitor : BaseSystemMonitor
    {
        public override SystemStats GetStats()
        {
            // ToDo : Implementataion
            return new SystemStats { Cpu = 0, DiskUsed = 0, RamUsed = 0};
        }
    }
}
