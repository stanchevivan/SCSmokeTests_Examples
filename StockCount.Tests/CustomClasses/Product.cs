using System;
using OpenQA.Selenium;

namespace StockCount.Tests.CustomClasses
{
    public class Product
    {
        public IWebElement Webelement;

        public string Description;
        public string Unit;
        public string Quantity;

		public void SetQuanitity(int quantity)
		{
			Webelement.FindElement(By.TagName("input")).Clear();
			Webelement.FindElement(By.TagName("input")).SendKeys(quantity.ToString());
		}
    }
}
