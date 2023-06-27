using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskERP.DAL.Models;


namespace TaskERP.BLL.ViewModels
{
	public class EmployeeVM
	{

		public int ID { get; set; }
		[Required]
		[RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Only letters and spaces allowed")]
		public string Name { get; set; }
		[Required]
		[RegularExpression(@"^[1-3]\d{13}$", ErrorMessage = "Invalid national ID")]
		public string NationalID { get; set; }
		[Required]
		public DateTime DateOfBirth { get; set; }

		public int Age { get; set; }

		[Required]
		public string Leveles { get; set; }

		public List<string> Levelelist
		{
			get
			{
				return Leveles?.Split(',').ToList();
			}
			set
			{
				Leveles = string.Join(',', value);
			}
		}

		[Required]
		public int AccountId { get; set; }
		[Required]
		public Account Account { get; set; }


		[Required]
		public int LineOfBusinessId { get; set; }
		[Required]
		public LineOfBusiness LineOfBusiness { get; set; }

		[Required]
		public int LanguageId { get; set; }
		[Required]
		public Language Language { get; set; }




	}
}
