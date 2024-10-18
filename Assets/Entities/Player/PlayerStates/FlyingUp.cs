using Godot;
using System;

public partial class FlyingUp : State
{


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



    }

    public override void Update(double delta)
    {

    }

    public override void HandleInput()
    {

        if (Input.IsActionPressed("dive"))
        {
            ChangeState(PlayerState.DIVING);
        }
        else if (Input.IsActionJustReleased("flyUp"))
        {
            ChangeState(PlayerState.GLIDING);
        }

    }


    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

}
