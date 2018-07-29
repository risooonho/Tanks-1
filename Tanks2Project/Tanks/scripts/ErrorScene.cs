using Godot;
using System;

public class ErrorScene : Control
{
    private RichTextLabel label;

    public override void _Ready() => label = (RichTextLabel)GetNode("RichTextLabel");
    public void SetErrorText(string Text) => label.SetText(Text);
    private void _OnQuitButtonPressed() => GetTree().Quit();

    private void _OnTanksFolderButtonPressed()
    {
        OS.ShellOpen(ProjectSettings.GlobalizePath("user://Tanks"));
        GetTree().Quit();
    }
    private void _OnMapsFolderButtonPressed()
    {
        OS.ShellOpen(ProjectSettings.GlobalizePath("user://Maps"));
        GetTree().Quit();
    }

}