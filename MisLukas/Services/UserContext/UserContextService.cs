using System;
using MisLukas.Models;

namespace MisLukas.Services.UserContext;

public class UserContextService : IUserContextService
{
    private Usuario? _currentUser;
    public Usuario? CurrentUser
    {
        get => _currentUser;
        set
        {
            _currentUser = value;
            ProfileChanged?.Invoke(_currentUser!);
        }
    }
    
    public event Action<Usuario>? ProfileChanged;
}