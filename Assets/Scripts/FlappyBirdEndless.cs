using Godot;
using System;

public partial class FlappyBirdEndless : Node2D
{

	[Export] GameManager gameManager;
	[Export] FlappyBirdGenerator flappyBirdGenerator;



	public override void _Ready()
	{
		flappyBirdGenerator.PipeSpawned += ConnectScorezoneSignal;
	}

	private void ConnectScorezoneSignal(Node2D spawnedPipe)
	{
		var spawnedPipeScorezone = spawnedPipe.GetNode<Scorezone>("Scorezone");
		spawnedPipeScorezone.Connect(Scorezone.SignalName.PointScored, Callable.From(gameManager.AddPoint));
	}

}
