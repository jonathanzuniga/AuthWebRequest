using System;
using Xamarin.Forms;

namespace AuthWebRequest
{
	public class App : Application
	{
		public static AuthManager Manager { get; set; }
//		public static IRestService Service { get; set; }

		public App ()
		{
			Manager = new AuthManager (new RestService ());

//			if (Manager.CheckLoggedIn ()) {
//				MainPage = new NavigationPage (new HelloPage ());
//			} else {
				MainPage = new NavigationPage (new LoginPage ());
//			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
