//The scene that appears when BaseTank.pck is not found in "user://Tanks" (%appdata%/Godot/app_userdata/Tanks/Tanks on Windows) or
//when no map .pck files are found in "user://Maps" (%appdata%/Godot/app_userdata/Tanks/Maps on Windows)

using Godot;
using System;

public class ErrorScene : Control
{
    private RichTextLabel label;

    public override void _Ready() => label = (RichTextLabel)GetNode("RichTextLabel"); //get Label node
    public void SetErrorText(string Text) => label.SetText(Text); //set text relevant to the error
    private void _OnQuitButtonPressed() => GetTree().Quit();

    private void _OnTanksFolderButtonPressed()
    {
        OS.ShellOpen(ProjectSettings.GlobalizePath("user://Tanks"));// go to "user://Tanks" using system file manager
        GetTree().Quit();
    }
    private void _OnMapsFolderButtonPressed()
    {
        OS.ShellOpen(ProjectSettings.GlobalizePath("user://Maps"));// go to "user://Maps" using system file manager
        GetTree().Quit();
    }

}