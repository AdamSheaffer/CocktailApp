using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailApp.Model;
using CocktailApp.Repository;

namespace CocktailApp.Model
{
    public class RecipeIngredient
    {
        private RecipeContext Repo = new RecipeContext();

        public int RecipeIngredientId { get; set; }
        public int Recipe_Id { get; set; }
        public int Ingredient_Id { get; set; }

        public RecipeIngredient() { }

        public RecipeIngredient(Model.Recipe recipe, Model.Ingredient ingredient)
        {
            this.Recipe_Id = recipe.RecipeId;
            this.Ingredient_Id = ingredient.IngredientId;
        }
    }
}
