using Godot;
using System;
using System.Reflection.Metadata;

public partial class Player : CharacterBody2D
{

	[Export] PlayerSprite animatedSprite2D;
	[Export] StateMachine stateMachine;


	public override void _Ready()
	{
		stateMachine.StateChanged += animatedSprite2D.UpdateAnimations;
	}

	public override void _PhysicsProcess(double delta)
	{


		if (!IsDead()) HandleHorizontalMovement(delta);
		Rotate();

		MoveAndSlide();

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
			stateMachine.ChangeState(PlayerState.DEAD);
		}

	}

	private void HandleHorizontalMovement(double delta)
	{

		Vector2 velocity = Velocity;

		float direction = Input.GetAxis("moveLeft", "moveRight");
		if (direction != 0)
		{
			if (direction * velocity.X < 0) velocity.X += PlayerStats.HorizontalBrakeSpeed * direction * (float)delta;
			else velocity.X = Mathf.Clamp(velocity.X + PlayerStats.HorizontalMoveSpeed * (float)delta * direction, -PlayerStats.HorizontalMoveSpeedLimit, PlayerStats.HorizontalMoveSpeedLimit);

		}
		else
		{

			velocity.X *= 0.95f;

		}

		Velocity = velocity;


	}

	public bool IsDead()
	{
		return stateMachine.StateName == PlayerState.DEAD;
	}

	public void AddAdditionalMovement(Vector2 additionalMovement)
	{
		Position += additionalMovement;
	}

	private void Rotate()
	{
		float velocity = Velocity.Y;
		RotationDegrees = velocity / 3;
	}

}
