using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DASApi.Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DuoController : ControllerBase
	{
		public IConfiguration Configuration { get; }
		private Duo.DuoApi _client;

		public DuoController(IConfiguration configuration)
		{
			Configuration = configuration;

			string ikey = Configuration["Duo:ikey"];
			string skey = Configuration["Duo:skey"];
			string host = Configuration["Duo:host"];

			_client = new Duo.DuoApi(ikey, skey, host);
		}

		// GET api/values
		[HttpGet("{userEmail}"), Route("find-user"), Authorize(Roles = "Manager")]
		[ProducesResponseType(typeof(Dictionary<string, object>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult FindUser([FromHeader]string userEmail)
		{
			if (userEmail == null)
			{
				return BadRequest("Invalid Client Request");
			}

			IActionResult response = NotFound();

			var duoUser = GetDuoUserByUsername(userEmail);
			if (duoUser is null)
			{
				duoUser = GetDuoUserByEmail(userEmail);
			}

			if (duoUser != null)
			{
				response = Ok(new { DuoUser = duoUser });
			}

			return response;
		}

		[HttpDelete("{userPhones}"), Route("tfa-reset"), Authorize(Roles = "Manager")]
		public IActionResult TfaReset([FromBody]IList<Dictionary<string, object>> userPhones)
		{
			if (userPhones == null)
			{
				return BadRequest("Invalid Client Request");
			}

			IActionResult response = NotFound();

			if (userPhones.Count > 0)
			{
				foreach (Dictionary<string, object> phoneObj in userPhones)
				{
					string phoneId = phoneObj["phone_id"] as string;

					try
					{
						//var delPhone = _client.JSONApiCall<System.Collections.ArrayList>(
						//				"DELETE", string.Format("/admin/v1/phones/{0}", phoneId), new Dictionary<string, string>());
					}
					catch (Duo.DuoException ex)
					{
						throw new WebException(
							string.Format("There is an exception with DUO Admin API: {0}", ex.Message));
					}
					catch (Exception ex)
					{
						throw new Exception(
							string.Format("There is an error while resetting the phone-s (DUO Config logic): {0}", ex.InnerException.Message));
					}
				}

				response = Ok(new { Message = "The user's phone(s) have been deleted successfully." });
			}

			return response;
		}

		private Dictionary<string, object> GetDuoUserByUsername(string userName)
		{
			try
			{
				Dictionary<string, object> duoUser = null;

				var serializedDuoUserObj = _client.JSONApiCall<object>(
					"GET", "/admin/v1/users", new Dictionary<string, string> {
						{ "username", userName }
					});
				var duoUserArr = Newtonsoft.Json.JsonConvert
													.DeserializeObject<System.Collections.ArrayList>(serializedDuoUserObj.ToString());

				if (duoUserArr.Count > 0)
				{
					duoUser = Newtonsoft.Json.JsonConvert
											.DeserializeObject<Dictionary<string, object>>(duoUserArr[0].ToString());
				}

				return duoUser;
			}
			catch (Duo.DuoException ex)
			{
				throw new WebException(
					string.Format("There is an exception with DUO Admin API: {0}", ex.Message));
			}
			catch (Exception ex)
			{
				throw new Exception(
					string.Format("There is an error while finding DUO User (DUO Config logic): {0}", ex.InnerException.Message));
			}
		}

		private Dictionary<string, object> GetDuoUserByEmail(string userEmail)
		{
			try
			{
				int limit = 300, offset = 0;
				Dictionary<string, object> duoUser = null;

				while (duoUser is null)
				{
					var serializedDuoUsersObj = _client.JSONApiCall<object>(
						"GET", "/admin/v1/users", new Dictionary<string, string> {
							{ "limit", limit.ToString() },
							{ "offset", (offset + 1).ToString() }
						});
					var duoUsersArr = Newtonsoft.Json.JsonConvert
															.DeserializeObject<System.Collections.ArrayList>(serializedDuoUsersObj.ToString());

					if (duoUsersArr.Count > 0)
					{
						foreach (var duoUserObj in duoUsersArr)
						{
							var user = Newtonsoft.Json.JsonConvert
													.DeserializeObject<Dictionary<string, object>>(duoUserObj.ToString());

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
			catch (Duo.DuoException ex)
			{
				throw new WebException(
					string.Format("There is an exception with DUO Admin API: {0}", ex.Message));
			}
			catch (Exception ex)
			{
				throw new Exception(
					string.Format("There is an error while finding DUO User (DUO Config logic): {0}", ex.InnerException.Message));
			}
		}
	}
}