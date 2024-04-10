using Godot;
using System;

public partial class ring : Node2D
{
    [Export]
    private int score = 0;
    private Label scoreText;
    private Label labelNode; // Reference to the Label node you want to update

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        scoreText = GetNode<Label>("TxtLabel");
        scoreText.Text = "Score: " + score;

        // Get reference to the Label node called "Label"
        labelNode = GetNode<Label>("Label");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // Your _Process() implementation
    }

    private void _on_rigid_body_2d_body_entered(Node body)
    {
        score += 1;
        QueueFree(); /

        // Update the score text
        scoreText.Text = "Score: " + score;

        // Update the label node text with the updated score
        if (labelNode != null)
        {
            labelNode.Text = "Score: " + score;
        }
        else
        {
            GD.Print("Label node not found!"); // Print error message if the Label node is not found
        }
    }
}
