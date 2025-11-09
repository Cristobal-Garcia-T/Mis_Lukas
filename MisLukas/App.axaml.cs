using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using MisLukas.Models;
using MisLukas.Services.Navigation;
using MisLukas.Services.Perfil;
using MisLukas.Services.UserContext;
using MisLukas.ViewModels;
using MisLukas.Views;
using MisLukas.Views.Modals;

namespace MisLukas;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        // DbContext
        services.AddDbContext<SqLiteContext>();
        
        // Services
        services.AddSingleton<IUserContextService, UserContextService>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddTransient<IUsuarioService, UsuarioService>();

        // ViewModels
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<AccountViewModel>();
        services.AddTransient<BalanceViewModel>();

        Services = services.BuildServiceProvider();
        //DbInitializer.Initialize();

        var userContex = Services.GetRequiredService<IUserContextService>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            
            
            desktop.MainWindow = new MainWindow
            {
                DataContext = Services.GetRequiredService<MainWindowViewModel>()
            };

            desktop.MainWindow.Opened += async (sender, e) =>
            {
                if (userContex.CurrentUser == null) {
                    var loginWindow = new LoginView();
                    var result = loginWindow.ShowDialog<Usuario?>(desktop.MainWindow);

                    await result.ContinueWith(task =>
                    {
                        if (task.Result == null)
                            desktop.Shutdown();
                    });
                }
            };
            
            
            desktop.Exit += (sender, e) =>
            {
                //DbInitializer.Delete();
            };

        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}