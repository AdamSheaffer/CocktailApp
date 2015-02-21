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
        private RecipeIngredientRepository RecIngRepo = new RecipeIngredientRepository();
  
        public int RecipeId { get; set; }
        public Ingredient[] IngredientList { get; set; }
        public string Instructions { get; set; }
        public string Name { get; set; }

        public Recipe(string name, Ingredient[] ingredientList, string instructions)
        {
            this.IngredientList = ingredientList;
            this.Instructions = instructions;
            this.Name = name;

            //I want to efficiently check if the ingredients in the new recipe are already in the database. If any ingredients are already in the db, they should not be added. I want to do this by touching the database the least.

            IEnumerable<Ingredient> AllIngredients = IngRepo.All();

            foreach (Ingredient ingredient in ingredientList)
            {
                if ( AllIngredients.Contains<Ingredient>(ingredient) )
                {
                    IngRepo.AddIngredient(ingredient);
                    RecipeIngredient recipeIngredient = new RecipeIngredient(this, ingredient);
                    RecIngRepo.Add(recipeIngredient);
                }
                
            }
        }
        public Recipe() { }
    }
}
