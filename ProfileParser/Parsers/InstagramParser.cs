using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProfileParser.Abstraction.Interfaces;
using ProfileParser.Data;
using ProfileParser.Entities;
using ProfileParser.Options;

namespace ProfileParser.Parsers;

public class InstagramParser : IParser
{
    private readonly InstagramProfileParsingOptions _options;
    
    private readonly ChromeDriver _driver;

    private int _followersCount = 0;
  
    public  List<User> Users { get; } = new();

    private readonly List<string> _profilesLinks = new();

    public InstagramParser(ProfileParsingOptions opt, ChromeDriver driver)
    {
        _options = (InstagramProfileParsingOptions)opt;
        _driver = driver;
    }


    public Task Parse()
    {
        return Task.Run(() =>
        {
            try
            {
                HideNotificationModal();

                MoveToAccount();
                
                //_driver.Navigate().GoToUrl("https://www.instagram.com/obezbashena15/");
                
                InitFollowersBLock();

                while (MoveNext())
                {
                    Console.Clear();
                    Console.WriteLine($"Getting followers info\nTotal:{_followersCount}");
                }
                
                ParseUsers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
    }

    public Task Save(ISaveDataStrategy dataSaver)
    {
        return Task.Run(() => { dataSaver.Save(Users); });
    }

    public void ParseUsers()
    {
        foreach (var link in _profilesLinks)
        {
            _driver.Navigate().GoToUrl(link);
            var waitPageLoad = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            var user = new User();
            var infoSection = waitPageLoad.Until(d =>
            {
                try
                {
                    return d.FindElement(By.CssSelector(_options.UserInfoSection));
                }
                catch (NoSuchElementException e)
                {
                    return null;
                }
            });
            if (infoSection != null)
            {
                try
                {
                    var nickName = infoSection.FindElement(By.CssSelector(_options.UserName));
                    user.UserName = nickName.Text ?? "";
                }
                catch (NoSuchElementException e)
                {
                }
            }

            var overallInfo = _driver.FindElement(By.CssSelector(_options.OverallInfo));

            var overallItems = overallInfo.FindElements(By.TagName("li"));
            var userType = typeof(User);
            foreach (var i in overallItems)
            {
                var text = i.Text;
                var arr = text.Split(" ");
                var filedName = arr[1];
                var toUpper = char.ToUpper(filedName[0]) + filedName.Substring(1);
                var field = userType.GetProperty(toUpper);
                if (field != null)
                {
                    field.SetValue(user, arr[0]);
                }
            }

            user.SecondName = TryGetString(_options.UserInfoSection, _options.SecondNameBlock);
            user.AccountAbout = TryGetString(_options.UserInfoSection, _options.AccountAbout);
            user.Bio = TryGetString(_options.UserInfoSection, _options.BioBlock);
            user.Site = TryGetString(_options.UserInfoSection, _options.WebSite);
            var links = _driver.FindElement(By.CssSelector(_options.UserInfoSection))
                .FindElements(By.TagName("a"));

            foreach (var accountLink in links)
            {
                user.Links.Add(new Link(accountLink.Text, accountLink.GetAttribute("href")));
            }

            Users.Add(user);
        }
    }

    public string TryGetString(string element, string selector)
    {
        string value;
        try
        {
            value = _driver.FindElement(By.CssSelector(element)).FindElement(By.CssSelector(selector)).Text;
        }
        catch (NoSuchElementException e)
        {
            value = "";
        }

        return value;
    }

    public void HideNotificationModal()
    {
        var notificationWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        var account = _driver.FindElement(By.CssSelector(_options.Home));
        account.Click();

        notificationWait.Until(d =>
        {
            try
            {
                var body = _driver.FindElement(By.CssSelector(_options.CloseLogInModalButton));
                body.Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        });
    }

    public void Logout()
    {
        ((IJavaScriptExecutor)_driver).ExecuteScript("window.open();");
        var windowHandles = _driver.WindowHandles;
        _driver.SwitchTo().Window(windowHandles[1]);

        _driver.Navigate().GoToUrl("https://www.instagram.com/");


        var pageLoadWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        pageLoadWait.Until(d =>
        {
            try
            {
                d.FindElement(By.CssSelector(_options.SettingsWrapper));
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        });

        var settingsButton = _driver
            .FindElement(By.CssSelector(_options.SettingsWrapper))
            .FindElements(By.CssSelector(_options.SettingsButton));

        settingsButton.Last().Click();

        var waitSettingsBLock = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        waitSettingsBLock.Until(d =>
        {
            try
            {
                d.FindElement(By.CssSelector(_options.LogoutBlock));
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        });

        var logoutBtn = _driver
            .FindElement(By.CssSelector(_options.LogoutBlock))
            .FindElements(By.CssSelector(_options.LogoutButton));

        logoutBtn.Last().Click();
    }

    public void MoveToAccount()
    {
        var accountLoadWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

        var toAccountBlock = _driver.FindElement(By.CssSelector(_options.SideBar));
        var items = toAccountBlock.FindElements(By.XPath("./*"));
        var lastBlock = items.Last();
        var link = lastBlock.FindElement(By.CssSelector(_options.ToAccount));
        link.Click();
        accountLoadWait.Until(driver =>
        {
            try
            {
                driver.FindElement(By.CssSelector(_options.NickNameBlock));
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        });
    }

    public void InitFollowersBLock()
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        var followersBlock = _driver.FindElement(By.CssSelector(_options.FollowersSection));
        var list = followersBlock.FindElements(By.CssSelector("li"));

        var followBlock = list[1];
        followBlock.Click();
        var followBLockWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        followBLockWait.Until(d =>
        {
            try
            {
                d.FindElement(By.CssSelector(_options.FollowerBlock));
                return true;
            }
            catch
            {
                return false;
            }
        });
    }

    public bool MoveNext()
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        var followers =
            _driver.FindElements(By.CssSelector($"{_options.FollowerBlock}:nth-child(n+{_followersCount})"));
        if (!followers.Any())
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            followers = _driver.FindElements(
                By.CssSelector($"{_options.FollowerBlock}:nth-child(n+{_followersCount})"));
            if (!followers.Any())
            {
                return false;
            }
        }

        foreach (var follower in followers)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", follower);
            var followerLink = follower.FindElement(By.CssSelector(_options.FollowerPageLink));
            var href = followerLink.GetAttribute("href");
            _profilesLinks.Add(href);
        }

        _followersCount += followers.Count + 1;

        return true;
    }
}