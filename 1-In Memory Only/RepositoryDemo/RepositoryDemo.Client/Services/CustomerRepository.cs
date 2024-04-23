using RepositoryDemo.Client.Models;
namespace RepositoryDemo.Client.Services;

public class CustomerRepository : APIRepository<Customer>
{
    HttpClient http;

    static string controllerName = "inmemorycustomers";

    public CustomerRepository(HttpClient _http)
       : base(_http, controllerName, "Id")
    {
        http = _http;
    }
}
