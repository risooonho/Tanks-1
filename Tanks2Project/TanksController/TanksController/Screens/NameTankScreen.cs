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
using Microsoft.Xna.Framework;
using static FlatRedBall.Camera;
using TanksController.Entities;

namespace TanksController.Screens
{
    public partial class NameTankScreen
    {

        int? TouchID;

        private string GetButtonTap()
        {
            if (FingerInstance.Y <= 0) // lower than center of screen -> keyboard
            {
                foreach (KeyboardKey Key in KeyboardInstance.KeyboardKeyList)
                    if (Key.AxisAlignedRectangleInstance.CollideAgainst(FingerInstance.CircleInstance))
                        return Key.Text;
                if (KeyboardInstance.DeleteKeyInstance.AxisAlignedRectangleInstance.CollideAgainst(FingerInstance.CircleInstance))
                    return "Del";
                if (KeyboardInstance.GoButtonInstance.AxisAlignedRectangleInstance.CollideAgainst(FingerInstance.CircleInstance))
                    return "Go";
            }
            return "";
        }

        private void CheckNameAndGo(string name)
        {
            name = name.ToLower();
            foreach (var Name in GlobalData.Names)
                if (Name.ToLower() == name)
                {
                    ErrorText.Visible = true;
                    return;
                }
            GlobalData.PlayerName = name;
            MoveToScreen(typeof(SelectTankScreen));
        }

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
                string key = GetButtonTap();
                switch (key)
                {
                    case "Del":
                        TextBoxInstance.RemoveLetter();
                        break;
                    case "Go":
                        CheckNameAndGo(TextBoxInstance.TextInstance.DisplayText);
                        break;
                    case "SP":
                        TextBoxInstance.AddLetter(" ");
                        break;
                    default:
                        TextBoxInstance.AddLetter(key);
                        break;
                }
                TouchID = null;
            }

        }

        void CustomInitialize()
        {
            Main.BackgroundColor = Microsoft.Xna.Framework.Color.LightGray;

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
