using System;
using System.IO;
//using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;


namespace CocktailAppTest
{
    [TestClass]
    public class UITests
    {
        private static TestContext test_context;
        private static Window window;
        private static Application application;

        [ClassInitialize]
        public static void Setup(TestContext _context)
        {
            test_context = _context;
            var applicationDir = _context.DeploymentDirectory;
            var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\CocktailAppTest\\bin\\Debug\\CocktailApp");
            application = Application.Launch(applicationPath);
            window = application.GetWindow("MainWindow", InitializeOption.NoCache);

        }

        [TestMethod]
        public void TestZeroState()
        {
            TestStack.White.UIItems.ListBoxItems.ComboBox combo_box = window.Get<TestStack.White.UIItems.ListBoxItems.ComboBox>("TypeSelect");
            TestStack.White.UIItems.ListBoxItems.ListBox list_box = window.Get<TestStack.White.UIItems.ListBoxItems.ListBox>("IngOptions");

            Assert.AreEqual( combo_box.SelectedItem.Text, "");
        }
            

        [ClassCleanup]
        public static void TearDown()
        {
            window.Close();
            application.Close();
        }
    }
}