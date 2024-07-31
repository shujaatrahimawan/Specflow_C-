
using SpecFlowProject1.Features;
using SpecFlowProject1.Resource;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions : Utility
    {

        [Given("open website (.*)")]
        [When("open website (.*)")]
        [Then("open website (.*)")]
        public void OpenWebsite(string url)
        {
            Page.Init_Driver();
            Page.OpenUrl(url);
            
        }

        [Given("enter username (.*) on (.*)")]
        [When("enter username (.*) on (.*)")]
        [Then("enter username (.*) on (.*)")]
        public void EnterUsername(string username, string element)
        {
            Page.Type(username, POM.LoginPage[element]);
        }

        [Given("enter password (.*) on (.*)")]
        [When("enter password (.*) on (.*)")]
        [Then("enter password (.*) on (.*)")]
        public void EnterPassword(string password, string element)
        {
            Page.Type(password, POM.LoginPage[element]);

        }

        [Given("click submit (.*)")]
        [When("click submit (.*)")]
        [Then("click submit (.*)")]
        public void ClickSubmit(string element)
        {
            Page.Click(POM.LoginPage[element]);

        }

    }
}