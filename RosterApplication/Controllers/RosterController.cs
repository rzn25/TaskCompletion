using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RosterApplication.Models;

namespace RosterApplication.Controllers
{
    public class RosterController : Controller
    {
        private readonly ILogger<RosterController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RosterController(ILogger<RosterController> logger, HttpClient httpClient, IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetPartial()
        {
            var response = await _httpClient.GetAsync($"{_configuration["TaskSample"]}/users/avengers");

            var data = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(data);

            Console.WriteLine(users);

            return PartialView("_RosterList", users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
