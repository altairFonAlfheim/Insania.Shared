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
        BorderColor = string.Empty;
        BackgroundColor = string.Empty;
    }

    /// <summary>
    /// Конструктор абстрактной модели сущности типа координаты без идентификатора
    /// </summary>
    /// <param cref="ITransliterationSL" name="transliteration">Сервис транслитерации</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="string" name="name">Наименование</param>
    /// <param cref="string" name="backgroundColor">Цвет фона</param>
    /// <param cref="string" name="borderColor">Цвет границ</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public CoordinateType(ITransliterationSL transliteration, string username, string name, string borderColor, string backgroundColor, DateTime? dateDeleted = null) : base(transliteration, username, name, dateDeleted)
    {
        BorderColor = borderColor;
        BackgroundColor = backgroundColor;
    }

    /// <summary>
    /// Конструктор абстрактной модели сущности типа координаты с идентификатором
    /// </summary>
    /// <param cref="ITransliterationSL" name="transliteration">Сервис транслитерации</param>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="string" name="name">Наименование</param>
    /// <param cref="string" name="backgroundColor">Цвет фона</param>
    /// <param cref="string" name="borderColor">Цвет границ</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public CoordinateType(ITransliterationSL transliteration, long id, string username, string name, string borderColor, string backgroundColor, DateTime? dateDeleted = null) : base(transliteration, id, username, name, dateDeleted)
    {
        BorderColor = borderColor;
        BackgroundColor = backgroundColor;
    }
    #endregion

    #region Поля
    /// <summary>
    /// Цвет фона
    /// </summary>
    public string BackgroundColor { get; private set; }

    /// <summary>
    /// Цвет границ
    /// </summary>
    public string BorderColor { get; private set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод записи цвета фона
    /// </summary>
    /// <param cref="string" name="backgroundColor">Цвет фона</param>
    public void SetBackgroundColor(string backgroundColor) => BackgroundColor = backgroundColor;

    /// <summary>
    /// Метод записи цвета границ
    /// </summary>
    /// <param cref="string" name="borderColor">Цвет границ</param>
    public void SetBorderColor(string borderColor) => BorderColor = borderColor;
    #endregion
}