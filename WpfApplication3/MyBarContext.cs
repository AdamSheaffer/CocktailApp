using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CocktailApp
{
    public class MyBarContext : DbContext
    {
        public DbSet<Model.Ingredient> MyIngredients { get; set; }
        public DbSet<Model.Recipe> MyFavorites { get; set; }
    }
}
