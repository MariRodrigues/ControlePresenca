namespace ControlePresenca.Application.Response;

public class ResponseApi(bool success, string message)
{
    public int Id { get; set; }
    public object Infos { get; set; }
    public string Message { get; set; } = message;
    public bool Success { get; set; } = success;
}
