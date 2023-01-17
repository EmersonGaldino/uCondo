namespace uCondo.Galdino.BootStraper.Configurations.Exceptions;

public class RequestException : Exception
{
    private string ErrorMessage { get; set; }
    private int StatusCode { get; set; }
    public RequestException(int statusCode, string message)
    {
        StatusCode = statusCode;
        ErrorMessage = message;
    }
}