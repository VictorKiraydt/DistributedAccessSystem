using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DASApi.Core.Models;

namespace DASApi.Core.Repositories.Interfaces
{
	public interface IUserRepository
	{
		Task<List<UserModel>> GetAll();
		Task<UserModel> GetByID(int id);
		Task<UserModel> GetByUserName(string userName);
		Task<UserModel> GetByEmail(string email);
		Task<List<UserModel>> GetByDateOfBirth(System.DateTime dateOfBirth);
		Task<bool> Add(UserModel user);
		Task<bool> Delete(UserModel user);
		Task<bool> Update(UserModel user);
	}
}
