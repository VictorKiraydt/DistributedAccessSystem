namespace DASApi.Core.Models
{
	public class UserModel
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }
		public string Password { get; set; }
		public System.DateTime DateOfBirth { get; set; }
		public string Company { get; set; }
		public string Department { get; set; }
		public string PrivatePhone { get; set; }
		public string OfficePhone { get; set; }
	}
}
