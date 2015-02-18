using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CocktailApp.Model;

namespace CocktailAppTest
{
    [TestClass]
    public class ModelIngredientTest
    {
        [TestMethod]
        public void TestIngredientConstructors()
        {
            Ingredient myMixer = new Ingredient("Bailey's", "Mixer");
            Assert.AreEqual(myMixer.IngredientType, "Mixer");
            Assert.AreEqual(myMixer.Name, "Bailey's");
        }
    }
}
