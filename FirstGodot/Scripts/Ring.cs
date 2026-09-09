using Godot;
using System;

public partial class Ring : Node2D
{
    public event Action Collected;
    public event Action Missed;

    private bool _resolved;

    private void OnBodyEntered(Node body)
    {
        if (_resolved)
        {
            return;
        }

        _resolved = true;

        if (IsPlayerBody(body))
        {
            Collected?.Invoke();
        }
        else
        {
            Missed?.Invoke();
        }

        QueueFree();
    }

    private static bool IsPlayerBody(Node body)
    {
        return body.IsInGroup("Player")
            || body is PlayerMovement
            || body.GetParent() is PlayerMovement;
    }
}
