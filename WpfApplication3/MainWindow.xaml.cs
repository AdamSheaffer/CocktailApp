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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using CocktailApp.Repository;
using CocktailApp.Model;
using System.Collections.ObjectModel;

namespace CocktailApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MyBarRepository MyBarRepo = new MyBarRepository();
        public MyFavoritesRepository MyFavoritesRepo = new MyFavoritesRepository();

        public RecipePopulator recipePopulator = new RecipePopulator();
        public IngredientPopulator ingredientPopulator = new IngredientPopulator();

        public MainWindow()
        {
            InitializeComponent();
            recipePopulator.PopulateDrinkRecipes();
            DrinkExplorer.DataContext = recipePopulator.DrinkRecipes;
            ingredientPopulator.PopulateIngredientList();
            SetIngredientData();
            SetMyBarData();
            MyFavorites.DataContext = MyFavoritesRepo.RecipeContext();
        }

        public void SetIngredientData()
        {
            AllLiqueurs.DataContext = ingredientPopulator.Ingredients.Where(c => c.IngredientType == "Liqueur");
            AllBitters.DataContext = ingredientPopulator.Ingredients.Where(c => c.IngredientType =="Bitters");
            AllFruits.DataContext = ingredientPopulator.Ingredients.Where(c => c.IngredientType == "Fruit");
            AllMixers.DataContext = ingredientPopulator.Ingredients.Where(c => c.IngredientType == "Mixer");
        }

        private void SetMyBarData()
        {
            MyFruits.DataContext = MyBarRepo.GetByType("Fruit");
            MyMixers.DataContext = MyBarRepo.GetByType("Mixer");
            MyBitters.DataContext = MyBarRepo.GetByType("Bitters");
            MyLiqueurs.DataContext = MyBarRepo.GetByType("Liqueur");
        }

        private void AddToMyBar(object sender, MouseButtonEventArgs e)
        {
            TextBlock myTextBlock = sender as TextBlock;
            Ingredient ingredient = myTextBlock.DataContext as Ingredient;
            MyBarRepo.Add(ingredient);
            SetMyBarData();
            myTextBlock.IsEnabled = false;
        }

        private void ViewOrAddTOMyBar(object sender, RoutedEventArgs e)
        {
            Button buttonClicked = e.Source as Button;
            string buttonContent = buttonClicked.Content.ToString();
            TextBlock recipeTextBlock = sender as TextBlock;
            Recipe selectedRecipe = recipeTextBlock.DataContext as Recipe;

            if (buttonContent == "Favorite")
            {
                MyFavoritesRepo.AddToFavorites(selectedRecipe);
                MyFavorites.DataContext = MyFavoritesRepo.RecipeContext();
            }
            else if (buttonContent == "View")
            {
                ViewRecipe(selectedRecipe);
            }
        }

        private void CheckPossibleDrinks(object sender, RoutedEventArgs e)
        {
            PossibleDrinks drinkResults = new PossibleDrinks();
            drinkResults.Show();
        }

        public void ViewRecipe(Recipe recipe)
        {
            ViewDrinkRecipe recipeWindow = new ViewDrinkRecipe();
            recipeWindow.Show();
            recipeWindow.DrinkIngredients.DataContext = recipe.IngredientList;
            recipeWindow.DrinkInstructions.Text = recipe.Instructions;
            recipeWindow.DrinkName.Text = recipe.Name;
        }

        private void DeleteFromBar(object sender, MouseButtonEventArgs e)
        {
            TextBlock myTextBlock = sender as TextBlock;
            Ingredient ingredient = myTextBlock.DataContext as Ingredient;
            MyBarRepo.Delete(ingredient);
            SetMyBarData();
        }

        private void EmptyMyBar(object sender, RoutedEventArgs e)
        {
            MyBarRepo.Clear();
            SetMyBarData();
        }

        private void ShowRecipeForm(object sender, RoutedEventArgs e)
        {
            NewRecipeForm newRecipeForm = new NewRecipeForm();
            newRecipeForm.Show();
        }
    }
}
