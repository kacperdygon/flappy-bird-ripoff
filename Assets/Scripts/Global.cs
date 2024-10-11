using Godot;
using System;

[GlobalClass]
public partial class Global : Node
{
    public static SignalBus signalBus = new();
}
