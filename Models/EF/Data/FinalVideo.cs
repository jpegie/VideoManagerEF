using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideosManager.Models.EF.Data;

[Table("FINAL_VIDEOS")]
[PrimaryKey(nameof(ID))]
public class FinalVideo
{
    [Column("ID")]
    public string ID { get; set; } = null!;

    [Column("NAME")]
    public string Name { get; set; } = null!;
    public ICollection<FinalVideoClip> Clips { get; set; } = null!;
}

