using Godot;
using System;
using Tanks;

public class PauseMenu : Control
{

    global global;
    AnimationPlayer AnimationPlayer;
    CheckButton FullScreenCheck;
    UdpListener CurrentListener;
    GameScene GameScene;

    public override void _Ready()
    {
        global = (global)GetNode("/root/global");
        CurrentListener = (UdpListener)GetNode("/root/GameScene/UdpListener");
        AnimationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
        FullScreenCheck = (CheckButton)GetNode("FullScreenCheck");
        GameScene = (GameScene)GetParent();
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
        global.SplashAudioPosition = 0;
        global.GotoScene("res://scenes/SplashScreen.tscn");
    }


    private void _on_AddAIButton_pressed() => GameScene.AddAI();
    private void _on_RemoveAIButton_pressed() => GameScene.RemoveAI();

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

