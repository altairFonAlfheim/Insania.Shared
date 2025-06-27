using NetTopologySuite.Geometries;

using Insania.Shared.Contracts.Services;
using Insania.Shared.Messages;

namespace Insania.Shared.Services;

/// <summary>
/// Сервис преобразования полигона
/// </summary>
public class PolygonParserSL : IPolygonParserSL
{
    #region Методы
    /// <summary>
    /// Метод преобразования из массива дробных значений в полигон
    /// </summary>
    /// <param cref="double[][][]" name="coordinates">Координаты для преобразования</param>
    /// <returns cref="Polygon">Полигон</returns>
    /// <exception cref="Exception">Исключение</exception>
    public Polygon FromDoubleArrayToPolygon(double[][][] coordinates)
    {
        //Проверки
        if (coordinates == null || coordinates.Length == 0) throw new Exception(ErrorMessages.EmptyCoordinates);
        if (coordinates[0].Length < 4) throw new Exception(ErrorMessages.IncorrectCoordinates);

        //Создание внешнего полигона
        LinearRing shell = CreateLinearRing(coordinates[0]);

        //Создание массива внутренних полигонов
        LinearRing[] holes = new LinearRing[coordinates.Length - 1];

        //Проход по массиву координат внутренних полигонов
        for (int i = 1; i < coordinates.Length; i++)
        {
            //Проверки
            if (coordinates[i].Length < 4) throw new Exception(ErrorMessages.IncorrectCoordinates);

            //Создание и добавление в массив внутреннего полигона
            holes[i - 1] = CreateLinearRing(coordinates[i]);
        }

        //Возврат полигона
        return new Polygon(shell, holes);
    }
    #endregion

    #region Внутренние методы
    /// <summary>
    /// Метод преобразования из массива дробных значений в замкнутое кольцо
    /// </summary>
    /// <param cref="double[][]" name="ringCoordinates">Координаты для преобразования</param>
    /// <returns cref="LinearRing">Замкнутое кольцо</returns>
    /// <exception cref="Exception">Исключение</exception>
    private static LinearRing CreateLinearRing(double[][] ringCoordinates) 
    {
        //Создание массива координат
        var coordinates = new Coordinate[ringCoordinates.Length];

        //Проход по массиву координат кольца
        for (int i = 0; i < ringCoordinates.Length; i++)
        {
            //Проверки
            if (ringCoordinates[i].Length != 2) throw new Exception(ErrorMessages.IncorrectCoordinates);

            //Добавление координат
            coordinates[i] = new Coordinate(ringCoordinates[i][0], ringCoordinates[i][1]);
        }

        //Проверка замкнутости кольца
        if (!coordinates[0].Equals2D(coordinates[^1])) throw new Exception(ErrorMessages.IncorrectCoordinates);

        //Возврат результата
        return new LinearRing(coordinates);
    }
    #endregion
}