using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class LoginPage
    {
        public IWebDriver WebDriver { get; }
        public LoginPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        #region Get_Element

        //login
        public IWebElement txtusername => WebDriver.FindElement(By.Id("C000101L"));
        public IWebElement txtpassword => WebDriver.FindElement(By.Id("C000102L"));
        public IWebElement btnlogin => WebDriver.FindElement(By.XPath("//div[@class='ui-dialog-buttonset']/child::button"));

        //logout
        public IWebElement drpprofile => WebDriver.FindElement(By.XPath("//div[@class='logoutButton']/child::div/child::ul/child::li"));
        public IWebElement btnlogout => WebDriver.FindElement(By.XPath("//div[@class='logoutButton']/child::div/child::ul/child::li/child::ul/child::li[2]/child::a"));

        #endregion

        #region Check_Login

        public void Check_Login(string UserName, string Password)
        {
            txtusername.SendKeys(UserName);
            System.Threading.Thread.Sleep(500);
            txtpassword.SendKeys(Password);
            System.Threading.Thread.Sleep(500);
            btnlogin.Click();
            System.Threading.Thread.Sleep(1000);
        }

        #endregion

        #region Check_Logout

        public void Check_Logout()
        {
            drpprofile.Click();
            System.Threading.Thread.Sleep(500);
            btnlogout.Click();
            System.Threading.Thread.Sleep(500);
        }

        #endregion
    }
}
