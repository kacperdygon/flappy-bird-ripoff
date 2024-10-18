using Godot;
using System;

public partial class State : Node
{

    [Signal] public delegate void StateChangedEventHandler(string targetState);

    public Node parent;

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void PhysicsUpdate() { }

    public virtual void Update() { }

    public virtual void HandleInput() { }

    public void ChangeState(string targetState)
    {
        EmitSignal(SignalName.StateChanged, targetState);
    }

}