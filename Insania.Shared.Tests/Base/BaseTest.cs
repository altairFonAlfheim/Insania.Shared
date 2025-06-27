using Microsoft.Extensions.DependencyInjection;

using Insania.Shared.Contracts.Services;
using Insania.Shared.Services;

namespace Insania.Shared.Tests.Base;

/// <summary>
/// Базовый класс тестирования
/// </summary>
public class BaseTest
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор базового класса тестирования
    /// </summary>
    public BaseTest()
    {
        //Создание коллекции сервисов
        IServiceCollection services = new ServiceCollection();

        //Внедрение зависимостей сервисов
        services.AddScoped<ITransliterationSL, TransliterationSL>(); //сервис транслитерации
        services.AddScoped<IPolygonParserSL, PolygonParserSL>(); //сервис преобразования полигона

        //Создание поставщика сервисов
        ServiceProvider = services.BuildServiceProvider();
    }
    #endregion

    #region Зависимости
    /// <summary>
    /// Поставщик сервисов
    /// </summary>
    protected IServiceProvider ServiceProvider { get; set; }
    #endregion
}