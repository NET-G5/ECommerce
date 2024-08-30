namespace ECommerce.Models;

public class Product:OrderDetail
{
    public int Id { get; set; }

    public Category Category { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public double? Size { get; set; }
}