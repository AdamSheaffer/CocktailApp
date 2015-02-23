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
    public class RecipeIngredientRepository
    {
        private RecipeContext _dbContext;
        private IngredientRepository IngRepo = new IngredientRepository();
        //private RecipeRepository RecRepo = new RecipeRepository();

        public RecipeIngredientRepository()
        {
            _dbContext = new RecipeContext();
            _dbContext.RecipeIngredients.Load();
        }

        public int RecipeIngredientCount()
        {
            return _dbContext.RecipeIngredients.Count();
        }

        public void Add(Model.RecipeIngredient recipeIngredient)
        {
            //check that it's not already in DB
            var query = from RecipeIngredient in _dbContext.RecipeIngredients                          where recipeIngredient.Recipe_Id == RecipeIngredient.Recipe_Id
                        && recipeIngredient.Ingredient_Id == RecipeIngredient.Ingredient_Id
                        select RecipeIngredient;
            if (query.ToList<RecipeIngredient>().Count == 0)
            {
                _dbContext.RecipeIngredients.Add(recipeIngredient);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<RecipeIngredient> All()
        {
            var query = from RecipeIngredient in _dbContext.RecipeIngredients
                        select RecipeIngredient;
            return query.ToList<RecipeIngredient>();
        }
    }
}
