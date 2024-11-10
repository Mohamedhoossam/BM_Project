using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Core.Entities
{
	public class Employee
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Title { get; set; }
		public string? Address { get; set; }
		public string? Image { get; set; }

		public Guid DeptId { get; set; }

		[ForeignKey("Department")]
		Department? Department { get; set; }
	}
}
