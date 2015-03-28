using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsecaseTesting;

namespace SeleniumTesting
{
    public class ChromeBrowser_Setting : Setting
    {
        private ChromeDriver Browser { get; set; }
        private string chrome_url;

        public ChromeBrowser_Setting(string url)
        {
            chrome_url = url;
        }

        public override void Initialize()
        {
            Browser = new ChromeDriver();
            Browser.Url = chrome_url;
            this.SetResource("Chrome", Browser);
        }

        public override void Cleanup()
        {
            Browser.Quit();
        }
    }
}
