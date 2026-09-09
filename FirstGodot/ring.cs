using Godot;
using System;
using System.Collections;
using System.Diagnostics;



public partial class ring : Node2D
{
    // HUD labels in the parent world scene.
    [Export]
    private Label scoreText;
    private Label livesText;
 
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        scoreText = GetParent().GetNode<Label>("Label");
        livesText = GetParent().GetNode<Label>("Label2");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        
    }

    private void _on_rigid_body_2d_body_entered(Node body)
    {
        // If the player touches a ring, award score; otherwise remove a life.
        if(body.Name == "CharacterBody2D"){//checks to see what the ring is colliding with
            QueueFree();
            scoreText.Text = "Score: " + ScoreUpdate().ToString();

        }
        else{
            QueueFree();
            int lives = Lives();
            if(lives == 0){
                // Move to the game-over screen when all lives are consumed.
                GetTree().ChangeSceneToFile("res://death.tscn");//changes scene to death screen
            }else{
                livesText.Text = "Lives: " + lives.ToString();
            }
        }  
        
        
    }
    private int ScoreUpdate(){ //function to update the score
        // Keep score state in the world scene so all rings share the same value.
        GetParent<world>().score += 1;
        return GetParent<world>().score;
    }

    private int Lives(){ //function to update the lives
        // Keep lives state in the world scene so all rings share the same value.
        GetParent<world>().lives -= 1;
        return GetParent<world>().lives;
    }
        
    }
