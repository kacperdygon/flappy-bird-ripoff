using Godot;
using System;

public partial class PlayerSprite : AnimatedSprite2D
{


	public void UpdateAnimations(string state)
	{
		// GD.Print("Animations updated!");
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

			default:
				GD.Print("state not recognized");
				GD.Print(state);

				break;



		}

	}


}
