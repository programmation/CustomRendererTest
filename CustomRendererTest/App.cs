using System;

using Xamarin.Forms;

namespace CustomRendererTest
{
    public class App : Application
    {
        public App()
        {
            var loginPageModel = new LoginPageModel();
            var loginPage = new LoginPage();
            loginPage.BindingContext = loginPageModel;
            loginPage.Title = "Welcome";

            var homePage = new NavigationPage(loginPage);
            homePage.BackgroundColor = Color.Silver;
            homePage.BarBackgroundColor = Color.Silver;
            homePage.BarTextColor = Color.White;

//            NavigationPage.SetHasNavigationBar(loginPage, false);

            MainPage = homePage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

