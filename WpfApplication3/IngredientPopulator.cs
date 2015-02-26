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
        public ObservableCollection<Ingredient> Ingredients;

        private RecipePopulator recipePopulator = new RecipePopulator();

        private bool NewIngredient(Ingredient ingredient, ObservableCollection<Ingredient> ingredients)
        {
            var query = from Ingredient in ingredients
                        where Ingredient.Name == ingredient.Name
                        && Ingredient.IngredientType == ingredient.IngredientType
                        select Ingredient;
            return (query.ToList<Ingredient>().Count == 0);
        }

        public void PopulateIngredientList()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            
            recipePopulator.PopulateDrinkRecipes();
            foreach (Recipe recipe in recipePopulator.DrinkRecipes)
            {
                foreach (Ingredient ingredient in recipe.IngredientList)
                {
                    if (NewIngredient(ingredient, Ingredients))
                    {
                        Ingredients.Add(ingredient);
                    }
                }
            }
        }

        public void AddUserIngredient(Ingredient[] newIngredients)
        {
            foreach (Ingredient ingredient in newIngredients)
            {
                var query = from Ingredient in Ingredients
                            where Ingredient.Name == ingredient.Name
                            && Ingredient.IngredientType == ingredient.IngredientType
                            select Ingredient;
                if (query.ToList<Ingredient>().Count == 0)
                {
                    Ingredients.Add(ingredient);
                }
            }          
        }

        //public ObservableCollection<Ingredient> findAllOfType(string type)
        //{
        //    ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        //    recipePopulator.PopulateDrinkRecipes();
        //    foreach (Recipe recipe in recipePopulator.DrinkRecipes)
        //    {
        //        foreach (Ingredient ingredient in recipe.IngredientList)
        //        {
        //            if (ingredient.IngredientType == type && 
        //                NewIngredient(ingredient.Name, ingredients))
        //            {
        //                ingredients.Add(ingredient);
        //            }
        //        }
        //    }       
        //    return ingredients;
        //}
  
    }
}
