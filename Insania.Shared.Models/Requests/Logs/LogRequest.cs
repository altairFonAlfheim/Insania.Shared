namespace Insania.Shared.Models.Requests.Logs;

/// <summary>
/// Модель запроса для записи в лог
/// </summary>
/// <param cref="string?" name="token">Токен запроса</param>
/// <param cref="string?" name="queryParams">Параметры строки</param>
/// <param cref="string?" name="body">Тело запроса</param>
public class LogRequest (string? token = null, string? queryParams = null, string? body = null)
{
    /// <summary>
    /// Токен запроса
    /// </summary>
    public string? Token { get; set; } = token;

    /// <summary>
    /// Параметры строки
    /// </summary>
    public string? QueryParams { get; set; } = queryParams;

    /// <summary>
    /// Тело запроса
    /// </summary>
    public string? Body { get; set; } = body;
}