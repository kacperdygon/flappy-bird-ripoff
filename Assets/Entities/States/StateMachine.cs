using Godot;
using System;

public partial class StateMachine : Node
{

    [Export] State state;
    public string StateName { get { return state.GetClass(); } }

    public override void _Ready()
    {
        state.StateChanged += ChangeState;
    }

    public override void _PhysicsProcess(double delta)
    {
        state.Update();
    }

    public override void _Process(double delta)
    {
        state.Update();
    }

    public void ChangeState(string targetState)
    {
        state.Exit();
        state = GetNode<Node>(targetState) as State;
        state.Enter();
        state.StateChanged += ChangeState;

    }



}
