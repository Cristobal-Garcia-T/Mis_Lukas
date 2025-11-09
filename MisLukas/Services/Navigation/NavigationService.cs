using System;

namespace MisLukas.Services.Navigation;

public class NavigationService : INavigationService
{
    public event Action<Type>? PageChanged;
    public void NavigateTo<TViewModel>() where TViewModel : class
    {
        PageChanged?.Invoke(typeof(TViewModel));
    }
}