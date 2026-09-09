using Godot;
using System;

public partial class Ring : Node2D
{
    public event Action Collected;
    public event Action Missed;

    private const string PlayerGroup = "Player";
    private const string MissZoneGroup = "RingMissZone";

    private bool _resolved;

    private void OnBodyEntered(Node body)
    {
        if (_resolved || body == null)
        {
            return;
        }

        if (IsPlayerBody(body))
        {
            Resolve(Collected);
            return;
        }

        // Only the dedicated miss zone should consume a life.
        if (body.IsInGroup(MissZoneGroup))
        {
            Resolve(Missed);
        }
    }

    private void Resolve(Action callback)
    {
        _resolved = true;
        callback?.Invoke();
        QueueFree();
    }

    private static bool IsPlayerBody(Node body)
    {
        return body.IsInGroup(PlayerGroup);
    }
}
