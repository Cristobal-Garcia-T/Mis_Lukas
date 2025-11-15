using System;
using CommunityToolkit.Mvvm.Input;
using MisLukas.Models;
using MisLukas.Services.Navigation;
using MisLukas.Services.UserContext;

namespace MisLukas.ViewModels;

public partial class NavigationMenuViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IUserContextService _userContextService;
    
    public NavigationMenuViewModel(INavigationService navigationService, IUserContextService userContextService)
    {
        _navigationService = navigationService;
        _userContextService = userContextService;
        _userContextService.ProfileChanged += OnProfileChanged;

    }

    public bool UserLoggedIn => _userContextService.CurrentUser != null;

    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToCuentas() => _navigationService.NavigateTo<AccountViewModel>();

    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToBalance() => _navigationService.NavigateTo<BalanceViewModel>();

    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToGastos()
    {
        throw new NotImplementedException();    
    }
    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToIngresos()
    {
        throw new NotImplementedException();
    }
    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToDeudas()
    {
        throw new NotImplementedException();
    }
    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToPresupuestos()
    {
        throw new NotImplementedException();
    }

    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToPerfil()
    {
        throw new NotImplementedException();
    }
    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToConfiguracion()
    {
        throw new NotImplementedException();
    }

    [RelayCommand (CanExecute = nameof(UserLoggedIn))]
    private void NavigateToChangeCurrentUser()
    {
        _navigationService.NavigateTo<LoginViewModel>();
        _userContextService.CurrentUser = null;
    }


    private void OnProfileChanged(Usuario? user)
    {
        OnPropertyChanged(nameof(UserLoggedIn));
        NavigateToCuentasCommand.NotifyCanExecuteChanged();
        NavigateToBalanceCommand.NotifyCanExecuteChanged();
        /*
        NavigateToGastosCommand.NotifyCanExecuteChanged();
        NavigateToIngresosCommand.NotifyCanExecuteChanged();
        NavigateToDeudasCommand.NotifyCanExecuteChanged();
        NavigateToPresupuestosCommand.NotifyCanExecuteChanged();
        NavigateToPerfilCommand.NotifyCanExecuteChanged();
        NavigateToConfiguracionCommand.NotifyCanExecuteChanged();
        */
        NavigateToChangeCurrentUserCommand.NotifyCanExecuteChanged();
    }
}