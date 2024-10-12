using Godot;
using System;

public partial class Player : CharacterBody2D
{



	private const float HorizontalMoveSpeed = 200f;
	private const float HorizontalBrakeSpeed = 500f;
	private const float HorizontalSlowDownFactor = 0.9f;
	private const float HorizontalMoveSpeedLimit = 100f;

	private const float FlyUpGravity = 330f;
	private const float FlyUpSpeedLimit = -150f;

	private const float DiveGravity = 500f;
	private const float DiveSpeedLimit = 250f;

	private const float FallGravity = 200f;
	private const float FallSpeedLimit = 120f;
	private const float FallLimiter = -50f;

	private const float BrakingPower = 2f;
	private const float HorizontalDiveSpeedModifier = 1.3f;



	PlayerState state;
	private float generalSpeedModifier;

	[Export] PlayerSprite animatedSprite2D;

	public override void _Ready()
	{

	}


	public override void _PhysicsProcess(double delta)
	{

		GetState();
		HandleMovement(delta);
		UpdateSpeedModifiers();
		Rotate();

		MoveAndSlide();

		animatedSprite2D.UpdateAnimations(state);

	}

	private void GetState()
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


	private void HandleMovement(double delta)
	{

		Vector2 velocity = Velocity;

		// MOVEMENT Y



		switch (state)
		{
			case PlayerState.FlyingUp:

				if (velocity.Y > 0) // faster flying up when facing down
				{
					velocity.Y -= FlyUpGravity * BrakingPower * (float)delta;
				}
				else
				{
					velocity.Y = Mathf.Max(velocity.Y - FlyUpGravity * (float)delta, FlyUpSpeedLimit);
				}

				break;

			case PlayerState.Diving:


				velocity.Y = Mathf.Min(velocity.Y + DiveGravity * (float)delta, DiveSpeedLimit);

				break;

			case PlayerState.Gliding:

				if (velocity.Y > FallSpeedLimit)
				{
					velocity.Y += FallLimiter * (float)delta;
				}
				else
				{
					velocity.Y = MathF.Min(velocity.Y += FallGravity * (float)delta, FallSpeedLimit);
				}

				break;

		}

		// MOVEMENT X


		float direction = Input.GetAxis("moveLeft", "moveRight");
		if (direction != 0)
		{
			if ((direction < 0 && velocity.X > 0) || direction > 0 && velocity.X < 0) velocity.X += HorizontalBrakeSpeed * direction * (float)delta;
			else if (state == PlayerState.Diving && velocity.Y > FallSpeedLimit) velocity.X = Mathf.Clamp(velocity.X + HorizontalMoveSpeed * (float)delta * direction * HorizontalDiveSpeedModifier, -HorizontalMoveSpeedLimit * HorizontalDiveSpeedModifier, HorizontalMoveSpeedLimit * HorizontalDiveSpeedModifier);
			else velocity.X = Mathf.Clamp(velocity.X + HorizontalMoveSpeed * (float)delta * direction, -HorizontalMoveSpeedLimit, HorizontalMoveSpeedLimit);

		}
		else
		{

			velocity.X *= 0.95f;

		}

		Velocity = velocity;

	}

	private void UpdateSpeedModifiers()
	{
		if (state == PlayerState.Diving) generalSpeedModifier *= HorizontalDiveSpeedModifier;
	}

	public void Die()
	{
		Global.signalBus.EmitSignal(SignalBus.SignalName.PlayerDied);
	}

	public void AddHorizontalMovement(float movement)
	{
		var positionTemp = Position;
		positionTemp.X += movement;
		Position = positionTemp;
	}

	private void Rotate()
	{
		// RotationDegrees = Mathf.RadToDeg(Velocity.Angle());
		float velocity = Velocity.Y;
		RotationDegrees = velocity / 3;
	}




}

public enum PlayerState
{
	FlyingUp,
	Diving,
	Gliding
}