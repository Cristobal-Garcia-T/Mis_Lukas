using System;
using MisLukas.Models;

namespace MisLukas.Services;

public class DbInitializer
{
    public static void Initialize()
    {
        using var db = new SqLiteContext();
        var isCreated = db.Database.EnsureCreated();
        Console.WriteLine($"Database created");
    }

    public static void Delete()
    {
        using var db = new SqLiteContext();
        db.Database.EnsureDeleted();
        Console.WriteLine($"Database deleted");
    }

}