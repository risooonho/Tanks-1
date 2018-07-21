using Godot;
using System;
using Tanks;

public class SplashScreen : Node
{
    AnimationPlayer AP;
    Label PressAnyKey;
    OptionButton PlayOptionButton;
    global global;
    CheckButton AllowCheck, FullScreenCheck;

    public override void _Ready()
    {
        global = (global)GetNode("/root/global");

        AP = (AnimationPlayer)GetNode("AnimationPlayer");
        if (!global.GameStarted)
            AP.Play("MoveShoot");
        else
        {
            ((CanvasItem)(GetNode("BlueTank/Explosion"))).Visible = false;
            ((CanvasItem)(GetNode("BlueTank/Exhaust"))).Visible = false;
            ((CanvasItem)(GetNode("BlueTank/ShootSmoke"))).Visible = false;
            ((CanvasItem)(GetNode("BlueTank/Bullet"))).Visible = false;
            ((CanvasItem)(GetNode("BrownTank/Exhaust"))).Visible = false;
            ((Particles2D)(GetNode("BrownTankFire/BrownTankFire1"))).Preprocess = 2;
            ((Particles2D)(GetNode("BrownTankFire/BrownTankFire2"))).Preprocess = 2;
            ((Particles2D)(GetNode("BrownTankFire/BrownTankFire3"))).Preprocess = 2;
            AP.CurrentAnimation = "MoveShoot"; AP.Advance(3.5f);
            AP.CurrentAnimation = "BringInGUI"; AP.Advance(1);
        }

        PressAnyKey = (Label)GetNode("GUI/Label");

        AllowCheck = (CheckButton)GetNode("GUI/Settings/AllowCheck");
        FullScreenCheck = (CheckButton)GetNode("GUI/Settings/FullScreenCheck");

        PlayOptionButton = (OptionButton)GetNode("GUI/PlayOptions/OptionButton");

        if (global.AllowMobileControllers)
        {
            AllowCheck.SetPressed(true);
            _OnAllowCheckToggled(true);
        }
        else PlayOptionButton.AddItem("2", 2);

        if (global.IsFullscreen)
        {
            FullScreenCheck.SetPressed(true);
            _OnFullScreenCheckToggled(true);
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (AP.CurrentAnimation == "FlashLabel")
            if (!(@event is InputEventMouse))
            {
                PressAnyKey.Visible = false;
                AP.Stop();
                AP.SetCurrentAnimation("BringInGUI");
                AP.Play();
            }
    }

    private void _OnAnimationFinished(String anim_name)
    {
        switch (anim_name)
        {
            case "MoveShoot":
                if(!global.GameStarted)
                    AP.SetCurrentAnimation("FlashLabel");
                break;
        }
    }

    private void _OnQuitButtonPressed()
    {
        global.SaveSettings();
        GetTree().Quit();
    }

    private void _OnPlayButtonToggled(bool button_pressed)
    {
        if (button_pressed)
            AP.Play(name: "BringInPlayOptions");
        else
            AP.Play(name: "BringInPlayOptions", customSpeed: -1, fromEnd: true);
    }

    private void _OnOptionsButtonToggled(bool button_pressed)
    {
        if (button_pressed)
            AP.Play(name: "BringInOptions");
        else
            AP.Play(name: "BringInOptions", customSpeed: -1, fromEnd: true);
    }

    private void _OnFullScreenCheckToggled(bool button_pressed)
    {
        global.IsFullscreen = button_pressed;
        OS.SetWindowFullscreen(button_pressed);
    }

    private void _OnAllowCheckToggled(bool button_pressed)
    {
        global.AllowMobileControllers = button_pressed;
        PlayOptionButton.Clear();
        if (button_pressed)
        {
            PlayOptionButton.AddItem("0", 0);
            PlayOptionButton.AddItem("1", 1);
        }
        PlayOptionButton.AddItem("2", 2);
    }

    private void _OnGoButtonPressed()
    {
        global.NumberOfPlayers = PlayOptionButton.GetSelectedId();
        global.GameStarted = true;
        global.GotoScene("res://scenes/SelectTanks.tscn");
    }

}

