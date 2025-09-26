using WebWorker.Models.Ingredient;

namespace WebWorker.Interfaces;

public interface IIngredientService
{
    Task<long> CreateAsync(IngredientCreateModel model);
}


