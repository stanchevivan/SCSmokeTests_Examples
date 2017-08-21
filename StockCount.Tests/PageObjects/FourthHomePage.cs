using System.Linq;
using Fourth.Automation.Framework.Extension;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomationStockCount.StockCount.Tests.PageObjects
{
    public class FourthHomePage : BasePage
    {
		#region Constructor
        FourthHomePage(IWebDriver webDriver) : base(webDriver)
        {
			Driver.AsMobile().SwitchToWebViewContext();
		}
		#endregion

		#region PageObjects
        [FindsBy(How = How.XPath, Using = "//span[text() = 'Stock Count']")]
        private IWebElement LNK_StockCount { get; set; }
		#endregion

		#region Methods
        private void SwitchToTab()
		{
			Driver.AsMobile().SwitchToWebViewContext();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
		}

        public void OpenStockCount()
        {
            Driver.WaitElementToExists(LNK_StockCount);
            LNK_StockCount.Click();
            SwitchToTab();
        }
        #endregion
    }
}
