using TaskERP.BLL.ViewModels;
using TaskERP.Models;

namespace TaskERP.BLL.Interface
{
	public interface IEmployeeRepo
	{
		Task<List<Employee>> GetAllAsync();
		Task<Employee> GetByIdAsync(int id);
		Task<Employee> CreateAsync(Employee employee);
		Task<Employee> UpdateAsync(Employee employee);
		Task DeleteAsync(int id);
	}
}
