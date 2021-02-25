using OpenQA.Selenium;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using SeleniumExtras.PageObjects;
using System;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Threading;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class TShirts : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public TShirts(BaseBrowser browser) : base(browser) { }

        #endregion



        #region WEBELEMENTS
        //span[@class="category-name" and contains(text(),"T-shirts")]
        // [FindsBy(How = How.Id, Using = "//span[@class='cat - name' and contains(text(),'T - shirts'")]
        [FindsBy(How = How.XPath, Using = "//span[@class='category-name' and contains(text(),'T-shirts')]")] 
        public IWebElement TShirtsLbl { get; set; }

       
        [FindsBy(How = How.XPath, Using = "//span[@class='availability']")]
        public IWebElement InStockLnks { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//a[@class='button ajax_add_to_cart_button btn btn-default' and @title='Add to cart']")]
        public IWebElement AddToCartBtn { get; set; }


        //TODO: This element is repeatable and cold be kept in ParentPOMClasses
        [FindsBy(How = How.PartialLinkText, Using = "Proceed to checkout")]
        public IWebElement ProceedToCheckoutBtn { get; set; }


        #endregion


        #region Methods
        public override bool CheckPageLoaded()
        {
            bool isPageLoaded;
            isPageLoaded = TShirtsLbl.WaitUntillDisplayedAndEnabled(GlobalVariables.Browser.Driver);
            return isPageLoaded;
        }

        public override void FillPageForm(Table table)
        {
            throw new NotImplementedException();
        }

        public override void MoveToNextPage(string elementName)
        {
            //IList<IWebElement> InStockBtns = GlobalVariables.Browser.Driver.FindElements(By.XPath("//span[@class='available-now']"));
            IList<IWebElement> InStockLnks = GlobalVariables.Browser.Driver.FindElements(By.PartialLinkText("In stock"));
            if (InStockLnks.Count >= 1)
            {
                foreach (IWebElement element in InStockLnks)
                {
                    element.SendKeys(Keys.Control + Keys.Add);

                    Thread.Sleep(3000);

                    element.MouseOverAndClick(AddToCartBtn, GlobalVariables.Browser.Driver);
                    break;
                }
            }
            else
            { 
                //Log There is no T-Shirt Available
            }
            Thread.Sleep (3000);

            ProceedToCheckoutBtn.Click();

        }

        #endregion
    }
}
