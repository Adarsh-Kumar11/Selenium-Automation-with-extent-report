using BigSmallSiteAutomation.Feature_Objects;
using System;
using TechTalk.SpecFlow;

namespace BigSmallSiteAutomation.Feature_Files
{
    [Binding]
    public class WishlistItemSteps
    {
        WishlistItemObjects obj = new WishlistItemObjects();

        [When(@"user click on item")]
        public void WhenUserClickOnItem()
        {
            obj.ClickOnItem();  
        }
        
        [When(@"user click on add to wishlist")]
        public void WhenUserClickOnAddToWishlist()
        {
            obj.AddToWishlist();
        }

        [When(@"user navigate to wishlist")]
        public void WhenUserNavigateToWishlist()
        {
            obj.GoToWishlist();
        }


        [Then(@"the item must be added")]
        public void ThenTheItemMustBeAdded()
        {
            obj.VerifyWishlist();
        }
    }
}
