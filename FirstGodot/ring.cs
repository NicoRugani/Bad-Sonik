using Godot;
using System;
using System.Collections;
using System.Diagnostics;



public partial class ring : Node2D
{
    [Export]
    private Label scoreText;

    private CharacterBody2D player;
    private Label labelNode; // Reference to the Label node you want to update

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        scoreText = GetParent().GetNode<Label>("Label");
        player = (CharacterBody2D)GetNode("../Player");
        
        

        // Get reference to the Label node called "Label"
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // Your _Process() implementation
    }

    private void _on_rigid_body_2d_body_entered(Node body)
    {
        QueueFree();
        GD.Print(player);
        
        if(body == player){
            scoreText.Text = "Score: " + ScoreUpdate().ToString();
        }
        
       
        
        
    }
    private int ScoreUpdate(){
        GetParent<world>().score += 1;
        return GetParent<world>().score;
    }
        
    }
