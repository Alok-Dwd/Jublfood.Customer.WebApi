using Jublfood.POSCustomer.WebApi.Models;
using Jublfood.POSCustomer.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Jublfood.POSCustomer.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // POST: api/Customer/GetCustomerByPhoneNumber
        [HttpPost]
        public GetCustomerByPhoneNumberResponse GetCustomerByPhoneNumber(GetCustomerByPhoneNumberRequest requestModel)
        {
            return _customerService.GetCustomerByPhoneNumber(requestModel);
        }

        [HttpPost]
        public SaveCustomerResponse SaveCustomer(SaveCustomerRequest saveCustomerRequestModel)
        {
            return _customerService.SaveCustomer(saveCustomerRequestModel);
        }

        [HttpGet]
        public string Get()
        {
            return "Test";
        }        
    }
}
