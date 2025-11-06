using System;
using UnityEngine;

public static class GlobalEvents
{
    public static event Action OnPlayerKilled;

    public static void PlayerKilled() => OnPlayerKilled?.Invoke();
}
