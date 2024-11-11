using BMEmployee.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Service.Services.DepartmentS
{
	public interface IDepartmentService
	{
		Task<GeneralResponse> GetAllService();
		Task<GeneralResponse> GetByIdService(Guid id);
		Task<GeneralResponse> DeleteService(Guid id);
		Task<GeneralResponse> UpdateService(DrpartmentUpdateDTO entity, Guid id);
		Task<GeneralResponse> CreateService(DepartmentCreateDTO entity);

	}
}
