namespace Insania.Shared.Models.Responses.Base;

/// <summary>
/// Базовая модель ответа списком
/// </summary>
/// <param cref="bool" name="success">Признак успешности</param>
/// <param cref="List{BaseResponseListItem}?" name="items">Коллекция элементов</param>
public class BaseResponseList(bool success, List<BaseResponseListItem>? items) : BaseResponse(success)
{
    /// <summary>
    /// Коллекция элементов
    /// </summary>
    public List<BaseResponseListItem>? Items { get; set; } = items;
}