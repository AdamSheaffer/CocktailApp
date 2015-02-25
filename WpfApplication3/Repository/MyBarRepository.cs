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
        private RecipePopulator recipePopulator = new RecipePopulator();

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

        public ObservableCollection<Recipe> FindPossibleDrinks()
        {
            ObservableCollection<Recipe> PossibleDrinks = new ObservableCollection<Recipe>();
            foreach (Recipe recipe in recipePopulator.DrinkRecipes())
            {
                if (HasAllIngredients(recipe))
                {
                    PossibleDrinks.Add(recipe);
                }
            }
            return PossibleDrinks;
        }

        public IEnumerable<Ingredient> NecessaryIngredients(Recipe recipe)
        {
            var query = from Ingredient in recipe.IngredientList
                        select Ingredient;
            return query.ToList<Ingredient>();         
        }

        public bool HasAllIngredients(Recipe recipe)
        {
            IEnumerable<Ingredient> myIngredients = All();
            foreach (Ingredient ingredient in recipe.IngredientList)
            {
                if (!HasIngredient(recipe.IngredientList, ingredient))
                {
                    return false;
                }
            }
            return true;
        }

        public bool HasIngredient(Ingredient[] ingredientList, Ingredient ingredient)
        {
            var query = from Ingredient in ingredientList
                        where Ingredient.Name == ingredient.Name
                        && Ingredient.IngredientType == ingredient.IngredientType
                        select Ingredient;
            return query.ToList<Ingredient>().Count > 0;
        }
    }
}
