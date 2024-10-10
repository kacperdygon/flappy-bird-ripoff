using Godot;
using System;
using System.Collections.Generic;

public partial class FlappyBirdGenerator : Node2D
{

	[Signal]
	public delegate void PipeSpawnedEventHandler(Node2D spawnedPipe);
	const float PipeInterval = 200;
	const float DistanceFromCamera = 700;
	int pipesSpawned = 0;
	Vector2 startPosition;

	PackedScene pipeSet;

	Random randomNumber = new();
	Camera camera;
	
	public override void _Ready()
	{
		
		startPosition = GlobalPosition;
		camera = GetViewport().GetCamera2D() as Camera;
		pipeSet = GD.Load<PackedScene>("res://Assets/Scenes/Flappy bird/pipe_set.tscn");
		
	}

	public override void _Process(double delta)
	{
		if ((camera.Position.X - camera.PlayerXOffset) / PipeInterval > pipesSpawned) 
		{
			SpawnPipe();
			if (GetChildCount() == 5) GetChild(0).QueueFree();
		}
		
	}



	private void SpawnPipe()
	{
		pipesSpawned++;
		Vector2 position;
		position.Y = randomNumber.Next((int)GlobalPosition.Y - 80, (int)GlobalPosition.Y + 81);
		position.X = camera.Position.X;
		var currentPipeSet = pipeSet.Instantiate() as Node2D;
		currentPipeSet.Position = position;


		AddChild(currentPipeSet);
		EmitSignal(SignalName.PipeSpawned, currentPipeSet);
		
		
	
	}


}
