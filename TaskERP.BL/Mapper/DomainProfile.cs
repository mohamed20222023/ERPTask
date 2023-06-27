using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskERP.BLL.ViewModels;
using TaskERP.Models;

namespace TaskERP.BLL.Mapper
{
	public class DomainProfile:Profile
	{

		public DomainProfile()
		{
			CreateMap<Employee, EmployeeVM>();
			CreateMap<EmployeeVM, Employee >();
		}

	}
}
