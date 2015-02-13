using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailApp.Model;

namespace CocktailApp.Repository
{
    public interface IRecipeRepository
    {
        int RecipeCount();
        void Add(Recipe recipe);
        void Delete(Recipe recipe);
        void Clear();
        Recipe GetByName();
        Recipe GetById();
        IEnumerable<Recipe> GetPossibleRecipes(IEnumerable<Ingredient> ingredientList);
        IEnumerable<Recipe> All();
    }
}
