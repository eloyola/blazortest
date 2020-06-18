using Beam.Shared.Configuration;
using Beam.Shared.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.Client.Data
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private EndpointCfg _endpointCfg;
        public EmployeeService(HttpClient httpClient, IConfiguration Configuration)
        {
            _endpointCfg = Configuration.GetSection(EndpointCfg.Section).Get<EndpointCfg>();
            _httpClient = httpClient;
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            List<Employee> result;
            var json = await _httpClient.GetStringAsync($"{_endpointCfg.Employee}");
            result = JsonConvert.DeserializeObject<List<Employee>>(json);
            return result;
        }
    }
}
