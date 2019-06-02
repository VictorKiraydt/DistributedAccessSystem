using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DASApi.Core.Models;

namespace DASApi.Core.Repositories.Interfaces
{
	public interface IBatchQueueEntryRepository
	{
		Task<List<BatchQueueEntryModel>> GetAll();
		Task<BatchQueueEntryModel> GetByID(int id);
		Task<BatchQueueEntryModel> GetProjectID(int projectId);
		Task<BatchQueueEntryModel> GetByEmail(string email);
		Task<List<BatchQueueEntryModel>> GetByDateOfQueue(System.DateTime dateOfQueue);
		Task<List<BatchQueueEntryModel>> GetByDateOfDequeue(System.DateTime dateOfDequeue);

		//Task<bool> Add(BatchQueueEntryModel project);
		//Task<bool> Delete(BatchQueueEntryModel project);
		//Task<bool> Update(BatchQueueEntryModel project);
	}
}
