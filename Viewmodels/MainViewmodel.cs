using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideosManager.Models.EF.Data;
using VideosManager.Models.EF;
using VideosManager.Models;

namespace VideosManager.Viewmodels;
class MainViewmodel
{
    MainModel _model;
    public MainViewmodel(MainModel model)
    {
        _model = model;
        InitCollections();
    }

    private void InitCollections()
    {
        var context = _model.Context;
        Clips = context.Clips.Local.ToObservableCollection();
        Categories = context.Categories.Local.ToObservableCollection();
        Channels = context.Channels.Local.ToObservableCollection();    
        ClipsWithCat = context.ClipsWithCat.Local.ToObservableCollection();    
        FinalVideos = context.FinalVideos.Local.ToObservableCollection();
        FinalVideoClips = context.FinalVideoClips.Local.ToObservableCollection();
    }

    public ObservableCollection<Clip> Clips { get; set; } = null!;
    public ObservableCollection<Category> Categories { get; set; } = null!;
    public ObservableCollection<Channel> Channels { get; set; } = null!;
    public ObservableCollection<ClipWithCat> ClipsWithCat { get; set; } = null!;
    public ObservableCollection<FinalVideo> FinalVideos { get; set; } = null!;
    public ObservableCollection<FinalVideoClip> FinalVideoClips { get; set; } = null!;


}
