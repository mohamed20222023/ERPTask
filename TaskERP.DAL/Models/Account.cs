using System.ComponentModel.DataAnnotations;
using TaskERP.Models;

namespace TaskERP.DAL.Models
{
	public class Account
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public List<LineOfBusiness> LineOfBusinesses { get; set; }
		public List<Employee> Employees { get; set; }
	}
}
