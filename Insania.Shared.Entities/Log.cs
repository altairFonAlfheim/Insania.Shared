using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Insania.Shared.Entities;

/// <summary>
/// Абстрактная модель сущности лога
/// </summary>
public abstract class Log : Reestr
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор модели сущности лога
    /// </summary>
    public Log() : base()
    {
        Method = string.Empty;
        Type = string.Empty;
    }

    /// <summary>
    /// Конструктор модели сущности лога без идентификатора
    /// </summary>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    /// <param cref="string" name="method">Наименование вызываемого метода</param>
    /// <param cref="string" name="type">Тип вызываемого метода</param>
    /// <param cref="string?" name="dataIn">Данные на вход</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Log(string username, bool isSystem, string method, string type, string? dataIn = null, DateTime? dateDeleted = null) : base(username, isSystem, dateDeleted)
    {
        Method = method;
        DataIn = dataIn;
        Type = type;
        DateStart = DateTime.UtcNow;
    }

    /// <summary>
    /// Конструктор модели сущности лога с идентификатором
    /// </summary>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    /// <param cref="string" name="method">Наименование вызываемого метода</param>
    /// <param cref="string" name="type">Тип вызываемого метода</param>
    /// <param cref="string" name="dataIn">Данные на вход</param>
    /// <param cref="int?" name="statusCode">Код статуса</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Log(long id, string username, bool isSystem, string method, string type, string? dataIn = null, DateTime? dateDeleted = null) : base(id, username, isSystem, dateDeleted)
    {
        Method = method;
        DataIn = dataIn;
        Type = type;
        DateStart = DateTime.UtcNow;
    }
    #endregion

    #region Поля
    /// <summary>
    /// Наименование вызываемого метода
    /// </summary>
    [Column("method")]
    [Comment("Наименование вызываемого метода")]
    public string Method { get; private set; }

    /// <summary>
    /// Тип вызываемого метода
    /// </summary>
    [Column("type")]
    [Comment("Тип вызываемого метода")]
    public string Type { get; private set; }

    /// <summary>
    /// Признак успешного выполнения
    /// </summary>
    [Column("success")]
    [Comment("Признак успешного выполнения")]
    public bool Success { get; private set; }

    /// <summary>
    /// Дата начала
    /// </summary>
    [Column("date_start")]
    [Comment("Дата начала")]
    public DateTime DateStart { get; private set; }

    /// <summary>
    /// Дата окончания
    /// </summary>
    [Column("date_end")]
    [Comment("Дата окончания")]
    public DateTime? DateEnd { get; private set; }

    /// <summary>
    /// Данные на вход
    /// </summary>
    [Column("data_in", TypeName = "jsonb")]
    [Comment("Данные на вход")]
    public string? DataIn { get; private set; }

    /// <summary>
    /// Данные на выход
    /// </summary>
    [Column("data_out", TypeName = "jsonb")]
    [Comment("Данные на выход")]
    public string? DataOut { get; private set; }

    /// <summary>
    /// Код статуса
    /// </summary>
    [Column("status_code")]
    [Comment("Код статуса")]
    public int? StatusCode { get; private set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод записи завершения выполнения
    /// </summary>
    /// <param cref="bool" name="success">Признак успешного выполнения</param>
    /// <param cref="string?" name="dataOut">Данные на выход</param>
    /// <param cref="int?" name="statusCode">Код статуса</param>
    public void SetEnd(bool success, string? dataOut, int? statusCode)
    {
        Success = success;
        DataOut = dataOut;
        StatusCode = statusCode;
        DateEnd = DateTime.UtcNow;
    }
    #endregion
}