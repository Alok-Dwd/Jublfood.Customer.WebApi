using Jublfood.POSCustomer.WebApi.Entities;
using System.Collections.Generic;

namespace Jublfood.POSCustomer.WebApi.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomerByPhoneNumber(string locationCode, string phoneNumber, string phoneExtension);

        int SaveCustomer(Customer customer);
    }
}
