using Godot;
using System;

public partial class Dead : State
{

    public override void _Ready()
    {
        base._Ready();
    }

    public override void PhysicsUpdate(double delta)
    {

        Vector2 velocity = parent.Velocity;

        velocity.Y = MathF.Min(velocity.Y += PlayerStats.FallGravity * (float)delta, PlayerStats.FallSpeedLimit);

        velocity.X *= 0.99f;

        parent.Velocity = velocity;

        parent.Velocity = velocity;

        parent.MoveAndSlide();


    }

    public override void Update(double delta)
    {

    }

    public override void HandleInput()
    {

    }


    public override void Enter()
    {

    }

    public override void Exit()
    {

    }
}
