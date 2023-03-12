using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideosManager.Models.EF.Data;

[Table("CLIPS_WITH_CATEGORIES")]
[PrimaryKey(nameof(ClipID), nameof(CategoryID))]
public class ClipWithCat
{
    [Column("CLIP_ID")]
    public string ClipID { get; set; } = null!;

    [Column("CATEGORY_ID")]
    public string CategoryID { get; set; } = null!;

    [ForeignKey(nameof(CategoryID))]
    public Category Category { get; set; } = null!;

    [ForeignKey(nameof(ClipID))]
    public Clip Clip { get; set; } = null!;
}

