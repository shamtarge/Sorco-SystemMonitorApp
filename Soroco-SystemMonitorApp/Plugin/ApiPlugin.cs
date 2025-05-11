using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Soroco_SystemMonitorApp.Model;

namespace Soroco_SystemMonitorApp.Plugin
{
    public class ApiPostPlugin : IMonitorPlugin
    {
        private readonly string _endpoint;
        private readonly HttpClient _httpClient;

        public ApiPostPlugin(string endpoint)
        {
            _endpoint = endpoint;
            _httpClient = new HttpClient();
        }

        public async Task HandleStatsAsync(SystemStats stats)
        {
            var payload = new
            {
                cpu = stats.Cpu,
                ram_used = stats.RamUsed,
                disk_used = stats.DiskUsed
            };

            string json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_endpoint, content);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[ERROR] Failed to post to API: {ex.Message}");
            }
        }
    }
}
