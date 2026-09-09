using Godot;

public partial class PlayerMovement : CharacterBody2D
{
    public const float Speed = 600f;
    public const float JumpVelocity = -600f;

    [Export]
    private float _gravity = 1500f;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity.Y += _gravity * (float)delta;
        }

        if (Input.IsActionJustPressed("ui_up") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
