using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Sockets;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Localization;
using Microsoft.Xna.Framework.Input.Touch;
using FlatRedBall.Math;
using static FlatRedBall.Camera;
using TanksController.Entities;
using TanksController.Factories;
using Microsoft.Xna.Framework;

namespace TanksController.Screens
{
    public partial class StartScreen
    {
        private class Computer
        {
            public int ID;
            public IPAddress IP;
            public List<string> PlayerNames;
            public List<string> TankNames;
            public Computer(string[] Splitted, int ID)
            {
                this.ID = ID;
                IP = IPAddress.Parse(Splitted[2]);
                string[] Players = Splitted[3].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string[] Tanks = Splitted[4].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                PlayerNames = Players.ToList();
                TankNames = Tanks.ToList();
            }
        }

        static int ListX = 140;
        static int ListStartingY = 250;
        static int ListYDecrement = 60;
        static List<string> NamesAdded;
        static List<Computer> ComputerData;
        UdpClient Client = new UdpClient(new IPEndPoint(IPAddress.Any, 11000));
        static PositionedObjectList<ComputerName> CompNameList;
        static Finger Finger;

        private static void AddToList(string Name)
        {
            ComputerName NewName = ComputerNameFactory.CreateNew();
            NewName.X = ListX;
            NewName.Y = ListStartingY;
            NewName.TextInstance.DisplayText = Name;
            ListStartingY -= ListYDecrement;
        }

        private static Computer CheckPosition()
        {
            foreach (ComputerName Label in CompNameList)
            {
                if (Label.Rectangle.CollideAgainst(Finger.CircleInstance))
                {
                    return ComputerData[CompNameList.IndexOf(Label)];
                }
            }
            return null;
        }

        private static void DataReceived(IAsyncResult ar)
        {
            try
            {
                UdpClient Client = ar.AsyncState as UdpClient;
                IPEndPoint Ep = new IPEndPoint(IPAddress.Any, 0);
                Byte[] ReceivedBytes = Client.EndReceive(ar, ref Ep);
                string s = Encoding.ASCII.GetString(ReceivedBytes);
                string[] ss = s.Split(new char[] { '$' });
                if (ss[0] == "TANKS")
                {
                    if (!NamesAdded.Contains(ss[1]))
                    {
                        InstructionManager.AddSafe(() => AddToList(ss[1]));
                        NamesAdded.Add(ss[1]);
                        ComputerData.Add(new Computer(ss, NamesAdded.IndexOf(ss[1])));
                    }
                    else
                    {
                        Computer Comp = new Computer(ss, NamesAdded.IndexOf(ss[1]));
                        ComputerData[NamesAdded.IndexOf(ss[1])] = Comp;
                    }
                }

                Client.BeginReceive(DataReceived, Client);
            }
            catch (ObjectDisposedException)
            {

            }
        }

        int? TouchID;

        private void ManageTaps()
        {
            bool FoundTracked = false;
            TouchCollection Collection = TouchPanel.GetState();
            foreach (TouchLocation Location in Collection)
            {
                if (TouchID == null)
                {
                    TouchID = Location.Id;
                    float x = 0, y = 0;
                    MathFunctions.WindowToAbsolute((int)Location.Position.X, (int)Location.Position.Y, ref x, ref y, 0, SpriteManager.Camera, CoordinateRelativity.RelativeToWorld);
                    FingerInstance.X = x;
                    FingerInstance.Y = y;
                    FoundTracked = true;
                }
                else if (TouchID == Location.Id)
                    FoundTracked = true;
            }
            if (!FoundTracked && TouchID != null)
            {
                Computer Clicked = CheckPosition();
                if (Clicked != null)
                {
                    GlobalData.SelectedIP = Clicked.IP;
                    GlobalData.Names = Clicked.PlayerNames;
                    GlobalData.Tanks = Clicked.TankNames;
                    MoveToScreen(typeof(NameTankScreen));
                }
                TouchID = null;
            }

        }

        void CustomInitialize()
        {
            ListX = 140;
            ListStartingY = 250;
            ListYDecrement = 60;

            Main.BackgroundColor = Microsoft.Xna.Framework.Color.LightGray;
            SpinningTank.RotationZVelocity = 3.14f;
            SpinningTank.Drag = 0;
            NamesAdded = new List<string>();
            ComputerData = new List<Computer>();
            CompNameList = ComputerNameList;
            Finger = FingerInstance;

            Client.BeginReceive(DataReceived, Client);
        }

        void CustomActivity(bool firstTimeCalled)
        {
            ManageTaps();
        }


        void CustomDestroy()
        {


        }

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

    }
}
