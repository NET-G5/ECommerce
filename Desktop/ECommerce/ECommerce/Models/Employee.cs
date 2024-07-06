namespace ECommerce.Models;

public class Employee
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

	public override string ToString()
	{
		return $"{LastName} {FirstName}";
	}
}
