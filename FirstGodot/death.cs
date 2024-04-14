using Godot;
using System;

public partial class death : Control
{
	private Label finalScore;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		finalScore = GetNode<Label>("Label2");
		finalScore = GetParent<ring>().GetNode<Label>("Label");
		
	}

	private void _on_button_pressed()
	{
		
		GetTree().ChangeSceneToFile("res://world.tscn");


	}

	private void _on_button_2_pressed(){
		GetTree().Quit();
	}

	/*private Label GetScore(){
		
		
        return GetParent<ring>().GetNode<Label>("Label");
		
		
	}*/
}
