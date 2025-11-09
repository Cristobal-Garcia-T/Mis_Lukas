using System;

namespace MisLukas.Services.Navigation;

public interface INavigationService
{
    event Action<Type>? PageChanged;
    void NavigateTo<TViewModel>() where TViewModel : class;

}