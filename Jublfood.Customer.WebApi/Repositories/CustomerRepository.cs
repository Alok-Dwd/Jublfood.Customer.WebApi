using Jublfood.POSCustomer.WebApi.Data;
using Jublfood.POSCustomer.WebApi.Entities;
using System.Collections.Generic;
using System.Data;

namespace Jublfood.POSCustomer.WebApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCustomerByPhoneNumber(string locationCode, string phoneNumber, string phoneExtension)
        {
            List<Customer> customers = new List<Customer>();

            DataTable customerDetails = CustomerDataAccess.GetCustomerByPhoneNumber(locationCode, phoneNumber, phoneExtension);
            customers.AddRange(EntityHelper.ConvertDataTable<Customer>(customerDetails));

            return customers;
        }

        public int SaveCustomer(Customer customer)
        {
            int result = 0;

            result = CustomerDataAccess.SaveCustomer(customer);

            return result;
        }

    }
}
