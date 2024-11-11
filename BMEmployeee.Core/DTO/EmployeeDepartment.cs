using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Core.DTO
{
	public class EmployeeDepartment
	{

        public Guid EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
    }
}
