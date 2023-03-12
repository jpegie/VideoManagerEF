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

    public void RemoveClip(Clip clip)
    {
        throw new NotImplementedException();
    }

    public void AddClip()
    {
        throw new NotImplementedException();
    }

    public void RemoveCategory(Category cat)
    {
        throw new NotImplementedException();
    }

    public void AddCategory()
    {
        throw new NotImplementedException();
    }

    public void RemoveChannel(Channel ch)
    {
        throw new NotImplementedException();
    }

    public void AddChannel()
    {
        throw new NotImplementedException();
    }

    public void RemoveFinalVideo(FinalVideo vid)
    {
        throw new NotImplementedException();
    }

    public void AddFinalVideo()
    {
        throw new NotImplementedException();
    }

    public void RemoveFinalVideoClip(FinalVideoClip clip)
    {
        throw new NotImplementedException();
    }

    public void AddFinalVideoClip()
    {
        throw new NotImplementedException();
    }

    public void SaveClips()
    {
        throw new NotImplementedException();
    }
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
