namespace LeiaJa.Domain.Common;
public class ResponseModel<TDate>
{
    public TDate? Date { get; set; }
    public string Messege { get; set; } = null!;
    public int StatusCode { get; set; } = StatusCodeModel.DefaultStatusCode;
}
