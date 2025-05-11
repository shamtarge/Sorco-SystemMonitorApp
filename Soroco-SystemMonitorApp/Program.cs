// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Soroco_SystemMonitorApp.Platform;
using Soroco_SystemMonitorApp.Plugin;


class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true).Build();

        int interval = config.GetValue<int>("MonitoringInterval",5000);
        string file = config.GetValue<string>("LogFilePath", "log_file.txt");
        string apiEndPoint = config.GetValue<string>("ApiEndPoint","");

        var monitor = SystemMonitorFactory.CreateSystemMonitor();
        var plugins  = new List<IMonitorPlugin> { new FileLoggerPlugin(file) };

        if (!string.IsNullOrEmpty(apiEndPoint))
        {
            plugins.Add(new ApiPostPlugin(apiEndPoint));
        }

        while (true)
        {
            var stats = monitor.GetStats();
            Console.WriteLine($"CPU = {stats.Cpu:F2}%, RAM = {stats.RamUsed:F2}MB, Disk-Space = {stats.DiskUsed:F2}MB");

            foreach(var plugin in plugins)
            {
                await plugin.HandleStatsAsync(stats);
            }

            Thread.Sleep(interval);
        }
    }
}


