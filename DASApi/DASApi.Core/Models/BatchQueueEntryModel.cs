using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DASApi.Core.Models
{
	public class BatchQueueEntryModel
	{
		public int ID { get; set; }
		public string ProjectID { get; set; }
		public string EventType { get; set; }
		public string TypeID { get; set; }
		public string ProcessName { get; set; }
		public string ProcessID { get; set; }
		public string Email { get; set; }
		public string UserID { get; set; }
		public string Status { get; set; }
		public System.DateTime DateOfQueue { get; set; }
		public System.DateTime DateOfDequeue { get; set; }
	}
}
