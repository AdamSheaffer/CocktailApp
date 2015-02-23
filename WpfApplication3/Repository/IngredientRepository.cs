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
    public class IngredientRepository
    {
        private RecipeContext _dbContext;

        public IngredientRepository() 
        {
            _dbContext = new RecipeContext();
            _dbContext.Ingredients.Load();
        }

        public ObservableCollection<Model.Ingredient> Context()
        {
            return _dbContext.Ingredients.Local;
        }

        public int IngredientCount()
        {
           return _dbContext.Ingredients.Count();
        }

        public void AddIngredient(Model.Ingredient ingredient)
        {
            //check that it's not already in DB
            var query = from Ingredient in _dbContext.Ingredients
                        where ingredient.Name == Ingredient.Name
                        && ingredient.IngredientType == Ingredient.IngredientType
                        select Ingredient;
            if(query.ToList<Ingredient>().Count == 0)
            {
                _dbContext.Ingredients.Add(ingredient);
                _dbContext.SaveChanges();
            }
        }

        public void AddIngredientsFromRecipe(Recipe recipe)
        {
            foreach (Ingredient ingredient in recipe.IngredientList)
            {
                AddIngredient(ingredient);
            }
        }

        public void Delete(Model.Ingredient recipe)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Model.Ingredient GetByName()
        {
            throw new NotImplementedException();
        }

        public Model.Ingredient GetById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Ingredient> GetPossibleRecipes(IEnumerable<Model.Ingredient> ingredientList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Ingredient> All()
        {
            var query = from Ingredient in _dbContext.Ingredients
                        select Ingredient;
            return query.ToList<Model.Ingredient>();
        }

        public ObservableCollection<Model.Ingredient> IngType(string ingredientType)
        {
            var query = from Ingredient in _dbContext.Ingredients
                        where Ingredient.IngredientType == ingredientType
                        select Ingredient;
            var ings = new ObservableCollection<Ingredient>(query.ToList<Ingredient>());
            return ings;   
        }

        public int GetId(string ingredientName)
        {
            var query = from Ingredient in _dbContext.Ingredients
                        where Ingredient.Name == ingredientName
                        select Ingredient;
            return query.First<Ingredient>().IngredientId;
        }
     
    }
}
