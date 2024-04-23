using RepositoryDemo.Client.Models;
namespace RepositoryDemo.Client.Services;

public class CustomerRepository : APIRepository<Customer>
{
    HttpClient http;

    // swap out the controller name
    //static string controllerName = "inmemorycustomers";
    static string controllerName = "efcustomers";

    public CustomerRepository(HttpClient _http)
       : base(_http, controllerName, "Id")
    {
        http = _http;
    }
}
