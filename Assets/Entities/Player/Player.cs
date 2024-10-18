using Godot;
using System;

public partial class Player : CharacterBody2D
{

	[Export] MoveComponent moveComponent;
	[Export] PlayerSprite animatedSprite2D;
	[Export] StateMachine stateMachine;


	public override void _Ready()
	{
		stateMachine.StateChanged += animatedSprite2D.UpdateAnimations;
	}

	public override void _PhysicsProcess(double delta)
	{

		Rotate();

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
		Position += additionalMovement;
	}

	private void Rotate()
	{
		float velocity = Velocity.Y;
		RotationDegrees = velocity / 3;
	}

}
