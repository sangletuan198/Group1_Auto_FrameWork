using CoreFramework.DriverCore;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenario_Team1_Auto.PageObject
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver driver) : base(driver)
        { 
        }
             
        private readonly String tfUserName = "//*[@id='login_username']"; 
        private readonly String tfPassWord = "//*[@id='login_password']";
        private readonly String btnLogin = "//button[@type='submit']";






        public void SendKeyLogin()
        {

            IsElementEnable(btnLogin);
            SendKeys_(tfUserName, "vangdv");
            SendKeys_(tfPassWord, "vangdv@01011990");
            IsElementEnable(btnLogin);
            Clicks(btnLogin);
        }
    }
}

