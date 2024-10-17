using Godot;
using System;

public partial class Player : CharacterBody2D
{

	[Export] MoveComponent moveComponent;
	[Export] PlayerSprite animatedSprite2D;
	PlayerState state;


	public override void _PhysicsProcess(double delta)
	{

		if (!IsDead())
		{
			SwitchState();
		}
		moveComponent.HandlePlayerMovement(this);
		Rotate();

		animatedSprite2D.UpdateAnimations(state);

	}

	private void SwitchState()
	{
		if (Input.IsActionPressed("flyUp"))
		{
			state = PlayerState.FlyingUp;
		}
		else if (Input.IsActionPressed("dive"))
		{
			state = PlayerState.Diving;
		}
		else
		{
			state = PlayerState.Gliding;
		}
	}

	public PlayerState GetState()
	{
		return state;
	}

	public void Die()
	{
		if (!IsDead())
		{
			Global.signalBus.EmitSignal(SignalBus.SignalName.PlayerDied);
			state = PlayerState.Dead;
			moveComponent.AddDeathJump(this);
		}

	}

	public bool IsDead()
	{
		return state == PlayerState.Dead;
	}

	public void SetAdditionalMovement(Vector2 additionalMovement)
	{
		moveComponent.SetAdditionalMovement(additionalMovement);
	}

	private void Rotate()
	{
		float velocity = Velocity.Y;
		RotationDegrees = velocity / 3;
	}

}

public enum PlayerState
{
	FlyingUp,
	Diving,
	Gliding,
	Dead
}