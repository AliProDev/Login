using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Login
{
    [Binding]
    public sealed class LoginStep
    {
        IWebDriver webDriver;
        LoginPage login;


        #region Launch_Application

        [Given(@"launch the application")]
        public void Launch_Application()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demo.dbfront.com/dbFront");
            login = new LoginPage(webDriver);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(2000);
        }

        #endregion

        #region Check_Login
        public class login_info
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        [When(@"input value in username and password")]
        public void Check_Login(Table table)
        {
            System.Threading.Thread.Sleep(2000);
            var info = table.CreateSet<login_info>();
            foreach (login_info item in info)
            {
                login.Check_Login(item.UserName, item.Password);
            }
        }

        #endregion

        #region Check_Logout

        [Then(@"logout the application")]
        public void Check_Logout()
        {
            System.Threading.Thread.Sleep(2000);
            login.Check_Logout();
        }
        #endregion

    }
}
