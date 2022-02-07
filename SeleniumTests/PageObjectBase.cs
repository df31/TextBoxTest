﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class PageObjectBase
    {
        protected IWebDriver _driver;

        public PageObjectBase(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement WaitForElement(By by, int timeOut = 2)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            var element = wait.Until(d => d.FindElement(by));
            return element;
        }

    }
}
