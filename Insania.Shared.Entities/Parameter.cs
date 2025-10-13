using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using Insania.Shared.Contracts.Services;

namespace Insania.Shared.Entities;

/// <summary>
/// Абстрактная модель сущности параметра
/// </summary>
public class Parameter: Compendium
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор модели сущности параметра
    /// </summary>
    public Parameter(): base()
    {
    }

    /// <summary>
    /// Конструктор модели сущности параметра без идентификатора
    /// </summary>
    /// <param cref="ITransliterationSL" name="transliteration">Сервис транслитерации</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="string" name="name">Наименование</param>
    /// <param cref="string?" name="value">Значение параметра</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Parameter(ITransliterationSL transliteration, string username, string name, string? value = null, DateTime? dateDeleted = null) : base(transliteration, username, name, dateDeleted)
    {
        Value = value;
    }

    /// <summary>
    /// Конструктор модели сущности параметра с идентификатором
    /// </summary>
    /// <param cref="ITransliterationSL" name="transliteration">Сервис транслитерации</param>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="string" name="name">Наименование</param>
    /// <param cref="string?" name="value">Значение параметра</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Parameter(ITransliterationSL transliteration, long id, string username, string name, string? value = null, DateTime? dateDeleted = null) : base(transliteration, id, username, name, dateDeleted)
    {
        Value = value;
    }
    #endregion

    #region Поля
    /// <summary>
    /// Значение параметра
    /// </summary>
    [Column("value")]
    [Comment("Значение параметра")]
    public string? Value { get; private set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод записи значения параметра
    /// </summary>
    /// <param cref="string?" name="value">Значение параметра</param>
    public void SetValue(string? value)
    {
        Value = value;
    }
    #endregion
}