using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Linq;
using VideosManager.Models.EF;
using VideosManager.Models.EF.Data;
using VideosManager.Viewmodels;

namespace VideosManager.Models;
class MainModel : INotifyPropertyChanged
{
    const string EMPTY_NAME = "empty name";
    const string EMPTY_LINK = "empty link";

    public MainModel()
    {
        InitContext();
        InitVariables();
    }

    private void InitVariables()
    {
        NewFinalVideoClip_Clip = Context!.Clips.FirstOrDefault();
        NewFinalVideoClip_Video = Context!.FinalVideos.FirstOrDefault();
        NewClipWithCat_Clip = Context!.Clips.FirstOrDefault();
        NewClipWithCat_Cat = Context!.Categories.FirstOrDefault();

        OnPropertyChanged(nameof(NewFinalVideoClip_Clip));
        OnPropertyChanged(nameof(NewFinalVideoClip_Video));
        OnPropertyChanged(nameof(NewClipWithCat_Clip));
        OnPropertyChanged(nameof(NewClipWithCat_Cat));
    }

    public MainViewmodel Viewmodel { get; set; }
    public VideosManagerContext Context { get; private set; }
    public string NewClipID { get; set; }
    public string NewCatID { get; set; }
    public string NewChannelID { get; set; }
    public string NewFinalVideoID { get; set; }
    public FinalVideo? NewFinalVideoClip_Video { get; set; }
    public Clip? NewFinalVideoClip_Clip { get; set; }
    public Clip? NewClipWithCat_Clip { get; set; }
    public Category? NewClipWithCat_Cat { get; set; }

    public void SaveChanges()
    {
        Context.SaveChanges();
    }
    public void UndoChanges()
    {
        Context.Dispose();
        InitContext();
        InitVariables();
        Viewmodel.InitCollections();
    }
    public void AddClip()
    {
        if (Context.Channels == null || Context.Channels.Count() == 0)
        {
            return;
        }

        var cl = new Clip
        {
            ID = NewClipID,
            Link = EMPTY_LINK,
            Name = EMPTY_NAME,
            Views = 0,
            PubDate = DateTime.Now,
            Duration = TimeSpan.Zero,
            ChannelID = Context.Channels.First().ID,
        };
            
        if (!Viewmodel.Clips
                      .Any(a => a.ID == cl.ID))
        {
            Context.Clips.Add(cl);
        }

        NewClipID = "";
        OnPropertyChanged(nameof(NewClipID));
    }
    public void AddCategory()
    {
        var cat = new Category
        {
            Name = EMPTY_NAME,
            ID = NewCatID
        };

        if (!Viewmodel.Categories
                      .Any(c => c.ID == cat.ID))
        {
            Context.Categories.Add(cat);
        }

        NewCatID = "";
        OnPropertyChanged(nameof(NewCatID));
    }
    public void AddChannel()
    {
        var ch = new Channel
        {
            Name = EMPTY_NAME,
            ID = NewChannelID,
            Link = EMPTY_LINK
        };

        if (!Viewmodel.Channels
                      .Any(c => c.ID == ch.ID))
        {
            Context.Channels.Add(ch);
        }

        NewChannelID = "";
        OnPropertyChanged(nameof(NewChannelID));

    }
    public void AddFinalVideo()
    {
        var vid = new FinalVideo
        {
            ID = NewFinalVideoID,
            Name = EMPTY_NAME
        };

        if (!Viewmodel.FinalVideos
                      .Any(v => v.ID == vid.ID))
        {
            Context.FinalVideos.Add(vid);
        }

        NewFinalVideoID = "";
        OnPropertyChanged(nameof(NewFinalVideoID));
    }
    public void AddFinalVideoClip()
    {
        if (NewFinalVideoClip_Clip == null || NewFinalVideoClip_Video == null)
        {
            return;
        }
        var newOrderInVideo = 0;
        if (NewFinalVideoClip_Video.Clips != null && NewFinalVideoClip_Video.Clips.Count != 0)
        {
            newOrderInVideo = NewFinalVideoClip_Video.Clips.Max(c => c.OrderInVideo) + 1;
        }

        var clip = new FinalVideoClip
        {
            ClipID = NewFinalVideoClip_Clip.ID,
            VideoID = NewFinalVideoClip_Video.ID,
            OrderInVideo = newOrderInVideo
        };

        if (!Viewmodel.FinalVideoClips
                      .Any(f => f.ClipID == clip.ClipID && f.VideoID == clip.VideoID))
        {
            Context.FinalVideoClips.Add(clip);
        }
    }
    public void AddClipWithCat()
    {
        if (NewClipWithCat_Clip == null || NewClipWithCat_Cat == null)
        {
            return;
        }
        var clip = new ClipWithCat
        {
            ClipID = NewClipWithCat_Clip.ID,
            CategoryID = NewClipWithCat_Cat.ID
        };

        if (!Viewmodel.ClipsWithCats
                      .Any(c => c.ClipID == clip.ClipID && c.CategoryID == clip.CategoryID))
        {
            Context.ClipsWithCat.Add(clip);
        }  
    }

    public void RemoveClip(Clip clip)
    {
        Context.Remove(clip);
        NewFinalVideoClip_Clip = Viewmodel.Clips.FirstOrDefault();
        NewClipWithCat_Clip = Viewmodel.Clips.FirstOrDefault();
        OnPropertyChanged(nameof(NewFinalVideoClip_Clip));
        OnPropertyChanged(nameof(NewClipWithCat_Clip));
    }
    public void RemoveCategory(Category cat)
    {
        Context.Remove(cat);
        NewClipWithCat_Cat = Viewmodel.Categories.FirstOrDefault();
        OnPropertyChanged(nameof(NewClipWithCat_Cat));
    }
    public void RemoveChannel(Channel ch)
    {
        Context.Remove(ch);
    }
    public void RemoveFinalVideo(FinalVideo vid)
    {
        Context.Remove(vid);
        NewFinalVideoClip_Video = Viewmodel.FinalVideos.FirstOrDefault();
        OnPropertyChanged(nameof(NewFinalVideoClip_Video));
    }
    public void RemoveFinalVideoClip(FinalVideoClip clip)
    {
        Context.Remove(clip);
    }
    public void RemoveClipWithCat(ClipWithCat clip)
    {
        Context.ClipsWithCat.Remove(clip);
    }

    private void InitContext()
    {
        Context = new VideosManagerContext();
        Context.Database.EnsureCreated();
        Context.Channels.Load();
        Context.Categories.Load();
        Context.Clips.Load();
        Context.ClipsWithCat.Load();
        Context.FinalVideoClips.Load();
        Context.FinalVideos.Load();
    }
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    #endregion

}
