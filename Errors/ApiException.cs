namespace ECommerceServerSide.Errors
{
    public class ApiException : ApiResponse
    {
        public string Details { get; set; }
        public ApiException(int code, string message = null, string details = null) : base (code, message)
        {
            this.Details = details;
        }
    }
}
