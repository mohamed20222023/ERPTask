using System.ComponentModel.DataAnnotations;
using TaskERP.Models;

namespace TaskERP.DAL.Models
{
	public class Language
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public List<Employee> Employees { get; set; }
	}
}
