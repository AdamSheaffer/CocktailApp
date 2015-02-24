using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.Model
{
    public class MyIngredient
    {
        public int MyIngredientId { get; set; }
        public string Name { get; set; }
        public string IngredientType { get; set; }
        public int Ingredient_Id { get; set; }

        public MyIngredient(Model.Ingredient ingredient) 
        {
            this.Name = ingredient.Name;
            this.IngredientType = ingredient.IngredientType;
            this.Ingredient_Id = ingredient.IngredientId;
        }

        public MyIngredient() { }
    }
}
