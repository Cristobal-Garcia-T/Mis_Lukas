using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MisLukas.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentPage;
    
    public MainWindowViewModel()
    {
        _currentPage = App.Services.GetRequiredService<AccountViewModel>();
    }
    
    [RelayCommand]
    public void NavigateToBalance()
    {
        CurrentPage = App.Services.GetRequiredService<BalanceViewModel>();
        Console.WriteLine($"Navigate to {CurrentPage.GetType().Name}");
    }
    [RelayCommand]
    public void NavigateToAccount()
    {
        CurrentPage = App.Services.GetRequiredService<AccountViewModel>();
        Console.WriteLine($"Navigate to {CurrentPage.GetType().Name}");
    }
}