using Godot;
using System;
using Tanks;
using System.Collections.Generic;

public class SelectTanks : Node
{
    global global;

    TextureRect Tank1Rect, Tank2Rect;
    RichTextLabel Tank1Description, Tank2Description;

    int mT1Idx = 0;
    int Tank1Idx
    {
        get => mT1Idx;
        set
        {
            if (value < 0)
                mT1Idx = global.TanksList.Count - 1;
            else if (value > global.TanksList.Count - 1)
                mT1Idx = 0;
            else mT1Idx = value;
            var Tank = global.TanksList[mT1Idx].Instance();
            Tank1Rect.Texture = ((Sprite)(Tank.GetNode("Sprite"))).Texture;
            Tank1Description.Text = ((RichTextLabel)(Tank.GetNode("Description"))).Text;
            Tank.QueueFree();
        }
    }

    int mT2Idx = 0;
    int Tank2Idx
    {
        get => mT2Idx;
        set
        {
            if (value < 0)
                mT2Idx = global.TanksList.Count - 1;
            else if (value > global.TanksList.Count - 1)
                mT2Idx = 0;
            else mT2Idx = value;
            var Tank = global.TanksList[mT2Idx].Instance();
            Tank2Rect.Texture = ((Sprite)(Tank.GetNode("Sprite"))).Texture;
            Tank2Description.Text = ((RichTextLabel)(Tank.GetNode("Description"))).Text;
            Tank.QueueFree();
        }
    }

    public override void _Ready()
    {
        global = (global)GetNode("/root/global");

        ((AudioStreamPlayer2D)GetNode("Sounds/AudioStreamPlayer2D")).Play(0);
        ((AudioStreamPlayer2D)GetNode("Sounds/Music")).Play(global.SplashAudioPosition);

        Tank1Rect = (TextureRect)GetNode("GUI/Player1Label/Tank/TextureRect");
        Tank1Description = (RichTextLabel)GetNode("GUI/Player1Label/Tank/Description");
        Tank2Rect = (TextureRect)GetNode("GUI/Player2Label/Tank/TextureRect");
        Tank2Description = (RichTextLabel)GetNode("GUI/Player2Label/Tank/Description");

        if (global.NumberOfPlayers == 1)
            ((CanvasItem)(GetNode("GUI/Player2Label"))).Visible = false;
        else if (global.NumberOfPlayers == 0)
            Play();
        Tank1Idx = 0;
        Tank2Idx = 0;
    }

    private void _OnBackButtonPressed()
    {
        global.SplashAudioPosition = ((AudioStreamPlayer2D)GetNode("Sounds/Music")).GetPlaybackPosition();
        global.GotoScene("res://scenes/SplashScreen.tscn");
    }

    private void Play()
    {
        string P1Name = ((LineEdit)GetNode("GUI/Player1Label/Name/LineEdit")).Text,
               P2Name = ((LineEdit)GetNode("GUI/Player2Label/Name/LineEdit")).Text;
        global.SelectedTanks = new Dictionary<string, Node>();
        if(P1Name.ToLower() == P2Name.ToLower() && P1Name != "")
        {
            P1Name += " 1";
            P2Name += " 2";
        }
        if(global.NumberOfPlayers > 0)
        {
            global.SelectedTanks.Add(((P1Name != "") ? P1Name : "Player 1"), global.TanksList[Tank1Idx].Instance());
            if(global.NumberOfPlayers == 2)
            {
                Node NewTank = global.TanksList[Tank2Idx].Instance();
                NewTank.Set("UP", KeyList.W);
                NewTank.Set("DOWN", KeyList.S);
                NewTank.Set("LEFT", KeyList.A);
                NewTank.Set("RIGHT", KeyList.D);
                NewTank.Set("SHOOT", KeyList.Q);
                global.SelectedTanks.Add(((P2Name != "") ? P2Name : "Player 2"), NewTank);
            }
                
        }
        global.GotoScene("res://scenes/GameScene.tscn");
    }

    private void _OnPlayButtonPressed()
    {
        Play();
    }

    #region Select Buttons

    private void _OnTank1LeftPressed() => Tank1Idx--;
    private void _OnTank1RightPressed() => Tank1Idx++;
    private void _OnTank2LeftPressed() => Tank2Idx--;
    private void _OnTank2RightPressed() => Tank2Idx++;

    #endregion
}

