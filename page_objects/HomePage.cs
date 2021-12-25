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
    class HomePage : AbstractPage
    {
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string HomePageCaption()
        {
            string HomePageCaption = "error";

            IWebElement label = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2[text()='Home page']"));

            if (label.Displayed)
            { HomePageCaption = "Home page"; }

            return HomePageCaption;
        }

        [FindsBy(How = How.LinkText, Using = "Logout")]
        private IWebElement logOutLink;
        public LoginPage LogOut()
        {
            IAction action = new Actions(driver)
                .Click(logOutLink)
                .Build();

            action.Perform();

            return new LoginPage(driver);
        }

        [FindsBy(How = How.CssSelector, Using = ".container-fluid:nth-child(3) > div:nth-child(1) > a")]
        private IWebElement allProductslink;
        public AllProductsPage GoToProductsPage()
        {
            IAction action = new Actions(driver)
                .Click(allProductslink)
                .Build();

            action.Perform();
            return new AllProductsPage(driver);
        }


    }
}
