namespace WebWorker.Models.Ingredient;

public class IngredientCreateModel
{
    public string Name { get; set; } = string.Empty;
    public IFormFile? Image { get; set; } = null;
}


