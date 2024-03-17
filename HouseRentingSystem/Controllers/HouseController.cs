using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HouseRentingSystem.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(IHouseService _houseService,
            IAgentService _agentService)
        {
            houseService = _houseService;
            agentService = _agentService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllHousesQueryModel model
            )
        {
            var houses = await houseService.AllAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.HousesPerPage);

            model.TotalHousesCount = houses.TotalHousesCount;
            model.Houses = houses.Houses;
                       
            model.Categories = await houseService.AllCategoriesNamesAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<HouseServiceModel> model;

            if (await agentService.ExistsByIdAsync(userId))
            {
                int agentId = await agentService.GetAgentIdAsync(userId) ?? 0;
                model = await houseService.AllHousesByAgentIdAsync(agentId);
            }
            else
            {
                model = await houseService.AllHousesByUserIdAsync(userId);
            }       
                     
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }


            var model = await houseService.HouseDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [MustBeAgent]
        public async Task<IActionResult> Add()
        {
            
            var model = new HouseFormModel()
            {
                Categories = await houseService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if(await houseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houseService.AllCategoriesAsync();
                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newHouseId = await houseService.CreateAsync(model, agentId ?? 0);
            
            return RedirectToAction(nameof(Details), new { id =  newHouseId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }
            string userId = User.Id();

            if(!await houseService.HasAgentWithIdAsync(id, userId))
            {
                return Unauthorized();
            }

            var model = await houseService.GetHouseFormByIdAsync(id);
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormModel model)
        {
            if (!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }
            string userId = User.Id();

            if (!await houseService.HasAgentWithIdAsync(id, userId))
            {
                return Unauthorized();
            }

            if (await houseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houseService.AllCategoriesAsync();
                return View(model);
            }

            await houseService.EditAsync(id, model);
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }

            string userId = User.Id();

            if(!await houseService.HasAgentWithIdAsync(id, userId))
            {
                return Unauthorized();
            }

            var house = await houseService.HouseDetailsByIdAsync(id);

            var model = new HouseDetailsViewModel()
            {
                Title = house.Title,
                Address = house.Address,
                ImageUrl = house.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HouseDetailsViewModel model)
        {
            if (!await houseService.ExistsAsync(model.Id))
            {
                return BadRequest();
            }

            string userId = User.Id();

            if (!await houseService.HasAgentWithIdAsync(model.Id, userId))
            {
                return Unauthorized();
            }

            await houseService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if(!await houseService.ExistsAsync(id))
            {
                return BadRequest();
            }

            string userId = User.Id();

            if(await agentService.ExistsByIdAsync(userId))
            {
                return Unauthorized();
            }

            if(await houseService.IsRentedAsync(id))
            {
                return BadRequest();
            }

            if(await houseService.HasAgentWithIdAsync(id, userId))
            {
                return BadRequest();
            }
            

            await houseService.Rent(id, userId);

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if(!await houseService.ExistsAsync(id) || !await houseService.IsRentedAsync(id))
            {
                return BadRequest();
            }

            if(!await houseService.IsRentedByUserWithIdAsync(id, User.Id()))
            {
                return Unauthorized();
            }

            await houseService.Leave(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
