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
        public int Recipe_Id { get; set; }
        public int Ingredient_Id { get; set; }

        public RecipeIngredient() { }

        public RecipeIngredient(int recipeId, int ingredientId)
        {
            this.Recipe_Id = recipeId;
            this.Ingredient_Id = ingredientId;
        }
    }
}
