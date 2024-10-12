using Godot;
using System;

[GlobalClass]
public partial class SceneManager : Node
{
    public static SceneManager Instance { get; private set; }
    public Node CurrentScene { get; set; }

    public override void _Ready()
    {
        Instance = this;
        Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(root.GetChildCount() - 1);
    }

    public void ChangeScene(string targetScenePath)
    {

        CallDeferred(MethodName.DefferedGotoScene, targetScenePath);

    }

    public void DefferedGotoScene(string targetScenePath)
    {

        CurrentScene.Free();

        // Load a new scene.
        var nextScene = GD.Load<PackedScene>(targetScenePath);

        // Instance the new scene.
        CurrentScene = nextScene.Instantiate();

        // Add it to the active scene, as child of root.
        GetTree().Root.AddChild(CurrentScene);

        // Optionally, to make it compatible with the SceneTree.change_scene_to_file() API.
        GetTree().CurrentScene = CurrentScene;

    }

}
