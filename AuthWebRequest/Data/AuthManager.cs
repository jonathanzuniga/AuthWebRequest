using System;
using System.Threading.Tasks;

namespace AuthWebRequest
{
	public class AuthManager
	{
		IRestService service;

		public AuthManager (IRestService restService)
		{
			service = restService;
		}

		public Task<bool> CheckCredentialAsync (User user)
		{
			return service.LoginUserAsync (user);
		}

		public bool CheckLoggedIn ()
		{
			return service.IsUserLoggedIn ();
		}
	}
}
