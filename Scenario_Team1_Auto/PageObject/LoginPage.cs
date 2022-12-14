using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace Scenario_Team1_Auto.PageObject
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver driver) : base(driver)
        { 
        }

        private readonly String tfUserName = "//input[@id='login_username']"; 
        private readonly String tfPassWord = "//input[@id='login_password']";
        private readonly String btnLogin = "//button[@type='submit']";
        
        public void Login(string username, string password)
        {
            IsElementDisable(btnLogin);
            SendKey(tfUserName, username);
            SendKey(tfPassWord, password);
            IsElementEnable(btnLogin);
            Click(btnLogin);
            Thread.Sleep(2000);
        }
    }
}

