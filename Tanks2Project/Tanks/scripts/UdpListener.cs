//UdpListener used to manage requests/controls, advertise on local network

using Godot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Tanks
{
    class UdpListener : Node
    {
        public static Dictionary<int, string> Players = new Dictionary<int, string>();
        static int ID = 1;
        UdpClient Client;
        static GameScene GameScene;
        static global global;

        public static byte[] CreatePacket()
        {
            string ToSend = "TANKS" + "$" + System.Environment.MachineName + "$" + GetLocalIPAddress() + "$";
            foreach (KeyValuePair<string, Node> Player in global.SelectedTanks)
                ToSend += Player.Key + "|";
            ToSend += "$";
            foreach (string Tank in global.TanksNames)
                ToSend += Tank + "|";
            return Encoding.ASCII.GetBytes(ToSend);
        }

        public void Start()
        {
            GameScene = (GameScene)(GetTree().GetRoot().GetNode("GameScene"));
            global = GameScene.global;
            Client = new UdpClient(new IPEndPoint(IPAddress.Any, 11000));
            byte[] Packet = CreatePacket();
            Client.BeginReceive(DataReceived, Client);
            Client.BeginSend(Packet, Packet.Length, new IPEndPoint(IPAddress.Broadcast, 11000), Advertise, Client);
            
        }

        public void Stop() => ((IDisposable)Client).Dispose();

        private static void Advertise(IAsyncResult ar)  //Announcement example: TANKS$PCNAME$192.168.0.100$Player1|Player2|Player3|$BaseTank|RedTank|
        {
            try
            {
                UdpClient c = ar.AsyncState as UdpClient;
                IPEndPoint IP = new IPEndPoint(IPAddress.Any, 0);
                System.Threading.Thread.Sleep(2000);
                c.EndSend(ar);
                byte[] Packet = CreatePacket();
                c.BeginSend(Packet, Packet.Length, new IPEndPoint(IPAddress.Broadcast, 11000), Advertise, ar.AsyncState);
            }
            catch (ObjectDisposedException)
            {
                GD.Print("Closed Send");
            };
        }

        private static void DataReceived(IAsyncResult ar)
        {
            try
            {
                UdpClient c = ar.AsyncState as UdpClient;
                IPEndPoint IP = new IPEndPoint(IPAddress.Any, 0);
                Byte[] ReceivedBytes = c.EndReceive(ar, ref IP);
                string s = Encoding.ASCII.GetString(ReceivedBytes);
                string[] ss = s.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);
                switch (ss[0])
                {
                    case "TANKS":
                        break;
                    case "ID":
                        break;
                    case "CN":                                                          //Connection request ex.: CN$192.168.0.100$Player$2
                        IPEndPoint Ep = new IPEndPoint(IPAddress.Parse(ss[1]), 11000);  //                        CN     IP         Name  TankIndex
                        Players.Add(ID, ss[2]);
                        string str = "ID$" + ID;
                        ID++;
                        byte[] send = Encoding.ASCII.GetBytes(str);
                        int index = Int32.Parse(ss[3]);
                        GameScene.AddTank(ss[2], index);
                        c.Send(send, send.Length, Ep);
                        break;
                    case "DCN":                                                        //Disconnect request ex.: DCN$4
                        int id = Int32.Parse(ss[1]);
                        if (global.SelectedTanks.ContainsKey(Players[id]))
                        {
                            GameScene.RemoveTank(Players[id]);
                            Players.Remove(id);
                        }
                        break;
                    default:                                                          //Control ex.: [1, 2, 2]
                        if (global.SelectedTanks.ContainsKey(Players[ReceivedBytes[0]]))
                        {
                            Node Tank = global.SelectedTanks[Players[ReceivedBytes[0]]];
                            switch (ReceivedBytes[1])
                            {
                                case 0:
                                    switch (ReceivedBytes[2])
                                    {
                                        case 0:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            Tank.Set("CONTROLLER_UP", true);
                                            Tank.Set("CONTROLLER_LEFT", true);
                                            break;
                                        case 1:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            Tank.Set("CONTROLLER_UP", true);
                                            break;
                                        case 2:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            Tank.Set("CONTROLLER_UP", true);
                                            Tank.Set("CONTROLLER_RIGHT", true);
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (ReceivedBytes[2])
                                    {
                                        case 0:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            Tank.Set("CONTROLLER_LEFT", true);
                                            break;
                                        case 1:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            break;
                                        case 2:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            Tank.Set("CONTROLLER_RIGHT", true);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (ReceivedBytes[2])
                                    {
                                        case 0:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            Tank.Set("CONTROLLER_DOWN", true);
                                            Tank.Set("CONTROLLER_LEFT", true);
                                            break;
                                        case 1:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            Tank.Set("CONTROLLER_DOWN", true);
                                            break;
                                        case 2:
                                            Tank.Set("CONTROLLER_UP", false);
                                            Tank.Set("CONTROLLER_DOWN", false);
                                            Tank.Set("CONTROLLER_LEFT", false);
                                            Tank.Set("CONTROLLER_RIGHT", false);
                                            Tank.Set("CONTROLLER_DOWN", true);
                                            Tank.Set("CONTROLLER_RIGHT", true);
                                            break;
                                    }
                                    break;
                                case 3:
                                    if (ReceivedBytes[2] == 3)
                                        Tank.Set("CONTROLLER_SHOOT", true);
                                    break;
                            }
                        }
                        break;
                }
                c.BeginReceive(DataReceived, ar.AsyncState);
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Closed Receive");
            };

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
