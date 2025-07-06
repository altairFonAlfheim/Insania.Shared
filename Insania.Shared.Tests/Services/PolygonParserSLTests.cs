using System.Collections;
using System.Text.Json;

using Microsoft.Extensions.DependencyInjection;

using NetTopologySuite.Geometries;

using Insania.Shared.Contracts.Services;
using Insania.Shared.Messages;
using Insania.Shared.Tests.Base;

namespace Insania.Shared.Tests.Services;

/// <summary>
/// Тесты сервиса транслитерации
/// </summary>
[TestFixture]
public class PolygonParserSLTests : BaseTest
{
    #region Поля
    /// <summary>
    /// Кейс тестирования метода преобразования из массива дробных значений в полигон
    /// </summary>
    public static IEnumerable FromDoubleArrayToPolygonTestCase
    {
        get { yield return new TestCaseData(new double[][][] { new double[][] { [0, 0], [0, 20], [20, 20], [20, 0], [0, 0] }, new double[][] { [5, 5], [5, 15], [15, 15], [15, 5], [5, 5] } } ); }
    }

    #endregion

    #region Зависимости
    /// <summary>
    /// Сервис преобразования полигона
    /// </summary>
    private IPolygonParserSL PolygonParserSL { get; set; }
    #endregion

    #region Общие методы
    /// <summary>
    /// Метод, вызываемый до тестов
    /// </summary>
    [SetUp]
    public void Setup()
    {
        //Получение зависимости
        PolygonParserSL = ServiceProvider.GetRequiredService<IPolygonParserSL>();
    }

    /// <summary>
    /// Метод, вызываемый после тестов
    /// </summary>
    [TearDown]
    public void TearDown()
    {

    }
    #endregion

    #region Методы тестирования
    /// <summary>
    /// Тест метода преобразования из массива дробных значений в полигон
    /// </summary>
    /// <param cref="string" name="coordinates">Координаты для преобразования</param>
    [TestCase("[[[0, 0],[0, 20],[20, 20],[20, 0],[0, 0]],[[5, 5],[5, 15],[15, 15],[15, 5],[5, 5]]]")]
    public void FromDoubleArrayToPolygonTest(string coordinates)
    {
        try
        {
            //Формирование запроса
            double[][][]? request = JsonSerializer.Deserialize<double[][][]>(coordinates);

            //Получение результата
            Polygon? result = PolygonParserSL.FromDoubleArrayToPolygon(request);

            //Проверка результата
            Assert.That(result, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result.IsValid, Is.True);
                Assert.That(result.Shell.Coordinates.Length, Is.Positive);
            }
        }
        catch (Exception)
        {
            //Проброс исключения
            throw;
        }
    }
    
    /// <summary>
    /// Тест метода преобразования из массива дробных значений в полигон
    /// </summary>
    /// <param cref="string" name="coordinates">Координаты для преобразования</param>
    [TestCase("[[[0, 0],[0, 20],[20, 20],[20, 0],[0, 0]],[[5, 5],[5, 15],[15, 15],[15, 5],[5, 5]]]")]
    public void FromPolygonToDoubleArrayTest(string coordinates)
    {
        try
        {
            //Формирование запроса
            Polygon? request = null;
            switch (coordinates)
            {
                case "[[[0, 0],[0, 20],[20, 20],[20, 0],[0, 0]],[[5, 5],[5, 15],[15, 15],[15, 5],[5, 5]]]":
                    Coordinate[] shell = [new Coordinate(0, 0), new Coordinate(0, 20), new Coordinate(20, 20), new Coordinate(20, 0), new Coordinate(0, 0)];
                    LinearRing[] holes = new LinearRing[1];
                    for (int i = 0; i < 1; i++)
                    {
                        Coordinate[] hole = [new Coordinate(5, 5), new Coordinate(5, 15), new Coordinate(15, 15), new Coordinate(15, 5), new Coordinate(5, 5)];
                        holes[i] = new LinearRing(hole);
                    }
                    request = new Polygon(new LinearRing(shell), holes);
                    break;
                default: throw new Exception(ErrorMessages.NotFoundTestCase);

            }

            //Получение результата
            double[][][]? result = PolygonParserSL.FromPolygonToDoubleArray(request);

            //Формирование переменной сравнения
            double[][][]? compare = JsonSerializer.Deserialize<double[][][]>(coordinates);

            //Проверка результата
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(compare));
        }
        catch (Exception)
        {
            //Проброс исключения
            throw;
        }
    }
    #endregion
}