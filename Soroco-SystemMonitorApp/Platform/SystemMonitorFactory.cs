using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Soroco_SystemMonitorApp.Platform
{
    public static class SystemMonitorFactory
    {
        public static ISystemMonitor CreateSystemMonitor()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return new WindowsSystemMonitor();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return new LinuxSystemMonitor();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return new MacSystemMonitor();
            else
                throw new PlatformNotSupportedException("Unsupported OS");
        }
    }
}
