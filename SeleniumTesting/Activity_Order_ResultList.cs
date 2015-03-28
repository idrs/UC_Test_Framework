using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UsecaseTesting;

namespace SeleniumTesting
{
    public class Order
    {
        public string Sortorder { get; set; }
    }

    public class Activity_Order_ResultList : Activity<Order>
    {
        public override void DoActivity()
        {
            var driver = TestSetting.GetResource<ChromeDriver>("Chrome");

            // implizit global wait
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var selectbox = driver.FindElementById("SortDropDownList");
                
            SelectElement el = new SelectElement(selectbox);
            el.SelectByText(Data.Sortorder);

            // Explicit wait
            var searchbutton = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until<IWebElement>(d =>
                d.FindElement(By.Id("SearchSubmitButton_ButtonValue"))
            );

            Thread.Sleep(TimeSpan.FromSeconds(10));

            searchbutton.Click();
            
        }
    }
}
