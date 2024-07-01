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

		public int OrderId { get; set; }

		public int ProductId { get; set; }

		public double Amount { get; set; }

		public double TotalPrice { get; set; }
	}
}
