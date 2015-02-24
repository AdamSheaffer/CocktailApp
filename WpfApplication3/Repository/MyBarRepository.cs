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

        public void Add(MyIngredient ingredient)
        {
            _dbContext.MyIngredients.Add(ingredient);
            _dbContext.SaveChanges();
        }

        public ObservableCollection<MyIngredient> GetByType(string ingredientType)
        {
            var query = from MyIngredient in _dbContext.MyIngredients
                        where ingredientType == MyIngredient.IngredientType
                        select MyIngredient;
            var ings = new ObservableCollection<MyIngredient>(query.ToList<MyIngredient>());
            return ings;
        }

        public IEnumerable<MyIngredient> All()
        {
            var query = from MyIngredient in _dbContext.MyIngredients
                        select MyIngredient;
            return query.ToList<MyIngredient>();
        }

        public IEnumerable<int> AllIds()
        {
            var query = from MyIngredient in _dbContext.MyIngredients
                        select MyIngredient.Ingredient_Id;
            return query.ToList<int>();
        }
    }
}
