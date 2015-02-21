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
        public RecipeRepository Repo = new RecipeRepository();
        public IngredientRepository IngRepo = new IngredientRepository();
        public MyBarRepository MyBarRepo = new MyBarRepository();
        public MyFavoritesRepository MyFavoritesRepo = new MyFavoritesRepository();
        public DBPopulator DbPopulator = new DBPopulator();

        public MainWindow()
        {
            if (Repo.RecipeCount() < 1)
            {
                DbPopulator.Populate();
            }
            InitializeComponent();
            AllRecipesList.DataContext = Repo.RecipeContext();
            AllFruits.DataContext = IngRepo.IngType("Fruit");
            AllMixers.DataContext = IngRepo.IngType("Mixer");
            AllBitters.DataContext = IngRepo.IngType("Bitters");
            AllLiqueurs.DataContext = IngRepo.IngType("Liqueur");
            MyFruits.DataContext = MyBarRepo.GetByType("Fruit");
            MyMixers.DataContext = MyBarRepo.GetByType("Mixer");
            MyBitters.DataContext = MyBarRepo.GetByType("Bitters");
            MyLiqueurs.DataContext = MyBarRepo.GetByType("Liqueur");
        }

        private void AddToMyBar(object sender, MouseButtonEventArgs e)
        {
            TextBlock myTextBlock = sender as TextBlock;
            Ingredient ingredient = myTextBlock.DataContext as Ingredient;
            // I may want to delete the ingredient clicked from the total list
                // when it gets added to the bar.
            MyBarRepo.Add(ingredient);
            MyFruits.DataContext = MyBarRepo.GetByType("Fruit");
            MyMixers.DataContext = MyBarRepo.GetByType("Mixer");
            MyBitters.DataContext = MyBarRepo.GetByType("Bitters");
            MyLiqueurs.DataContext = MyBarRepo.GetByType("Liqueur");
        }

        private void ViewOrAddTOMyBar(object sender, RoutedEventArgs e)
        {
            Button buttonClicked = e.Source as Button;
            string buttonContent = buttonClicked.Content.ToString();

        }

        private void AddToFavorites(Recipe recipe)
        {

        }
       
    }
}
