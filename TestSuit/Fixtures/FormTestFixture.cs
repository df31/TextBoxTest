using System;
using SeleniumTests;
using TechTalk.SpecFlow;
using SeleniumTests.PageObjects;

namespace SnPTestSuit.Steps
{
    [Binding]
    public class FormTestFixture: IDisposable
    {
        public FormPageActions FormTestActions { get; set; }
        public FormTestFixture()
        {
            FormTestActions = new FormPageActions(WebDriverFactory.GetChromeDriver(), Startup.Config);
        }
        public void Dispose()
        {
            FormTestActions.Dispose();
        }
    }
}
