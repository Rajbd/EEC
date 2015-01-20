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
    public class Training
    {
        public static TrainingPage TrainingPage
        {
            get
            {
                var trainingpage = new TrainingPage();
                PageFactory.InitElements(Browser.Driver, trainingpage);
                return trainingpage;
            }
        }
    }
    public class TrainingPage
    {
        string Url = "http://192.168.3.7/qaeec/Training.aspx/lan/en-US";
        string Title = "Training";
        //Search
        [FindsBy(How = How.Id, Using = "txtSearchCourse")]
        public IWebElement SearchBox;
        [FindsBy(How = How.Id, Using = "btnSearchCourse")]
        public IWebElement SearchBtn;
        [FindsBy(How = How.Id, Using = "txtCommentbox")]
        public IWebElement CommentBox;
        [FindsBy(How = How.ClassName, Using = "sfCommentBox")]
        [FindsBy(How = How.TagName, Using = "p")]
        //[FindsBy(How = How.TagName, Using = "input")]
        public IWebElement CommentBtn;
        //Login
        [FindsBy(How = How.Id, Using = "lytA_ctl23_UserName")]
        public IWebElement UserNameBox;
        [FindsBy(How = How.Id, Using = "lytA_ctl23_Password")]
        public IWebElement PasswordBox;
        [FindsBy(How = How.Id, Using = "lytA_ctl23_btnLogin")]
        public IWebElement LoginButton;
        public void GoTo()
        {
            Browser.GoTo(Url);
        }
        public bool IsAt()
        {
            return Browser.Title == Title;
        }
        public void LogIn(string Username, string Password)
        {
            UserNameBox.Click();
            UserNameBox.Clear();
            UserNameBox.SendKeys(Username);
            PasswordBox.Click();
            PasswordBox.Clear();
            PasswordBox.SendKeys(Password);
            LoginButton.Click();
        }
        public void Menu(int m)
        {
            var ID = Browser.Driver.FindElement(By.Id("divNav_48"));
            var Title = ID.FindElement(By.TagName("ul"));
            var Menu = Title.FindElements(By.TagName("li"))[m];
            var Links = Menu.FindElement(By.TagName("a"));
            Links.Click();
        }
        public void Course_Details(int n)
        {
            var ID = Browser.Driver.FindElement(By.Id("ulCourselist"));
            var List = ID.FindElements(By.TagName("li"))[n];
            var Link = List.FindElements(By.TagName("div"))[1];
            var Course = Link.FindElement(By.TagName("h2"));
            var Details = Course.FindElement(By.TagName("a"));
            Details.Click();
        }

        public void Course_Join(int n, string Comment, int m, int i)
        {
            var ID = Browser.Driver.FindElement(By.Id("ulCourselist"));
            var List = ID.FindElements(By.TagName("li"))[n];
            var Link = List.FindElements(By.TagName("div"))[1];
            var Join = Link.FindElement(By.TagName("input"));
            Join.Click();
            var Course = Browser.Driver.FindElement(By.ClassName("ulTrainingcourse"));
            var Links = Course.FindElements(By.TagName("div"))[3];
            var Lists = Links.FindElements(By.TagName("p"))[2];
            var CourseList = Lists.FindElements(By.TagName("span"))[1];
            var CourseLink = CourseList.FindElements(By.TagName("a"))[i];
            CourseLink.Click();
            /*CommentBox.Click();
              CommentBox.Clear();
              CommentBox.SendKeys(Comment);
              CommentBtn.Click();
             var Rating = Browser.Driver.FindElement(By.Id("divExtRating"));
              var span = Rating.FindElements(By.TagName("spab"))[0]; 
              var Rate = span.FindElements(By.TagName("div"))[m];
              Rate.Click();*/
        }
   }
}
