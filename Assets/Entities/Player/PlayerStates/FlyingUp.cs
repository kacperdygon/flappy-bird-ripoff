using Godot;
using System;

public partial class FlyingUp : State
{

    public override void _Ready()
    {

    }

    public override void PhysicsUpdate(double delta)
    {

        Vector2 velocity = parent.Velocity;

        if (velocity.Y > 0) // faster flying up when facing down
        {
            velocity.Y -= PlayerStats.FlyUpGravity * PlayerStats.BrakingPower * (float)delta;
        }
        else
        {
            velocity.Y = Mathf.Max(velocity.Y - PlayerStats.FlyUpGravity * (float)delta, PlayerStats.FlyUpSpeedLimit);
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
