using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MisLukas.Services.Navigation;
using MisLukas.Services.UserContext;
using MisLukas.Services.UsuariosService;

namespace MisLukas.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly IUserContextService _userContext;
    private readonly INavigationService _navigationService;
    private readonly IUsuarioService _usuarioService;
    [ObservableProperty] private string? _username;
    [ObservableProperty] private string? _password;
    [ObservableProperty] private bool _loginSucces;
    [ObservableProperty] private bool _showWarningLabel;
    [ObservableProperty] private string _warningLabel = "";

    public LoginViewModel(IUserContextService userContext, INavigationService navigationService, IUsuarioService usuarioService)
    {
        _navigationService = navigationService;
        _userContext = userContext;
        _usuarioService = usuarioService;
    }

    [RelayCommand]
    private async Task Login()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            ShowWarningLabel = true;
            WarningLabel = "Campos incompletos";
            return;
        }

        if (await _usuarioService.IniciarSesionAsync(Username, Password))
            _navigationService.NavigateTo<BalanceViewModel>();
        else
        {
            ShowWarningLabel = true;
            WarningLabel = "Nombre de usuario o contraseña incorrectos";
        }
    }

    [RelayCommand]
    private void Register()
    {
        _navigationService.NavigateTo<NewUserViewModel>();
    }
}