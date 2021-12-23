using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;

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
            //wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));

            IWebElement inputLogin = driver.FindElement(By.Id("Name"));
            inputLogin.SendKeys("user");

            IWebElement inputPassword = driver.FindElement(By.Id("Password"));
            inputPassword.SendKeys("user");

            IWebElement button = driver.FindElement(By.CssSelector(".btn"));
            button.Click();

        }

        [Test]

        // logout and successful login test
        public void Test1()
        {

            IWebElement link = driver.FindElement(By.LinkText("Logout"));
            link.Click();

            IWebElement inputLogin = driver.FindElement(By.Id("Name"));
            inputLogin.SendKeys("user");

            IWebElement inputPassword = driver.FindElement(By.Id("Password"));
            inputPassword.SendKeys("user");

            IWebElement button = driver.FindElement(By.CssSelector(".btn"));
            button.Click();

            IWebElement label = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2[text()='Home page']"));


            Assert.IsTrue(label.Displayed);
        }


        [Test]

        // logout login failed test
        public void Test2()
        {
            IWebElement link = driver.FindElement(By.LinkText("Logout"));
            link.Click();

            IWebElement inputLogin = driver.FindElement(By.Id("Name"));
            inputLogin.SendKeys("were");

            IWebElement inputPassword = driver.FindElement(By.Id("Password"));
            inputPassword.SendKeys("were");

            IWebElement button = driver.FindElement(By.CssSelector(".btn"));
            button.Click();

            IWebElement label = driver.FindElement(By.XPath("//div[@class='validation-summary-errors text-danger']/ul/li[text()='Login failed. Please check Username and/or password']"));


            Assert.IsTrue(label.Displayed);
        }

        [Test]

        // new product added
        public void Test3()
        {
            IWebElement AllproductsPage = driver.FindElement(By.CssSelector(".container-fluid:nth-child(3) > div:nth-child(1) > a"));
            AllproductsPage.Click();

            IWebElement link = driver.FindElement(By.LinkText("Create new"));
            link.Click();

            IWebElement inputProduct = driver.FindElement(By.Id("ProductName"));
            inputProduct.SendKeys("Чай индийский");

            IWebElement inputCategory = driver.FindElement(By.Id("CategoryId"));
            inputCategory.SendKeys("Condiments");

            IWebElement inputSupplier = driver.FindElement(By.Id("SupplierId"));
            inputSupplier.SendKeys("New Orleans Cajun Delights");

            IWebElement inputUnitPrice = driver.FindElement(By.Id("UnitPrice"));
            inputUnitPrice.SendKeys("3");

            IWebElement inputQuantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit"));
            inputQuantityPerUnit.SendKeys("21 000");

            IWebElement inputUnitsInStock = driver.FindElement(By.Id("UnitsInStock"));
            inputUnitsInStock.SendKeys("0");

            IWebElement inputUnitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder"));
            inputUnitsOnOrder.SendKeys("0");

            IWebElement inputReorderLevel = driver.FindElement(By.Id("ReorderLevel"));
            inputReorderLevel.SendKeys("0");

            IWebElement checkDiscontinued = driver.FindElement(By.Id("Discontinued"));
            checkDiscontinued.Click();

            IWebElement button = driver.FindElement(By.CssSelector(".btn"));
            button.Click();

            IWebElement label = driver.FindElement(By.XPath("//li[text()='Products']"));

            Assert.IsTrue(label.Displayed);
        }


        [Test]

        // new product adding fail
        public void Test4()
        {
            IWebElement AllproductsPage = driver.FindElement(By.CssSelector(".container-fluid:nth-child(3) > div:nth-child(1) > a"));
            AllproductsPage.Click();

            IWebElement link = driver.FindElement(By.LinkText("Create new"));
            link.Click();

            IWebElement inputProduct = driver.FindElement(By.Id("ProductName"));
            inputProduct.SendKeys("Чай индийский");

            IWebElement inputCategory = driver.FindElement(By.Id("CategoryId"));
            inputCategory.SendKeys("Condiments");

            IWebElement inputSupplier = driver.FindElement(By.Id("SupplierId"));
            inputSupplier.SendKeys("New Orleans Cajun Delights");

            IWebElement inputUnitPrice = driver.FindElement(By.Id("UnitPrice"));
            inputUnitPrice.SendKeys("35 коробок");

            IWebElement inputQuantityPerUnit = driver.FindElement(By.Id("QuantityPerUnit"));
            inputQuantityPerUnit.SendKeys("21 000");

            IWebElement inputUnitsInStock = driver.FindElement(By.Id("UnitsInStock"));
            inputUnitsInStock.SendKeys("0");

            IWebElement inputUnitsOnOrder = driver.FindElement(By.Id("UnitsOnOrder"));
            inputUnitsOnOrder.SendKeys("0");

            IWebElement inputReorderLevel = driver.FindElement(By.Id("ReorderLevel"));
            inputReorderLevel.SendKeys("0");

            IWebElement checkDiscontinued = driver.FindElement(By.Id("Discontinued"));
            checkDiscontinued.Click();

            IWebElement button = driver.FindElement(By.CssSelector(".btn"));
            button.Click();

            IWebElement label = driver.FindElement(By.XPath("//div[@class='col-md-4 form-group']/span[@class='field-validation-error']/span[text()='The field UnitPrice must be a number.']"));

            Assert.IsTrue(label.Displayed);
        }

        [Test]

        // new product find
        public void Test5()
        {
            IWebElement AllproductsPage = driver.FindElement(By.CssSelector(".container-fluid:nth-child(3) > div:nth-child(1) > a"));
            AllproductsPage.Click();

            IWebElement link = driver.FindElement(By.LinkText("Чай индийский"));
            link.Click();

            IWebElement inputProduct = driver.FindElement(By.CssSelector("input[value='Чай индийский']"));

            Assert.IsTrue(inputProduct.Displayed);


        }

        [Test]

        // incorrect product find
        public void Test6()
        {
            IWebElement AllproductsPage = driver.FindElement(By.CssSelector(".container-fluid:nth-child(3) > div:nth-child(1) > a"));
            AllproductsPage.Click();

            IWebElement link = driver.FindElement(By.LinkText("Чай индийский"));
            link.Click();

            try
            {   

                IWebElement inputProduct = driver.FindElement(By.CssSelector("input[value='221 000']"));
                
            }
             catch (OpenQA.Selenium.NoSuchElementException ex)
             {
                Assert.Pass();
             }

            Assert.Fail();

        }

        [TearDown]
        public void TearDown()
        {
           driver.Close();
        }
    }
}