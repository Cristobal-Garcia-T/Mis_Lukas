using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MisLukas.Models;
using MisLukas.Services.Navigation;
using MisLukas.Services.UserContext;

namespace MisLukas.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly IUserContextService _userContext;
    private readonly INavigationService _navigationService;
    [ObservableProperty]
    private string? _username;
    [ObservableProperty]
    private string? _password;

    private Usuario _someUser = new Usuario
    {
        IdUsuario = 0,
        Nombre = "Cristobal",
        PasswordHash = "null",
        FechaRegistro = DateTime.Now,
        Cuentas = [],
        Presupuestos = [],
        Deudas = [],
        Categorias = []
    };

    public LoginViewModel(IUserContextService userContext, INavigationService navigationService)
    {
        _navigationService = navigationService;
        _userContext = userContext;
    }

    [RelayCommand]
    private void Login()
    {
        _someUser.Nombre = Username!;
        _someUser.PasswordHash = Password!;
        _userContext.CurrentUser = _someUser;
    }

    [RelayCommand]
    private void Register()
    {
        _navigationService.NavigateTo<NewUserViewModel>();
    }
}