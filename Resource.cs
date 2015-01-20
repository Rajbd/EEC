using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace EEC
{
    public class Resource
    {
        public static ResourcePage ResourcePage
        {
            get
            {
                var resourcepage = new ResourcePage();
                PageFactory.InitElements(Browser.Driver, resourcepage);
                return resourcepage;
            }
        }
    }

    public class ResourcePage
    {
        string Url = "http://192.168.3.7/qaeec/Resources.aspx/lan/en-US";
        string Title = "Resources";
        //Search
        [FindsBy(How = How.Id, Using = "txtResourceSearch")]
        public IWebElement SearchBox;
        [FindsBy(How = How.Id, Using = "btnResourceSearch")]
        public IWebElement SearchBtn;
        [FindsBy(How = How.Id, Using = "ddlOperational")]
        public IWebElement Operationalddl;
        [FindsBy(How = How.Id, Using = "ddlTypeofDoc")]
        public IWebElement DocumentTypeddl;
        [FindsBy(How = How.Id, Using = "ddlTypeofEmer")]
        public IWebElement EmergencyTypeddl;
        //Advanced Search
        [FindsBy(How = How.Id, Using = "btnSearchAdvance")]
        public IWebElement AdvancedSearch;
        [FindsBy(How = How.Id, Using = "ddlAdvOpt")]
        public IWebElement AdvanceOperationalddl;
        [FindsBy(How = How.Id, Using = "ddlAdvTOD")]
        public IWebElement AdvanceDocumentddl;
        [FindsBy(How = How.Id, Using = "ddlAdvTOE")]
        public IWebElement AdvanceEmergencyddl;
        [FindsBy(How = How.Id, Using = "txtAdvanceSearch")]
        public IWebElement AdvanceSearchBox;
        [FindsBy(How = How.Id, Using = "btnAdvanceSearch")]
        public IWebElement AdvanceSearchBtn;
        //Sort
        [FindsBy(How = How.Id, Using = "rdDate")]
        public IWebElement DateSort;
        [FindsBy(How = How.Id, Using = "rdRating")]
        public IWebElement RatingSort;
        public void GoTo()
        {
            Browser.GoTo(Url);
        }
        public bool IsAt()
        {
            return Browser.Title == Title;
        }
        public void Search_Resources(string Search, string Operation, string Document, string Emergency)
        {
            SearchBox.Click();
            SearchBox.Clear();
            SearchBox.SendKeys(Search);
            var SelectOperation = new SelectElement(Operationalddl);
            SelectOperation.SelectByText(Operation);
            var SelectDocumentType = new SelectElement(DocumentTypeddl);
            SelectDocumentType.SelectByText(Document);
            var SelectEmergency = new SelectElement(EmergencyTypeddl);
            SelectEmergency.SelectByText(Emergency);
            SearchBtn.Click();
        }
        public void Advanced_Search(int n, string Search, string Operation, string Document, string Emergency)
        {
            AdvancedSearch.Click();
            var SelectAdvanceOperation = new SelectElement(AdvanceOperationalddl);
            SelectAdvanceOperation.SelectByText(Operation);
            var SelectAdvanceTOD = new SelectElement(AdvanceDocumentddl);
            SelectAdvanceTOD.SelectByText(Document);
            var SelectAdvanceEmergency = new SelectElement(AdvanceEmergencyddl);
            SelectAdvanceEmergency.SelectByText(Emergency);
            int i;
            for(i=0; i<n; i++)
            {
                var Class = Browser.Driver.FindElement(By.ClassName("ulTheme"));
                var List = Class.FindElements(By.TagName("li"))[i];
                var Link = List.FindElement(By.TagName("label"));
                var Theme = Link.FindElement(By.TagName("input"));
                Theme.Click();
            }
            AdvanceSearchBox.Click();
            AdvanceSearchBox.Clear();
            AdvanceSearchBox.SendKeys(Search);
            AdvanceSearchBtn.Click(); 
        }
        public void View_Resources(int n)
        {
            var ID = Browser.Driver.FindElement(By.Id("ulResources"));
            var List = ID.FindElements(By.TagName("li"))[n];
            var Link = List.FindElements(By.TagName("div"))[1];
            var Head = Link.FindElement(By.TagName("h3"));
            var Resource = Head.FindElement(By.TagName("a"));
            Resource.Click(); 
        }
        public void Download_Resources(int m)
        {
            var ID = Browser.Driver.FindElement(By.Id("ulResources"));
            var List = ID.FindElements(By.TagName("li"))[7];
            var Link = List.FindElements(By.TagName("div"))[1];
            var Resource = Link.FindElements(By.TagName("p"))[1];
            var Down = Resource.FindElement(By.TagName("a"));
            Down.Click();
        }
        public void Sort(string Category)
        {
            if(Category == "Date")
            {
                DateSort.Click();
            }
            else
            {
                RatingSort.Click();
            }
            
        }
        public void Pagination()
        {
            var ID = Browser.Driver.FindElement(By.Id("Pagination"));
            var List = ID.FindElement(By.TagName("div"));
            var Link = List.FindElements(By.TagName("a"))[1];
            Link.Click();
        }
    }
}
