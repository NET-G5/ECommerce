using ECommerce.Models;

namespace ECommerce.Services;

public class OrderService
{
    internal static List<Order> orders =
    [
        new Order ()
        {
            Id = 1,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "Ro'zimuhammad",
                LastName = "Abdullayev",
                PhoneNumber = "994801084"
            },
            Status = OrderStatus.Pending,
            OrderedDate = new DateTime(2024, 07, 02),
            ExpireDate = new DateTime(2024, 07, 05),
            SoldDate = null
        },

        new Order()
        {
            Id = 2,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "Bobur",
                LastName = "Boboyev",
                PhoneNumber = "934773206"
            },
            Status = OrderStatus.Pending,
            OrderedDate = new DateTime(2024, 07, 02),
            ExpireDate = new DateTime(2024, 07, 05),
            SoldDate = null
        },

        new Order()
        {
            Id = 3,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "Ramazon",
                LastName = "Choriyev",
                PhoneNumber = "918327575"
            },
            Status = OrderStatus.Pending,
            OrderedDate = DateTime.Now,
            ExpireDate =  DateTime.Now + new TimeSpan(3, 0, 0, 0),
            SoldDate = null
        },

        new Order()
        {
            Id = 4,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "Jamshidbek",
                LastName = "Choriyev",
                PhoneNumber = "918327575"
            },
            Status = OrderStatus.Pending,
            OrderedDate = DateTime.Now - new TimeSpan(1, 0, 0, 0),
            ExpireDate = DateTime.Now + new TimeSpan(2, 0, 0, 0),
            SoldDate = null
        },

        new Order()
        {
            Id = 5,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "98726526"
            },
            Status = OrderStatus.Pending,
            OrderedDate = DateTime.Now,
            ExpireDate = DateTime.Now + new TimeSpan(3, 0, 0, 0),
            SoldDate = null
        },

        new Order()
        {
            Id = 6,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "George",
                LastName = "Smith",
                PhoneNumber = "657498428879"
            },
            Status = OrderStatus.Pending,
            OrderedDate = DateTime.Now,
            ExpireDate = DateTime.Now + new TimeSpan(3, 0, 0, 0),
            SoldDate = null
        },

        new Order()
        {
            Id = 7,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "Cristiano",
                LastName = "Ronaldo",
                PhoneNumber = "659816565"
            },
            Status = OrderStatus.Pending,
            OrderedDate = new DateTime (2024, 07, 02),
            ExpireDate = new DateTime(2024, 07, 05),
            SoldDate = null
        },

        new Order()
        {
            Id = 8,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "Leonardo",
                LastName = "Di Kaprio",
                PhoneNumber = "79842326544"
            },
            Status = OrderStatus.Pending,
            OrderedDate = DateTime.Now,
            ExpireDate = DateTime.Now + new TimeSpan(3, 0, 0, 0),
            SoldDate = null
        },

        new Order()
        {
            Id = 9,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "Eldor",
                LastName = "Shomurodov",
                PhoneNumber = "956598746"
            },
            Status = OrderStatus.Pending,
            OrderedDate = DateTime.Now - new TimeSpan(1, 0, 0, 0),
            ExpireDate = DateTime.Now + new TimeSpan(2, 0, 0, 0),
            SoldDate = null
        },

        new Order()
        {
            Id = 10,
            Customer = new Customer ()
            {
                Id = 1,
                FirstName = "Iker",
                LastName = "Casillas",
                PhoneNumber = "65489765"
            },
            Status = OrderStatus.Pending,
            OrderedDate = DateTime.Now,
            ExpireDate = DateTime.Now + new TimeSpan(3, 0, 0, 0),
            SoldDate = null
        }
    ];

    private void CheckingForRefund()
    {
        for (int i = 0; i < orders.Count; i++)
        {
            if (orders[i].ExpireDate < DateTime.Now && orders[i].SoldDate is null)
            {
                orders[i].Status = OrderStatus.Refunded;
            }
        }
    }

    public List<Order> GetOrder(int? orderId = null, string customer = "", OrderStatus? status = null)
    {
        CheckingForRefund();

        List<Order> searchOrders = [];

        if (orderId is not null && !string.IsNullOrEmpty(customer) && status is not null)
        {
            foreach (var order in orders)
            {
                if (order.Id == orderId &&
                   (order.Customer.FirstName.StartsWith(customer, StringComparison.InvariantCultureIgnoreCase) ||
                   order.Customer.LastName.StartsWith(customer, StringComparison.InvariantCultureIgnoreCase)) &&
                   order.Status == status)
                {
                    searchOrders.Add(order);
                }
            }
        }
        else if (orderId is not null && !string.IsNullOrEmpty(customer))
        {
            foreach (var order in orders)
            {
                if (order.Id == orderId &&
                   (order.Customer.FirstName.StartsWith(customer, StringComparison.InvariantCultureIgnoreCase) ||
                   order.Customer.LastName.StartsWith(customer, StringComparison.InvariantCultureIgnoreCase)))
                {
                    searchOrders.Add(order);
                }
            }
        }
        else if (orderId is not null && status is not null)
        {
            foreach (var order in orders)
            {
                if (order.Id == orderId && order.Status == status)
                {
                    searchOrders.Add(order);
                }
            }
        }
        else if (!string.IsNullOrEmpty(customer) && status is not null)
        {
            foreach (var order in orders)
            {
                if ((order.Customer.FirstName.StartsWith(customer, StringComparison.InvariantCultureIgnoreCase) ||
                   order.Customer.LastName.StartsWith(customer, StringComparison.InvariantCultureIgnoreCase)) &&
                    order.Status == status)
                {
                    searchOrders.Add(order);
                }
            }
        }
        else if (orderId is not null)
        {
            foreach (var order in orders)
            {
                if (order.Id == orderId)
                {
                    searchOrders.Add(order);
                }
            }
        }
        else if (!string.IsNullOrEmpty(customer))
        {
            foreach (var order in orders)
            {
                if (order.Customer.FirstName.StartsWith(customer, StringComparison.InvariantCultureIgnoreCase) ||
                   order.Customer.LastName.StartsWith(customer, StringComparison.InvariantCultureIgnoreCase))
                {
                    searchOrders.Add(order);
                }
            }
        }
        else if (status is not null)
        {
            foreach (var order in orders)
            {
                if (order.Status == status)
                {
                    searchOrders.Add(order);
                }
            }
        }
        else
        {
            return orders;
        }

        return searchOrders;
    }

    public List<Order> UpdateOrder(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        orders[order.Id - 1] = order;

        return orders;
    }
}