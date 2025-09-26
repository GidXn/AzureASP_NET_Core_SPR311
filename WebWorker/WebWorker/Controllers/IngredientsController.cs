using Microsoft.AspNetCore.Mvc;
using WebWorker.Interfaces;
using WebWorker.Models.Ingredient;

namespace WebWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController(IIngredientService ingredientService)
        : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] IngredientCreateModel model)
        {
            var ingredientId = await ingredientService.CreateAsync(model);
            return Ok(new { ingredientId });
        }
    }
}


