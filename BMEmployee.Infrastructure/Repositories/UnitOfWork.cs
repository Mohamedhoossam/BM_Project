using BMEmployee.Infrastructure.Contexts;
using BMEmployee.Core.Entities;
using BMEmployee.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private readonly AppDbContext _context;
		private IGenericRepository<Employee> employeeRepository;
		private IGenericRepository<Department> departmentRepository;
	
		public UnitOfWork(AppDbContext context)
        {
			_context = context;

		}

		public IGenericRepository<Employee> EmployeeRepository
			=> employeeRepository ??= new GenericRepository<Employee>(_context);
		public IGenericRepository<Department> DepartmentRepository
			=> departmentRepository ??= new GenericRepository<Department>(_context);



		public async Task<int> Complete()
		{
			return await _context.SaveChangesAsync();
			
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
