using BigSmallSiteAutomation.Feature_Objects;
using System;
using TechTalk.SpecFlow;

namespace BigSmallSiteAutomation.Feature_Step_Definition
{
    [Binding]
    public class AddItemToCartSteps
    {
        AddItemToCartObjects obj = new AddItemToCartObjects();

        [When(@"User click on the Item")]
        public void WhenUserClickOnTheItem()
        {
            obj.ClickOnTheItem();
        }
        
        [When(@"user click on add to cart")]
        public void WhenUserClickOnAddToCart()
        {
            obj.ClickOnAddToCart();
        }
        
        [Then(@"the item should be added to cart")]
        public void ThenTheItemShouldBeAddedToCart()
        {
            obj.VerifyCart();
        }
    }
}
