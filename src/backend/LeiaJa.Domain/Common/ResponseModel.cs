namespace LeiaJa.Domain.Common;
public class ResponseModel<TDate>
{
    public TDate? Data { get; set; }
    public string Message { get; set; } = null!;
    public int StatusCode { get; set; } = StatusCodeModel.DefaultStatusCode;
}
