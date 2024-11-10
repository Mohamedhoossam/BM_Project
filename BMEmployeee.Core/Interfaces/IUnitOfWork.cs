using BMEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Core.Interfaces
{
	
	public interface IUnitOfWork
	{
		 IGenericRepository<Employee > EmployeeRepository { get; }
		 IGenericRepository<Department> DepartmentRepository { get; }
		
		Task<int> Complete();
	}
}
