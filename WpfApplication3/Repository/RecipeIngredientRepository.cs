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
    class RecipeIngredientRepository
    {
        private RecipeContext _dbContext;

        public RecipeIngredientRepository()
        {
            _dbContext = new RecipeContext();
            _dbContext.RecipeIngredients.Load();
        }
    }
}
