using BigSmallSiteAutomation.Feature_Objects;
using System;
using TechTalk.SpecFlow;

namespace BigSmallSiteAutomation.Feature_Step_Definition
{
    [Binding]
    public class SearchItemSteps
    {
        SearchItemObjects obj = new SearchItemObjects();

        [When(@"user enter value in search tab")]
        public void WhenUserEnterValueInSearchTab()
        {
            obj.SearchItem();
        }
        
        [When(@"user click on related item")]
        public void WhenUserClickOnRelatedItem()
        {
            obj.SelectItem();
        }

        [Then(@"verify the item added")]
        public void ThenVerifyTheItemAdded()
        {
            obj.VerifyItem();
        }

    }
}
