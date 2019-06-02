using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DASApi.Core.Models;
using DASApi.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DASApi.Core.Repositories
{
	public class BatchQueueEntryRepository : IBatchQueueEntryRepository
	{
		private readonly IConfiguration _config;

		public BatchQueueEntryRepository(IConfiguration config)
		{
			_config = config;
		}

		public IDbConnection Connection
		{
			get
			{
				return new SqlConnection(_config.GetConnectionString("DBConnectionString"));
			}
		}

		public async Task<List<BatchQueueEntryModel>> GetAll()
		{
			using (IDbConnection conn = Connection)
			{
				string sGetAllQuery = "SELECT * FROM BatchQueueEntry WITH (NOLOCK)";
				conn.Open();
				var result = await conn.QueryAsync<BatchQueueEntryModel>(sGetAllQuery);
				return result.ToList();
			}
		}

		public async Task<BatchQueueEntryModel> GetByID(int id)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByIdQuery = "SELECT * FROM BatchQueueEntry WITH (NOLOCK) WHERE ID = @ID";
				conn.Open();
				var result = await conn.QueryAsync<BatchQueueEntryModel>(sGetByIdQuery, new { ID = id });
				return result.FirstOrDefault();
			}
		}

		public async Task<BatchQueueEntryModel> GetProjectID(int projectID)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByProjectIdQuery = "SELECT * FROM BatchQueueEntry WITH (NOLOCK) WHERE ProjectID = @ProjectID";
				conn.Open();
				var result = await conn.QueryAsync<BatchQueueEntryModel>(sGetByProjectIdQuery, new { ProjectID = projectID });
				return result.FirstOrDefault();
			}
		}

		public async Task<BatchQueueEntryModel> GetByEmail(string email)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByEmailQuery = "SELECT * FROM BatchQueueEntry WITH (NOLOCK) WHERE Email = @Email";
				conn.Open();
				var result = await conn.QueryAsync<BatchQueueEntryModel>(sGetByEmailQuery, new { Email = email });
				return result.FirstOrDefault();
			}
		}

		public async Task<List<BatchQueueEntryModel>> GetByDateOfQueue(DateTime dateOfQueue)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByDateQuery = "SELECT * FROM BatchQueueEntry WITH (NOLOCK) WHERE DateOfQueue = @DateOfQueue";
				conn.Open();
				var result = await conn.QueryAsync<BatchQueueEntryModel>(sGetByDateQuery, new { DateOfQueue = dateOfQueue });
				return result.ToList();
			}
		}

		public async Task<List<BatchQueueEntryModel>> GetByDateOfDequeue(DateTime dateOfDequeue)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByDateQuery = "SELECT * FROM BatchQueueEntry WITH (NOLOCK) WHERE DateOfDequeue = @DateOfDequeue";
				conn.Open();
				var result = await conn.QueryAsync<BatchQueueEntryModel>(sGetByDateQuery, new { DateOfDequeue = dateOfDequeue });
				return result.ToList();
			}
		}
	}
}
