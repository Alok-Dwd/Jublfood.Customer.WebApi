namespace Jublfood.POSCustomer.WebApi.Models
{
    public class SaveCustomerResponse
    {
        public SaveCustomerResult Result { get; set; }
    }

    public class SaveCustomerResult
    {
        public string ResponseStatus { get; set; }
        public string ResponseStatusCode { get; set; }

    }
}
