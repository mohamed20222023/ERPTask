using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskERP.Models;

namespace TaskERP.DAL.Models
{
	public class LineOfBusiness
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }


		[ForeignKey("Account")]
		public int AccountId { get; set; }
		public Account Account { get; set; }


		public List<Employee> Employees { get; set; }
	}
}
