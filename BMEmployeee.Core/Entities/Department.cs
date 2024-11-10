﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMEmployee.Core.Entities
{
	public class Department
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }

		List<Employee>? employees { get; set; }=new List<Employee>();


	}
}
