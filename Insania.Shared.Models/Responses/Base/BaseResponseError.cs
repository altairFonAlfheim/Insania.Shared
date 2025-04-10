namespace Insania.Shared.Models.Responses.Base;

/// <summary>
/// Базовая модель ответа с ошибкой
/// </summary>
/// <param cref="string" name="message">Сообщение</param>
public class BaseResponseError(string? message) : BaseResponse(false)
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public string? Message { get; set; } = message;
}