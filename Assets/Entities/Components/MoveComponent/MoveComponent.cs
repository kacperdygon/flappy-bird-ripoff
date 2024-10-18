using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class MoveComponent : Node2D
{



	// public void HandleMovement()
	// {

	// 	Vector2 velocity = parent.Velocity;
	// 	double delta = GetTree().Root.GetPhysicsProcessDeltaTime();

	// 	switch (parent.State)
	// 	{
	// 		case State.FlyingUp:

	// 			velocity = HandleFlyingUp(delta, velocity);
	// 			break;

	// 		case State.Diving:

	// 			velocity = HandleDiving(delta, velocity);
	// 			break;

	// 		case State.Gliding:

	// 			velocity = HandleGliding(delta, velocity);
	// 			break;
	// 		case State.Dead:

	// 			velocity = HandleDead(delta, velocity);
	// 			break;

	// 	}

	// 	if (!parent.IsDead()) velocity = HandleHorizontalMovement(delta, velocity);

	// 	parent.Velocity = velocity;

	// 	parent.MoveAndSlide();

	// 	if (!parent.IsDead()) ApplyAdditionalMovement(parent);

	// }

	// private void HandleGliding(double delta, Vector2 velocity)
	// {

	// 	if (velocity.Y > FallSpeedLimit)
	// 	{
	// 		velocity.Y += FallLimiter * (float)delta;
	// 	}
	// 	else
	// 	{
	// 		velocity.Y = MathF.Min(velocity.Y += FallGravity * (float)delta, FallSpeedLimit);
	// 	}

	// 	return velocity;
	// }

	// private void HandleDiving(double delta, Vector2 velocity)
	// {

	// 	velocity.Y = Mathf.Min(velocity.Y + DiveGravity * (float)delta, DiveSpeedLimit);

	// 	return velocity;
	// }

	// private void HandleFlyingUp(double delta, Vector2 velocity)
	// {

	// 	if (velocity.Y > 0) // faster flying up when facing down
	// 	{
	// 		velocity.Y -= FlyUpGravity * BrakingPower * (float)delta;
	// 	}
	// 	else
	// 	{
	// 		velocity.Y = Mathf.Max(velocity.Y - FlyUpGravity * (float)delta, FlyUpSpeedLimit);
	// 	}

	// 	return velocity;
	// }

	// private void HandleDead(double delta, Vector2 velocity)
	// {

	// 	velocity.Y = MathF.Min(velocity.Y += FallGravity * (float)delta, FallSpeedLimit);

	// 	velocity.X *= 0.99f;

	// 	parent.Velocity = velocity;
	// }

	// private Vector2 HandleHorizontalMovement(double delta, Vector2 velocity)
	// {
	// 	float direction = Input.GetAxis("moveLeft", "moveRight");
	// 	if (direction != 0)
	// 	{
	// 		if (direction * velocity.X < 0) velocity.X += HorizontalBrakeSpeed * direction * (float)delta;
	// 		else velocity.X = Mathf.Clamp(velocity.X + HorizontalMoveSpeed * (float)delta * direction, -HorizontalMoveSpeedLimit, HorizontalMoveSpeedLimit);

	// 	}
	// 	else
	// 	{

	// 		velocity.X *= 0.95f;

	// 	}

	// 	return velocity;
	// }




}
