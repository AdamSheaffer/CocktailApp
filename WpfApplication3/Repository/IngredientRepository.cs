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
        private IngredientContext _dbContext;

        public IngredientRepository() 
        {
            _dbContext = new IngredientContext();
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

        public void Add(Model.Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            _dbContext.SaveChanges();
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

        public IEnumerable<Model.Ingredient> IngType(string ingredientType)
        {
            var query = from Ingredient in _dbContext.Ingredients
                        where Ingredient.IngredientType == ingredientType
                        select Ingredient;
            return query.ToList<Model.Ingredient>();                      
        }

        
    }
}
