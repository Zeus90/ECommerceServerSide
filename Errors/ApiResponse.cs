namespace ECommerceServerSide.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int code, string message = null)
        {
            this.Code = code;
            this.Message = message ?? GetDefeaukyMessageForStatusCode(code);
        }

        private string GetDefeaukyMessageForStatusCode(int code) => code switch
        {
            400 => "A bad request, you have made",
            401 => "Authorized, you are not",
            404 => "Resources found, it was not",
            500 => "Errors are the path to the dark side. Error leads to anger, anger leads to hate, hate leads to career change.",
            _ => null
        };

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
