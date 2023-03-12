using System.Windows;
using System.Windows.Controls;
using VideosManager.Models;
using VideosManager.Viewmodels;

namespace VideosManager.Views;
public partial class VideosManagerWindow : Window
{
    MainModel _model;
    MainViewmodel _viewmodel;

    public VideosManagerWindow()
    {
        InitializeComponent();

        _model = new MainModel();
        _viewmodel = new MainViewmodel(_model);
        _model.Viewmodel = _viewmodel;
        DataContext = _viewmodel;
    }
}
