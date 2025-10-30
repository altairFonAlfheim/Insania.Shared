namespace Insania.Shared.Models.Responses.Base;

/// <summary>
/// Базовая модель элемента ответа списком
/// </summary>
/// <param cref="long" name="id">Идентификатор сущности</param>
/// <param cref="string" name="name">Наименование сущности</param>
/// <param cref="string?" name="description">Описание сущности</param>
/// <param cref="string?" name="file">Ссылка на файл сущности</param>
public class BaseResponseListItem(long id, string name, string? description = null, string? file = null)
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public long? Id { get; set; } = id;

    /// <summary>
    /// Наименование сущности
    /// </summary>
    public string? Name { get; set; } = name;

    /// <summary>
    /// Описание сущности
    /// </summary>
    public string? Description { get; set; } = description;

    /// <summary>
    /// Ссылка на файл сущности
    /// </summary>
    public string? File { get; set; } = file;
}