using System.Diagnostics;
using Soroco_SystemMonitorApp.Model;

namespace Soroco_SystemMonitorApp.Platform
{
    public class WindowsSystemMonitor : BaseSystemMonitor
    {
        public override SystemStats GetStats()
        {
            var cpu = GetCpuUsageViaWmic();
            var ramUsed = ConvertBytesToMB(GC.GetTotalMemory(false));
            var diskUsed = DriveInfo.GetDrives().Where(d => d.IsReady)
                              .Sum(d => d.TotalSize - d.TotalFreeSpace) / (1024.0 * 1024.0);

            return new SystemStats { Cpu = cpu, RamUsed = ramUsed, DiskUsed = diskUsed };
        }

        // To check CPU usage specific to process
        private static double GetCpuUsage()
        {
            var startTime = DateTime.UtcNow;
            var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;
            Thread.Sleep(500);
            var endTime = DateTime.UtcNow;
            var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;

            var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
            var totalMsPassed = (endTime - startTime).TotalMilliseconds;
            var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);

            return Math.Round(cpuUsageTotal * 100, 2);
        }

        private static double GetCpuUsageViaWmic()
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "wmic",
                    Arguments = "cpu get loadpercentage",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                var lines = output.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                var valueLine = lines.FirstOrDefault(l => l.Trim().All(char.IsDigit));
                return double.TryParse(valueLine, out double cpuLoad) ? cpuLoad : 0;
            }
            catch
            {
                return 0;
            }
        }


    }
}