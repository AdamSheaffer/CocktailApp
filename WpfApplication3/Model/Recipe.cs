using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using CocktailApp;
using CocktailApp.Repository;

namespace CocktailApp.Model
{

    public class Recipe
    {
        private IngredientRepository IngRepo = new IngredientRepository();
  
        public int RecipeId { get; set; }
        public Ingredient[] IngredientList { get; set; }
        public string Instructions { get; set; }
        public string Name { get; set; }

        public Recipe(string name, Ingredient[] ingredientList, string instructions)
        {
            this.IngredientList = ingredientList;
            this.Instructions = instructions;
            this.Name = name;

            //I want to efficiently check if the ingredients in the new recipe are already in the database. If any ingredients are already in the db, they should not be added. Current implementation is O(n^).

            //IEnumerable<Ingredient> AllIngredients = IngRepo.All();
            //bool IngredientExists;

            //foreach (Ingredient ingredient in IngredientList)
            //{
            //    IngredientExists = false;
            //    foreach(Ingredient dbIngredients in AllIngredients)
            //    if ( ingredient.Name == dbIngredients.Name && ingredient.IngredientType == dbIngredients.IngredientType)
            //    {
            //        IngredientExists = true;
            //        break;
            //    }
            //    if (!IngredientExists)
            //    {
            //        IngRepo.AddIngredient(ingredient);
            //    }
                    
            //}
        }
        public Recipe() { }
    }
}
