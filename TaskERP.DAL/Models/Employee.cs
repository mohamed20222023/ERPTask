using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskERP.DAL.Models;

namespace TaskERP.Models
{
	public class Employee
    {
        public int ID { get; set; }

		[Required]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain letters only.")]
		public string Name { get; set; }


		[Required]
		[RegularExpression(@"^\d{14}$", ErrorMessage = "National ID must contain 14 numbers only.")]
		public string NationalID { get; set; }


		[Required]
		//[CustomValidation(typeof(Employee), "ValidateAge")]
		public DateTime DateOfBirth { get; set; }


		public int Age { get; set; }

		
		public string Leveles { get; set; }


		[Required]
		[ForeignKey("LineOfBusiness")]
		public int LineOfBusinessId { get; set; }
		public LineOfBusiness LineOfBusiness { get; set; }


		[Required]
		[ForeignKey("Language")]
		public int LanguageId { get; set; }
		public Language Language { get; set; }


		[Required]
		public int AccountId { get; set; }
		public Account Account { get; set; }



	}


}
