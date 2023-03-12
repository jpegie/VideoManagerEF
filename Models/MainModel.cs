using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VideosManager.Models.EF;
using VideosManager.Models.EF.Data;
using VideosManager.Viewmodels;

namespace VideosManager.Models;
class MainModel
{
    VideosManagerContext _context;
    MainViewmodel _viewmodel;
    string _newClipID = "";
    public MainModel()
    {
        InitContext();
    }

    public MainViewmodel Viewmodel
    {
        get => _viewmodel;
        set => _viewmodel = value;
    }
    public VideosManagerContext Context => _context;
    public string NewClipID
    {
        get => _newClipID;
        set
        {
            _newClipID = value; 
            _viewmodel.OnPropertyChanged(nameof(NewClipID));
        }
    }
    public void RemoveClip(Clip clip)
    {
        var delete = _context.Clips
                             .OrderBy(cl => cl.ID == clip.ID)
                             .Include(cl => cl.ClipsWithCat)
                             .Where(cl => cl.ID == clip.ID)
                             .Include(cl => cl.FinalVideoClips)
                             .First();
        _context.Remove(delete);
    }

    public void AddClip()
    {
        var cl = new Clip
        {
            ID = NewClipID,
            Link = "empty link",
            Name = "empty name",
            Views = 0,
            PubDate = DateTime.Now,
            Duration = TimeSpan.Zero,
            ChannelID = _context.Channels.First().ID,
        };
        _context.Clips.Add(cl);
        NewClipID = "";
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
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
