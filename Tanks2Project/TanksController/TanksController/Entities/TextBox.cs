using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;

namespace TanksController.Entities
{
    public partial class TextBox
    {
        public int Count = 0;

        public void AddLetter(string Letter)
        {
            if (Count < 12)
            {
                TextInstance.DisplayText += Letter;
                Count++;
            }
        }

        public void RemoveLetter()
        {
            if(Count > 0)
            {
                try
                {
                    TextInstance.DisplayText = TextInstance.DisplayText.Substring(0, TextInstance.DisplayText.Length - 1);
                }
                catch(ArgumentOutOfRangeException) { };
                Count--;
            }
        }

        private void CustomInitialize()
        {


        }

        private void CustomActivity()
        {


        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }
}
