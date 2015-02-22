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
using CocktailApp.Repository;

namespace CocktailApp
{
    /// <summary>
    /// Interaction logic for PossibleDrinks.xaml
    /// </summary>
    public partial class PossibleDrinks : Window
    {
        public RecipeRepository Repo = new RecipeRepository();
        public IngredientRepository IngRepo = new IngredientRepository();
        public MyBarRepository MyBarRepo = new MyBarRepository();

        public PossibleDrinks()
        {

            InitializeComponent();
        }
    }
}
