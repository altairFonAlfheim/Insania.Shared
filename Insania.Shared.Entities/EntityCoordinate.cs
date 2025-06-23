using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using NetTopologySuite.Geometries;

namespace Insania.Shared.Entities;

/// <summary>
/// Абстрактная модель сущности координаты сущности
/// </summary>
public abstract class EntityCoordinate : Reestr
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор модели сущности координаты сущности
    /// </summary>
    public EntityCoordinate() : base()
    {
        Center = new(new());
    }

    /// <summary>
    /// Конструктор модели сущности координаты сущности без идентификатора
    /// </summary>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    /// <param cref="Point" name="center">Координаты точки центра сущности</param>
    /// <param cref="int" name="zoom">Коэффициент масштаба отображения сущности</param>
    /// <param cref="Coordinate" name="coordinate">Координата</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public EntityCoordinate(string username, bool isSystem, Coordinate coordinate, Point center, int zoom, DateTime? dateDeleted = null) : base(username, isSystem, dateDeleted)
    {
        Center = center;
        Zoom = zoom;
        CoordinateId = coordinate.Id;
        CoordinateEntity = coordinate;
    }

    /// <summary>
    /// Конструктор модели сущности координаты сущности с идентификатором
    /// </summary>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    /// <param cref="Point" name="center">Координаты точки центра сущности</param>
    /// <param cref="int" name="zoom">Коэффициент масштаба отображения сущности</param>
    /// <param cref="Coordinate" name="coordinate">Координата</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public EntityCoordinate(long id, string username, bool isSystem, Coordinate coordinate, Point center, int zoom, DateTime? dateDeleted = null) : base(id, username, isSystem, dateDeleted)
    {
        Center = center;
        Zoom = zoom;
        CoordinateId = coordinate.Id;
        CoordinateEntity = coordinate;
    }
    #endregion

    #region Поля
    /// <summary>
    /// Координаты точки центра сущности
    /// </summary>
    [Column("center")]
    [Comment("Координаты точки центра сущности")]
    public Point Center { get; private set; }

    /// <summary>
    /// Коэффициент масштаба отображения сущности
    /// </summary>
    [Column("zoom")]
    [Comment("Коэффициент масштаба отображения сущности")]
    public int Zoom { get; private set; }

    /// <summary>
    /// Идентификатор координаты
    /// </summary>
    [Column("coordinate_id")]
    [Comment("Идентификатор координаты")]
    public long? CoordinateId { get; private set; }
    #endregion

    #region Навигационные свойства
    /// <summary>
    /// Навигационное свойство координаты
    /// </summary>
    [ForeignKey("CoordinateId")]
    public Coordinate? CoordinateEntity { get; private set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод записи координат точки центра сущности
    /// </summary>
    /// <param cref="Point" name="center">Координаты точки центра сущности</param>
    public void SetCenter(Point center) => Center = center;

    /// <summary>
    /// Метод записи коэффициент масштаба отображения
    /// </summary>
    /// <param cref="int" name="zoom">Коэффициент масштаба отображения сущности</param>
    public void SetZoom(int zoom) => Zoom = zoom;

    /// <summary>
    /// Метод записи координаты
    /// </summary>
    /// <param cref="Coordinate" name="coordinate">Координата</param>
    public void SetCoordinate(Coordinate coordinate) 
    {
        CoordinateId = coordinate.Id;
        CoordinateEntity = coordinate;
    }
    #endregion
}