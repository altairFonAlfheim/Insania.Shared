namespace Insania.Shared.Models.Responses.Base;

/// <summary>
/// Базовая модель элемента ответа списком
/// </summary>
/// <param cref="long" name="id">Идентификатор сущности</param>
/// <param cref="string" name="name">Наименование сущности</param>
public class BaseResponseListItem(long id, string name)
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public long? Id { get; set; } = id;

    /// <summary>
    /// Наименование сущности
    /// </summary>
    public string? Name { get; set; } = name;
}