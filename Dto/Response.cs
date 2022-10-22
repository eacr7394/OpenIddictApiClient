namespace Dto;

public class Response
{
    public object? Data { get; set; }
    public string Message { get; set; } = null!;
    public int Code { get; set; }
    public bool Success { get; set; }
}
