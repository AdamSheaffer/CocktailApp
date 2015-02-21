using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CocktailApp.Repository
{
    public class MyFavoritesRepository
    {
        private MyFavoritesContext _dbContext;

        public MyFavoritesRepository()
        {
            _dbContext = new MyFavoritesContext();
            _dbContext.MyFavorites.Load();
        }

        public void AddToFavorites(Model.Recipe recipe)
        {
            _dbContext.MyFavorites.Add(recipe);
            _dbContext.SaveChanges();
        }
    }
}
