using System;
using OpenQA.Selenium;

using System.Collections.Generic;


namespace SeleniumTests.PageObjects
{
    public class FormPage : PageObjectBase
    {
        public IWebElement FullNameTextBox => WaitForElement(By.Id("userName"));
        public IWebElement EmailTextBox => WaitForElement(By.Id("userEmail"));
        public IWebElement CurrentAdrTextBox => WaitForElement(By.Id("currentAddress"));
        public IWebElement PermanentAdrTextBox => WaitForElement(By.Id("permanentAddress"));
        public IWebElement SubmitButton => WaitForElement(By.Id("submit"));
        public IWebElement OutputBox => WaitForElement(By.Id("output"));
        public IWebElement OutputBoxUndefined => WaitForElement(By.XPath("//*[@id='output']//*[contains(@class,'undefined')]"));
        public IWebElement ReturnedName => WaitForElement(By.XPath("//*[@id='output']//*[@id='name']"));
        public IWebElement ReturnedEmail => WaitForElement(By.XPath("//*[@id='output']//*[@id='email']"));
        public IWebElement ReturnedCadr => WaitForElement(By.XPath("//*[@id='output']//*[@id='currentAddress']"));
        public IWebElement ReturnedPadr => WaitForElement(By.XPath("//*[@id='output']//*[@id='permanentAddress']"));

        public FormPage(IWebDriver _driver) : base(_driver)
        {

        }

    }
}
