using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideosManager.Models.EF.Data;

[Table("FINAL_VIDEO_CLIPS")]
[PrimaryKey(nameof(ClipID), nameof(VideoID))]
public class FinalVideoClip 
{
    [Column("CLIP_ID")]
    public string ClipID { get; set; } = null!;

    [Column("VIDEO_ID")] 
    public string VideoID { get; set; } = null!;

    [Column("ORDER_IN_VIDEO")]
    public int OrderInVideo { get; set; }

    [ForeignKey(nameof(ClipID))]
    public Clip Clip { get; set; } = null!;

    [ForeignKey(nameof(VideoID))]
    public FinalVideo FinalVideo { get; set; } = null!;
}
