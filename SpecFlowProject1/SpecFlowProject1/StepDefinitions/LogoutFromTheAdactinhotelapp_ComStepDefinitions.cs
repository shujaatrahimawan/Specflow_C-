using SpecFlowProject1.Features;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LogoutFromTheAdactinhotelapp_ComStepDefinitions:Utility
    {
        [Given(@"click on logout ""([^""]*)""")]
        [When(@"click on logout ""([^""]*)""")]
        [Then(@"click on logout ""([^""]*)""")]
        public void GivenClickOnLogout(string element)
        {
            Page.Click(POM.LogoutPage[element]);
        }

        [Given(@"verify login screen ""([^""]*)"" from ""([^""]*)""")]
        [When(@"verify login screen ""([^""]*)"" from ""([^""]*)""")]
        [Then(@"verify login screen ""([^""]*)"" from ""([^""]*)""")]
        public void WhenVerifyLoginScreen(string text, string element)
        {
            Page.Asserts(POM.LogoutPage[element], text);
        }

        [Given(@"verify user name ""([^""]*)"" from ""([^""]*)""")]
        [When(@"verify user name ""([^""]*)"" from ""([^""]*)""")]
        [Then(@"verify user name ""([^""]*)"" from ""([^""]*)""")]
        public void ThenVerifyUserName(string text, string element)
        {
            Page.Asserts(POM.LogoutPage[element], text);

        }

        [Given(@"verify password ""([^""]*)"" from ""([^""]*)""")]
        [When(@"verify password ""([^""]*)"" from ""([^""]*)""")]
        [Then(@"verify password ""([^""]*)"" from ""([^""]*)""")]
        public void ThenVerifyPassword(string text, string element)
        {
            Page.Asserts(POM.LogoutPage[element], text);

        }
    }
}
