using System.Security.Claims;
using System.Text.Json;

using Microsoft.AspNetCore.Http;

using Insania.Shared.Messages;
using Insania.Shared.Models.Responses.Base;

namespace Insania.Shared.Middleware;

/// <summary>
/// Конвейер запросов авторизации
/// </summary>
/// <param cref="RequestDelegate" name="next">Делегат следующего метода</param>
/// <param cref="List{string}" name="exceptions">Исключения, которые не нужно проверять</param>
public class AuthorizationMiddleware(RequestDelegate next, List<string> exceptions)
{
    #region Зависимости
    /// <summary>
    /// Делегат следующего метода
    /// </summary>
    private readonly RequestDelegate _next = next;
    #endregion

    #region Поля
    /// <summary>
    /// Исключения, которые не нужно проверять
    /// </summary>
    private readonly List<string> _exceptions = exceptions;
    #endregion

    #region Основные методы
    /// <summary>
    /// Метод перехватывания запросов
    /// </summary>
    /// <param cref="HttpContext" name="context">Контекст запроса</param>
    public async Task Invoke(HttpContext context)
    {
        //Переход к следующему элементу при наличии метода среди исключений
        if (_exceptions.Contains(context.Request.Path))
        {
            await _next(context);
            return;
        }

        //Получение параметров запроса
        string? path = context.Request.Path.Value?.ToLower(); //адрес запроса
        ClaimsPrincipal? user = context.User; //пользователь
        IEnumerable<Claim>? accessRights = user?.Claims.Where(x => x.Type == "accessRight"); //права доступа

        //Возврат ошибки при отсутствии пути
        if (string.IsNullOrEmpty(path))
        {
            await WriteErrorResponse(context, StatusCodes.Status500InternalServerError, ErrorMessages.EmptyPath);
            return;
        }

        //Возврат ошибки при отсутствии пользователя
        if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
        {
            await WriteErrorResponse(context, StatusCodes.Status401Unauthorized, ErrorMessages.NotFoundCurrentUser);
            return;
        }

        //Возврат ошибки при отсутствии прав доступа
        if (accessRights == null || !accessRights.Any())
        {
            await WriteErrorResponse(context, StatusCodes.Status403Forbidden, ErrorMessages.NotFoundAccessRight);
            return;
        }

        //Возврат ошибки при отсутствии прав доступа к методу
        if (!accessRights.Any(x => x.Value.EndsWith(path, StringComparison.OrdinalIgnoreCase)))
        {
            await WriteErrorResponse(context, StatusCodes.Status403Forbidden, ErrorMessages.NotFoundAccessRight);
            return;
        }

        //Переход к следующему элементу
        await _next(context);
    }
    #endregion

    #region Вспомогательные методы
    /// <summary>
    /// Метод записи ответа с ошибкой в формате JSON
    /// </summary>
    /// <param cref="HttpContext" name="context">Контекст запроса</param>
    /// <param cref="int" name="statusCode">Код статуса</param>
    /// <param cref="string" name="message">Сообщение об ошибке</param>
    private static async Task WriteErrorResponse(HttpContext context, int statusCode, string message)
    {
        //Запись статус кода
        context.Response.StatusCode = statusCode;

        //Запись типа контента
        context.Response.ContentType = "application/json";

        //Формирование переменной ответа
        BaseResponseError response = new(message);

        //Сериализация ответа
        string json = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        });

        //Запись ответа
        await context.Response.WriteAsync(json);
    }
    #endregion
}