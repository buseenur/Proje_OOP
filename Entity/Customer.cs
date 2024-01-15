using System;
using System.ComponentModel.DataAnnotations;

namespace Proje_OOP.Entity
{
	public class Customer
	{
        [Key]
        public int CustomerID { get; set; }

		public string CustomerName { get; set; }

		public string CustomerCity { get; set; }


	}
}

