using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideosManager.Models.EF.Data;

[Table("CLIPS")]
[PrimaryKey(nameof(ID))]
public class Clip
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public string ID { get; set; } = null!;
    [Column("NAME")]
    public string Name { get; set; } = null!;
    [Column("LINK")]
    public string Link { get; set; } = null!;
    [Column("VIEWS")]
    public int Views { get; set; }
    [Column("PUB_DATE")]
    public DateTime PubDate { get; set; }
    [Column("DURATION")]
    public TimeSpan Duration { get; set; }

    [Column("CHANNEL_ID")]
    public string ChannelID { get; set; } = null!;

    [ForeignKey(nameof(ChannelID))]
    public Channel Channel { get; set; } = null!;
    public ICollection<ClipWithCat> ClipsWithCat { get; set; } = null!;
    public ICollection <FinalVideoClip> FinalVideoClips { get; set; } = null!;
}
