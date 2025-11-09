using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using MisLukas.ViewModels;

namespace MisLukas.Views.Modals;

public partial class LoginView : Window
{
    public LoginView()
    {
        var vm = App.Services.GetRequiredService<LoginViewModel>();
        DataContext = vm;
        InitializeComponent();
        
        vm.RequestClose += currentUser => Close(currentUser);
    }
}