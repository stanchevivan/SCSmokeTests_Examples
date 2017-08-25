using System.Collections.Generic;
using System.Linq;
using Fourth.Automation.Framework.Extension;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomationStockCount.StockCount.Tests.PageObjects
{
    public class SCHomePage : BasePage
    {
		#region Constructor
        public SCHomePage(IWebDriver webDriver) : base(webDriver)
        {
			Driver.AsMobile().SwitchToWebViewContext();
		}
		#endregion

		#region PageObjects
        [FindsBy(How = How.CssSelector, Using = "span.md-headline")]
        private IList<IWebElement> LST_Areas { get; set; }
        [FindsBy(How = How.ClassName, Using = "icon-home")]
		private IWebElement IconHome { get; set; }
        [FindsBy(How = How.ClassName, Using = "stock-period__label")]
		private IWebElement LBL_StockPeriod { get; set; }
		[FindsBy(How = How.CssSelector, Using = "button.md-headline")]
        private IWebElement BTN_NewArea { get; set; }
		[FindsBy(How = How.ClassName, Using = "area-card__new-title")]
		private IWebElement FLD_NewAreaName { get; set; }
        [FindsBy(How = How.CssSelector, Using = "md-card-actions button:last-of-type")]
        private IWebElement BTN_ConfirmNewAreaName { get; set; }
        #endregion

        public List<string> AreaList => LST_Areas.Select(x => x.Text).ToList();

        #region Methods
        public void OpenArea(string areaName)
        {
            LST_Areas.First(x => x.Text == areaName).Click();
            Driver.WaitElementToExists(IconHome);
        }

        public bool IsLabelStockPeriodPresent()
        {
            return LBL_StockPeriod.Displayed;
        }

        public SCHomePage UseNewAreaButton()
        {
            BTN_NewArea.Click();
            //Driver.WaitIsClickable(BTN_ConfirmNewAreaName);

            return this;
        }

        public SCHomePage ConfirmNewAreaName()
        {
            BTN_ConfirmNewAreaName.Click();

            return this;
        }

        public SCHomePage EnterNewAreaName(string name)
        {
            FLD_NewAreaName.ClearAndSendKeys(name);

            return this;
        }

        public SCHomePage CreateNewArea(string name)
        {
            UseNewAreaButton();
            EnterNewAreaName(name);
            ConfirmNewAreaName();

            return this;
        }
        #endregion
    }
}
