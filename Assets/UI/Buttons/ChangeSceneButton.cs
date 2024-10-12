using Godot;
using System;
using System.IO;

public partial class ChangeSceneButton : Button
{
	// Called when the node enters the scene tree for the first time.

	[Export(PropertyHint.File)]
	public string targetScenePath;



	public void _OnButtonUp()
	{

		if (IsHovered())
		{

			SceneManager.Instance.ChangeScene(targetScenePath);

		}
	}
}
