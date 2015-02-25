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

        public ObservableCollection<Recipe> RecipeContext()
        {
            return _dbContext.Recipes.Local;
        }

        public int RecipeCount()
        {
            return _dbContext.Recipes.Count<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            var query = from Recipe in _dbContext.Recipes
                        where recipe.Name == Recipe.Name
                        select Recipe;
            if( query.ToList<Recipe>().Count == 0)
            {

                foreach(Model.Ingredient ingredient in recipe.IngredientList ) 
                {
                    AddIngredient(ingredient);
                    RecipeIngredient recIng = new RecipeIngredient(recipe.Name, ingredient.Name, ingredient.IngredientType);
                    AddRecipeIngredient(recIng);
                }

                _dbContext.Recipes.Add(recipe);
                _dbContext.SaveChanges();
            }
        }

        public void AddIngredient(Ingredient ingredient)
        {
            var query = from Ingredient in _dbContext.Ingredients
                        where Ingredient.Name == ingredient.Name
                        && Ingredient.IngredientType == ingredient.IngredientType
                        select Ingredient;
            if (query.ToList<Ingredient>().Count == 0)
            {
                _dbContext.Ingredients.Add(ingredient);
                _dbContext.SaveChanges();
            }
        }

        public void AddRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            _dbContext.RecipeIngredients.Add(recipeIngredient);
            _dbContext.SaveChanges();
        }

        public void Delete(Recipe recipe)
        {
            var query = from Recipe in _dbContext.Recipes
                        where Recipe.RecipeId == recipe.RecipeId
                        select Recipe;
            Recipe recipeToDelete = query.First<Recipe>();
            _dbContext.Recipes.Remove(recipeToDelete);
            _dbContext.SaveChanges();
        }

        public void Clear()
        {
            foreach (Recipe recipe in All())
            {
                Delete(recipe);
            }
            _dbContext.SaveChanges();
        }

        public IEnumerable<Recipe> All()
        {
            var query = from Recipe in _dbContext.Recipes
                        select Recipe;
            return query.ToList<Recipe>();
        }

        public IEnumerable<RecipeIngredient> AllRecipeIngredients()
        {
            var query = from RecipeIngredient in _dbContext.RecipeIngredients
                        select RecipeIngredient;
            return query.ToList<RecipeIngredient>();
        }

        public Recipe GetByName(string name)
        {
            var query = from Recipe in _dbContext.Recipes
                        where name == Recipe.Name
                        select Recipe;
            return query.First<Recipe>();
        }

        public int GetId(string name) 
        {
            var query = from Recipe in _dbContext.Recipes
                        where name == Recipe.Name
                        select Recipe;
            Recipe recipe = query.First<Recipe>();
            return recipe.RecipeId;
        }

        public Recipe GetById(int id)
        {
            var query = from Recipe in _dbContext.Recipes
                        where id == Recipe.RecipeId
                        select Recipe;
            return query.First<Recipe>();
        }

        public ObservableCollection<Recipe> GetRecFromIdList(List<int> recipeIds)
        {
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
            foreach (int id in recipeIds)
            {
                var query = from Recipe in _dbContext.Recipes
                            where id == Recipe.RecipeId
                            select Recipe;
                recipes.Add( query.First<Recipe>() );
            }
            return recipes;
        }

        public IEnumerable<Recipe> GetPossibleRecipes(IEnumerable<Ingredient> ingredientList)
        {
            throw new NotImplementedException();
        }

    }
}
