using NetTopologySuite.Geometries;

namespace Insania.Shared.Contracts.Services;

/// <summary>
/// Интерфейс преобразования полигона
/// </summary>
public interface IPolygonParserSL
{
    /// <summary>
    /// Метод преобразования из массива дробных значений в полигон
    /// </summary>
    /// <param cref="double[][][]?" name="coordinates">Координаты для преобразования</param>
    /// <returns cref="Polygon?">Полигон</returns>
    /// <exception cref="Exception">Исключение</exception>
    Polygon? FromDoubleArrayToPolygon(double[][][]? coordinates);

    /// <summary>
    /// Метод преобразования из полигона в массив дробных значений
    /// </summary>
    /// <param cref="Polygon?" name="coordinates">Полигон для преобразования</param>
    /// <returns cref="double[][][]?">Координаты</returns>
    /// <exception cref="Exception">Исключение</exception>
    double[][][]? FromPolygonToDoubleArray(Polygon? coordinates);
}