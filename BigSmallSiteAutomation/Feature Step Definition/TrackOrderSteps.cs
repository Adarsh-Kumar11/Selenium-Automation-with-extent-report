using BigSmallSiteAutomation.Feature_Objects;
using System;
using TechTalk.SpecFlow;

namespace BigSmallSiteAutomation.Feature_Step_Definition
{
    [Binding]
    public class TrackOrderSteps
    {
        TrackOrderObjects obj = new TrackOrderObjects(); 

        [When(@"user click on track your order link")]
        public void WhenUserClickOnTrackYourOrderLink()
        {
            obj.ClickOnTrack();
        }
        
        [When(@"user enter valid email")]
        public void WhenUserEnterValidEmail()
        {
            obj.EnterValidEmail();
        }
        
        [When(@"user enter invalid track id")]
        public void WhenUserEnterInvalidTrackId()
        {
            obj.EnterInvalidTrackId();
        }

        [When(@"user click on find order")]
        public void WhenUserClickOnFindOrder()
        {
            obj.ClickOnFindOrder();
        }


        [Then(@"the error message must be displayed")]
        public void ThenTheErrorMessageMustBeDisplayed()
        {
            obj.VerifyErrorMessage();
        }
    }
}
