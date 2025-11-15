using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using MisLukas.Services.Navigation;

namespace MisLukas.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;

    private readonly INavigationService _navigationService;
    
    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.PageChanged += OnNavigation;
        _currentPage = App.Services.GetRequiredService<LoginViewModel>();
    }

    private void OnNavigation(Type vmType)
    {
        CurrentPage = (ViewModelBase)App.Services.GetRequiredService(vmType);
    }
}