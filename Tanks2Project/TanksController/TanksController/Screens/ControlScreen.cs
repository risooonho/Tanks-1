using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
using Microsoft.Xna.Framework;
using System.Net.Sockets;
using System.Net;

namespace TanksController.Screens
{
    public partial class ControlScreen
    {

        int? LeftTouchID,
             RightTouchID;
        int MaxJoyStickDistanceFromOrigin = 200;
        int CenterLineDistance = 100;
        int? ControllerID;

        byte[] LastPairOfBytes = new byte[2] { 1, 1 };

        UdpClient Client;

        private void SendControl(byte[] Control)
        {
            if (ControllerID != null)
            {
                byte[] bytes = new byte[] { (byte)ControllerID, Control[0], Control[1] };
                Client.Send(bytes, bytes.Length, new IPEndPoint(GlobalData.SelectedIP, 11000));
            }
        }

        private void DataReceived(IAsyncResult ar)
        {
            try
            {
                UdpClient Client = ar.AsyncState as UdpClient;
                IPEndPoint Ep = new IPEndPoint(IPAddress.Any, 0);
                Byte[] ReceivedBytes = Client.EndReceive(ar, ref Ep);
                string s = Encoding.ASCII.GetString(ReceivedBytes);
                string[] ss = s.Split(new char[] { '$' });
                if (ss[0] == "ID")
                {
                    ControllerID = Int32.Parse(ss[1]);
                }
                Client.BeginReceive(DataReceived, Client);
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Got ID: " + ControllerID);
            }
        }

        private Vector3 BestJoystickPosition(Vector3 Origin, Vector3 DesiredPosition)
        {
            double Distance = FlatRedBall.Math.Geometry.Point.DistanceTo(
                new FlatRedBall.Math.Geometry.Point(Origin.X, Origin.Y),
                new FlatRedBall.Math.Geometry.Point(DesiredPosition.X, DesiredPosition.Y));

            if (Distance <= MaxJoyStickDistanceFromOrigin)
                return DesiredPosition;
            Vector2 Direction = new Vector2(DesiredPosition.X, DesiredPosition.Y) - new Vector2(Origin.X, Origin.Y);
            Direction.Normalize();

            Vector2 Result2D = new Vector2(Origin.X, Origin.Y) + MaxJoyStickDistanceFromOrigin * Direction;

            return new Vector3(Result2D.X, Result2D.Y, 1);
        }

        private byte[] GetJoystickPosition()
        {
            if (JoyStickStickInstance.CircleInstance.CollideAgainst(JoyStickBaseInstance.UpLeftPolygon))
                return new byte[] { 0, 0 };
            if (JoyStickStickInstance.CircleInstance.CollideAgainst(JoyStickBaseInstance.UpPolygon))
                return new byte[] { 0, 1 };
            if (JoyStickStickInstance.CircleInstance.CollideAgainst(JoyStickBaseInstance.UpRightPolygon))
                return new byte[] { 0, 2 };
            if (JoyStickStickInstance.CircleInstance.CollideAgainst(JoyStickBaseInstance.LeftPolygon))
                return new byte[] { 1, 0 };
            if (JoyStickStickInstance.CircleInstance.CollideAgainst(JoyStickBaseInstance.RightPolygon))
                return new byte[] { 1, 2 };
            if (JoyStickStickInstance.CircleInstance.CollideAgainst(JoyStickBaseInstance.DownLeftPolygon))
                return new byte[] { 2, 0 };
            if (JoyStickStickInstance.CircleInstance.CollideAgainst(JoyStickBaseInstance.DownPolygon))
                return new byte[] { 2, 1 };
            if (JoyStickStickInstance.CircleInstance.CollideAgainst(JoyStickBaseInstance.DownRightPolygon))
                return new byte[] { 2, 2 };
            return new byte[] { 1, 1 };
        }
        private void CheckButtonPress()
        {
            if (FingerInstance.CircleInstance.CollideAgainst(ShootButton.AxisAlignedRectangleInstance))
                SendControl(new byte[] { 3, 3 });
            else if (FingerInstance.CircleInstance.CollideAgainst(ExitButton.AxisAlignedRectangleInstance))
            {
                if (ControllerID != null)
                {
                    byte[] bytes = Encoding.ASCII.GetBytes("DCN$" + ControllerID);
                    Client.Send(bytes, bytes.Length, new IPEndPoint(GlobalData.SelectedIP, 11000));
                }
                MoveToScreen(typeof(StartScreen));
            }

        }

        private void ManageTaps()
        {
            TouchCollection Collection = TouchPanel.GetState();
            bool FoundLeft = false,
                 FoundRight = false;

            foreach (TouchLocation Tap in Collection)
            {
                float x = 0, y = 0;
                MathFunctions.WindowToAbsolute((int)Tap.Position.X, (int)Tap.Position.Y, ref x, ref y, 0, SpriteManager.Camera, CoordinateRelativity.RelativeToWorld);
                if (x <= CenterLineDistance)//Left side -> joystick
                {
                    if (LeftTouchID == null)
                    {
                        LeftTouchID = Tap.Id;
                        FoundLeft = true;
                    }
                    else if (LeftTouchID == Tap.Id) //Set location of stick
                    {
                        JoyStickStickInstance.Position = BestJoystickPosition(JoyStickStickInstance.StartPos, new Vector3(x, y, 0));
                        byte[] StickBytes = GetJoystickPosition();
                        if (StickBytes[0] != LastPairOfBytes[0] || StickBytes[1] != LastPairOfBytes[1])
                        {
                            LastPairOfBytes[0] = StickBytes[0];
                            LastPairOfBytes[1] = StickBytes[1];
                            SendControl(StickBytes);
                        }
                        FoundLeft = true;
                    }
                }
                else
                {
                    if (RightTouchID == null)
                    {
                        RightTouchID = Tap.Id;
                        FingerInstance.X = x;
                        FingerInstance.Y = y;
                        FoundRight = true;
                    }
                    else if (RightTouchID == Tap.Id)
                        FoundRight = true;
                }
            }
            if (!FoundLeft && LeftTouchID != null)
            {
                JoyStickStickInstance.Position = JoyStickStickInstance.StartPos;
                SendControl(new byte[] { 1, 1 });
                LastPairOfBytes[0] = LastPairOfBytes[1] = 1;
                LeftTouchID = null;
            }
            if (!FoundRight && RightTouchID != null)
            {
                Console.WriteLine("RIGHT");
                CheckButtonPress();
                RightTouchID = null;
            }
        }

        void CustomInitialize()
        {
            Client = new UdpClient(new IPEndPoint(IPAddress.Any, 11000));
            Main.BackgroundColor = Color.LightGray;

            byte[] bytes = Encoding.ASCII.GetBytes("CN$" + GetLocalIPAddress() + "$" + GlobalData.PlayerName + "$" + GlobalData.SelectedTankIndex);
            Client.Send(bytes, bytes.Length, new IPEndPoint(GlobalData.SelectedIP, 11000));
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

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
