using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideosManager.Models.EF;
using VideosManager.Models.EF.Data;

namespace VideosManager.Models;
class MainModel
{
    VideosManagerContext _context;

    public MainModel()
    {
        InitContext();
    }

    public VideosManagerContext Context => _context;

    private void InitContext()
    {
        _context = new VideosManagerContext();
        _context.Channels.Load();
        _context.Categories.Load();
        _context.Clips.Load();
        _context.ClipsWithCat.Load();
        _context.FinalVideoClips.Load();
        _context.FinalVideos.Load();

    }
}
