﻿using CoreFramework.DriverCore;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.Network;
using Scenario_Team1_Auto.TestSetup;
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
        //tuandv la staff
        //vangdv la admin

        private readonly String tfUserName = "//*[@id='login_username']"; 
        private readonly String tfPassWord = "//*[@id='login_password']";
        private readonly String btnLogin = "//button[@type='submit']";

        public void Login(string username, string password)
        {
            IsElementEnable(btnLogin);
            SendKeys_(tfUserName, username);
            SendKeys_(tfPassWord, password);
            IsElementEnable(btnLogin);
            Clicks(btnLogin);
        }
    }
}
