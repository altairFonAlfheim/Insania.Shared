using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insania.Shared.Entities;

/// <summary>
/// Абстрактная модель сущности
/// </summary>
public abstract class Entity
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор абстрактной модели сущности
    /// </summary>
    public Entity()
    {
        Id = 0;
        DateCreate = DateTime.UtcNow;
        UsernameCreate = "system";
        DateUpdate = DateTime.UtcNow;
        UsernameUpdate = "system";
    }

    /// <summary>
    /// Конструктор абстрактной модели сущности без идентификатора
    /// </summary>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Entity(string username, DateTime? dateDeleted = null) : this()
    {
        DateCreate = DateTime.UtcNow;
        UsernameCreate = username;
        DateUpdate = DateTime.UtcNow;
        UsernameUpdate = username;
        SetDeleted(dateDeleted);
    }

    /// <summary>
    /// Конструктор абстрактной модели сущности с идентификатором
    /// </summary>
    /// <param cref="long" name="id">Первичный ключ таблицы</param>
    /// <param cref="string" name="username">Логин пользователя, выполняющего действие</param>
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    public Entity(long id, string username, DateTime? dateDeleted = null) : this(username)
    {
        Id = id;
        SetDeleted(dateDeleted);
    }
    #endregion

    #region Поля
    /// <summary>
    /// Первичный ключ таблицы
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    [Comment("Первичный ключ таблицы")]
    public long Id { get; private set; }

    /// <summary>
    ///	Дата создания
    /// </summary>
    [Column("date_create")]
    [Comment("Дата создания")]
    public DateTime DateCreate { get; private set; }

    /// <summary>
    /// Логин пользователя, создавшего
    /// </summary>
    [Column("username_create")]
    [Comment("Логин пользователя, создавшего")]
    public string UsernameCreate { get; private set; }

    /// <summary>
    ///	Дата обновления
    /// </summary>
    [Column("date_update")]
    [Comment("Дата обновления")]
    public DateTime DateUpdate { get; private set; }

    /// <summary>
    ///	Логин пользователя, обновившего
    /// </summary>
    [Column("username_update")]
    [Comment("Логин пользователя, обновившего")]
    public string UsernameUpdate { get; private set; }

    /// <summary>
    ///	Дата удаления
    /// </summary>
    [Column("date_deleted")]
    [Comment("Дата удаления")]
    public DateTime? DateDeleted { get; private set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод записи создания
    /// </summary>
    /// <param cref="string" name="username">Логин пользователя, создавшего</param>
    /// <param cref="DateTime" name="dateCreate">Дата создания</param>
    public void SetCreate(string username, DateTime dateCreate)
    {
        DateCreate = dateCreate;
        UsernameCreate = username;
    }

    /// <summary>
    /// Метод записи изменения
    /// </summary>
    /// <param cref="string" name="username">Логин пользователя, обновившего</param>
    public void SetUpdate(string username)
    {
        DateUpdate = DateTime.UtcNow;
        UsernameUpdate = username;
    }

    /// <summary>
    /// Метод записи изменения с датой изменения
    /// </summary>
    /// <param cref="string" name="username">Логин пользователя, обновившего</param>
    /// <param cref="DateTime" name="dateUpdate">Дата обновления</param>
    public void SetUpdate(string username, DateTime dateUpdate)
    {
        DateUpdate = dateUpdate;
        UsernameUpdate = username;
    }

    /// <summary>
    /// Метод удаления
    /// </summary>
    public void SetDeleted()
    {
        DateDeleted = DateTime.UtcNow;
    }

    /// <summary>
    /// Метод удаления с датой удаления
    /// <param cref="DateTime?" name="dateDeleted">Дата удаления</param>
    /// </summary>
    public void SetDeleted(DateTime? dateDeleted)
    {
        DateDeleted = dateDeleted;
    }

    /// <summary>
    /// Метод восстановления
    /// </summary>
    public void SetRestored()
    {
        DateDeleted = null;
    }
    #endregion
}