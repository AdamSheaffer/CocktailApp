using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Model
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string IngredientType { get; set; }

        public Ingredient(string name, string ingredientType)
        {
            this.Name = name;
            this.IngredientType = ingredientType;
        }

        public Ingredient() { }
    }
}
