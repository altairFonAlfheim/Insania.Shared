using System.Collections;
using System.Text.Json;

using Microsoft.Extensions.DependencyInjection;

using NetTopologySuite.Geometries;

using Insania.Shared.Contracts.Services;
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
            Polygon? result = PolygonParserSL.FromDoubleArrayToPolygon(request!);

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
    #endregion
}