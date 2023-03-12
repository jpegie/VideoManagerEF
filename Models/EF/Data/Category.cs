using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace VideosManager.Models.EF.Data;

[Table("CATEGORIES")]
[PrimaryKey(nameof(Id))]
public class Category
{
    [Column("ID")]
    public string Id { get; set; } = null!;

    [Column("NAME")]
    public string Name { get; set; } = null!;
    public ICollection<ClipWithCat> Clips { get; set; } = null!;
}
