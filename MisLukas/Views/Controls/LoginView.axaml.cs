using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using MisLukas.ViewModels;

namespace MisLukas.Views;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        DataContext = App.Services.GetRequiredService<LoginViewModel>();
        InitializeComponent();
    }
}