using LoadManagement.LoadModels;
using LoadManagement.Services;

public class Startup
{
    public static void Main(string[] args)
    {
        int fulfilledLoad = LoadService.GetNumberOfLoadsThatCanBeFulfilled(new Customer());
        Console.WriteLine($"Number of fulfilled loads : {fulfilledLoad}");
    }
}