using BigSmallSiteAutomation.Feature_Objects;
using System;
using TechTalk.SpecFlow;

namespace BigSmallSiteAutomation.Feature_Step_Definition
{
    [Binding]
    public class SignInSteps
    {
        SignInObjects obj = new SignInObjects();

        [Given(@"the homepage of the website")]
        public void GivenTheHomepageOfTheWebsite()
        {
            obj.GotoHomepage();
        }
        
        [When(@"user click on sign In buttton")]
        public void WhenUserClickOnSignInButtton()
        {
            obj.GotoLoginPage();
        }

        [When(@"user enter (.*) and (.*)")]
        public void WhenUserEnterAnd(string id, string pass)
        {
            obj.EnterIdPass(id,pass);
        }


        [When(@"user click on sign In button")]
        public void WhenUserClickOnSignInButton()
        {
            obj.ClickOnSignIn();
        }
        
        [Then(@"the user must login to the site")]
        public void ThenTheUserMustLoginToTheSite()
        {
            obj.VerifyAccount();
        }
    }
}
