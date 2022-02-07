using Xunit;
using System;
using Shouldly;
using SnPTestSuit;
using SeleniumTests;
using SnPTestSuit.Steps;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using SeleniumTests.PageObjects;

namespace SnPTask
{
    [Binding]
    public class FormTestSteps : IClassFixture<FormTestFixture>
    {
        private FormTestFixture _fixture;
        private FeatureContext _context;
        public FormTestSteps(FormTestFixture fixture, FeatureContext context)
        {
            _fixture = fixture;
            _context = context;
        }

        [Given(@"The Full Name is (.*)")]
        public void GivenTheFullNameIs(string name)
        {
            _fixture.FormTestActions.InputFullName(name);
            _context.Set<string>(name, "UserName");
        }

        [Given(@"The Email is (.*)")]
        public void GivenTheEmailIs(string email)
        {
            _fixture.FormTestActions.InputEmail(email);
            _context.Set<string>(email, "Email");
        }

        [Given(@"The Current Address is (.*)")]
        public void GivenTheCurrentAddressIs(string cadr)
        {
            _fixture.FormTestActions.InputCurrentAdr(cadr);
            _context.Set<string>(cadr, "CurrentAddress");
        }

        [Given(@"The Permanent Address is (.*)")]
        public void GivenThePermanentAddressIsStreetXMadridSpain(string padr)
        {
            _fixture.FormTestActions.InputPermanentAdr(padr);
            _context.Set<string>(padr, "PermanentAddress");
        }

        [When(@"The Information are submitted")]
        public void WhenTheInformationAreSubmitted()
        {
            _fixture.FormTestActions.ClickSubmitButton();
        }

        [Then(@"The input values returned in the bottom part")]
        public void ThenTheInputValuesReturnedInTheBottomPart()
        {
            var returnedValues = _fixture.FormTestActions.GetOutputValue();
            returnedValues.ShouldNotBeNullOrEmpty();
            returnedValues.ShouldContain(_context.Get<string>("UserName"));
            returnedValues.ShouldContain(_context.Get<string>("Email"));
            returnedValues.ShouldContain(_context.Get<string>("CurrentAddress"));
            returnedValues.ShouldContain(_context.Get<string>("PermanentAddress"));
            _fixture.FormTestActions.WaitForSeconds();
        }

        [Then(@"Error shows in page")]
        public void ThenErrorShowsInPage()
        {
            _fixture.FormTestActions.GetOutputBorderChildrenNumber().ShouldBe(0);
            _fixture.FormTestActions.WaitForSeconds();
        }

    }
}
