using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CocktailApp.Model;

namespace CocktailApp
{
    public class MyFavoritesContext : DbContext
    {
        public DbSet<Recipe> MyFavorites { get; set; }
    }
}
