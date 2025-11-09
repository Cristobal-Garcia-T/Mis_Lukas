using System;
using MisLukas.Models;

namespace MisLukas.Services.UserContext;

public interface IUserContextService
{
    Usuario? CurrentUser { get; set; }
    event Action<Usuario>? ProfileChanged;
}