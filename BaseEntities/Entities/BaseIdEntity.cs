using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseEntities.Entities;

/// <summary>
///     Сущность с Id
/// </summary>
public class BaseIdEntity
{
    /// <summary>
    ///     Id
    /// </summary>
    [Key]
    [Column("id")]
    public long Id { get; set; }
}