using BMEmployee.Core.DTO;
using BMEmployee.Core.Entities;
using BMEmployee.Core.Interfaces;
using BMEmployee.Service.Services.EmployeeS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Service.Services.EmployeeS
{
	public class EmployeeService : IEmployeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public EmployeeService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

		public async Task CreateService(EmployeeDTO entity)
		{
			
			
			await _unitOfWork.EmployeeRepository.Add(new Employee() {
			Email = entity.Email,
			Address = entity.Address,
			Name= entity.Name,
			Phone= entity.Phone,
			Title= entity.Title,
			
			
			
			});
			await _unitOfWork.Complete();
		}

		public Task DeleteService(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<EmployeeDTO>> GetAllService()
		{
			throw new NotImplementedException();
		}

		public Task<EmployeeDTO> GetByIdService(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateService(EmployeeDTO entity, Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
