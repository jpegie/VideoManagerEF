using Microsoft.EntityFrameworkCore;
using VideosManager.Models.EF.Data;

namespace VideosManager.Models.EF;
public class VideosManagerContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Clip> Clips { get; set; }
    public DbSet<FinalVideo> FinalVideos { get; set; }
    public DbSet<FinalVideoClip> FinalVideoClips { get; set; }
    public DbSet<ClipWithCat> ClipsWithCat { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=VladimirPC\SERVER00;Database=VIDEO_MANAGER1;Trusted_Connection=True;TrustServerCertificate=true;");
    }
}
