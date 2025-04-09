namespace Insania.Shared.Contracts.Services;

/// <summary>
/// Интерфейс транслитерации
/// </summary>
public interface ITransliterationSL
{
    /// <summary>
    /// Метод транслитерации из кириллицы в латиницу
    /// </summary>
    /// <param cref="string" name="text">Текст для транслитерации</param>
    /// <returns cref="string">Транслитерированная строка</returns>
    string FromCyrillicToLatin(string text);

    /// <summary>
    /// Метод транслитерации из латиницы в кириллицу
    /// </summary>
    /// <param cref="string" name="text">Текст для транслитерации</param>
    /// <returns cref="string">Транслитерированная строка</returns>
    string FromLatinToCyrillic(string text);
}