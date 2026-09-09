using Godot;
using System;


public partial class world : Node2D
{
	// Tracks collected rings in the current run.
	[Export]
	public int score;

	// Player loses one life each time a ring reaches a wall/ground collider.
	public int lives = 3;
	Random random = new Random();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private float GetRandomXCoordinate(float minX, float maxX){
		// Returns a random horizontal spawn location inside the play area.
		return (float)random.NextDouble() * (maxX - minX) + minX;
	}
	
	private void _on_spawn_timer_timeout()
	{
		// Spawns a new falling ring whenever the world timer fires.
		float randomX = GetRandomXCoordinate(0f, 1187f);
		var scene = GD.Load<PackedScene>("res://ring.tscn");
		var instance = (Node2D)scene.Instantiate();
		
		AddChild(instance);
		instance.Position = new Vector2(randomX, 0);
	}
	
	
}


