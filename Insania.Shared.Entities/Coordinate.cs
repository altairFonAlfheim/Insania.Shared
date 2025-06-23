using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using NetTopologySuite.Geometries;

namespace Insania.Shared.Entities;

/// <summary>
/// Абстрактная модель сущности координаты
/// </summary>
public abstract class Coordinate : Reestr
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор модели сущности координаты
    /// </summary>
    public Coordinate() : base()
    {
        PolygonEntity = new(new([]));
    }

    /// <summary>
    /// Конструктор модели сущности координаты без идентификатора
    /// </summary>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    /// <param cref="Polygon" name="polygon">Полигон (массив координат)</param>
    /// <param cref="CoordinateType" name="type">Тип</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Coordinate(string username, bool isSystem, Polygon polygon, CoordinateType type, DateTime? dateDeleted = null) : base(username, isSystem, dateDeleted)
    {
        PolygonEntity = polygon;
        TypeId = type.Id;
        TypeEntity = type;
    }

    /// <summary>
    /// Конструктор модели сущности координаты с идентификатором
    /// </summary>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    /// <param cref="Polygon" name="polygon">Полигон (массив координат)</param>
    /// <param cref="CoordinateType" name="type">Тип</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Coordinate(long id, string username, bool isSystem, Polygon polygon, CoordinateType type, DateTime? dateDeleted = null) : base(id, username, isSystem, dateDeleted)
    {
        PolygonEntity = polygon;
        TypeId = type.Id;
        TypeEntity = type;
    }
    #endregion

    #region Поля
    /// <summary>
    /// Полигон (массив координат)
    /// </summary>
    [Column("polygon")]
    [Comment("Полигон (массив координат)")]
    public Polygon PolygonEntity { get; private set; }

    /// <summary>
    /// Идентификатор типа координаты
    /// </summary>
    [Column("type_id")]
    [Comment("Идентификатор типа координаты")]
    public long? TypeId { get; private set; }
    #endregion

    #region Навигационные свойства
    /// <summary>
    /// Навигационное свойство типа координаты
    /// </summary>
    [ForeignKey("TypeId")]
    public CoordinateType? TypeEntity { get; private set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод записи полигона (массива координат)
    /// </summary>
    /// <param cref="Polygon" name="polygon">Полигон (массив координат)</param>
    public void SetPolygon(Polygon polygon) => PolygonEntity = polygon;

    /// <summary>
    /// Метод записи типа
    /// </summary>
    /// <param cref="CoordinateType" name="type">Тип</param>
    public void SetType(CoordinateType type) 
    {
        TypeId = type.Id;
        TypeEntity = type;
    }
    #endregion
}