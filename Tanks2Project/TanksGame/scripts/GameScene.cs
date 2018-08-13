using Godot;
using System;
using System.Collections.Generic;
using Tanks;

public class GameScene : Node
{

    [Export]
    int PlayerSpawnMargin = 100;

    public global global;
    Dictionary<string, int> PlayerScores;
    public List<string> AlivePlayers;
    List<string> DestroyedPlayers;
    Node CurrentMap;
    int CurrentMapID = 0;
    Random rnd = new Random();
    Scores Scores;
    PauseMenu Menu;
    UdpListener Listener;

    public override void _Ready()
    {
        global = (global)GetNode("/root/global");
        PlayerScores = new Dictionary<string, int>();
        AlivePlayers = new List<string>();
        DestroyedPlayers = new List<string>();
        Scores = (Scores)GetNode("Scores");
        Menu = (PauseMenu)GetNode("PauseMenu");
        if (global.NumberOfPlayers == 0)
        {
            Scores.SetNoPlayers();
            Scores.Show();
        }
        else Scores.Empty();
        ChangeMap();
        foreach (KeyValuePair<string, Node> Player in global.SelectedTanks)
        {
            PlayerScores.Add(Player.Key, 0);
            AlivePlayers.Add(Player.Key);
            AddChild(Player.Value);
            ((Node2D)(Player.Value)).SetGlobalPosition(GetRandomPosition());
            float rrot = GetRandomRotation();
            ((Node2D)(Player.Value)).SetRotation(rrot);
            Player.Value.Set("rot", rrot);
            Player.Value.Set("player_name", Player.Key);
            Player.Value.Connect("public_destroy", this, "TankDestroyed");
            Scores.AddPlayer(Player.Key);
        }

        if (global.AllowMobileControllers)
        {
            Listener = (UdpListener)GetNode("UdpListener");
            Listener.Start();
        }
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (global.NumberOfPlayers == 1)
        {
            if (AlivePlayers.Count == 0)
            {
                AlivePlayers.AddRange(DestroyedPlayers);
                DestroyedPlayers.Clear();
                ((Node2D)(global.SelectedTanks[AlivePlayers[0]])).Show();
                ((KinematicBody2D)(global.SelectedTanks[AlivePlayers[0]])).Call("collide_again");
            }

        }
        else if (global.NumberOfPlayers >= 2)
        {
            if (AlivePlayers.Count == 1)
            {
                ChangeLevel();
                Scores.SetPlayerScore(AlivePlayers[0], PlayerScores[AlivePlayers[0]]);
                Scores.Show2Sec();
            }
            else if (AlivePlayers.Count == 0)
                ChangeLevel();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey IEV)
            if (IEV.Scancode == (int)KeyList.Escape)
                Menu.Show();
    }

    private void ChangeLevel()
    {
        var Bullets = GetTree().GetNodesInGroup("Bullets");
        foreach (Node Bullet in Bullets)
            Bullet.QueueFree();

        if (AlivePlayers.Count != 0)
        {
            PlayerScores[AlivePlayers[0]]++;
            GD.Print(AlivePlayers[0] + " won");
            ((Node2D)(global.SelectedTanks[AlivePlayers[0]])).SetGlobalPosition(GetRandomPosition());
        }
        else
        {
            PlayerScores[DestroyedPlayers[DestroyedPlayers.Count - 1]]++;
            PlayerScores[DestroyedPlayers[DestroyedPlayers.Count - 2]]++;
            GD.Print("Draw between " + DestroyedPlayers[DestroyedPlayers.Count - 2] + " and " + DestroyedPlayers[DestroyedPlayers.Count - 1]);
        }

        foreach (string DestroyedPlayer in DestroyedPlayers)
        {
            ((Node2D)(global.SelectedTanks[DestroyedPlayer])).Show();
            ((Node2D)(global.SelectedTanks[DestroyedPlayer])).SetGlobalPosition(GetRandomPosition());
            ((KinematicBody2D)(global.SelectedTanks[DestroyedPlayer])).Call("collide_again");
            GD.Print("Showing " + DestroyedPlayer);
        }
        AlivePlayers.AddRange(DestroyedPlayers);
        DestroyedPlayers.Clear();

        CurrentMap.QueueFree();

        ChangeMap();
    }

    private void ChangeMap()
    {
        CurrentMap = global.MapsList[CurrentMapID++].Instance();
        AddChild(CurrentMap);
        if (CurrentMapID >= global.MapsList.Count) CurrentMapID = 0;
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 Max = GetViewport().Size;
        Max.x -= 2 * PlayerSpawnMargin;
        Max.y -= 2 * PlayerSpawnMargin;
        return new Vector2(
            (float)(PlayerSpawnMargin + rnd.NextDouble() * Max.x),
            (float)(PlayerSpawnMargin + rnd.NextDouble() * Max.y));
    }

    private float GetRandomRotation() => (float)(rnd.NextDouble() * 6.28);

    private void TankDestroyed(string name)
    {
        GD.Print(name + " destroyed");
        AlivePlayers.Remove(name);
        DestroyedPlayers.Add(name);
    }

    public void AddTank(string Name, int SelectedIndex)
    {
        Node NewTank = global.TanksList[SelectedIndex].Instance();
        global.SelectedTanks.Add(Name, NewTank);
        NewTank.Set("is_controlled_by_mobile", true);
        NewTank.Set("player_name", Name);
        NewTank.Connect("public_destroy", this, "TankDestroyed");
        AlivePlayers.Add(Name);
        PlayerScores.Add(Name, 0);

        if (global.NumberOfPlayers == 0)
        {
            Scores.Empty();
            Scores.Hide();
        }

        global.NumberOfPlayers++;
        Scores.AddPlayer(Name);
        Scores.Show2Sec();
        float rrot = GetRandomRotation();
        ((Node2D)NewTank).SetRotation(rrot);
        NewTank.Set("rot", rrot);
        AddChild(NewTank);
    }

    private string GenerateName()
    {
        string str = "";
        string[] Vowels = { "a", "e", "i", "y", "o", "u" };
        string[] Consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", };
        int NumberOfVowels = Vowels.Length;
        int NumberOfConsonants = Consonants.Length;
        int WordLength = rnd.Next(4, 13); // result word length
        bool CurrentIsVowel = rnd.Next(0, 2) == 0; // alternating consonants and vowels

        if (CurrentIsVowel) // first letter is always upper
            str += Consonants[rnd.Next(0, NumberOfConsonants)].ToUpper();
        else str += Vowels[rnd.Next(0, NumberOfVowels)].ToUpper();

        for (int i = 1; i < WordLength; i++, CurrentIsVowel = !CurrentIsVowel)
            if (CurrentIsVowel)
                str += Vowels[rnd.Next(0, NumberOfVowels)];
            else str += Consonants[rnd.Next(0, NumberOfConsonants)];
        return str.ToString();
    }

    public void AddAI()
    {
        int idx = rnd.Next(global.TanksList.Count);
        Node NewTank = global.TanksList[idx].Instance();

        string Name = GenerateName();
        while (global.SelectedTanks.ContainsKey(Name))
            Name = GenerateName();
        NewTank.Set("player_name", Name);

        NewTank.AddToGroup("AI");
        global.SelectedTanks.Add(Name, NewTank);
        NewTank.Set("AI", true);
        NewTank.Connect("public_destroy", this, "TankDestroyed");
        AlivePlayers.Add(Name);
        PlayerScores.Add(Name, 0);

        if (global.NumberOfPlayers == 0)
        {
            Scores.Empty();
            Scores.Hide();
        }

        global.NumberOfPlayers++;
        Scores.AddPlayer(Name);
        Scores.Show2Sec();
        float rrot = GetRandomRotation();
        ((Node2D)NewTank).SetRotation(rrot);
        NewTank.Set("rot", rrot);
        AddChild(NewTank);
    }

    public void RemoveAI()
    {
        object[] AIs = GetTree().GetNodesInGroup("AI");
        if(AIs.Length > 0)
        {
            int idx = rnd.Next(AIs.Length);
            Node ToRemove = AIs[idx] as Node;
            RemoveTank((string)(ToRemove.Get("player_name")));
        }
    }

    public void RemoveTank(string Name)
    {
        if (AlivePlayers.Contains(Name)) AlivePlayers.Remove(Name);
        else DestroyedPlayers.Remove(Name);
        PlayerScores.Remove(Name);
        global.NumberOfPlayers--;
        Scores.RemovePlayer(Name);
        if (global.NumberOfPlayers == 0)
        {
            Scores.SetNoPlayers();
            Scores.Show();
        }
        global.SelectedTanks[Name].QueueFree();
        global.SelectedTanks.Remove(Name);
    }
}
