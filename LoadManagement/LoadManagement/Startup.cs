using LoadManagement.LoadModels;
using LoadManagement.Services;

public class Startup
{
    public static void Main(string[] args)
    {
        var customers = GetCustomersHavingLoad(new Customer());
        foreach(var customer in customers)
        {
            Console.WriteLine($"Customers who have at least one Load : {customer.Name}");
            int fulfilledLoad = LoadService.GetNumberOfLoadsThatCanBeFulfilled(customer);
            Console.WriteLine($"Number of loads that can be fulfilled at any warehouse: {fulfilledLoad}");
        }
    }

    private static IEnumerable<Customer> GetCustomersHavingLoad(Customer customer)
    {
        var customers = from c in GetCustomers()
                        join l in LoadService.GetLoads() on c.Id equals l.Id
                        select c;
        return customers;
    }

    private static List<Customer> GetCustomers() => new();

}