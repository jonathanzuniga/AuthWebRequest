using System;
using Xamarin.Forms;

namespace AuthWebRequest
{
	public class HelloPage : ContentPage
	{
		public HelloPage ()
		{
			Title = "Hello";
			Content = new StackLayout {
				Children = {
					new Label {
						XAlign = TextAlignment.Center,
						Text = "Welcome to Xamarin Forms!"
					}
				},
				VerticalOptions = LayoutOptions.Center
			};
		}
	}
}
