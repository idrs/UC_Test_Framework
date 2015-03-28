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
    public class Search
    {
        public string Input { get; set; }
    }

    public class Activity_Search_City : Activity<Search>
    {
        public override void Assert(Assertion assertionHandler)
        {
            assertionHandler.AssertState = AssertionState.Fail;
            assertionHandler.Message = "Its fail because you are a fail bitch!";
        }

        public override void DoActivity()
        {
            var driver = TestSetting.GetResource<ChromeDriver>("Chrome");
            
            driver.Navigate().GoToUrl("http://www.hotel.de");
            
            var searchbox = driver.FindElementById("SearchCriteria_Destination");
            searchbox.SendKeys(Data.Input);
            
            Log.Write.Info("Testmessage");

            // Die loggs von Selenium sollen auch in die Log rein, als Source aber "Selenium" haben.
            // Type = Info|Fail|Fatal|Warning Source = Activity|Selenium
            
            // Explicit wait
            var searchbutton = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until<IWebElement>(d =>
                d.FindElement(By.Id("SearchSubmitButton_ButtonValue"))
            );

            Thread.Sleep(TimeSpan.FromSeconds(10));

            searchbutton.Click();
            
        }
    }
}
