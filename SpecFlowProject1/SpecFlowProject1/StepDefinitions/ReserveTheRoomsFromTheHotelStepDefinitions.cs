using SpecFlowProject1.Features;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ReserveTheRoomsFromTheHotelStepDefinitions : Utility
    {
        [Given(@"click on ""([^""]*)""")]
        [When(@"click on ""([^""]*)""")]
        [Then(@"click on ""([^""]*)""")]
        public void GivenClickOn(string locator)
        {
            Page.Click(POM.ReservationPage[locator]);
        }

        [Given(@"Select ""([^""]*)"" from ""([^""]*)""")]
        [When(@"Select ""([^""]*)"" from ""([^""]*)""")]
        [Then(@"Select ""([^""]*)"" from ""([^""]*)""")]
        public void GivenSelectFrom(string listitem, string locator)
        {
            Page.Select(POM.ReservationPage[locator], listitem);
        }

        [Given(@"check mark ""([^""]*)""")]
        [When(@"check mark ""([^""]*)""")]
        [Then(@"check mark ""([^""]*)""")]
        public void ThenCheckMark(string locator)
        {
            Page.Click(POM.ReservationPage[locator]);
        }

        [Given(@"enter first name ""([^""]*)"" on ""([^""]*)""")]
        [When(@"enter first name ""([^""]*)"" on ""([^""]*)""")]
        [Then(@"enter first name ""([^""]*)"" on ""([^""]*)""")]
        public void GivenEnterFirstNameOn(string firstname, string element)
        {
            Page.Type(firstname, POM.ReservationPage[element]);
        }

        [Given(@"enter last name ""([^""]*)"" on ""([^""]*)""")]
        [When(@"enter last name ""([^""]*)"" on ""([^""]*)""")]
        [Then(@"enter last name ""([^""]*)"" on ""([^""]*)""")]
        public void WhenEnterLastNameOn(string lastname, string element)
        {
            Page.Type(lastname, POM.ReservationPage[element]);
        }

        [Given(@"enter billing address ""([^""]*)"" on ""([^""]*)""")]
        [When(@"enter billing address ""([^""]*)"" on ""([^""]*)""")]
        [Then(@"enter billing address ""([^""]*)"" on ""([^""]*)""")]
        public void WhenEnterBillingAddressOn(string address, string element)
        {
            Page.Type(address, POM.ReservationPage[element]);

        }

        [Given(@"enter credit card no ""([^""]*)"" on ""([^""]*)""")]
        [When(@"enter credit card no ""([^""]*)"" on ""([^""]*)""")]
        [Then(@"enter credit card no ""([^""]*)"" on ""([^""]*)""")]
        public void WhenEnterCreditCardNoOn(string cc_no, string element)
        {
            Page.Type(cc_no, POM.ReservationPage[element]);
        }

        [Given(@"enter credit card type ""([^""]*)"" on ""([^""]*)""")]
        [When(@"enter credit card type ""([^""]*)"" on ""([^""]*)""")]
        [Then(@"enter credit card type ""([^""]*)"" on ""([^""]*)""")]
        public void WhenEnterCreditCardTypeOn(string cc_type, string element)
        {
            Page.Type(cc_type, POM.ReservationPage[element]);
        }

        [Given(@"enter CVV ""([^""]*)"" on ""([^""]*)""")]
        [When(@"enter CVV ""([^""]*)"" on ""([^""]*)""")]
        [Then(@"enter CVV ""([^""]*)"" on ""([^""]*)""")]
        public void WhenEnterCVVOn(string cvv, string element)
        {
            Page.Type(cvv, POM.ReservationPage[element]);
        }

        [Given(@"verify the booking confirmation ""([^""]*)"" from ""([^""]*)""")]
        [When(@"verify the booking confirmation ""([^""]*)"" from ""([^""]*)""")]
        [Then(@"verify the booking confirmation ""([^""]*)"" from ""([^""]*)""")]
        public void GivenVerifyTheBookingConfirmationFrom(string text, string element)
        {
            Page.Asserts(POM.ReservationPage[element], text);
        }
        
        [Given(@"wait for (.*) seconds")]
        [When(@"wait for (.*) seconds")]
        [Then(@"wait for (.*) seconds")]
        public void GivenWaitForSeconds(int seconds)
        {
            Page.Wait(seconds);
        }


    }
}
