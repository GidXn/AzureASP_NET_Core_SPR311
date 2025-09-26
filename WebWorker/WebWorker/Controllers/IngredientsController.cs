using Microsoft.AspNetCore.Mvc;
using WebWorker.Interfaces;
using WebWorker.Models.Ingredient;
using WebWorker.Models.Seeder;

namespace WebWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController(IIngredientService ingredientService)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await ingredientService.GetListAsync();
            return Ok(items);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] IngredientCreateModel model)
        {
            var ingredientId = await ingredientService.CreateAsync(model);
            return Ok(new { ingredientId });
        }
    }
}


