using Godot;
using System;

public partial class Diving : State
{

    public override void _Ready()
    {

    }

    public override void PhysicsUpdate(double delta)
    {

        Vector2 velocity = parent.Velocity;

        velocity.Y = Mathf.Min(velocity.Y + PlayerStats.DiveGravity * (float)delta, PlayerStats.DiveSpeedLimit);

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
