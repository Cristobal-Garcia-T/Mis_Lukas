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
    public void NavigateToCuentas()
    {
        CurrentPage = App.Services.GetRequiredService<AccountViewModel>();
        Console.WriteLine($"Navigate to {CurrentPage.GetType().Name}");
    }
    [RelayCommand]
    public void NavigateToBalance()
    {
        CurrentPage = App.Services.GetRequiredService<BalanceViewModel>();
        Console.WriteLine($"Navigate to {CurrentPage.GetType().Name}");
    }

    [RelayCommand]
    public void NavigateToGastos()
    {
        throw new NotImplementedException();
    }
    [RelayCommand]
    public void NavigateToIngresos()
    {
        throw new NotImplementedException();
    }
    [RelayCommand]
    public void NavigateToDeudas()
    {
        throw new NotImplementedException();
    }
    [RelayCommand]
    public void NavigateToPresupuestos()
    {
        throw new NotImplementedException();
    }

    [RelayCommand]
    public void NavigateToPerfil()
    {
        throw new NotImplementedException();
    }
    [RelayCommand]
    public void NavigateToConfiguracion()
    {
        throw new NotImplementedException();
    }
    [RelayCommand]
    public void NavigateToChangeCurrentUser()
    {
        throw new NotImplementedException();
    }
}