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
    /// <param cref="double[][][]" name="coordinates">Координаты для преобразования</param>
    /// <returns cref="Polygon">Полигон</returns>
    /// <exception cref="Exception">Исключение</exception>
    Polygon FromDoubleArrayToPolygon(double[][][] coordinates);
}