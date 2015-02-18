using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailApp.Model;

namespace CocktailApp
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
