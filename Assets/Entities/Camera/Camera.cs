using Godot;
using System;
using System.ComponentModel;



public partial class Camera : Camera2D
{

	[Export] Vector2 cameraMovement = new(150f, 0);

	[Export] Player player;

	float playerXOffset = 75f;
	public float PlayerXOffset { get { return playerXOffset; } }


	public override void _PhysicsProcess(double delta)
	{

		MoveCamera(delta);
		if (!player.IsDead()) MovePlayer(delta);


	}

	public void MoveCamera(double delta)
	{
		{
			Vector2 position = Position;
			position.X = MathF.Max(Position.X + cameraMovement.X * (float)delta, player.Position.X + playerXOffset);
			Position = position;
		}
	}

	public void MovePlayer(double delta)
	{
		player.AddAdditionalMovement(cameraMovement * (float)delta);

	}




}
