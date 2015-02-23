using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using CocktailApp.Model;

namespace CocktailApp.Repository
{
    public class PossibleDrinksRepository
    {
        private RecipeContext _dbContext;
        private MyBarRepository MyBarRepo = new MyBarRepository();

        public PossibleDrinksRepository()
        {
            _dbContext = new RecipeContext();
            _dbContext.RecipeIngredients.Load();
        }

        private IEnumerable<int> GetAllRecipeIds()
        {
            var query = from Recipe in _dbContext.Recipes
                        select Recipe.RecipeId;
            return query.ToList<int>();
        }

        public IEnumerable<RecipeIngredient> All()
        {
            var query = from RecipeIngredient in _dbContext.RecipeIngredients
                        select RecipeIngredient;
            return query.ToList<RecipeIngredient>();
        }

        public IEnumerable<int> FindIngredientIds(int recipeId)
        {
            var query = from RecipeIngredient in _dbContext.RecipeIngredients
                        where recipeId == RecipeIngredient.Recipe_Id
                        select RecipeIngredient.Ingredient_Id;
            return query.ToList<int>();
        }

        public bool HasAllIngredients(int recipeId, IEnumerable<int> myIngredientIds) 
        {
            IEnumerable<int> necessaryIngredientsId = FindIngredientIds(recipeId);
            return !necessaryIngredientsId.Except(myIngredientIds).Any();
        }

        public List<int> FindPossibleDrinkIds() 
        {
            IEnumerable<int> allRecipeIds = GetAllRecipeIds();
            IEnumerable<int> myIngredients = MyBarRepo.AllIds();
            List<int> possibleDrinkIds = new List<int>();
            foreach (int id in allRecipeIds)
            {
                if (HasAllIngredients(id, myIngredients))
                {
                    possibleDrinkIds.Add(id);
                }
            }
            return possibleDrinkIds;
        }

    }
}
