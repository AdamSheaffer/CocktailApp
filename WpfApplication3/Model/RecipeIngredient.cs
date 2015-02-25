using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailApp.Model;
using CocktailApp.Repository;
using System.Collections.ObjectModel;

namespace CocktailApp.Model
{
    public class RecipeIngredient
    {
        private RecipeContext Repo = new RecipeContext();

        public int RecipeIngredientId { get; set; }
        public string Recipe_Name { get; set; }
        public string Ingredient_Name { get; set; }
        public string Ingredient_Type { get; set; }

        public RecipeIngredient() { }

        public RecipeIngredient(string recipeName, string ingredientName, string ingredientType)
        {
            this.Recipe_Name = recipeName;
            this.Ingredient_Name = ingredientName;
            this.Ingredient_Type = ingredientType;
        }
    }
}
