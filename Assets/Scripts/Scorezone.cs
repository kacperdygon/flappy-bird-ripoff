using Godot;
using System;

public partial class Scorezone : Area2D
{

	[Signal]
	public delegate void PointScoredEventHandler();

	public void OnBodyEntered(Player player)
	{
		EmitSignal(SignalName.PointScored);
	}
	
}
