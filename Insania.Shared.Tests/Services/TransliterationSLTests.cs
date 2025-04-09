using Microsoft.Extensions.DependencyInjection;

using Insania.Shared.Contracts.Services;
using Insania.Shared.Messages;
using Insania.Shared.Tests.Base;

namespace Insania.Shared.Tests.Services;

/// <summary>
/// Тесты сервиса транслитерации
/// </summary>
[TestFixture]
public class TransliterationSLTests : BaseTest
{
    #region Зависимости
    /// <summary>
    /// Сервис транслитерации
    /// </summary>
    private ITransliterationSL TransliterationSL { get; set; }
    #endregion

    #region Общие методы
    /// <summary>
    /// Метод, вызываемый до тестов
    /// </summary>
    [SetUp]
    public void Setup()
    {
        //Получение зависимости
        TransliterationSL = ServiceProvider.GetRequiredService<ITransliterationSL>();
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
    /// Тест метода транслитерации из кириллицы в латиницу
    /// </summary>
    /// <param cref="string" name="text">Текст для транслитерации</param>
    [TestCase("А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я  а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я")]
    public void FromCyrillicToLatinTest(string text)
    {
        try
        {
            //Получение результата
            string? result = TransliterationSL.FromCyrillicToLatin(text);

            //Проверка результата
            switch (text)
            {
                case "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я  а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я":
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result, Is.EqualTo("A_B_V_G_D_YE_Yo_Zh_Z_I_IY_K_L_M_N_O_P_R_S_T_U_F_Kh_Ts_Ch_Sh_Shch_\"\"_Y_''_E_Yu_Ya__a_b_v_g_d_ye_yo_zh_z_i_iy_k_l_m_n_o_p_r_s_t_u_f_kh_ts_ch_sh_shch_\"_y_'_e_yu_ya"));
                    break;
                default: throw new Exception(ErrorMessages.NotFoundTestCase);
            }
        }
        catch (Exception)
        {
            //Проброс исключения
            throw;
        }
    }

    /// <summary>
    /// Тест метода транслитерации из латиницы в кириллицу
    /// </summary>
    /// <param cref="string" name="text">Текст для транслитерации</param>
    [TestCase("A_B_V_G_D_YE_Yo_Zh_Z_I_IY_K_L_M_N_O_P_R_S_T_U_F_Kh_Ts_Ch_Sh_Shch_\"\"_Y_''_E_Yu_Ya__a_b_v_g_d_ye_yo_zh_z_i_iy_k_l_m_n_o_p_r_s_t_u_f_kh_ts_ch_sh_shch_\"_y_'_e_yu_ya")]
    public void FromLatinToCyrillicTest(string text)
    {
        try
        {
            //Получение результата
            string? result = TransliterationSL.FromLatinToCyrillic(text);

            //Проверка результата
            switch (text)
            {
                case "A_B_V_G_D_YE_Yo_Zh_Z_I_IY_K_L_M_N_O_P_R_S_T_U_F_Kh_Ts_Ch_Sh_Shch_\"\"_Y_''_E_Yu_Ya__a_b_v_g_d_ye_yo_zh_z_i_iy_k_l_m_n_o_p_r_s_t_u_f_kh_ts_ch_sh_shch_\"_y_'_e_yu_ya":
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result, Is.EqualTo("А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я  а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я"));
                    break;
                default: throw new Exception(ErrorMessages.NotFoundTestCase);
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