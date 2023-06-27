using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskERP.BLL.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }


		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		[MinLength(5, ErrorMessage = "Minimum Length Of Password is 5 Chars")]
		public string Password { get; set; }

	}
}
