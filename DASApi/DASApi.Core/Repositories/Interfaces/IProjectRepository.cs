using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DASApi.Core.Models;

namespace DASApi.Core.Repositories.Interfaces
{
	public interface IProjectRepository
	{
		Task<List<ProjectModel>> GetAll();
		Task<ProjectModel> GetByID(int id);
		Task<ProjectModel> GetByOwnerEmail(string email);
		Task<List<ProjectModel>> GetByDateOfCreating(System.DateTime dateOfCreating);
		Task<bool> Add(ProjectModel project);
		Task<bool> Delete(ProjectModel project);
		Task<bool> Update(ProjectModel project);
	}
}
