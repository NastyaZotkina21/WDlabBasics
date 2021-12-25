using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace WDlabBasics
{
    

    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);


            //WDlabBasics.page_objects.LoginPage LoginPage = new WDlabBasics.page_objects.LoginPage(driver);
            //WDlabBasics.page_objects.HomePage HomePage = LoginPage.Login("user","user");


        }

        [Test]

        //successful login test
        public void Test1()
        {

            page_objects.LoginPage LoginPage = new WDlabBasics.page_objects.LoginPage(driver);
 
            page_objects.HomePage HomePage = LoginPage.Login("user", "user");

            Assert.AreEqual("Home page", HomePage.HomePageCaption());
        }


        [Test]

        // logout and login failed test
        public void Test2()
        {

            page_objects.LoginPage LoginPage = new WDlabBasics.page_objects.LoginPage(driver);

            page_objects.HomePage HomePage = LoginPage.Login("user", "user");

            HomePage.LogOut();

            HomePage = LoginPage.Login("were", "were");

            IWebElement label = driver.FindElement(By.XPath("//div[@class='validation-summary-errors text-danger']/ul/li[text()='Login failed. Please check Username and/or password']"));

            Assert.IsTrue(label.Displayed);
        }

        [Test]

        // new product added
        public void Test3()
        {

            page_objects.LoginPage LoginPage = new WDlabBasics.page_objects.LoginPage(driver);

            page_objects.HomePage HomePage = LoginPage.Login("user", "user");

            page_objects.AllProductsPage AllProductsPage = HomePage.GoToProductsPage();

            page_objects.ProductEditingPage ProductEditingPage = AllProductsPage.CreateNew();

            string[] productattr = new string[] { "Чай индийский", "Condiments", "New Orleans Cajun Delights", "3","21 000","0","0","0"};

            ProductEditingPage.CreateProduct(productattr);

            IWebElement label = driver.FindElement(By.XPath("//li[text()='Products']"));

            Assert.IsTrue(label.Displayed);
        }


        [Test]

        // new product find
        public void Test4()
        {
            page_objects.LoginPage LoginPage = new WDlabBasics.page_objects.LoginPage(driver);

            page_objects.HomePage HomePage = LoginPage.Login("user", "user");

            page_objects.AllProductsPage AllProductsPage = HomePage.GoToProductsPage();

            page_objects.ProductEditingPage ProductEditingPage = AllProductsPage.CreatedProducts();

            IWebElement inputProduct = driver.FindElement(By.CssSelector("input[value='Чай индийский']"));

            Assert.IsTrue(inputProduct.Displayed);

        }



        [TearDown]
        public void TearDown()
        {
           driver.Close();
        }
    }
}