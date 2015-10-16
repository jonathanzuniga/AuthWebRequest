using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net;

namespace AuthWebRequest
{
	public class RestService : IRestService
	{
		HttpClient client;

		public RestService ()
		{
//			var authData = string.Format ("{0}:{1}", "firstuser", "first_password");
//			var authHeaderValue = Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));

//			var handler = new HttpClientHandler {
//				Credentials = new NetworkCredential("firstuser", "first_password")
//			};

			// Use default credentials aka Windows Credentials.
//			HttpClientHandler handler = new HttpClientHandler() {
//				UseDefaultCredentials = true
//			};

			// Use username/password credentials.
//			client = new HttpClient(handler);
//			client = new HttpClient ();

//			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
//			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
//			client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
//			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

//			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
//			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
//			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.5");
//			client.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
//			client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.10; rv:41.0) Gecko/20100101 Firefox/41.0");
//			client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "UTF-8");

//			client.DefaultRequestHeaders.Accept.Clear();
//			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));

//			client.MaxResponseContentBufferSize = 256000;
//			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Authorization", authData);
//			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", authData);
		}

		public async Task<bool> LoginUserAsync (User user)
		{
//			var authData = string.Format ("{0}:{1}", user.Username, user.Password);
//			var authHeaderValue = Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));
//
//			client = new HttpClient ();
//			client.MaxResponseContentBufferSize = 256000;
//			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", authHeaderValue);

			var handler = new HttpClientHandler {
				Credentials = new NetworkCredential(user.Username, user.Password)
			};

			// Use username/password credentials.
			client = new HttpClient(handler);
			client.MaxResponseContentBufferSize = 256000;

			var uri = new Uri (string.Format (Constants.RestUrl, string.Empty));
			bool auth = false;

			Debug.WriteLine("GET: " + uri);

			try {
				HttpResponseMessage response = await client.GetAsync (uri);
				HttpContent content = response.Content;

				// Check status code.
				Debug.WriteLine("Response StatusCode: " + (int)response.StatusCode);

				// Read the string.
				string result = await content.ReadAsStringAsync();

				// Display the result.
				if (result != null && result.Length >= 50) {
//					Debug.WriteLine(result.Substring(0, 50) + "...");
					Debug.WriteLine(result);
				}

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
