using TaskERP.Models;
using Microsoft.EntityFrameworkCore;
using TaskERP.Data;
using TaskERP.BLL.Interface;
using TaskERP.BLL.ViewModels;

namespace TaskERP.BLL
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationContext _dbContext;

        public EmployeeRepo(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

		public async Task<List<Employee>> GetAllAsync()
		{
			return await _dbContext.Employees
				.Include(e => e.Account)
				.Include(e => e.LineOfBusiness)
				.Include(e => e.Language)
				.ToListAsync();
		}

		public async Task<Employee> GetByIdAsync(int id)
		{
			return await _dbContext.Employees
				.Include(e => e.Account)
				.Include(e => e.LineOfBusiness)
				.Include(e => e.Language)
				.FirstOrDefaultAsync(e => e.ID == id);
		}

		public async Task<Employee> CreateAsync(Employee employee)
		{
			

			_dbContext.Employees.Add(employee);
			await _dbContext.SaveChangesAsync();
			return employee;
		}

		public async Task<Employee> UpdateAsync(Employee employee)
		{
			var oldData = await _dbContext.Employees.FindAsync(employee.ID);
			//var str = "";
			//foreach (var item in employee.Leveles)
			//{
			//	str += item;
			//}
			//employee.Leveles = str;
			// detach the tracked entity
			_dbContext.Entry(oldData).State = EntityState.Detached;

			_dbContext.Entry(employee).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();

			return employee;
		}

		public async Task DeleteAsync(int id)
		{
			var employee = await _dbContext.Employees.FindAsync(id);
			_dbContext.Employees.Remove(employee);
			await _dbContext.SaveChangesAsync();
		}
	}
}