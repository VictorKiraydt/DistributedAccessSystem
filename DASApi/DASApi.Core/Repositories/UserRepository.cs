using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DASApi.Core.Models;
using DASApi.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace DASApi.Core.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IConfiguration _config;

		public UserRepository(IConfiguration config)
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

		public async Task<List<UserModel>> GetAll()
		{
			using (IDbConnection conn = Connection)
			{
				string sGetAllQuery = "SELECT * FROM User WITH (NOLOCK)";
				conn.Open();
				var result = await conn.QueryAsync<UserModel>(sGetAllQuery);
				return result.ToList();
			}
		}

		public async Task<UserModel> GetByID(int id)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByIdQuery = "SELECT * FROM User WITH (NOLOCK) WHERE ID = @ID";
				conn.Open();
				var result = await conn.QueryAsync<UserModel>(sGetByIdQuery, new { ID = id });
				return result.FirstOrDefault();
			}
		}

		public async Task<UserModel> GetByUserName(string userName)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByUserNameQuery = "SELECT * FROM User WITH (NOLOCK) WHERE UserName = @UserName";
				conn.Open();
				var result = await conn.QueryAsync<UserModel>(sGetByUserNameQuery, new { UserName = userName });
				return result.FirstOrDefault();
			}
		}

		public async Task<UserModel> GetByEmail(string email)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByIdQuery = "SELECT * FROM User WITH (NOLOCK) WHERE Email = @Email";
				conn.Open();
				var result = await conn.QueryAsync<UserModel>(sGetByIdQuery, new { Email = email });
				return result.FirstOrDefault();
			}
		}

		public async Task<List<UserModel>> GetByDateOfBirth(DateTime dateOfBirth)
		{
			using (IDbConnection conn = Connection)
			{
				string sGetByIdQuery = "SELECT * FROM User WITH (NOLOCK) WHERE DateOfBirth = @DateOfBirth";
				conn.Open();
				var result = await conn.QueryAsync<UserModel>(sGetByIdQuery, new { DateOfBirth = dateOfBirth });
				return result.ToList();
			}
		}

		public async Task<bool> Add(UserModel user)
		{
			using (IDbConnection conn = Connection)
			{
				string sAddUserQuery = @"INSERT INTO User VALUES(
																		FirstName		= @User.FirstName,
																		LastName		= @User.LastName,
																		UserName		= @User.UserName,
																		Email				= @User.Email,
																		Role				= @User.Role,
																		Password		= @User.Password,
																		DateOfBirth	= @User.DateOfBirth,
																		Company			= @User.Company,
																		Department	= @User.Department,
																		PrivatePhone= @User.PrivatePhone,
																		OfficePhone	= @User.OfficePhone
																)";
				conn.Open();
				var result = await conn.QueryAsync<UserModel>(sAddUserQuery, new { User = user });
				return true;
			}
		}

		public async Task<bool> Delete(UserModel user)
		{
			using (IDbConnection conn = Connection)
			{
				string sDelByIdQuery = "DELETE FROM User WHERE ID = @ID";
				conn.Open();
				var result = await conn.QueryAsync<UserModel>(sDelByIdQuery, new { ID = user.ID });
				return true;
			}
		}

		public async Task<bool> Update(UserModel user)
		{
			using (IDbConnection conn = Connection)
			{
				string sUpdateUserQuery = @"UPDATE User SET 
																			FirstName		= @User.FirstName,
																			LastName		= @User.LastName,
																			UserName		= @User.UserName,
																			Email				= @User.Email,
																			Role				= @User.Role,
																			Password		= @User.Password,
																			DateOfBirth	= @User.DateOfBirth,
																			Company			= @User.Company,
																			Department	= @User.Department,
																			PrivatePhone= @User.PrivatePhone,
																			OfficePhone	= @User.OfficePhone 
																	WHERE ID = @User.ID";
				conn.Open();
				var result = await conn.QueryAsync<UserModel>(sUpdateUserQuery, new { User = user });
				return true;
			}
		}
	}
}
