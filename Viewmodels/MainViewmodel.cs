using System.Collections.ObjectModel;
using VideosManager.Models.EF.Data;
using VideosManager.Models;
using System.Windows.Input;
using RelayCommands;
using System.ComponentModel;

namespace VideosManager.Viewmodels;
class MainViewmodel : INotifyPropertyChanged
{
    MainModel _model;

    ObservableCollection<Clip> _clips;
    ObservableCollection<Category> _categories;
    ObservableCollection<Channel> _channels;
    ObservableCollection<ClipWithCat> _clipsWithCats;
    ObservableCollection<FinalVideo> _finalVideos;
    ObservableCollection<FinalVideoClip> _finalVideoClips;

    public MainViewmodel(MainModel model)
    {
        _model = model;
        _model.PropertyChanged += ModelPropertyChanged;
        InitCollections();
    }

    public ObservableCollection<Clip> Clips
    {
        get => _clips;  
        set
        {
            _clips = value;
            OnPropertyChanged(nameof(Clips));
        }
    }
    public ObservableCollection<Category> Categories
    {
        get => _categories;
        set
        {
            _categories = value;
            OnPropertyChanged(nameof(Categories));
        }
    }
    public ObservableCollection<Channel> Channels
    {
        get => _channels;
        set
        {
            _channels = value;
            OnPropertyChanged(nameof(Channels));
        }
    }
    public ObservableCollection<ClipWithCat> ClipsWithCats
    {
        get => _clipsWithCats; 
        set
        {
            _clipsWithCats = value;
            OnPropertyChanged(nameof(ClipsWithCats));
        }
    }
    public ObservableCollection<FinalVideo> FinalVideos
    {
        get => _finalVideos; 
        set
        {
            _finalVideos = value;
            OnPropertyChanged(nameof(FinalVideos));
        }
    }
    public ObservableCollection<FinalVideoClip> FinalVideoClips
    {
        get => _finalVideoClips; 
        set
        {
            _finalVideoClips = value;
            OnPropertyChanged(nameof(FinalVideoClips));
        }
    }

    public string NewClipID
    {
        get => _model.NewClipID;
        set => _model.NewClipID = value;
    }
    public string NewCatID
    {
        get => _model.NewCatID;
        set => _model.NewCatID = value;
    }
    public string NewChannelID
    {
        get => _model.NewChannelID;
        set => _model.NewChannelID = value;
    }
    public Clip NewFinalVideoClip_Clip
    {
        get => _model.NewFinalVideoClip_Clip;
        set => _model.NewFinalVideoClip_Clip = value;
    }
    public FinalVideo NewFinalVideoClip_Video
    {
        get => _model.NewFinalVideoClip_Video;
        set => _model.NewFinalVideoClip_Video = value;
    }
    public Clip NewClipWithCat_Clip
    {
        get => _model.NewClipWithCat_Clip;
        set => _model.NewClipWithCat_Clip = value;
    }
    public Category NewClipWithCat_Cat
    {
        get => _model.NewClipWithCat_Cat;
        set => _model.NewClipWithCat_Cat = value;
    }
    public string NewFinalVideoID
    {
        get => _model.NewFinalVideoID;
        set => _model.NewFinalVideoID = value;
    }

    public ICommand SaveChangesCommand
    {
        get
        {
            return new RelayCommand(_ => _model.SaveChanges());
        }
    }
    public ICommand RemoveClipCommand
    {
        get
        {
            return new RelayCommand(param => _model.RemoveClip((Clip)param));
        }
    }
    public ICommand RemoveCategoryCommand
    {
        get
        {
            return new RelayCommand(param => _model.RemoveCategory((Category)param));
        }
    }
    public ICommand RemoveChannelCommand
    {
        get
        {
            return new RelayCommand(param => _model.RemoveChannel((Channel)param));
        }
    }
    public ICommand RemoveFinalVideoClipCommand
    {
        get
        {
            return new RelayCommand(param => _model.RemoveFinalVideoClip((FinalVideoClip)param));
        }
    }
    public ICommand RemoveFinalVideoCommand
    {
        get
        {
            return new RelayCommand(param => _model.RemoveFinalVideo((FinalVideo)param));
        }
    }
    public ICommand RemoveClipWithCatCommand
    {
        get
        {
            return new RelayCommand(param => _model.RemoveClipWithCat((ClipWithCat)param));
        }
    }
    
    public ICommand AddClipCommand
    {
        get
        {
            return new RelayCommand(_ => _model.AddClip());
        }
    }
    public ICommand AddCategoryCommand
    {
        get
        {
            return new RelayCommand(_ => _model.AddCategory());
        }
    }
    public ICommand AddChannelCommand
    {
        get
        {
            return new RelayCommand(_ => _model.AddChannel());
        }
    }
    public ICommand AddFinalVideoClipCommand
    {
        get
        {
            return new RelayCommand(_ => _model.AddFinalVideoClip());
        }
    }
    public ICommand AddFinalVideoCommand
    {
        get
        {
            return new RelayCommand(_ => _model.AddFinalVideo());
        }
    }
    public ICommand AddClipWithCatCommand
    {
        get
        {
            return new RelayCommand(_ => _model.AddClipWithCat());
        }
    }
    public ICommand UndoChangesCommand
    {
        get
        {
            return new RelayCommand(_ => _model.UndoChanges());
        }
    }
    private void ModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(e.PropertyName!); //свойства модели и вьюмодели имеют эквивалентные названия
    }

    public void InitCollections()
    {
        var context = _model.Context;
        Clips = context.Clips.Local.ToObservableCollection();
        Categories = context.Categories.Local.ToObservableCollection();
        Channels = context.Channels.Local.ToObservableCollection();
        ClipsWithCats = context.ClipsWithCat.Local.ToObservableCollection();
        FinalVideos = context.FinalVideos.Local.ToObservableCollection();
        FinalVideoClips = context.FinalVideoClips.Local.ToObservableCollection();
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