using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Model
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public Ingredient[] IngredientList { get; set; }
        public string Instructions { get; set; }
        public string Name { get; set; }

        public Recipe(string name, Ingredient[] ingredientList, string instructions)
        {
            this.IngredientList = ingredientList;
            this.Instructions = instructions;
            this.Name = name;
        }
        public Recipe() { }
    }
}
