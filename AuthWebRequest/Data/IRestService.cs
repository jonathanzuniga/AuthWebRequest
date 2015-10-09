using System;
using System.Threading.Tasks;

namespace AuthWebRequest
{
	public interface IRestService
	{
		Task<bool> LoginUserAsync (User user);
		bool IsUserLoggedIn ();
	}
}
