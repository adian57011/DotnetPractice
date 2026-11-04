namespace Utilities.Response;

public class ApiResponse
{
    public int StatusCode { get; set; }
    public string Messages { get; set; } = string.Empty;


    public static ApiResponse Success(string message = DefaultMessages.OperationSuccess)
    {
        var res = new ApiResponse();

        res.StatusCode = 200;
        res.Messages = message;

        return res;
    }

    public static ApiResponse Fail(int errorCode = 400, string messages = DefaultMessages.BadRequest)
    {
        var res = new ApiResponse();
        res.StatusCode = errorCode;
        res.Messages = messages;

        return res;
    }
}


public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }


    public static ApiResponse<T> Success(T? data, string messages = DefaultMessages.OperationSuccess)
    {
        return new ApiResponse<T>()
        {
            StatusCode = 200,
            Messages = messages,
            Data = data
        };
    }

    public static new ApiResponse<T> Fail(int code = 400,string messages = DefaultMessages.BadRequest)
    {
        return new ApiResponse<T>()
        {
            StatusCode = code,
            Messages = messages,
            Data = default
        };
    }
}


public class DefaultMessages
{
    public const string OperationSuccess = "Operation successful";
    public const string OperationFailed = "Opeartion failed";
    public const string AuhtenticationFailed = "Authentication failed";
    public const string InternalError = "Internal operations error";
    public const string BadRequest = "Bad Request";
}
