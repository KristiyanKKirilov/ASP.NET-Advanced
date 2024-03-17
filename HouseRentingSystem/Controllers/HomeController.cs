using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> logger;
		private readonly IHouseService houseService;

		public HomeController(
			ILogger<HomeController> _logger,
			IHouseService _houseService)
		{
			logger = _logger;
			houseService = _houseService;

		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var model = await houseService.LastThreeHousesAsync();

			return View(model);
		}

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<IActionResult> Error(int statusCode)
		{
			if(statusCode == 400)
			{
				return View("Error400");	
			}

			if(statusCode == 401)
			{
				return View("Error401");
			}
			return View();
		}
	}
}