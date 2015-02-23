using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CocktailApp;
using CocktailApp.Model;
using CocktailApp.Repository;

namespace CocktailAppTest
{
    [TestClass]
    public class PossibleDrinkTest
    {
        private PossibleDrinksRepository Repo = new PossibleDrinksRepository();

        [TestMethod]
        public void HasAllIngredientsTest()
        {
            int[] ingredientIds = new int[]{1,2,3};
            Assert.IsTrue(Repo.HasAllIngredients(1, ingredientIds));
        }

    }
}
