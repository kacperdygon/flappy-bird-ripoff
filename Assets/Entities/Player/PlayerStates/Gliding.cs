using Godot;
using System;
using System.ComponentModel;

public partial class Gliding : State
{

    public override void PhysicsUpdate(double delta)
    {


        Vector2 velocity = parent.Velocity;

        if (velocity.Y > PlayerStats.FallSpeedLimit)
        {
            velocity.Y += PlayerStats.FallLimiter * (float)delta;
        }
        else
        {
            velocity.Y = MathF.Min(velocity.Y += PlayerStats.FallGravity * (float)delta, PlayerStats.FallSpeedLimit);
        }

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
