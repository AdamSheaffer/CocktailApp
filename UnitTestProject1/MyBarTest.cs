using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CocktailApp;
using CocktailApp.Model;
using CocktailApp.Repository;

namespace CocktailAppTest
{
    [TestClass]
    public class MyBarTest
    {
        private MyBarRepository Repo = new MyBarRepository();
        private RecipePopulator Populator = new RecipePopulator();

        [TestMethod]
        public void HasAllIngredientsTest()
        {
            Assert.IsTrue(Repo.HasAllIngredients(Populator.Aviation()));
        }

        [TestMethod]
        public void HasIngredientsTest()
        {
            Ingredient Vermouth = new Ingredient("Dry Vermouth", "Liqueur");
            Ingredient Olive = new Ingredient("Olive", "Fruit");
            Ingredient[] myList = new Ingredient[]{Vermouth, Olive};
            Assert.IsTrue(Repo.HasIngredient(myList, Olive));
        }
    }
}
