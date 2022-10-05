using System.Collections;

namespace Billing.Authentication.Domains.Models
{
    public class HttpResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public int StatusCode { get; set; } = 200;
        public string StatusMessage { get; set; } = null;
    }
}
