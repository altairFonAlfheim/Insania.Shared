using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using Insania.Shared.Messages;
using Insania.Shared.Contracts.Services;

namespace Insania.Shared.Entities;

/// <summary>
/// Абстрактная модель сущности справочника
/// </summary>
public abstract class Compendium : Entity
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор абстрактной модели сущности справочника
    /// </summary>
    public Compendium() : base()
    {
        Name = string.Empty;
        Alias = string.Empty;
    }

    /// <summary>
    /// Конструктор абстрактной модели сущности справочника без идентификатора
    /// </summary>
    /// <param cref="ITransliterationSL" name="transliteration">Сервис транслитерации</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="string" name="name">Наименование</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Compendium(ITransliterationSL transliteration, string username, string name, DateTime? dateDeleted = null) : base(username, dateDeleted)
    {
        Transliteration = transliteration;
        Name = name;
        Alias = Transliteration.FromCyrillicToLatin(name);
    }

    /// <summary>
    /// Конструктор абстрактной модели сущности справочника с идентификатором
    /// </summary>
    /// <param cref="ITransliterationSL" name="transliteration">Сервис транслитерации</param>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="string" name="name">Наименование</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Compendium(ITransliterationSL transliteration, long id, string username, string name, DateTime? dateDeleted = null) : base(id, username, dateDeleted)
    {
        Transliteration = transliteration;
        Name = name;
        Alias = Transliteration.FromCyrillicToLatin(name);
    }
    #endregion

    #region Зависимости
    /// <summary>
    /// Сервис транслитерации
    /// </summary>
    private ITransliterationSL? Transliteration { get; set; }
    #endregion

    #region Поля
    /// <summary>
    /// Наименование
    /// </summary>
    [Column("name")]
    [Comment("Наименование")]
    public string Name { get; private set; }

    /// <summary>
    /// Псевдоним
    /// </summary>
    [Column("alias")]
    [Comment("Псевдоним")]
    public string Alias { get; private set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод записи наименования
    /// </summary>
    /// <param cref="string" name="name">Наименование</param>
    /// <exception cref="Exception">Исключение</exception>
    public void SetName(string name)
    {
        Name = name;
        Alias = Transliteration?.FromCyrillicToLatin(name) ?? throw new Exception(ErrorMessages.FailedTransliteration);
    }
    #endregion
}