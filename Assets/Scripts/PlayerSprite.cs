using Godot;
using System;

public partial class PlayerSprite : AnimatedSprite2D
{
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{




	}



	public void UpdateAnimations(PlayerState state)
	{
		if (state == PlayerState.FlyingUp)
		{
			Play("fly");
		}
		else if (state == PlayerState.Diving)
		{
			Play("dive");
		}
		else if (state == PlayerState.Gliding)
		{
			Play("glide");
		}

	}


}
