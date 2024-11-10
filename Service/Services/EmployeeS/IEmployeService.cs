using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMEmployee.Core.DTO;
using BMEmployee.Core.Entities;

namespace BMEmployee.Service.Services.EmployeeS
{
	public interface IEmployeService
	{
		Task<IEnumerable<EmployeeDTO>> GetAllService();
		Task<EmployeeDTO> GetByIdService(int id);
		Task DeleteService (Guid id);
		Task UpdateService(EmployeeDTO entity,Guid id);
		Task CreateService (EmployeeDTO entity);

		


	}
}
