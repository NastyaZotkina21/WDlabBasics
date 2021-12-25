using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace WDlabBasics.page_objects
{
    class ProductEditingPage: AbstractPage
    {
        public ProductEditingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ProductName")]
        private IWebElement ProductName;

        [FindsBy(How = How.Id, Using = "CategoryId")]
        private IWebElement CategoryId;

        [FindsBy(How = How.Id, Using = "SupplierId")]
        private IWebElement SupplierId;

        [FindsBy(How = How.Id, Using = "UnitPrice")]
        private IWebElement UnitPrice;

        [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
        private IWebElement QuantityPerUnit;

        [FindsBy(How = How.Id, Using = "UnitsInStock")]
        private IWebElement UnitsInStock;

        [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
        private IWebElement UnitsOnOrder;

        [FindsBy(How = How.Id, Using = "ReorderLevel")]
        private IWebElement ReorderLevel;

        [FindsBy(How = How.Id, Using = "Discontinued")]
        private IWebElement Discontinued;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        private IWebElement SubmitBtn;

        public AllProductsPage CreateProduct(string[] productAttributes)
        {

            IAction action = new Actions(driver)
                 .Click(ProductName)
                 .SendKeys(productAttributes[0])
                 .Click(CategoryId)
                 .SendKeys(productAttributes[1])
                 .Click(SupplierId)
                 .SendKeys(productAttributes[2])
                 .Click(UnitPrice)
                 .SendKeys(productAttributes[3])
                 .Click(QuantityPerUnit)
                 .SendKeys(productAttributes[4])
                 .Click(UnitsInStock)
                 .SendKeys(productAttributes[5])
                 .Click(UnitsOnOrder)
                 .SendKeys(productAttributes[6])
                 .Click(ReorderLevel)
                 .SendKeys(productAttributes[7])
                 .Click(Discontinued)
                 .Click(SubmitBtn)
                 .Build();

            action.Perform();

            return new AllProductsPage(driver);
        }

    }
}
