using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskERP.BLL.Interface;
using TaskERP.BLL.ViewModels;
using TaskERP.DAL.Models;
using TaskERP.Data;
using TaskERP.Models;

namespace TaskERP.Controllers
{
	[Authorize]
	public class HomeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepository;
		private readonly ApplicationContext _context;
		private readonly IMapper _mapper;

		public HomeController(IEmployeeRepo employeeRepository , ApplicationContext context , IMapper mapper)
        {
            _employeeRepository = employeeRepository;
			_context = context;
			_mapper = mapper;
		}

		#region Indexes
		public async Task<IActionResult> Index()
		{
			var employees = await _employeeRepository.GetAllAsync();
			var result = _mapper.Map<IEnumerable<EmployeeVM>>(employees);
			return View(result);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AdminIndex()
		{
			var employees = await _employeeRepository.GetAllAsync();
			var result = _mapper.Map<IEnumerable<EmployeeVM>>(employees);
			return View(result);
		}

		#endregion


		#region Detail
		public async Task<IActionResult> Detail(int id)
		{
			var employee = await _employeeRepository.GetByIdAsync(id);
			var result = _mapper.Map<EmployeeVM>(employee);

			if (employee == null)
			{
				return RedirectToAction(nameof(NotFound));
			}
			return View(result);
		}
		#endregion



		#region Create 
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
		{

			ViewBag.Accounts = _context.Accounts.ToList();
			ViewBag.LineOfBusiness = _context.LineOfBusinesses.ToList();
			ViewBag.Language = _context.Languages.ToList();
			ViewBag.LanguageLeveles = _context.Leveles;
			var employeeVM = new EmployeeVM();

			return View(employeeVM);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create(EmployeeVM employee)
		{

			var result = _mapper.Map<Employee>(employee);


			ViewBag.Accounts = _context.Accounts.ToList();
			ViewBag.LineOfBusiness = _context.LineOfBusinesses.ToList();
			ViewBag.Language = _context.Languages.ToList();
			ViewBag.LanguageLeveles = _context.Leveles; ;

			await _employeeRepository.CreateAsync(result);
			return RedirectToAction(nameof(AdminIndex));
		}

		#endregion



		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id)
		{

			ViewBag.Accounts = _context.Accounts.ToList();
			ViewBag.LineOfBusiness = _context.LineOfBusinesses.ToList();
			ViewBag.Language = _context.Languages.ToList();
			ViewBag.LanguageLeveles = _context.Leveles; ;

			var employee = await _employeeRepository.GetByIdAsync(id);
			var result = _mapper.Map<EmployeeVM>(employee);
			if (employee == null)
			{
				return RedirectToAction(nameof(NotFound));
			}
			return View(result);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(EmployeeVM employee)
		{

			ViewBag.Accounts = _context.Accounts.ToList();
			ViewBag.LineOfBusiness = _context.LineOfBusinesses.ToList();
			ViewBag.Language = _context.Languages.ToList();
			ViewBag.LanguageLeveles = _context.Leveles;

			var result = _mapper.Map<Employee>(employee);
			await _employeeRepository.UpdateAsync(result);
			return RedirectToAction(nameof(AdminIndex));
		}


		#region Delete
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var employee = await _employeeRepository.GetByIdAsync(id);
			if (employee == null)
			{
				return RedirectToAction(nameof(NotFound));
			}
			return View(employee);
		}


		[Authorize(Roles = "Admin")]
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _employeeRepository.DeleteAsync(id);
			return RedirectToAction(nameof(AdminIndex));
		}

		#endregion


		#region Dropdown helper and NotFound

		public IActionResult GetLineOfBusiness(int accountId)
		{
			var lines = _context.LineOfBusinesses
						.Where(l => l.AccountId == accountId)
						.OrderBy(o => o.Name)
						.ToList();

			return Ok(lines);
		}


		public async Task<IActionResult> NotFound()
		{
				return View();
		}

		#endregion
	}
}