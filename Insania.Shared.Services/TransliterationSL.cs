using Insania.Shared.Contracts.Services;

namespace Insania.Shared.Services;

/// <summary>
/// Сервис транслитерации
/// </summary>
public class TransliterationSL : ITransliterationSL
{
    #region Поля
    /// <summary>
    /// Прописные латинские символы
    /// </summary>
    readonly string[] LatinUp = ["Shch", "YE", "Yo", "Zh", "IY", "Kh", "Ts", "Ch", "Sh", "Yu", "Ya", "A", "B", "V", "G", "D", "Z", "I", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "\"\"", "Y", "''", "E"];

    /// <summary>
    /// Строчные латинские символы
    /// </summary>
    readonly string[] LatinLow = ["shch", "ye", "yo", "zh", "iy", "kh", "ts", "ch", "sh", "yu", "ya", "a", "b", "v", "g", "d", "z", "i", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "\"", "y", "'", "e"];

    /// <summary>
    /// Прописные кириллические символы
    /// </summary>
    readonly string[] CyrillicUp = ["Щ", "Е", "Ё", "Ж", "Й", "Х", "Ц", "Ч", "Ш", "Ю", "Я", "А", "Б", "В", "Г", "Д", "З", "И", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Ъ", "Ы", "Ь", "Э"];

    /// <summary>
    /// Строчные кириллические символы
    /// </summary>
    readonly string[] CyrillicLow = ["щ", "е", "ё", "ж", "й", "х", "ц", "ч", "ш", "ю", "я", "а", "б", "в", "г", "д", "з", "и", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "ъ", "ы", "ь", "э"];
    #endregion

    #region Методы
    /// <summary>
    /// Метод транслитерации из кириллицы в латиницу
    /// </summary>
    /// <param cref="string" name="text">Текст для транслитерации</param>
    /// <returns cref="string">Транслитерированная строка</returns>
    public string FromCyrillicToLatin(string text)
    {
        //Проход по числу символов в алфавите
        for (int i = 0; i < CyrillicLow.Length; i++)
        {
            /*Меняем символы*/
            text = text.Replace(CyrillicUp[i], LatinUp[i]);
            text = text.Replace(CyrillicLow[i], LatinLow[i]);
        }

        //Смена пробелов на нижние подчёркивания
        text = text.Replace(" ", "_");

        //Возврат результата
        return text;
    }

    /// <summary>
    /// Метод транслитерации из кириллицы в латиницу
    /// </summary>
    /// <param cref="string" name="text">Текст для транслитерации</param>
    /// <returns cref="string">Транслитерированная строка</returns>
    public string FromLatinToCyrillic(string text)
    {
        //Проход по числу символов в алфавите
        for (int i = 0; i < CyrillicLow.Length; i++)
        {
            /*Меняем символы*/
            text = text.Replace(LatinUp[i], CyrillicUp[i]);
            text = text.Replace(LatinLow[i], CyrillicLow[i]);
        }

        //Смена нижних подчёркиваний на пробелы
        text = text.Replace("_", " ");

        //Возврат результата
        return text;
    }
    #endregion
}