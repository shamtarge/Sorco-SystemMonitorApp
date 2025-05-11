using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Soroco_SystemMonitorApp.Model;

namespace Soroco_SystemMonitorApp.Plugin
{
    
    public class FileLoggerPlugin : IMonitorPlugin
    {

        private readonly string _fileName;
        public FileLoggerPlugin(string file) 
        {
            _fileName = file;
        }
        public async Task HandleStatsAsync(SystemStats stats)
        {
            var line = $"{DateTime.Now}: CPU={stats.Cpu:F2}%, RAM={stats.RamUsed:F2}MB, Disk-Space={stats.DiskUsed:F2}MB";
            await File.AppendAllTextAsync(_fileName, line + Environment.NewLine);
        }
    }
}
