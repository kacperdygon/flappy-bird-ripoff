using Godot;
using System;
using System.IO;

public partial class ChangeSceneButton : Button
{
	// Called when the node enters the scene tree for the first time.

	[Export(PropertyHint.File)]
	public string targetSceneFile;

	public override void _Ready()
	{
		GD.Print(targetSceneFile);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void _OnButtonUp()
	{

		if (IsHovered()) {

				GetTree().ChangeSceneToFile(targetSceneFile);
				// GetTree().CurrentScene = targetScene.Instantiate();

		}
	}
}
