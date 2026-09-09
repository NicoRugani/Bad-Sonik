using Godot;

public partial class PlayerMovement : CharacterBody2D
{
    [Export]
    private float _speed = 600f;

    [Export]
    private float _jumpVelocity = -600f;

    [Export]
    private float _gravity = 1500f;

    public override void _PhysicsProcess(double delta)
    {
        if (GetTree().CurrentScene is World world && !world.IsGameplayActive)
        {
            Velocity = new Vector2(0f, Velocity.Y);
            return;
        }

        Vector2 velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity.Y += _gravity * (float)delta;
        }

        if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
        {
            velocity.Y = _jumpVelocity;
        }

        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        if (!Mathf.IsZeroApprox(direction.X))
        {
            velocity.X = direction.X * _speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(velocity.X, 0f, _speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
