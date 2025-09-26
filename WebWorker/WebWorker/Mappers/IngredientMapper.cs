using AutoMapper;
using WebWorker.Data.Entities;
using WebWorker.Models.Seeder;
using WebWorker.Models.Ingredient;

namespace WebWorker.Mappers;

public class IngredientMapper : Profile
{
    public IngredientMapper()
    {
        CreateMap<SeederIngredientModel, IngredientEntity>();
        CreateMap<IngredientCreateModel, IngredientEntity>();
    }
}
