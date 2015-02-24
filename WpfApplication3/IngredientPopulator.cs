using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CocktailApp.Model;

namespace CocktailApp
{
    public class IngredientPopulator
    {
        private RecipePopulator recipePopulator = new RecipePopulator();

        private bool NewIngredient(string name, ObservableCollection<Ingredient> ingredients)
        {
            var query = from Ingredient in ingredients
                        where Ingredient.Name == name
                        select Ingredient;
            return (query.ToList<Ingredient>().Count == 0);
        }

        public ObservableCollection<Ingredient> findAllOfType(string type)
        {
            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
            
            foreach (Recipe recipe in recipePopulator.DrinkRecipes())
            {
                foreach (Ingredient ingredient in recipe.IngredientList)
                {
                    if (ingredient.IngredientType == type && 
                        NewIngredient(ingredient.Name, ingredients))
                    {
                        ingredients.Add(ingredient);
                    }
                }
            }       
            return ingredients;
        }
  
    }
}
