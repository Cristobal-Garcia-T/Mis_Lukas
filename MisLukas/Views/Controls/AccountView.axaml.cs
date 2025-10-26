using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using MisLukas.ViewModels;

namespace MisLukas.Views;

public partial class AccountView : UserControl
{
    public AccountView()
    {
        DataContext = App.Services.GetRequiredService<AccountViewModel>();
        InitializeComponent();
    }
}