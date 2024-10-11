using Godot;
using System;



public partial class Camera : Camera2D
{
	// Called when the node enters the scene tree for the first time.

	const float CameraMovementX = 150f;
	

	[Export] 
	bool isYStatic;

	[Export] Player player;

	float playerXOffset = 75f;
	public float PlayerXOffset { get {return playerXOffset;}}


	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		
		Vector2 position = Position;
		position.X = MathF.Max(Position.X + CameraMovementX * (float)delta, player.Position.X + playerXOffset);
		if (!isYStatic) position.Y = player.Position.Y;
		Position = position;

		// Position = Position.Round();


		
		player.AddHorizontalMovement(CameraMovementX * (float)delta);

		


	}




}
