using Godot;
using System;

public partial class Player : CharacterBody2D
{

	[Export] MoveComponent moveComponent;
	[Export] PlayerSprite animatedSprite2D;
	[Export] StateMachine stateMachine;


	public override void _PhysicsProcess(double delta)
	{

		if (!IsDead())
		{
			SwitchState();
		}
		Rotate();

		animatedSprite2D.UpdateAnimations(stateMachine.StateName);

	}

	private void SwitchState()
	{
		if (Input.IsActionPressed("flyUp"))
		{
			// state = State.FlyingUp;
		}
		else if (Input.IsActionPressed("dive"))
		{
			// state = State.Diving;
		}
		else
		{
			// state = State.Gliding;
		}
	}

	public string GetState()
	{
		return stateMachine.StateName;
	}

	public void Die()
	{
		if (!IsDead())
		{
			Global.signalBus.EmitSignal(SignalBus.SignalName.PlayerDied);
		}

	}

	public bool IsDead()
	{
		return stateMachine.StateName == PlayerState.DEAD;
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

// public enum State
// {
// 	FlyingUp,
// 	Diving,
// 	Gliding,
// 	Dead
// }