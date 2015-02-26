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
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using CocktailApp.Repository;
using CocktailApp.Model;

namespace CocktailApp
{
    /// <summary>
    /// Interaction logic for PossibleDrinks.xaml
    /// </summary>
    public partial class PossibleDrinks : Window
    {
        private MyBarRepository Repo = new MyBarRepository();

        public PossibleDrinks()
        {          
            InitializeComponent();
            DrinkResults.DataContext = Repo.FindPossibleDrinks();
        }

        private void ShowRecipe(object sender, RoutedEventArgs e)
        {
            Button buttonClicked = e.Source as Button;
            string buttonContent = buttonClicked.Content.ToString();
            TextBlock recipeTextBlock = sender as TextBlock;
            Recipe selectedRecipe = recipeTextBlock.DataContext as Recipe;
            var mainWindow = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;
            mainWindow.ViewRecipe(selectedRecipe);
        }
    }
}
