using System;
using CommunityToolkit.Mvvm.Input;
using MisLukas.Models;
using MisLukas.Services.UserContext;

namespace MisLukas.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    public string Text { get; set; }
    private readonly IUserContextService _userContext;
    private readonly Usuario _someUser = new Usuario
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

    public LoginViewModel(IUserContextService userContext)
    {
        _userContext = userContext;
        Text = "Seleccionar Usuario";
    }

    [RelayCommand]
    private void Login()
    {
        _userContext.CurrentUser = _someUser;
        RequestClose?.Invoke(_userContext.CurrentUser);
    }
    
    public event Action<Usuario?>? RequestClose; 
}