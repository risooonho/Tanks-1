using Godot;
using System;
using Tanks;

public class PauseMenu : Control
{

    global global;
    AnimationPlayer AnimationPlayer;
    CheckButton FullScreenCheck;
    UdpListener CurrentListener;

    public override void _Ready()
    {
        global = (global)GetNode("/root/global");
        CurrentListener = (UdpListener)GetNode("/root/GameScene/UdpListener");
        AnimationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
        FullScreenCheck = (CheckButton)GetNode("FullScreenCheck");
        FullScreenCheck.SetPressed(global.IsFullscreen);
    }

    private void _OnFullScreenCheckToggled(bool button_pressed)
    {
        global.IsFullscreen = button_pressed;
        OS.SetWindowFullscreen(button_pressed);
    }

    private void _OnResumeButtonPressed() => Hide();

    private void _OnMainMenuButtonPressed()
    {
        GetTree().SetPause(false);
        CurrentListener.Dispose();

        global.GotoScene("res://scenes/SplashScreen.tscn");
    }

    new public void Show()
    {
        AnimationPlayer.Play("Show");
        GetTree().SetPause(true);
    }

    new public void Hide()
    {
        AnimationPlayer.Play("Hide");
        GetTree().SetPause(false);
    }

}