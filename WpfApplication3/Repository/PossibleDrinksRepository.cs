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
        private MyBarContext _dbContext;
        private RecipePopulator recipePopulator = new RecipePopulator();

        public PossibleDrinksRepository()
        {
            _dbContext = new MyBarContext();
            _dbContext.MyIngredients.Load();
        }



    }
}
