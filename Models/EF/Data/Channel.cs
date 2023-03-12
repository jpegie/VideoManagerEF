using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideosManager.Models.EF.Data;

[Table("Channels")]
[PrimaryKey(nameof(ID))]
public class Channel 
{
    [Column("ID")]
    public string ID { get; set; } = null!;
    
    [Column("NAME")]
    public string Name { get; set; } = null!;

    [Column("LINK")]
    public string Link { get; set; } = null!;

    public ICollection<Clip> Clips { get; set; } = null!;
}
