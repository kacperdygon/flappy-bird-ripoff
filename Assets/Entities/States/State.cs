using Godot;
using System;

public abstract partial class State : Node
{

    [Signal] public delegate void StateChangedEventHandler(string targetState);

    public CharacterBody2D parent;

    public override void _Ready()
    {
        parent = Owner as CharacterBody2D;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void PhysicsUpdate(double delta) { }

    public virtual void Update(double delta) { }

    public virtual void HandleInput() { }

    public void ChangeState(string targetState)
    {
        EmitSignal(SignalName.StateChanged, targetState);
    }

}