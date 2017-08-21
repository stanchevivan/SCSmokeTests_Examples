using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Mobile;
using System.Linq;
using System.Collections.Generic;
using StockCount.Tests.CustomClasses;

namespace TestAutomationStockCount.StockCount.Tests.PageObjects
{
    public class ProductsPage : BasePage
    {
		#region Constructor
        ProductsPage(IWebDriver webDriver) : base(webDriver)
        {
			Driver.AsMobile().SwitchToWebViewContext();
		}
		#endregion

		#region PageObjects
        [FindsBy(How = How.ClassName, Using = "product-list-item")]
        private IList<IWebElement> LST_Products { get; set; }
        [FindsBy(How = How.ClassName, Using = "icon-home")]
        private IWebElement IconHome { get; set; }
        #endregion

        public List<Product> Products => LST_Products
                    .Select(x => new Product
                    {
                        Webelement = x,
                        Description = x.FindElement(By.ClassName("product-list-item__description")).Text,
                        Unit = x.FindElement(By.ClassName("product-list-item__attribute__unit")).Text,
                        Quantity = x.FindElement(By.TagName("input")).GetAttribute("value"),
                    })
                    .ToList();
        
        #region Methods
        public void Out_ProductDetails(Product product)
        {
            System.Console.WriteLine(product.Description);
            System.Console.WriteLine(product.Unit);
            System.Console.WriteLine(product.Quantity);
        }

        public void ClickHomeIcon()
        {
            IconHome.Click();
        }

        /*
        public void SetQuantity(this IWebElement product, int quantity)

			product.FindElement(By.TagName("input")).Clear();
			product.FindElement(By.TagName("input")).SendKeys(quantity.ToString());
        }*/
        #endregion
    }
}
