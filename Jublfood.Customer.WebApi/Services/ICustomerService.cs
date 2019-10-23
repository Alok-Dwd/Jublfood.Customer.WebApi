using Jublfood.POSCustomer.WebApi.Models;

namespace Jublfood.POSCustomer.WebApi.Services
{
    public interface ICustomerService
    {
        public GetCustomerByPhoneNumberResponse GetCustomerByPhoneNumber(GetCustomerByPhoneNumberRequest customerRequest);

        public SaveCustomerResponse SaveCustomer(SaveCustomerRequest saveCustomerRequestModel);

    }
}
