using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace CocktailApp.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private RecipeContext _dbContext;
        private IngredientContext _ingdbContext;

        public RecipeRepository() 
        {
            _dbContext = new RecipeContext();
            _dbContext.Recipes.Load();
            _ingdbContext = new IngredientContext();
            _ingdbContext.Ingredients.Load();
        }

        public ObservableCollection<Model.Recipe> Context()
        {
            return _dbContext.Recipes.Local;
        }

        public int RecipeCount()
        {
            return _dbContext.Recipes.Count<Model.Recipe>();
        }

        public void Add(Model.Recipe recipe)
        {     
            foreach(Model.Ingredient ingredient in recipe.IngredientList ) 
            {
                _ingdbContext.Ingredients.Add(ingredient);
            }

            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
            _ingdbContext.SaveChanges();
        }

        public void Delete(Model.Recipe recipe)
        {
            var query = from Recipe in _dbContext.Recipes
                        where Recipe.RecipeId == recipe.RecipeId
                        select Recipe;
            Model.Recipe recipeToDelete = query.First<Model.Recipe>();
            _dbContext.Recipes.Remove(recipeToDelete);
        }

        public void Clear()
        {
            var allRecipes = this.All();
            
        }

        public IEnumerable<Model.Recipe> All()
        {
            var query = from Recipe in _dbContext.Recipes
                        select Recipe;
            return query.ToList<Model.Recipe>();
        }

        public Model.Recipe GetByName()
        {
            throw new NotImplementedException();
        }

        public Model.Recipe GetById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Recipe> GetPossibleRecipes(IEnumerable<Model.Ingredient> ingredientList)
        {
            throw new NotImplementedException();
        }
    }
}
