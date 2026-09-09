using Godot;
using System;

public partial class World : Node2D
{
    [Export]
    private int _startingLives = 3;

    [Export]
    private float _spawnMinX = 0f;

    [Export]
    private float _spawnMaxX = 1187f;

    [Export]
    private float _spawnY = 0f;

    [Export]
    private NodePath _scoreLabelPath = "ScoreLabel";

    [Export]
    private NodePath _livesLabelPath = "LivesLabel";

    [Export]
    private PackedScene _ringScene;

    private readonly Random _random = new();
    private Label _scoreLabel;
    private Label _livesLabel;
    private int _score;
    private int _lives;

    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>(_scoreLabelPath);
        _livesLabel = GetNode<Label>(_livesLabelPath);

        _lives = _startingLives;

        if (_ringScene == null)
        {
            _ringScene = GD.Load<PackedScene>("res://Scenes/ring.tscn");
        }

        UpdateScoreLabel();
        UpdateLivesLabel();
    }

    private float GetRandomXCoordinate()
    {
        return (float)_random.NextDouble() * (_spawnMaxX - _spawnMinX) + _spawnMinX;
    }

    private void OnSpawnTimerTimeout()
    {
        var ringInstance = _ringScene.Instantiate<Ring>();
        ringInstance.Position = new Vector2(GetRandomXCoordinate(), _spawnY);
        ringInstance.Collected += OnRingCollected;
        ringInstance.Missed += OnRingMissed;
        AddChild(ringInstance);
    }

    private void OnRingCollected()
    {
        _score += 1;
        UpdateScoreLabel();
    }

    private void OnRingMissed()
    {
        _lives -= 1;

        if (_lives <= 0)
        {
            GetTree().ChangeSceneToFile("res://UI/death.tscn");
            return;
        }

        UpdateLivesLabel();
    }

    private void UpdateScoreLabel()
    {
        _scoreLabel.Text = $"Score: {_score}";
    }

    private void UpdateLivesLabel()
    {
        _livesLabel.Text = $"Lives: {_lives}";
    }
}
