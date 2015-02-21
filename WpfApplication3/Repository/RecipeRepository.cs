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
    public class RecipeRepository
    {
        private RecipeContext _dbContext;

        public RecipeRepository() 
        {
            _dbContext = new RecipeContext();
            _dbContext.Ingredients.Load();
            _dbContext.RecipeIngredients.Load();
            _dbContext.Recipes.Load();
        }

        public ObservableCollection<Model.Recipe> RecipeContext()
        {
            return _dbContext.Recipes.Local;
        }

        public int RecipeCount()
        {
            return _dbContext.Recipes.Count<Model.Recipe>();
        }

        public void AddRecipe(Model.Recipe recipe)
        {     
            foreach(Model.Ingredient ingredient in recipe.IngredientList ) 
            {
                _dbContext.Ingredients.Add(ingredient);
            }

            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();
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

        public Model.Recipe GetByName(string name)
        {
            var query = from Recipe in _dbContext.Recipes
                        where name == Recipe.Name
                        select Recipe;
            return query.First<Recipe>();
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
