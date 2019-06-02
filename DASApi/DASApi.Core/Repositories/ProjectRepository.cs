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
	public class ProjectRepository : IProjectRepository
	{
		private readonly IConfiguration _config;

		public ProjectRepository(IConfiguration config)
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

		public async Task<List<ProjectModel>> GetAll()
		{
			using (IDbConnection conn = Connection)
			{
				string sGetAllQuery = "SELECT * FROM Project WITH (NOLOCK)";
				conn.Open();
				var result = await conn.QueryAsync<ProjectModel>(sGetAllQuery);
				return result.ToList();
			}
		}

		public async Task<ProjectModel> GetByID(int id)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByIdQuery = "SELECT * FROM Project WITH (NOLOCK) WHERE ID = @ID";
				conn.Open();
				var result = await conn.QueryAsync<ProjectModel>(sGetByIdQuery, new { ID = id });
				return result.FirstOrDefault();
			}
		}

		public async Task<ProjectModel> GetByOwnerEmail(string email)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByEmailQuery = "SELECT * FROM Project WITH (NOLOCK) WHERE OwnerEmail = @OwnerEmail";
				conn.Open();
				var result = await conn.QueryAsync<ProjectModel>(sGetByEmailQuery, new { OwnerEmail = email });
				return result.FirstOrDefault();
			}
		}

		public async Task<List<ProjectModel>> GetByDateOfCreating(DateTime dateOfCreating)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByDateQuery = "SELECT * FROM Project WITH (NOLOCK) WHERE DateOfCreating = @DateOfCreating";
				conn.Open();
				var result = await conn.QueryAsync<ProjectModel>(sGetByDateQuery, new { DateOfCreating = dateOfCreating });
				return result.ToList();
			}
		}

		public async Task<bool> Add(ProjectModel project)
		{
			using (IDbConnection conn = Connection)
			{
				string sAddProjectQuery = @"INSERT INTO Project VALUES(
																		ProjectName		= @Project.ProjectName,
																		Type					= @Project.Type,
																		OwnerID				= @Project.OwnerID,
																		OwnerEmail		= @Project.OwnerEmail,
																		Status				= @Project.Status,
																		Classification= @Project.Classification,
																		DateOfCreating= @Project.DateOfCreating,
																		DateOfDeleting= @Project.DateOfDeleting,
																		Environment		= @Project.Environment
																	)";
				conn.Open();
				var result = await conn.QueryAsync<ProjectModel>(sAddProjectQuery, new { Project = project });
				return true;
			}
		}

		public async Task<bool> Delete(ProjectModel project)
		{
			using (IDbConnection conn = Connection)
			{
				string sDelByIdQuery = "DELETE FROM Project WHERE ID = @ID";
				conn.Open();
				var result = await conn.QueryAsync<ProjectModel>(sDelByIdQuery, new { ID = project.ID });
				return true;
			}
		}

		public async Task<bool> Update(ProjectModel project)
		{
			using (IDbConnection conn = Connection)
			{
				string sUpdateProjectQuery = @"UPDATE Project SET 
																				ProjectName		= @Project.ProjectName,
																				Type					= @Project.Type,
																				OwnerID				= @Project.OwnerID,
																				OwnerEmail		= @Project.OwnerEmail,
																				Status				= @Project.Status,
																				Classification= @Project.Classification,
																				DateOfCreating= @Project.DateOfCreating,
																				DateOfDeleting= @Project.DateOfDeleting,
																				Environment		= @Project.Environment 
																			WHERE ID = @Project.ID";
				conn.Open();
				var result = await conn.QueryAsync<ProjectModel>(sUpdateProjectQuery, new { Project = project });
				return true;
			}
		}
	}
}
