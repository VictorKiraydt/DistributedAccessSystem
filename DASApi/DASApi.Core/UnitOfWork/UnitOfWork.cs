using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DASApi.Core.Repositories;
using Microsoft.Extensions.Configuration;

namespace DASApi.Core.UnitOfWork
{
	public class UnitOfWork
	{
		private UserRepository _userRepository;
		private ProjectRepository _projectRepository;
		private BatchQueueEntryRepository _batchQueueEntryRepository;
		private readonly IConfiguration _config;

		public UnitOfWork(IConfiguration config)
		{
			_config = config;
		}

		public UserRepository UserRepository
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserRepository(_config);
				}
				return _userRepository;
			}
		}

		public ProjectRepository ProjectRepository
		{
			get
			{
				if (_projectRepository == null)
				{
					_projectRepository = new ProjectRepository(_config);
				}
				return _projectRepository;
			}
		}

		public BatchQueueEntryRepository BatchQueueEntryRepository
		{
			get
			{
				if (_batchQueueEntryRepository == null)
				{
					_batchQueueEntryRepository = new BatchQueueEntryRepository(_config);
				}
				return _batchQueueEntryRepository;
			}
		}
	}
}
