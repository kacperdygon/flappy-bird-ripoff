using Godot;
using System;

[GlobalClass]
public partial class DebugHelp : Node
{

    static public void IsInstanceValidWithInfo(Node instance, string text)
    {
        GD.Print(text + ":");
        if (!IsInstanceValid(instance))
        {
            GD.Print("Is valid: false");
        }
        else
        {
            GD.Print("Is valid: true");
            GD.Print(instance);
        }


    }
}
