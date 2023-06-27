using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using TaskERP.BLL.ViewModels;
using TaskERP.Data;

namespace TaskERP.Controllers
{
	public class ChartController : Controller
	{
		private readonly ApplicationContext _context;

		public ChartController(ApplicationContext context)
		{
			_context = context;
		}


		public IActionResult Chart()
		{
			var data = _context.Employees
				.GroupBy(e => e.Language.Name)
				.Select(g => new 
					ChartViewModel {
						Label = g.Key,
						Value = g.Count().ToString()
						 })
					//Language = g.Key, Count = g.Count() })
				.ToList();

			return Ok(data);
		}
	}
}
