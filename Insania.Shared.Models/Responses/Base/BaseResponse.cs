namespace Insania.Shared.Models.Responses.Base;

/// <summary>
/// Базовая модель ответа
/// </summary>
/// <param cref="bool" name="success">Признак успешности</param>
public class BaseResponse(bool success)
{
    #region Конструкторы
    /// <summary>
    /// Конструктор базовой модели ответа с идентификатором
    /// </summary>
    /// <param cref="bool" name="success">Признак успешности</param>
    /// <param cref="long?" name="id">Идентификатор сущности</param>
    public BaseResponse(bool success, long? id) : this(success)
    {
        Id = id;
    }
    #endregion

    #region Поля
    /// <summary>
    /// Признак успешности
    /// </summary>
    public bool Success { get; set; } = success;

    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public long? Id { get; set; }
    #endregion
}