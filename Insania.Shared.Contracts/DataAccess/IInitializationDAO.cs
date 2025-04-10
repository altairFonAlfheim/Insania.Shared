namespace Insania.Shared.Contracts.DataAccess;

/// <summary>
/// Интерфейс инициализации данных
/// </summary>
public interface IInitializationDAO
{
    /// <summary>
    /// Метод инициализации данных
    /// </summary>
    Task Initialize();
}