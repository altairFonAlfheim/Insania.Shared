using Insania.Shared.Contracts.Services;

namespace Insania.Shared.Entities;

/// <summary>
/// Абстрактная модель сущности типа координаты
/// </summary>
public abstract class CoordinateType : Compendium
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор абстрактной модели сущности типа координаты
    /// </summary>
    public CoordinateType() : base()
    {

    }

    /// <summary>
    /// Конструктор абстрактной модели сущности типа координаты без идентификатора
    /// </summary>
    /// <param cref="ITransliterationSL" name="transliteration">Сервис транслитерации</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="string" name="name">Наименование</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public CoordinateType(ITransliterationSL transliteration, string username, string name, DateTime? dateDeleted = null) : base(transliteration, username, name, dateDeleted)
    {

    }

    /// <summary>
    /// Конструктор абстрактной модели сущности типа координаты с идентификатором
    /// </summary>
    /// <param cref="ITransliterationSL" name="transliteration">Сервис транслитерации</param>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="string" name="name">Наименование</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public CoordinateType(ITransliterationSL transliteration, long id, string username, string name, DateTime? dateDeleted = null) : base(transliteration, id, username, name, dateDeleted)
    {

    }
    #endregion
}