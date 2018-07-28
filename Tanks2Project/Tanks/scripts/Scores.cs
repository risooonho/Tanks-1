//The scores panel on the left side of the screen

using Godot;
using System;
using System.Collections.Generic;

public class Scores : Control
{
    private PackedScene ScoreLabel;
    private AnimationPlayer AnimationPlayer;
    private Dictionary<string, Label> PlayerLabels;
    private VBoxContainer Container;

    public override void _Ready()
    {
        ScoreLabel = (PackedScene)GD.Load("res://scenes/ScoreLabel.tscn");
        AnimationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
        Container = (VBoxContainer)GetNode("Container");
        PlayerLabels = new Dictionary<string, Label>();
        SetNoPlayers();
    }

    public void Empty()
    {
        foreach(KeyValuePair<string, Label> Label in PlayerLabels)
            Label.Value.QueueFree();
        PlayerLabels.Clear();
    }

    public void SetNoPlayers() // Show "No Players" text
    {
        Empty();
        PlayerLabels.Add("", (Label)(ScoreLabel.Instance()));
        PlayerLabels[""].Text = "No players.";
        Container.AddChild(PlayerLabels[""]);
    }

    public void AddPlayer(string Player)
    {
        Label NewLabel = (Label)ScoreLabel.Instance();
        NewLabel.Text = Player + ": 0";
        PlayerLabels.Add(Player, NewLabel);
        Container.AddChild(NewLabel);
    }

    public void RemovePlayer(string Player)
    {
        PlayerLabels[Player].QueueFree();
        PlayerLabels.Remove(Player);
    }

    public void SetPlayerScore(string Player, int score) => PlayerLabels[Player].Text = Player + ": " + score;

    public void Show2Sec() => AnimationPlayer.Play("Show2Sec");
    new public void Show() => AnimationPlayer.Play("Show");
    new public void Hide() => AnimationPlayer.Play("Hide");

}
