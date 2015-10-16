using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AuthWebRequest
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

		async void OnLoginActivated(object sender, EventArgs e)
		{
			var user = new User () {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			};
			var result = await App.Manager.CheckCredentialAsync (user);

			if (result) {
				Navigation.InsertPageBefore (new HelloPage (), this);
				await Navigation.PopAsync ();
			} else {
				messageLabel.Text = "Login failed.";
			}
		}
	}
}
