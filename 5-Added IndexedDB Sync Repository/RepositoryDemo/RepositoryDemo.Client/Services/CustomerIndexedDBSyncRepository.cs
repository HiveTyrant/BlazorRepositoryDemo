using Microsoft.JSInterop;
using RepositoryDemo.Client.Services;

public class CustomerIndexedDBSyncRepository : IndexedDBSyncRepository<Customer>
{
    public CustomerIndexedDBSyncRepository(IBlazorDbFactory dbFactory,
        CustomerRepository customerRepository, IJSRuntime jsRuntime)
        : base("RepositoryDemo", "Id", true, dbFactory, customerRepository, jsRuntime)
    {
    }
}