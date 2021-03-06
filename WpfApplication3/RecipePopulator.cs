﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailApp.Model;
using CocktailApp.Repository;
using System.Collections.ObjectModel;

namespace CocktailApp
{
    public class RecipePopulator
    {
        private RecipeRepository RecipeRepo = new RecipeRepository();

        public ObservableCollection<Recipe> DrinkRecipes;

        public void PopulateDrinkRecipes()
        {
            DrinkRecipes = new ObservableCollection<Recipe>();
            DrinkRecipes.Add(Aviatrix());
            DrinkRecipes.Add(PinkestGin());
            DrinkRecipes.Add(GinSlush());
            DrinkRecipes.Add(TomCollins());
            DrinkRecipes.Add(StrawberryCocktail());
            DrinkRecipes.Add(GinSour());
            DrinkRecipes.Add(Fitzgerald());
            DrinkRecipes.Add(Aviation());
            DrinkRecipes.Add(Casino());
            DrinkRecipes.Add(PerfectMartini());
            DrinkRecipes.Add(GinRickey());
            DrinkRecipes.Add(GoldenSlipper());
            DrinkRecipes.Add(PerfectLady());
            DrinkRecipes.Add(Negroni());
            foreach(Recipe recipe in UserRecipes()) 
            {
                DrinkRecipes.Add(recipe);
            }
        }

        public ObservableCollection<Recipe> UserRecipes()
        {
            ObservableCollection<Recipe> recipeList = new ObservableCollection<Recipe>();
            foreach (string recipeName in RecipeNameList())
            {
                IEnumerable<RecipeIngredient> recipeIngs = GetRecipeIngredientsByName(recipeName);
                recipeList.Add(BuildFromRecipeIngredients(recipeIngs));
            }
            return recipeList;
        }

        private List<string> RecipeNameList()
        {
            List<string> recipeNames = new List<string>();
            foreach (Recipe recipe in RecipeRepo.All())
            {
                recipeNames.Add(recipe.Name);
            }
            return recipeNames;
        }

        private IEnumerable<RecipeIngredient> GetRecipeIngredientsByName(string recipeName)
        {
            var query = from RecipeIngredient in RecipeRepo.AllRecipeIngredients()
                        where RecipeIngredient.Recipe_Name == recipeName
                        select RecipeIngredient;
            return query.ToList<RecipeIngredient>();
        }

        private string GetInstructions(string recipeName)
        {
            var query = from Recipe in RecipeRepo.All()
                        where Recipe.Name == recipeName
                        select Recipe;
            return query.First<Recipe>().Instructions;
        }

        private Recipe BuildFromRecipeIngredients(IEnumerable<RecipeIngredient> recipeIngs)
        {
            Recipe recipe = new Recipe();
            recipe.Name = recipeIngs.First<RecipeIngredient>().Recipe_Name;
            recipe.Instructions = GetInstructions(recipe.Name);
            recipe.IngredientList = GetIngredients(recipe.Name);
            return recipe;
        }

        private Ingredient[] GetIngredients(string recipeName)
        {
            List<Ingredient> necessaryIngredients = new List<Ingredient>();
            foreach (RecipeIngredient recIng in GetRecipeIngredientsByName(recipeName))
            {
                Ingredient ingredient = new Ingredient(recIng.Ingredient_Name, recIng.Ingredient_Type);
                necessaryIngredients.Add(ingredient);
            }
            return necessaryIngredients.ToArray();
        }

        public Recipe Aviatrix()
        {
           Ingredient[] ings = {
                new Ingredient("Lillet Blanc", "Liqueur"),
                new Ingredient("Creme de Violette", "Liqueur"),
                new Ingredient("Lemon Bitters", "Bitters"),
                new Ingredient("Lemon", "Fruit")
            };
            string instructions = "Over ice, stir 2 ounces of gin, 1 ounce of Lillet Blanc, 1 teaspoon Creme de Violette, and 2 dashes of Lemon Bitters. Add Lemon twist for garnish.";
            Recipe Aviatrix = new Recipe("Aviatrix", ings, instructions);
            return Aviatrix;
        }

        public Recipe PinkestGin()
        {
            Ingredient[] ings = {
                new Ingredient("Grapefruit Juice", "Mixer"),
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Quince Syrup", "Mixer"),
                new Ingredient("Peychaud's Bitters", "Bitters")
            };
            string instructions = "Fill a cocktail shaker with ice. Add 2 ounces of gin, .5 ounces of grapefruit juice, .25 ounces of lemon juice, 1 ounces quince syrup, and 2 dashes of bitters. Shake until well chilled, about 20 seconds. Strain into a coupe glass.";
            Recipe PinkestGin = new Recipe("Pinkest Gin", ings, instructions);
            return PinkestGin;
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
                new Ingredient("Angostura Bitters", "Bitters"),
                new Ingredient("Club Soda", "Mixer"),
                new Ingredient("Lemon", "Fruit"),
                new Ingredient("Cherry", "Fruit")
            };
            string instructions = "Fill a cocktail shaker with ice. Pour in 2 ounces of gin, 2 ounces oflemon juice, 1 ounce of simple syrup and a dash of bitters. Cover and shake until the outside of the container is frosty, about 15 seconds. Strain into a highball glass full of ice. Top off with 1/4 cup of cold club soda and garnish with a lemon slice and cherry.";
            Recipe TomCollins = new Recipe("Tom Collins", ings, instructions);
            return TomCollins;
        }

        public Recipe StrawberryCocktail()
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
            return StrawberryCocktail;
        }

        public Recipe Fitzgerald()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Simple Syrup", "Mixer"),
                new Ingredient("Angostura Bitters", "Bitters")
            };
            string instructions = "Combine 2 ounces of gin, .75 ounces of Simple Syrup, .75 ounces of Lemon Juice, and 2 dashes of Angostura Bitters in a shaker over ice. Shake and strain into a cocktail glass.";
            Recipe Fitzgerald = new Recipe("Fitzgerald", ings, instructions);
            return Fitzgerald;
        }

        public Recipe GinSour()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Simple Syrup", "Mixer"),
            };
            string instructions = "Combine 2 ounces of gin, .75 ounces of Simple Syrup, and .75 ounces of Lemon Juice in a shaker over ice. Shake and strain into a cocktail glass.";
            Recipe GinSour = new Recipe("Gin Sour", ings, instructions);
            return GinSour;
        }

        public Recipe Aviation()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Maraschino ", "Liqueur"),
                new Ingredient("Creme de Violette", "Liqueur")
            };
            string instructions = "Combine 2 ounces of gin, .5 ounces of Maraschino, .25 ounces of Creme de Violette, and .75 ounces of Lemon Juice in a shaker over ice. Shake and strain into a cocktail glass.";
            Recipe Aviation = new Recipe("Aviation", ings, instructions);
            return Aviation;
        }

        public Recipe Casino()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Maraschino ", "Liqueur"),
                new Ingredient("Orange Bitters", "Bitters")
            };
            string instructions = "Combine 2 ounces of gin, .5 ounces of Maraschino, .75 ounces of Lemon Juice, and a dash of Orange Bitters in a shaker over ice. Shake and strain into a cocktail glass.";
            Recipe Casino = new Recipe("Casino", ings, instructions);
           return Casino;
        }

        public Recipe GinRickey() {
            Ingredient[] ings = {
                new Ingredient("Lime", "Fruit"),
                new Ingredient("Club Soda", "Mixer"),
                new Ingredient("Simple Syrup", "Mixer")
            };
            string instructions = "Fill a 10-ounce Collins glass with ice. Squeeze lime into the glass, getting as much juice out of it as you can. Toss in the lime shell, then add 2 ounces of gin. Top off glass with chilled club soda. The rickey doesn't need it, but if you like a sweeter drink, add splash of simple syrup.";
            Recipe GinRickey = new Recipe("Gin Rickey", ings, instructions);
            return GinRickey;
        }

        public Recipe GoldenSlipper()
        {
            Ingredient[] ings = {
                new Ingredient("Egg Liqueur", "Liqueur"),
                new Ingredient("Orange Juice", "Mixer"),
                new Ingredient("Egg White", "Mixer"),
                new Ingredient("Simple Syrup", "Mixer")
            };
            string instructions = "Fill a shaker with ice cubes. Add equal parts all ingredients. Shake and strain into a chilled cocktail glass.";
            Recipe GoldenSlipper = new Recipe("Golden Slipper", ings, instructions);
            return GoldenSlipper;
        }

        public Recipe PerfectLady()
        {
            Ingredient[] ings = {
                new Ingredient("Lemon Juice", "Mixer"),
                new Ingredient("Peach Liqueur", "Liqueur"),
                new Ingredient("Absinthe", "Liqueur")
            };
            string instructions = "Fill a shaker with ice cubes. Add 1 part gin, 2 parts Lemon Juice, 1 part Peach Liqueur, and 1 part Absinthe. Shake and strain into a chilled cocktail glass.";
            Recipe PerfectLady = new Recipe("Perfect Lady", ings, instructions);
            return PerfectLady;
        }

        public Recipe Negroni()
        {
            Ingredient[] ings = {
                new Ingredient("Campari", "Liqueur"),
                new Ingredient("Sweet Vermouth", "Liqueur"),
                new Ingredient("Orange", "Fruit")
            };
            string instructions = "Fill a chilled rocks glass with ice cubes. Add equal parts gin, Campari, and Vermouth. Stir. Garnish with Orange.";
            Recipe Negroni = new Recipe("Negroni", ings, instructions);
            return Negroni;
        }
    }
}
