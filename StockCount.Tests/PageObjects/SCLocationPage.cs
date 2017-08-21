using System.Collections.Generic;
using System.Linq;
using Fourth.Automation.Framework.Extension;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace TestAutomationStockCount.StockCount.Tests.PageObjects
{
    public class SCLocationPage : BasePage
    {
		#region Constructor
        SCLocationPage(IWebDriver webDriver) : base(webDriver)
        {
			
		}
		#endregion

		#region PageObjects
        [FindsBy(How = How.ClassName, Using = "ember-basic-dropdown-trigger")]
        private IWebElement DDL_Location { get; set; }
        [FindsBy(How = How.ClassName, Using = "location-picker__button")]
        private IWebElement BTN_Confirm { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[role=option]")]
        private IList<IWebElement> LST_Locations { get; set; }
        [FindsBy(How = How.ClassName, Using = "screen-loading")]
		private IWebElement LoadingScreen { get; set; }
		[FindsBy(How = How.ClassName, Using = "md-select-menu-container")]
		private IWebElement Panel_LocationList { get; set; }

		#endregion

		#region Methods
        public void SelectLocation(string location)
        {
			Driver.WaitIsClickable(DDL_Location);
			DDL_Location.Click();

            Driver.WaitIsClickable(Panel_LocationList);
            LST_Locations.First(x => x.Text == location).Click();
            Driver.WaitElementToDisappear(Panel_LocationList);
        }

        public void Confirm()
        {
            BTN_Confirm.Click();
            if(LoadingScreen.Exist())
            {
                Driver.WaitElementToDisappear(LoadingScreen);
            }
        }

        public void ChooseLocation(string location)
        {
            SelectLocation(location);
            Confirm();
        }

        private int GetNumberOfLocations()
        {
            return LST_Locations.Count;
        }
        #endregion
    }
}
