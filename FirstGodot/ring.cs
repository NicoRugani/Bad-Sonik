using Godot;
using System;
using System.Diagnostics;
public partial class ring : Node2D
{
	[Export]
	RigidBody2D body {get;set;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	
	private void _on_rigid_body_2d_body_entered(Node body)
	{
		
		QueueFree();
	}
}
