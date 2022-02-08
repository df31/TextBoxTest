using System;
using System.Text;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Microsoft.Extensions.Configuration;

namespace SeleniumTests.PageObjects
{
    public class FormPageActions : IDisposable
    {
        private IWebDriver _driver;
        private FormPage _formPage;

        public FormPageActions(IWebDriver driver, IConfiguration config)
        {
            _driver = driver;
            _driver.Url = config["FormPage:Url"];
            _formPage = new FormPage(_driver);
            closeFixedBan();
        }

        private void closeFixedBan()
        {
            string closeFixedBanId = "close-fixedban";
            if (_formPage.IsElementPresent(By.Id(closeFixedBanId)))
            {
                _driver.FindElement(By.Id(closeFixedBanId)).Click();
            }
        }

        private void scrollToOutpuBox()
        {
            //Actions actions = new Actions(_driver);
            //actions.MoveToElement(_formPage.OutputBox);
            //actions.Perform();
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView();", _formPage.OutputBox);
        }
        public void InputFullName(string name)
        {
            _formPage.FullNameTextBox.Clear();
            _formPage.FullNameTextBox.SendKeys(name);
        }

        public void InputEmail(string email)
        {
            _formPage.EmailTextBox.Clear();
            _formPage.EmailTextBox.SendKeys(email);
        }

        public void InputCurrentAdr(string adr)
        {
            _formPage.CurrentAdrTextBox.Clear();
            _formPage.CurrentAdrTextBox.SendKeys(adr);
        }

        public void InputPermanentAdr(string adr)
        {
            _formPage.PermanentAdrTextBox.Clear();
            _formPage.PermanentAdrTextBox.SendKeys(adr);
        }

        public void ClickSubmitButton()
        {
            _formPage.SubmitButton.Click();
            scrollToOutpuBox();
        }

        public string GetOutputValue()
        {
            var outputValue =
                _formPage.ReturnedName.Text + " "
                + _formPage.ReturnedEmail.Text + " "
                + _formPage.ReturnedCadr.Text + " "
                + _formPage.ReturnedPadr.Text;

            return outputValue;
        }

        public int GetOutputBorderChildrenNumber()
        {
            return _formPage.OutputBoxUndefined.FindElements(By.XPath(".//*")).Count;
        }

        public void WaitForSeconds(int delay = 5)
        {
            var now = DateTime.Now;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(delay));
            wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromSeconds(delay) > TimeSpan.Zero);
        }

        public void Dispose()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
