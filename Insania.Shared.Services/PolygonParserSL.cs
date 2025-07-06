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
    /// <param cref="double[][][]?" name="coordinates">Координаты для преобразования</param>
    /// <returns cref="Polygon?">Полигон</returns>
    /// <exception cref="Exception">Исключение</exception>
    public Polygon? FromDoubleArrayToPolygon(double[][][]? coordinates)
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

    /// <summary>
    /// Метод преобразования из полигона в массив дробных значений
    /// </summary>
    /// <param cref="Polygon?" name="coordinates">Полигон для преобразования</param>
    /// <returns cref="double[][][]?">Координаты</returns>
    /// <exception cref="Exception">Исключение</exception>
    public double[][][]? FromPolygonToDoubleArray(Polygon? polygon)
    {
        //Проверки
        if (polygon == null) return null;

        //Получение внешнего и внутренних полигонов
        var shell = polygon.Shell;
        var holes = polygon.Holes;

        //Инициализация массива результатов
        var result = new double[holes.Length + 1][][];

        //Преобразование внешнего полигона
        result[0] = ConvertLinearRingToDoubleArray(shell);

        //Проход по внутренним полигонам
        for (int i = 0; i < holes.Length; i++)
        {
            //Создание и добавление в массив внутреннего полигона
            result[i + 1] = ConvertLinearRingToDoubleArray(holes[i]);
        }

        //Возврат результата
        return result;
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

    /// <summary>
    /// Метод преобразования замкнутого кольца в массив дробных значений
    /// </summary>
    /// <param cref="LinearRing" name="ring">Замкнутое кольцо</param>
    /// <returns cref="double[][]">Массив координат</returns>
    /// <exception cref="Exception">Исключение</exception>
    private static double[][] ConvertLinearRingToDoubleArray(LinearRing ring)
    {
        //Получение массива координат
        var coordinates = ring.Coordinates;

        //Создание переменной результат
        var result = new double[coordinates.Length][];

        //Проход по массиву координат
        for (int i = 0; i < coordinates.Length; i++)
        {
            //Добавление координат в результат
            result[i] = [coordinates[i].X, coordinates[i].Y];
        }

        //Возврат результата
        return result;
    }
    #endregion
}