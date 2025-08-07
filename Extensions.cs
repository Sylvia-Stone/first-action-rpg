using System.Collections.Generic;
using System.Linq;
using Godot;

namespace FirstActionRPG;

public static class Extensions
{
    public static bool In<T>(this T obj, params T[]? collection)
    {
        return collection?.Contains(obj) ?? false;
    }
}