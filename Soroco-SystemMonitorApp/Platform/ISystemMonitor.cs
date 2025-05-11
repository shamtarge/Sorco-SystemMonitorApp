using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soroco_SystemMonitorApp.Model;

namespace Soroco_SystemMonitorApp.Platform
{
    public interface ISystemMonitor
    {
        SystemStats GetStats();
    }
}
