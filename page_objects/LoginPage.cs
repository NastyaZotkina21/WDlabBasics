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
    class LoginPage: AbstractPage
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this); 
        }

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement loginInput;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        private IWebElement submittBtn;

        public HomePage Login(string login, string password)
        {
            IAction action = new Actions(driver)
                .Click(loginInput)
                .SendKeys(login)
                .Click(passwordInput)
                .SendKeys(password)
                .Click(submittBtn)
                .Build();

            action.Perform();

            return new HomePage(driver);
        }
    }
}
