using Godot;
using System;

public partial class GameManager : Node
{

	int score = 0;
	[Export] Label scoreLabel;
	[Export] Label gameOverScoreLabel;
	[Export] PanelContainer gameOverPanel;


	public override void _Ready()
	{
		Global.signalBus.PlayerDied += EndGame;
	}



	public void AddPoint()
	{
		score++;
		UpdateScoreLabel();
	}

	private void UpdateScoreLabel()
	{
		scoreLabel.Text = "Score: " + score;
	}

	private void EndGame()
	{
		gameOverPanel.Visible = true;
		gameOverScoreLabel.Text = "Final score: " + score;
	}

	public override void _ExitTree()
	{
		Global.signalBus.PlayerDied -= EndGame;
	}



}
