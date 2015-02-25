using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CocktailApp.Model;
using CocktailApp.Repository;

namespace CocktailApp
{
    /// <summary>
    /// Interaction logic for NewRecipeForm.xaml
    /// </summary>
    public partial class NewRecipeForm : Window
    {
        private RecipeRepository RecipeRepo = new RecipeRepository();

        public NewRecipeForm()
        {
            InitializeComponent();
        }

        private void AddDrink(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.Name = DrinkName.Text;
            recipe.Instructions = DrinkInstructions.Text;
            recipe.IngredientList = GetUserIngredients();
            RecipeRepo.AddRecipe(recipe);
        }

        private string RecipeName {get; set;}
        private Ingredient UserIngredient1 { get; set; }
        private Ingredient UserIngredient2 { get; set; }
        private Ingredient UserIngredient3 { get; set; }
        private Ingredient UserIngredient4 { get; set; }
        private Ingredient UserIngredient5 { get; set; }
        private Ingredient UserIngredient6 { get; set; }
        private string Instructions { get; set; }

        private void SetIngredients() 
        {
            UserIngredient1 = new Ingredient(Ingredient1.Text, IngType1.SelectionBoxItem.ToString());
            UserIngredient2 = new Ingredient(Ingredient2.Text, IngType2.SelectionBoxItem.ToString());
            UserIngredient3 = new Ingredient(Ingredient3.Text, IngType3.SelectionBoxItem.ToString());
            UserIngredient4 = new Ingredient(Ingredient4.Text, IngType4.SelectionBoxItem.ToString());
            UserIngredient5 = new Ingredient(Ingredient5.Text, IngType5.SelectionBoxItem.ToString());
            UserIngredient6 = new Ingredient(Ingredient6.Text, IngType6.SelectionBoxItem.ToString());
        }

        private Ingredient[] IngredientFields()
        {
            SetIngredients();
            Ingredient[] ingList = new Ingredient[]{
                UserIngredient1,
                UserIngredient2,
                UserIngredient3,
                UserIngredient4,
                UserIngredient5,
                UserIngredient6
            };
            return ingList;
        }

        private Ingredient[] GetUserIngredients() 
        {
            List<Ingredient> ingList = new List<Ingredient>();
            foreach(Ingredient ingredient in IngredientFields()) 
            {
                if(ingredient.Name != "" && ingredient.IngredientType != "") 
                {
                    ingList.Add(ingredient);
                }
            }
            return ingList.ToArray<Ingredient>();
        }

    }
}
