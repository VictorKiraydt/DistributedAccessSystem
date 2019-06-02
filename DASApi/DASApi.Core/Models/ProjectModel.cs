namespace DASApi.Core.Models
{
	public class ProjectModel
	{
		public int ID { get; set; }
		public string ProjectName { get; set; }
		public string Type { get; set; }
		public string OwnerID { get; set; }
		public string OwnerEmail { get; set; }
		public string Status { get; set; }
		public string Classification { get; set; }
		public System.DateTime DateOfCreating { get; set; }
		public System.DateTime DateOfDeleting { get; set; }
		public string Environment { get; set; }
	}
}
