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
    public class MyBarRepository
    {
        private MyBarContext _dbContext;

        public MyBarRepository()
        {
            _dbContext = new MyBarContext();
            _dbContext.MyIngredients.Load();
        }

        public void Add(Ingredient ingredient)
        {
            _dbContext.MyIngredients.Add(ingredient);
            _dbContext.SaveChanges();
        }

        public ObservableCollection<Ingredient> GetByType(string ingredientType)
        {
            var query = from MyIngredient in _dbContext.MyIngredients
                        where ingredientType == MyIngredient.IngredientType
                        select MyIngredient;
            var ings = new ObservableCollection<Ingredient>(query.ToList<Ingredient>());
            return ings;
        }

        public IEnumerable<Ingredient> All()
        {
            var query = from Ingredient in _dbContext.MyIngredients
                        select Ingredient;
            return query.ToList<Ingredient>();
        }

    }
}
