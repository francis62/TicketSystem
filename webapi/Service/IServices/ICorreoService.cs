namespace webapi.Service.IServices
{
    public interface ICorreoService
    {
        Task EnviarCorreoAsync(string destino, string asunto, string cuerpo);
    }
}
