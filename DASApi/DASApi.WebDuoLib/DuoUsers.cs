using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebDuoLib;

namespace DASApi.WebDuoLib
{
	public class DuoUsers
	{
		private DuoApi _client;

		public DuoUsers()
		{
			_client = new DuoApi("DIGGIDE1DP2VBFEFJGRV", "IGFwxKEzEpoEoBXeweXZjZLqA8C2PFPirQ5O170v", "api-2111ed8d.duosecurity.com");
		}

		public Dictionary<string, object> GetDuoUserByUsername(string userName)
		{
			try
			{
				var test = _client.JSONApiCall<System.Collections.ArrayList>(
					"GET", "/admin/v1/users", new Dictionary<string, string>());

				var duoUser = _client.JSONApiCall<System.Collections.ArrayList>(
					"GET", "/admin/v1/users", new Dictionary<string, string> {
						{ "username", userName }
					});

				return duoUser[0] as Dictionary<string, object>;
			}
			catch (DuoException ex)
			{
				throw new WebException(
					string.Format("There is an exception with DUO Admin API: {0}", ex.Message));
			}
			catch (Exception ex)
			{
				throw new Exception(
					string.Format("There is an error while finding DUO User: {0}", ex.InnerException.Message));
			}
		}

		public Dictionary<string, object> GetDuoUserByEmail(string userEmail)
		{
			try
			{
				int limit = 300, offset = 0;
				Dictionary<string, object> duoUser = null;

				while (duoUser is null)
				{
					var duoUsers = _client.JSONApiCall<System.Collections.ArrayList>(
						"GET", "/admin/v1/users", new Dictionary<string, string> {
							{ "limit", limit.ToString() },
							{ "offset", (offset + 1).ToString() }
						});

					if (duoUsers != null)
					{
						foreach (Dictionary<string, object> user in duoUsers)
						{
							string email = user["email"] as string;

							if (!string.IsNullOrEmpty(email) && email.Equals(userEmail))
							{
								duoUser = user;
							}
						}
					}
					else
					{
						break;
					}

					offset += 300;
				}

				return duoUser;
			}
			catch (DuoException ex)
			{
				throw new WebException(
					string.Format("There is an exception with DUO Admin API: {0}", ex.Message));
			}
			catch (Exception ex)
			{
				throw new Exception(
					string.Format("There is an error while finding DUO User: {0}", ex.InnerException.Message));
			}
		}
	}
}