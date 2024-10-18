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



	public void UpdateAnimations(string state)
	{
		switch (state)
		{
			case PlayerState.FLYINGUP:

				Play("fly");

				break;

			case PlayerState.DIVING:

				Play("dive");

				break;

			case PlayerState.GLIDING:

				Play("glide");

				break;


		}

	}


}
