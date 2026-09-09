using Godot;

public partial class DeathMenu : Control
{
    private void OnPlayAgainButtonPressed()
    {
        Error result = GetTree().ChangeSceneToFile("res://Scenes/world.tscn");
        if (result != Error.Ok)
        {
            GD.PushError($"Failed to restart world scene: {result}");
        }
    }

    private void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }
}
