using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebWorker.Data;
using WebWorker.Data.Entities;
using WebWorker.Interfaces;
using WebWorker.Models.Ingredient;

namespace WebWorker.Services;

public class IngredientService(IMapper mapper,
    AppWorkerDbContext context,
    IImageService imageService) : IIngredientService
{
    public async Task<long> CreateAsync(IngredientCreateModel model)
    {
        var entity = mapper.Map<IngredientEntity>(model);
        if (model.Image != null)
        {
            entity.Image = await imageService.SaveAsync(model.Image);
        }
        context.Ingredients.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<IngredientItemModel>> GetListAsync()
    {
        var query = context.Ingredients
            .AsNoTracking()
            .Select(x => new IngredientItemModel
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image
            });

        return await query.ToListAsync();
    }
}


