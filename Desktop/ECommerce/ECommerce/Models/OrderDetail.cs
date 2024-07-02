using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }

		public Order Order { get; set; }

		public Product Product { get; set; }

		public double Amount { get; set; }

		public double TotalPrice { get; set; }
	}
}
