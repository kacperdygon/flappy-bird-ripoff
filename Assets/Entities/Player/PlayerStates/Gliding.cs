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


    }

    public override void Update(double delta)
    {

    }

    public override void HandleInput()
    {
        if (Input.IsActionPressed("flyUp"))
        {
            ChangeState(PlayerState.FLYINGUP);
        }
        else if (Input.IsActionPressed("dive"))
        {
            ChangeState(PlayerState.DIVING);
        }
    }


    public override void Enter()
    {

    }

    public override void Exit()
    {

    }



}
