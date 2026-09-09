using Godot;

public partial class DeathMenu : Control
{
    private void OnPlayAgainButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/world.tscn");
    }

    private void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }
}
