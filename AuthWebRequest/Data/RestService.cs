using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AuthWebRequest
{
	public class RestService : IRestService
	{
		HttpClient client;

		public RestService ()
		{
			var authData = string.Format ("{0}:{1}", "firstuser", "first_password");
//			var authHeaderValue = Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));

			client = new HttpClient ();
			client.MaxResponseContentBufferSize = 256000;
//			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Authorization", authData);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", authData);
		}

		public async Task<bool> LoginUserAsync (User user)
		{
//			var authData = string.Format ("{0}:{1}", user.Username, user.Password);
//			var authHeaderValue = Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));
//
//			client = new HttpClient ();
//			client.MaxResponseContentBufferSize = 256000;
//			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", authHeaderValue);

			var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));
			bool auth = false;

			try {
				var response = await client.GetAsync (uri);

				Debug.WriteLine (response);

				if (response.IsSuccessStatusCode) {
					auth = true;

					return auth;
				}
			} catch (Exception ex) {
				Debug.WriteLine (@"ERROR {0}", ex.Message);
			}

			return auth;
		}

		public bool IsUserLoggedIn ()
		{
			return true;
		}
	}
}
