using Godot;
using System;

public partial class Dead : State
{


    public override void PhysicsUpdate(double delta)
    {

        Vector2 velocity = parent.Velocity;

        velocity.Y = MathF.Min(velocity.Y += PlayerStats.FallGravity * (float)delta, PlayerStats.FallSpeedLimit);

        velocity.X *= 0.99f;

        parent.Velocity = velocity;



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
