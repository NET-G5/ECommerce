using ECommerce.Models;

namespace ECommerce.Services;

public class OrderDetailService
{
	private static List<Category> _categories =
	[
		new Category()
		{
			Id = 1,
			Name = "Sport garnitures"
		},
		new Category()
		{
			Id = 2,
			Name = "Clothes"
		},
		new Category()
		{
			Id = 3,
			Name = "Shoes"
		},
		new Category()
		{
			Id = 4,
			Name = "Watches"
		},
		new Category()
		{
			Id = 5,
			Name = "Electronics"
		},
		new Category()
		{
			Id = 6,
			Name = "Parfume"
		},
		new Category()
		{
			Id = 7,
			Name = "Kitchen garnitures"
		}
	];

	private static List<Product> _products =
	[
		new Product()
		{
			Id = 1,
			Category = _categories[0],
			Name = "Ball",
			Description = "Made in Pakistan. High quality ball",
			Price = 225000,
			Size = 5
		},
		new Product()
		{
			Id = 2,
			Category = _categories[0],
			Name = "Dumbbell",
			Description = "10 kg",
			Price = 150000,
			Size = null
		},
		new Product()
		{
			Id = 3,
			Category = _categories[0],
			Name = "Horizontal bar",
			Description = "Multifunctional horizontal bar",
			Price = 600000,
			Size = null
		},
		new Product()
		{
			Id = 4,
			Category = _categories[1],
			Name = "T-Shirt",
			Description = "100% cotton",
			Price = 50000,
			Size = 50
		},
		new Product()
		{
			Id = 5,
			Category = _categories[1],
			Name = "Jeans",
			Description = "Modern and high quality jeans from Lee",
			Price = 200000,
			Size = 52
		},
		new Product()
		{
			Id = 6,
			Category = _categories[1],
			Name = "Cap",
			Description = "High quality cap from Polo",
			Price = 100000,
			Size = null
		},
		new Product()
		{
			Id = 7,
			Category = _categories[2],
			Name = "Trainers",
			Description = "Modern and high quality trainers from Adidas",
			Price = 500000,
			Size = 40
		},
		new Product()
		{
			Id = 8,
			Category = _categories[2],
			Name = "Sneakers",
			Description = "Air Jordan",
			Price = 350000,
			Size = 40
		},
		new Product()
		{
			Id = 9,
			Category = _categories[2],
			Name = "Football boots",
			Description = "Nike - Zoom Mercurial boots",
			Price = 500000,
			Size = 40
		},
		new Product()
		{
			Id = 10,
			Category = _categories[3],
			Name = "Rolex",
			Description = "The latest model of Rolex",
			Price = 450000,
			Size = null
		},
		new Product()
		{
			Id = 11,
			Category = _categories[3],
			Name = "Shinola",
			Description = "Old Fashioned model from Shinola",
			Price = 350000,
			Size = null
		},
		new Product()
		{
			Id = 12,
			Category = _categories[3],
			Name = "Omega",
			Description = "Sports watch from Omega",
			Price = 400000,
			Size = null
		},
		new Product()
		{
			Id = 13,
			Category = _categories[4],
			Name = "Acer Laptop",
			Description = "Nitro 5 gaming laptop",
			Price = 12000000,
			Size = null
		},
		new Product()
		{
			Id = 14,
			Category = _categories[4],
			Name = "Samsung S24 Ultra",
			Description = "Titanium Gray, 12/256 GB",
			Price = 11500000,
			Size = null
		},
		new Product()
		{
			Id = 15,
			Category = _categories[4],
			Name = "Sony TV",
			Description = "43X81K Smart TV UHD 43",
			Price = 8000000,
			Size = 43
		},
		new Product()
		{
			Id = 16,
			Category = _categories[5],
			Name = "Dior Sauvage",
			Description = "Oriental, fougere aroma parfume",
			Price = 150000,
			Size = null
		},
		new Product()
		{
			Id = 17,
			Category = _categories[5],
			Name = "Chanel",
			Description = "Bleu de Chanel",
			Price = 170000,
			Size = null
		},
		new Product()
		{
			Id = 18,
			Category = _categories[5],
			Name = "Givenchy",
			Description = "Gentleman Givenchy",
			Price = 130000,
			Size = null
		},
		new Product()
		{
			Id = 19,
			Category = _categories[6],
			Name = "Blender",
			Description = "Bosch high quality blender",
			Price = 175000,
			Size = null
		},
		new Product()
		{
			Id = 20,
			Category = _categories[6],
			Name = "Meat grinder",
			Description = "Bosch meat grinder MG700",
			Price = 1700000,
			Size = null
		},
		new Product()
		{
			Id = 21,
			Category = _categories[6],
			Name = "Toaster",
			Description = "Philips HD2581/00",
			Price = 500000,
			Size = null
		}
	];

	private static List<OrderDetail> _orderDetails =
	[
		new OrderDetail()
		{
			Id = 1,
			Order = OrderService.orders[0],
			Product = _products[0],
			Amount = 1,
			TotalPrice = _products[0].Price
		},
		new OrderDetail()
		{
			Id = 2,
			Order = OrderService.orders[0],
			Product = _products[3],
			Amount = 2,
			TotalPrice = _products[3].Price * 3
		},
		new OrderDetail()
		{
			Id = 3,
			Order = OrderService.orders[1],
			Product = _products[1],
			Amount = 6,
			TotalPrice = _products[1].Price * 6
		},
		new OrderDetail()
		{
			Id = 4,
			Order = OrderService.orders[2],
			Product = _products[2],
			Amount = 1,
			TotalPrice = _products[2].Price
		},
		new OrderDetail()
		{
			Id = 5,
			Order = OrderService.orders[2],
			Product = _products[1],
			Amount = 2,
			TotalPrice = _products[1].Price * 2
		},
		new OrderDetail()
		{
			Id = 6,
			Order = OrderService.orders[3],
			Product = _products[3],
			Amount = 2,
			TotalPrice = _products[3].Price * 2
		},
		new OrderDetail()
		{
			Id = 7,
			Order = OrderService.orders[3],
			Product = _products[4],
			Amount = 1,
			TotalPrice = _products[4].Price
		},
		new OrderDetail()
		{
			Id = 8,
			Order = OrderService.orders[3],
			Product = _products[5],
			Amount = 1,
			TotalPrice = _products[1].Price
		},
		new OrderDetail()
		{
			Id = 9,
			Order = OrderService.orders[4],
			Product = _products[6],
			Amount = 1,
			TotalPrice = _products[6].Price
		},
		new OrderDetail()
		{
			Id = 10,
			Order = OrderService.orders[5],
			Product = _products[7],
			Amount = 1,
			TotalPrice = _products[7].Price
		},
		new OrderDetail()
		{
			Id = 11,
			Order = OrderService.orders[5],
			Product = _products[8],
			Amount = 2,
			TotalPrice = _products[8].Price * 2
		},
		new OrderDetail()
		{
			Id = 12,
			Order = OrderService.orders[6],
			Product = _products[8],
			Amount = 1,
			TotalPrice = _products[8].Price
		},
		new OrderDetail()
		{
			Id = 13,
			Order = OrderService.orders[6],
			Product = _products[3],
			Amount = 2,
			TotalPrice = _products[3].Price * 2
		},
		new OrderDetail()
		{
			Id = 14,
			Order = OrderService.orders[7],
			Product = _products[9],
			Amount = 1,
			TotalPrice = _products[9].Price
		},
		new OrderDetail()
		{
			Id = 15,
			Order = OrderService.orders[8],
			Product = _products[11],
			Amount = 1,
			TotalPrice = _products[11].Price
		},
		new OrderDetail()
		{
			Id = 16,
			Order = OrderService.orders[8],
			Product = _products[10],
			Amount = 1,
			TotalPrice = _products[10].Price
		},
		new OrderDetail()
		{
			Id = 17,
			Order = OrderService.orders[8],
			Product = _products[12],
			Amount = 1,
			TotalPrice = _products[12].Price
		},
		new OrderDetail()
		{
			Id = 18,
			Order = OrderService.orders[9],
			Product = _products[13],
			Amount = 1,
			TotalPrice = _products[13].Price
		},
		new OrderDetail()
		{
			Id = 19,
			Order = OrderService.orders[9],
			Product = _products[14],
			Amount = 1,
			TotalPrice = _products[14].Price
		}
	];

	public List<OrderDetail> GetOrderDetails(int orderId)
	{
		List<OrderDetail> orderDetails = [];

		foreach (var orderDetail in _orderDetails)
		{
			if (orderDetail.Order.Id == orderId)
			{
				orderDetails.Add(orderDetail);
			}
		}

		return orderDetails;
	}
}