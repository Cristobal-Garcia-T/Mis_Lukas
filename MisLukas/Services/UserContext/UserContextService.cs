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
            if (value == null)
                throw new ArgumentNullException(nameof(value), "El usuario activo no puede ser null.");
            
            _currentUser = value;
            ProfileChanged?.Invoke(_currentUser);
        }
    }
    
    public event Action<Usuario>? ProfileChanged;
}