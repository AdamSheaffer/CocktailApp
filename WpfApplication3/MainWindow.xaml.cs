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

            
        }

        private void AddToMyLiqueurs(object sender, MouseButtonEventArgs e)
        {
            TextBlock myTextBlock = sender as TextBlock;
            string ingredientName = myTextBlock.Text;
            
        }

       
    }
}
