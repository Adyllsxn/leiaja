namespace LeiaJa.Domain.Common;
public class ResponseModel<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; } = DomainConfiguration.DefaultStatusCode;
}
