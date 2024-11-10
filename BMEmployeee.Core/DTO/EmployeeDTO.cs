﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Core.DTO
{
	public class EmployeeDTO
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Title { get; set; }
		public string? Address { get; set; }
		public string? Image { get; set; }
	}
}