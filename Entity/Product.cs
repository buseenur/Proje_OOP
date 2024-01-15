using System;
using System.ComponentModel.DataAnnotations;

namespace Proje_OOP.Entity
{
	public class Product
	{
        [Key]
        public int ProductID { get; set; }

		public string ProductName { get; set; }

		public decimal Price { get; set; }

		public int Stock { get; set; }
	}
}

