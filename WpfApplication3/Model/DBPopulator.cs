using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailApp.Repository;
using CocktailApp;
using System.Data.Entity;

namespace CocktailApp.Model
{
    public class DBPopulator
    {
        public RecipeRepository recRepo = new RecipeRepository();
        public IngredientRepository IngRepo = new IngredientRepository();

        public DBPopulator() { }

        public void Populate() 
        {
            recRepo.AddRecipe(GinSlush());
            recRepo.AddRecipe(PerfectMartini());
            recRepo.AddRecipe(TomCollins());
        }

        public Recipe GinSlush()
        {
            Ingredient[] ings = {
                new Ingredient("White Sugar", "Mixer"),
                new Ingredient("Frozen Orange Juice", "Mixer"),
                new Ingredient("Frozen Lemonade", "Mixer"),
                new Ingredient("Water", "Mixer")
            };
            string instructions = "In a saucepan, combine 9 cups of water and 2 cups of sugar. Bring to a boil and let boil for 15 minutes. Remove from heat and allow to cool. Stir in 1 can(12 ounces) orange juice concentrate, 1 can of lemonade concentrate and 2 cups of gin. Pour into a plastic container and freeze overnight. To serve, scoop 1/2 cup slush into a glass and top with lemon-lime soda.";
            Recipe GinSlush = new Recipe("Gin Slush", ings, instructions);
            return GinSlush;
        }

        public Recipe PerfectMartini() 
        {
            Ingredient[] ings = {
                new Ingredient("Dry Vermouth", "Liqueur"),
                new Ingredient("Olives", "Fruit")
            };
            string instructions = "Fill a cocktail shaker with ice. Pour in 1/2 fluid ounce vermouth, followed closely by 4 fluid ounces of gin. Shake while counting to 30. Divide into 2 cocktail glasses. Garnish with 1 olive each.";
            Recipe PerfectMartini = new Recipe("Perfect Martini", ings, instructions);
            return PerfectMartini;
        }

        public Recipe TomCollins()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Simple Syrup", "Mixer"),
                new Ingredient("Angostura", "Bitters"),
                new Ingredient("Club Soda", "Mixer"),
                new Ingredient("Lemon", "Fruit"),
                 new Ingredient("Cherry", "Fruit")
            };
            string instructions = "Fill a cocktail shaker with ice. Pour in 2 ounces of gin, 2 ounces oflemon juice, 1 ounce of simple syrup and a dash of bitters. Cover and shake until the outside of the container is frosty, about 15 seconds. Strain into a highball glass full of ice. Top off with 1/4 cup of cold club soda and garnish with a lemon slice and cherry.";
            Recipe TomCollins = new Recipe("Tom Collins", ings, instructions);
            return TomCollins;
        }
    }
}
