using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Insania.Shared.Entities;

/// <summary>
/// Абстрактная модель сущности реестра
/// </summary>
public abstract class Reestr : Entity
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор абстрактной модели сущности реестра
    /// </summary>
    public Reestr() : base()
    {

    }

    /// <summary>
    /// Конструктор абстрактной модели сущности реестра без идентификатора
    /// </summary>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Reestr(string username, bool isSystem, DateTime? dateDeleted = null) : base(username, dateDeleted)
    {
        IsSystem = isSystem;
    }

    /// <summary>
    /// Конструктор абстрактной модели сущности реестра с идентификатором
    /// </summary>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Reestr(long id, string username, bool isSystem, DateTime? dateDeleted = null) : base(id, username, dateDeleted)
    {
        IsSystem = isSystem;
    }
    #endregion

    #region Поля
    /// <summary>
    ///	Признак системной записи
    /// </summary>
    [Column("is_system")]
    [Comment("Признак системной записи")]
    public bool IsSystem { get; private set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод записи признака системности записи
    /// </summary>
    /// <param cref="bool" name="isSystem">Признак системной записи</param>
    public void SetIsSystem(bool isSystem)
    {
        IsSystem = isSystem;
    }
    #endregion
}