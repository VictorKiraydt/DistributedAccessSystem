using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DASApi.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DASApi.Core.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		// GET api/values
		[HttpGet, Authorize(Roles = "Manager")]
		public IEnumerable<CustomerModel> Get()
		{
			return new List<CustomerModel>
			{
				new CustomerModel { FirstName = "John", LastName = "Doe" },
				new CustomerModel { FirstName = "Jane", LastName = "Doe" }
			};
		}
	}
}