using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jublfood.POSCustomer.WebApi.Models
{
    public class ResultModel
    {
        public string ResponseStatus { get; set; }
        public string ResponseStatusCode { get; set; }
        public object Response { get; set; }
    }
}
