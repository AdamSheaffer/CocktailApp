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
    public class MyFavoritesRepository
    {
        private MyBarContext _dbContext;

        public MyFavoritesRepository()
        {
            _dbContext = new MyBarContext();
            _dbContext.MyFavorites.Load();
        }

        public ObservableCollection<Recipe> RecipeContext()
        {
            return _dbContext.MyFavorites.Local;
        }

        public IEnumerable<Recipe> All()
        {
            var query = from Recipe in _dbContext.MyFavorites
                        select Recipe;
            return query.ToList<Recipe>();
        }

        public void AddToFavorites(Model.Recipe recipe)
        {
            _dbContext.MyFavorites.Add(recipe);
            _dbContext.SaveChanges();
        }
    }
}
