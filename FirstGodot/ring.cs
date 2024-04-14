using Godot;
using System;
using System.Collections;
using System.Diagnostics;



public partial class ring : Node2D
{
    [Export]
    private Label scoreText;
    private Label livesText;
    private Label labelNode; // Reference to the Label node you want to update

  
   


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        scoreText = GetParent().GetNode<Label>("Label");
        livesText = GetParent().GetNode<Label>("Label2");
       
       
        
        

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
        int lives = Lives();
        scoreText.Text = "Score: " + ScoreUpdate().ToString();
        GD.Print(lives);
        
        if(lives == 0){
           
            GetTree().ChangeSceneToFile("res://death.tscn");
        }else{
            livesText.Text = "Lives: " + lives.ToString();
        }

        

        
        
        
    }
    private int ScoreUpdate(){ //function to update the score
        GetParent<world>().score += 1;
        return GetParent<world>().score;
    }

    private int Lives(){ //function to update the lives
        GetParent<world>().lives -= 1;
        return GetParent<world>().lives;
    }
        
    }
