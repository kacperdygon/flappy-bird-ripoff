using Godot;
using System;

[GlobalClass]
public partial class SignalBus : Node
{

    

    [Signal] public delegate void PlayerDiedEventHandler();

}
