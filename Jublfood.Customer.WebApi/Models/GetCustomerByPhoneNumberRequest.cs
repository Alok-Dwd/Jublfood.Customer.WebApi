namespace Jublfood.POSCustomer.WebApi.Models
{
    public class GetCustomerByPhoneNumberRequest
    {
        public string PhoneNumber { get; set; }
        public string LocationCode { get; set; }
        public string PhoneNumberExt { get; set; }
    }
}
