using Godot;
using System;

public partial class Scorezone : Area2D
{

	bool alreadyEntered;

	[Signal]
	public delegate void PointScoredEventHandler();

	public void OnBodyEntered(Player player)
	{
		if(!alreadyEntered) {
			EmitSignal(SignalName.PointScored);
			alreadyEntered = true;
		}
		
	}
	
}
