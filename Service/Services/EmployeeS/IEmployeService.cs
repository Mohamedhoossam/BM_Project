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
		Task<GeneralResponse> GetAllService();
		Task<GeneralResponse> GetByIdService(Guid id);
		Task DeleteService (Guid id);
		Task<GeneralResponse> UpdateService(EmployeUpdateDto entity,Guid id);
		Task<GeneralResponse> CreateService (EmployeeDTO entity);

		


	}
}
