//singleton
//global data/methods

using Godot;
using System;
using System.Collections.Generic;

namespace Tanks
{
    public class global : Node
    {

        public bool IsFullscreen = true,
            AllowMobileControllers = true;

        public Node CurrentScene { get; set; }

        public int NumberOfPlayers = 0;

        public bool GameStarted = false; // used by SplashScreen to check if should play animation

        public float SplashAudioPosition; // for music persistance between SplashScreen and SelectTanks

        public List<PackedScene> TanksList = new List<PackedScene>();
        public List<string> TanksNames = new List<string>(); // sent to mobile controllers
        public Dictionary<string, Node> SelectedTanks; // Tank instances for each player name

        public List<PackedScene> MapsList = new List<PackedScene>(); // map instances
        public List<string> MapsNames = new List<string>(); // not used currently

        public override void _Ready()
        {
            try
            {
                LoadSettings();
            }
            catch
            { GD.Print("No settings.save file found"); }//no problem in case of error; game will have default settings

            LoadPCKs("user://Tanks");
            if (!ProjectSettings.LoadResourcePack("user://Tanks/BaseTank.pck"))//BaseTank is reloaded, because it could've been overriden by previous loads
            {
                GotoScene("res://scenes/ErrorScene.tscn");
                CallDeferred(nameof(SetError), "The base tank file \"BaseTank.pck\" could not be loaded.");// call when idle
            }
            LoadTankScenes("res://Tanks");

            if (!LoadPCKs("user://Maps"))
            {
                GotoScene("res://scenes/ErrorScene.tscn");
                CallDeferred(nameof(SetError), "There are no map files in the Maps folder.");
            }
            LoadMapScenes("res://Maps");

            Viewport root = GetTree().GetRoot();
            CurrentScene = root.GetChild(root.GetChildCount() - 1);//singletons are first in tree; get the last node

            OS.SetWindowPosition(OS.GetScreenSize() / 2 - OS.GetWindowSize() / 2);//center window
        }

        public void SetError(string Error)
        {
            ((ErrorScene)(GetTree().GetRoot().GetNode("ErrorScene"))).SetErrorText(Error);
        }

        public void GotoScene(string path)//Change scene when idle
        {
            CallDeferred(nameof(DeferredGotoScene), path);
        }

        private void DeferredGotoScene(string path)
        {
            CurrentScene.Free();
            var nextScene = (PackedScene)GD.Load(path);
            CurrentScene = nextScene.Instance();
            GetTree().GetRoot().AddChild(CurrentScene);
            GetTree().SetCurrentScene(CurrentScene);
        }

        public void SaveSettings()//settings.save file in "user://"
        {
            Dictionary<object, object> Settings = new Dictionary<object, object>
            {
                {"IsFullscreen", IsFullscreen },
                {"AllowMobileControllers", AllowMobileControllers }
            };
            File SaveFile = new File();
            SaveFile.Open("user://settings.save", (int)File.ModeFlags.Write);
            SaveFile.StoreLine(JSON.Print(Settings));
            SaveFile.Close();
        }

        private void LoadSettings()
        {
            File SaveFile = new File();
            SaveFile.Open("user://settings.save", (int)File.ModeFlags.Read);
            Dictionary<object, object> Settings = (Dictionary<object, object>)JSON.Parse(SaveFile.GetLine()).Result;
            IsFullscreen = (bool)Settings["IsFullscreen"];
            AllowMobileControllers = (bool)Settings["AllowMobileControllers"];
        }

        private void LoadTankScenes(string PATH)
        {
            Directory DIR = new Directory();

            if (DIR.Open(PATH) == Error.Ok)
            {
                DIR.ListDirBegin(skipNavigational: true);
                string Filename = DIR.GetNext();
                while (Filename != string.Empty)
                {
                    if (DIR.CurrentIsDir())
                    {
                        TanksList.Add((PackedScene)GD.Load(PATH + ((PATH[PATH.Length - 1] == '/') ? ("") : ("/")) + Filename + "/Tank.tscn"));
                        TanksNames.Add(Filename);
                    }
                    Filename = DIR.GetNext();
                }
            }
        }

        private void LoadMapScenes(string PATH)
        {
            Directory DIR = new Directory();

            if (DIR.Open(PATH) == Error.Ok)
            {
                DIR.ListDirBegin(skipNavigational: true);
                string Filename = DIR.GetNext();
                while (Filename != string.Empty)
                {
                    if (DIR.CurrentIsDir())
                    {
                        MapsList.Add((PackedScene)GD.Load(PATH + ((PATH[PATH.Length - 1] == '/') ? ("") : ("/")) + Filename + "/Map.tscn"));
                        MapsNames.Add(Filename);
                    }
                    Filename = DIR.GetNext();
                }
            }
        }

        private bool LoadPCKs(string PATH)
        {
            bool ok = false;
            Directory DIR = new Directory();

            if (DIR.Open(PATH) == Error.Ok)
            {
                DIR.ListDirBegin(skipNavigational: true);
                string Filename = DIR.GetNext();
                while (Filename != string.Empty)
                {
                    if (!DIR.CurrentIsDir())
                        if (ProjectSettings.LoadResourcePack(PATH + ((PATH[PATH.Length - 1] == '/') ? ("") : ("/")) + Filename))
                            ok = true;
                    Filename = DIR.GetNext();
                }
            }
            else // if no directory is found, make it so when user gets error message and tries to open the directory it opens
            {
                DIR = new Directory();
                DIR.Open(PATH.Substring(0, PATH.LastIndexOf("/") + 1));
                DIR.MakeDir(PATH.Substring(PATH.LastIndexOf("/") + 1));
            }
            return ok;
        }

    }

}