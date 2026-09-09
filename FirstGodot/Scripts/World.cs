using Godot;
using System;
using System.Collections.Generic;

public partial class World : Node2D
{
    private enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    [Export]
    private int _startingLives = 3;

    [Export]
    private float _spawnMinX = 0f;

    [Export]
    private float _spawnMaxX = 1187f;

    [Export]
    private float _spawnY = 0f;

    [Export(PropertyHint.Range, "0.1,10,0.1")]
    private double _spawnIntervalSeconds = 1.0;

    [Export(PropertyHint.Range, "0,300,1")]
    private float _spawnEdgePadding = 32f;

    [Export(PropertyHint.Range, "0,300,1")]
    private float _minimumSpawnDistance = 64f;

    [Export(PropertyHint.Range, "1,20,1")]
    private int _maxSpawnAttempts = 8;

    [Export]
    private NodePath _scoreLabelPath = "ScoreLabel";

    [Export]
    private NodePath _livesLabelPath = "LivesLabel";

    [Export]
    private NodePath _spawnTimerPath = "SpawnTimer";

    [Export]
    private PackedScene _ringScene;

    private readonly Random _random = new();
    private readonly HashSet<Ring> _activeRings = new();

    private Label _scoreLabel;
    private Label _livesLabel;
    private Timer _spawnTimer;

    private int _score;
    private int _lives;
    private GameState _gameState = GameState.MainMenu;
    public bool IsGameplayActive => _gameState == GameState.Playing;

    public override void _Ready()
    {
        _scoreLabel = GetNodeOrNull<Label>(_scoreLabelPath);
        _livesLabel = GetNodeOrNull<Label>(_livesLabelPath);
        _spawnTimer = GetNodeOrNull<Timer>(_spawnTimerPath);

        if (_scoreLabel == null || _livesLabel == null || _spawnTimer == null)
        {
            GD.PushError("World initialization failed because one or more required nodes are missing.");
            return;
        }

        if (_ringScene == null)
        {
            _ringScene = GD.Load<PackedScene>("res://Scenes/ring.tscn");
        }

        if (_ringScene == null)
        {
            GD.PushError("World initialization failed because ring scene could not be loaded.");
            return;
        }

        StartRound();
    }

    public override void _ExitTree()
    {
        ClearActiveRings();
    }

    private void StartRound()
    {
        _score = 0;
        _lives = Mathf.Max(1, _startingLives);

        UpdateScoreLabel();
        UpdateLivesLabel();

        SetGameState(GameState.Playing);

        _spawnTimer.WaitTime = _spawnIntervalSeconds;
        _spawnTimer.Start();
    }

    private void SetGameState(GameState newState)
    {
        _gameState = newState;

        if (_gameState != GameState.Playing)
        {
            _spawnTimer?.Stop();
        }
    }

    private float GetRandomXCoordinate()
    {
        float minX = Mathf.Min(_spawnMinX, _spawnMaxX) + _spawnEdgePadding;
        float maxX = Mathf.Max(_spawnMinX, _spawnMaxX) - _spawnEdgePadding;

        if (maxX <= minX)
        {
            return minX;
        }

        return (float)_random.NextDouble() * (maxX - minX) + minX;
    }

    private bool TryFindSpawnPosition(out Vector2 spawnPosition)
    {
        for (int attempt = 0; attempt < Mathf.Max(1, _maxSpawnAttempts); attempt++)
        {
            spawnPosition = new Vector2(GetRandomXCoordinate(), _spawnY);

            bool overlapsExisting = false;
            foreach (Ring ring in _activeRings)
            {
                if (!IsInstanceValid(ring))
                {
                    continue;
                }

                if (ring.GlobalPosition.DistanceTo(spawnPosition) < _minimumSpawnDistance)
                {
                    overlapsExisting = true;
                    break;
                }
            }

            if (!overlapsExisting)
            {
                return true;
            }
        }

        spawnPosition = new Vector2(GetRandomXCoordinate(), _spawnY);
        return false;
    }

    private void OnSpawnTimerTimeout()
    {
        if (!IsGameplayActive || _ringScene == null)
        {
            return;
        }

        Ring ringInstance = _ringScene.Instantiate<Ring>();

        TryFindSpawnPosition(out Vector2 spawnPosition);
        ringInstance.Position = spawnPosition;

        ringInstance.Collected += OnRingCollected;
        ringInstance.Missed += OnRingMissed;
        ringInstance.TreeExiting += () => OnRingTreeExiting(ringInstance);

        _activeRings.Add(ringInstance);
        AddChild(ringInstance);
    }

    private void OnRingTreeExiting(Ring ring)
    {
        if (!IsInstanceValid(ring))
        {
            return;
        }

        ring.Collected -= OnRingCollected;
        ring.Missed -= OnRingMissed;
        _activeRings.Remove(ring);
    }

    private void OnRingCollected()
    {
        if (!IsGameplayActive)
        {
            return;
        }

        _score += 1;
        UpdateScoreLabel();
    }

    private void OnRingMissed()
    {
        if (!IsGameplayActive)
        {
            return;
        }

        _lives -= 1;
        UpdateLivesLabel();

        if (_lives > 0)
        {
            return;
        }

        _lives = 0;
        UpdateLivesLabel();

        SetGameState(GameState.GameOver);
        ClearActiveRings();

        Error result = GetTree().ChangeSceneToFile("res://UI/death.tscn");
        if (result != Error.Ok)
        {
            GD.PushError($"Failed to load death scene: {result}");
        }
    }

    private void ClearActiveRings()
    {
        foreach (Ring ring in _activeRings)
        {
            if (!IsInstanceValid(ring))
            {
                continue;
            }

            ring.Collected -= OnRingCollected;
            ring.Missed -= OnRingMissed;
            ring.QueueFree();
        }

        _activeRings.Clear();
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
