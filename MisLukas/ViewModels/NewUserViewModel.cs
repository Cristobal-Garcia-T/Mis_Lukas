using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MisLukas.Services.Navigation;
using MisLukas.Services.UsuariosService;

namespace MisLukas.ViewModels;


public partial class NewUserViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IUsuarioService _usuarioService;
    
    [ObservableProperty] private string? _username;
    
    [ObservableProperty] private string? _password;
    
    [ObservableProperty] private string? _confirmPassword;

    [ObservableProperty] private bool _showWarningLabel;
    
    [ObservableProperty] private string _warningLabel = "";

    public NewUserViewModel(INavigationService navigationService, IUsuarioService usuarioService)
    {
        _navigationService = navigationService;
        _usuarioService = usuarioService;
    }

    [RelayCommand]
    private async Task Register()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
        {
            ShowWarningLabel = true;
            WarningLabel = "Campos incompletos";
            return;
        }
        if (Password != ConfirmPassword)
        {
            ShowWarningLabel = true;
            WarningLabel = "Las contraseñas no coinciden";
            return;
        }

        if (await _usuarioService.ExisteUsuarioAsync(Username!))
        {
            ShowWarningLabel = true;
            WarningLabel = "El nombre de usuario ya está en uso";
            return;
        }
        
        await _usuarioService.CrearAsync(Username, Password);
        
        _navigationService.NavigateTo<LoginViewModel>();
    }

    [RelayCommand]
    private void GoBack()
    {
        _navigationService.NavigateTo<LoginViewModel>();
    }
}