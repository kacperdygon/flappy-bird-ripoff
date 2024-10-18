using Godot;
using System;

public partial class StateMachine : Node
{

    [Export] State state;
    [Signal] public delegate void StateChangedEventHandler(string currentState);
    public string StateName { get { return state.Name; } }

    public override void _Ready()
    {
        state.StateChanged += ChangeState;
    }

    public override void _PhysicsProcess(double delta)
    {
        state.PhysicsUpdate(delta);
    }

    public override void _Process(double delta)
    {
        state.Update(delta);
        state.HandleInput();
    }

    public void ChangeState(string targetState)
    {
        state.Exit();
        state.StateChanged -= ChangeState;

        state = GetNode<Node>(targetState) as State;
        state.Enter();
        state.StateChanged += ChangeState;

        EmitSignal(SignalName.StateChanged, StateName);
        GD.Print("State updated!");

    }



}
