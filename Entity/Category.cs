using System;
using System.ComponentModel.DataAnnotations;

namespace Proje_OOP.Entity
{
	public class Category
	{
		[Key]
		public int CategoryID { get; set; }

		public string CategoryName { get; set; }


	}
}

