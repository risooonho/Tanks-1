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
using TanksController.Entities;
using TanksController.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using FlatRedBall.Math;
using static FlatRedBall.Camera;

namespace TanksController.Screens
{
    public partial class SelectTankScreen
    {
        int StartingX = -450,
            StartingY = 240,
            XInc = 250,
            YInc = 50,
            MaxCol = 4,
            line = 0,
            col = 0;
        
        private int? GetClickedTank()
        {
            foreach (ComputerName Tank in ComputerNameList)
                if (Tank.Rectangle.CollideAgainst(FingerInstance.CircleInstance))
                    return GlobalData.Tanks.IndexOf(Tank.TextInstance.DisplayText);
            return null;
        }

        private void AddTank(string Name)
        {
            ComputerName NewName = ComputerNameFactory.CreateNew();
            NewName.TextInstance.DisplayText = Name;
            NewName.X = StartingX + col * XInc;
            NewName.Y = StartingY + line * YInc;
            col++;
            if(col == MaxCol)
            {
                col = 0;
                line--;
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
                int? TankID = GetClickedTank();
                if (TankID != null)
                {
                    GlobalData.SelectedTankIndex = (int)TankID;
                    MoveToScreen(typeof(ControlScreen));
                }
                TouchID = null;
            }

        }

        void CustomInitialize()
        {
            Main.BackgroundColor = Color.LightGray;
            foreach(string Tank in GlobalData.Tanks)
                AddTank(Tank);
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
