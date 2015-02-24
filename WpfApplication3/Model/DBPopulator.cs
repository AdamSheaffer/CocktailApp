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
        public IngredientRepository ingRepo = new IngredientRepository();
        public RecipeIngredientRepository recIngRepo = new RecipeIngredientRepository();

        public DBPopulator() { }

        public void Populate() 
        {
            Aviatrix();
            PinkestGin();
            GinSlush();
            PerfectMartini();
            TomCollins();
            StrawberryCocktail();
            Fitzgerald();
            GinSour();
            Aviation();
            Casino();
        }

        private void AddAllRecIngs(Recipe recipe)
        {
            foreach (Ingredient ingredient in recipe.IngredientList)
            {
                int recipeId = recRepo.GetId(recipe.Name);
                int ingredientId = ingRepo.GetId(ingredient.Name);
                RecipeIngredient recipeIngredient = new RecipeIngredient(recipeId, ingredientId);
                recIngRepo.Add(recipeIngredient);
            }
        }

        private void AddToDatabase(Recipe recipe)
        {
            recRepo.AddRecipe(recipe);
            ingRepo.AddIngredientsFromRecipe(recipe);
            AddAllRecIngs(recipe);
        }

        public void Aviatrix()
        {
            Ingredient[] ings = {
                new Ingredient("Lillet Blanc", "Liqueur"),
                new Ingredient("Creme de Violette", "Liqueur"),
                new Ingredient("Lemon", "Bitters"),
                new Ingredient("Lemon", "Fruit")
            };
            string instructions = "Over ice, stir 2 ounces of gin, 1 ounce of Lillet Blanc, 1 teaspoon Creme de Violette, and 2 dashes of Lemon Bitters. Add Lemon twist for garnish.";
            Recipe Aviatrix = new Recipe("Aviatrix", ings, instructions);
            AddToDatabase(Aviatrix);
        }

        public void PinkestGin()
        {
            Ingredient[] ings = {
                new Ingredient("Grapefruit Juice", "Mixer"),
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Quince Syrup", "Mixer"),
                new Ingredient("Peychaud's ", "Bitters")
            };
            string instructions = "Fill a cocktail shaker with ice. Add 2 ounces of gin, .5 ounces of grapefruit juice, .25 ounces of lemon juice, 1 ounces quince syrup, and 2 dashes of bitters. Shake until well chilled, about 20 seconds. Strain into a coupe glass.";
            Recipe PinkestGin = new Recipe("Pinkest Gin", ings, instructions);
            AddToDatabase(PinkestGin);
        }

        public void GinSlush()
        {
            Ingredient[] ings = {
                new Ingredient("White Sugar", "Mixer"),
                new Ingredient("Frozen Orange Juice", "Mixer"),
                new Ingredient("Frozen Lemonade", "Mixer"),
                new Ingredient("Water", "Mixer")
            };
            string instructions = "In a saucepan, combine 9 cups of water and 2 cups of sugar. Bring to a boil and let boil for 15 minutes. Remove from heat and allow to cool. Stir in 1 can(12 ounces) orange juice concentrate, 1 can of lemonade concentrate and 2 cups of gin. Pour into a plastic container and freeze overnight. To serve, scoop 1/2 cup slush into a glass and top with lemon-lime soda.";
            Recipe GinSlush = new Recipe("Gin Slush", ings, instructions);
            AddToDatabase(GinSlush);
        }

        public void PerfectMartini() 
        {
            Ingredient[] ings = {
                new Ingredient("Dry Vermouth", "Liqueur"),
                new Ingredient("Olives", "Fruit")
            };
            string instructions = "Fill a cocktail shaker with ice. Pour in 1/2 fluid ounce vermouth, followed closely by 4 fluid ounces of gin. Shake while counting to 30. Divide into 2 cocktail glasses. Garnish with 1 olive each.";
            Recipe PerfectMartini = new Recipe("Perfect Martini", ings, instructions);
            AddToDatabase(PerfectMartini);
        }

        public void TomCollins()
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
            AddToDatabase(TomCollins);
        }

        public void StrawberryCocktail()
        {
            Ingredient[] ings = {
                new Ingredient("Strawberry", "Fruit"),
                new Ingredient("Basil Leaves", "Mixer"),
                new Ingredient("White Sugar", "Mixer"),
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Club Soda", "Mixer")
            };
            string instructions = "Place 1 strawberry, 2 basil leaves, and 2 teaspoons of sugar into a cocktail shaker, and mash well with a cocktail muddler. Add ice to the cocktail shaker and also into a tall glass. Pour 2 ounces of gin and 1 ounce of lemon juice, cover, and shake until the outside of the shaker has frosted. Strain into the chilled glass over the ice, top with 3 ounces of club soda, and stir to serve.";
            Recipe StrawberryCocktail = new Recipe("Strawberry Cocktail", ings, instructions);
            AddToDatabase(StrawberryCocktail);
        }

        public void Fitzgerald()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Simple Syrup", "Mixer"),
                new Ingredient("Angostura", "Bitters")
            };
            string instructions = "Combine 2 ounces of gin, .75 ounces of Simple Syrup, .75 ounces of Lemon Juice, and 2 dashes of Angostura Bitters in a shaker over ice. Shake and strain into a cocktail glass.";
            Recipe Fitzgerald = new Recipe("Fitzgerald", ings, instructions);
            AddToDatabase(Fitzgerald);
        }

        public void GinSour()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Simple Syrup", "Mixer"),
            };
            string instructions = "Combine 2 ounces of gin, .75 ounces of Simple Syrup, and .75 ounces of Lemon Juice in a shaker over ice. Shake and strain into a cocktail glass.";
            Recipe GinSour = new Recipe("Gin Sour", ings, instructions);
            AddToDatabase(GinSour);
        }

        public void Aviation()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Maraschino ", "Liqueur"),
                new Ingredient("Creme de Violette", "Liqueur")
            };
            string instructions = "Combine 2 ounces of gin, .5 ounces of Maraschino, .25 ounces of Creme de Violette, and .75 ounces of Lemon Juice in a shaker over ice. Shake and strain into a cocktail glass.";
            Recipe Aviation = new Recipe("Aviation", ings, instructions);
            AddToDatabase(Aviation);
        }

        public void Casino()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Maraschino ", "Liqueur"),
                new Ingredient("Orange", "Bitters")
            };
            string instructions = "Combine 2 ounces of gin, .5 ounces of Maraschino, .75 ounces of Lemon Juice, and a dash of Orange Bitters in a shaker over ice. Shake and strain into a cocktail glass.";
            Recipe Casino = new Recipe("Casino", ings, instructions);
            AddToDatabase(Casino);
        }
    }
}
