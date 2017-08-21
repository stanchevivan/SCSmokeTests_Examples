using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationStockCount.StockCount.Tests.PageObjects;

namespace StockCount.Tests
{
    [Binding]
    public class AreasSteps
    {
		private FourthLoginPage FourthLoginPage;
		private FourthHomePage FourthHomePage;
		private SCLocationPage SCLocationPage;
		private SCHomePage SCHomePage;
        private ProductsPage ProductsPage;

		public AreasSteps(FourthLoginPage login, FourthHomePage fourthHomePage, SCLocationPage scLocationPage, SCHomePage scHomePage, ProductsPage productsPage)
		{
			FourthLoginPage = login;
			FourthHomePage = fourthHomePage;
			SCLocationPage = scLocationPage;
			SCHomePage = scHomePage;
            ProductsPage = productsPage;
		}

        [Given(@"I am on the Fourth app Homepage")]
        public void GivenIAmOnTheFourthAppHomepage()
        {
            FourthLoginPage.OpenLoginPage();
            FourthLoginPage.PerformLogin();
        }

        [When(@"I Open Stock Count app")]
        public void WhenIOpenStockCountApp()
        {
			FourthHomePage.OpenStockCount();
        }

        [When(@"I Select location ""(.*)""")]
        public void WhenISelectLocation(string location)
        {
            SCLocationPage.ChooseLocation(location);
        }

        [Then(@"There is an area with name ""(.*)""")]
        public void ThenThereIsAnAreaWithName(string areaName)
        {
            Assert.That(SCHomePage.AreaList, Has.Member(areaName));
        }

		[When(@"a new area ""(.*)"" is created")]
		public void WhenANewAreaIsCreated(string areaName)
		{
			SCHomePage.CreateNewArea(areaName);

		}

		[Then(@"""(.*)"" is present on the area list")]
		public void ThenIsPresentOnTheAreaList(string areaName)
		{
			Assert.That(SCHomePage.AreaList, Has.Member(areaName));
		}

		[Given(@"the user is on a screen containing a Home button")]

		public void GivenTheUserIsOnAScreenContainingAHomeButton()
		{
			SCLocationPage.ChooseLocation("11 test");
			SCHomePage.OpenArea("Kitchen");
		}

		[When(@"they click the Home button")]

		public void WhenTheyClickTheHomeButton()
		{
			ProductsPage.ClickHomeIcon();
		}

		[Then(@"they are redirected to the Main screen")]

		public void ThenTheyAreRedirectedToTheMainScreen()
		{
			Assert.That(SCHomePage.IsLabelStockPeriodPresent(), Is.True);
		}

		[Given(@"Stock Count app is opened")]
		public void GivenStockCountAppIsOpened()
		{
			FourthLoginPage.OpenLoginPage();
			FourthLoginPage.PerformLogin();
			FourthHomePage.OpenStockCount();
		}

		[When(@"user selects a location")]
		public void WhenUserSelectsALocation()
		{
            SCLocationPage.ChooseLocation("Covent Garden");
		}

		[Then(@"the correct list of areas associated with the given location is displayed")]
		public void ThenTheCorrectListOfAreasAssociatedWithTheGivenLocationIsDisplayed()
		{
			var expectedAreas = new List<string>
			{
				"Kitchen",
				"Bar",
				"New Area",
				"Basement",
			};

			Assert.That(SCHomePage.AreaList, Is.EquivalentTo(expectedAreas));
		}
    }
}