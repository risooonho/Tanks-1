#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
namespace TanksController.Screens
{
    public partial class StartScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static Microsoft.Xna.Framework.Graphics.Texture2D btnNormal;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D btnPressed;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D Title;
        protected static FlatRedBall.Graphics.BitmapFont Revengeance;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D font_0;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D tank;
        
        private FlatRedBall.Sprite SpriteInstance;
        private FlatRedBall.Graphics.Text TextInstance;
        private FlatRedBall.Graphics.Text TextInstance2;
        private FlatRedBall.Graphics.Text TextInstance3;
        private FlatRedBall.Graphics.Text TextInstance4;
        private FlatRedBall.Graphics.Text TextInstance5;
        private FlatRedBall.Graphics.Text TextInstance6;
        private FlatRedBall.Sprite SpinningTank;
        private FlatRedBall.Math.PositionedObjectList<TanksController.Entities.ComputerName> ComputerNameList;
        private TanksController.Entities.Finger FingerInstance;
        public StartScreen () 
        	: base ("StartScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            TextInstance = new FlatRedBall.Graphics.Text();
            TextInstance.Name = "TextInstance";
            TextInstance2 = new FlatRedBall.Graphics.Text();
            TextInstance2.Name = "TextInstance2";
            TextInstance3 = new FlatRedBall.Graphics.Text();
            TextInstance3.Name = "TextInstance3";
            TextInstance4 = new FlatRedBall.Graphics.Text();
            TextInstance4.Name = "TextInstance4";
            TextInstance5 = new FlatRedBall.Graphics.Text();
            TextInstance5.Name = "TextInstance5";
            TextInstance6 = new FlatRedBall.Graphics.Text();
            TextInstance6.Name = "TextInstance6";
            SpinningTank = new FlatRedBall.Sprite();
            SpinningTank.Name = "SpinningTank";
            ComputerNameList = new FlatRedBall.Math.PositionedObjectList<TanksController.Entities.ComputerName>();
            ComputerNameList.Name = "ComputerNameList";
            FingerInstance = new TanksController.Entities.Finger(ContentManagerName, false);
            FingerInstance.Name = "FingerInstance";
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            Factories.ComputerNameFactory.Initialize(ContentManagerName);
            Factories.ComputerNameFactory.AddList(ComputerNameList);
            FlatRedBall.SpriteManager.AddSprite(SpriteInstance);
            FlatRedBall.Graphics.TextManager.AddText(TextInstance); if(TextInstance.Font != null) TextInstance.SetPixelPerfectScale(SpriteManager.Camera);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(mLayer);
            }
            FlatRedBall.Graphics.TextManager.AddText(TextInstance2); if(TextInstance2.Font != null) TextInstance2.SetPixelPerfectScale(SpriteManager.Camera);
            if (TextInstance2.Font != null)
            {
                TextInstance2.SetPixelPerfectScale(mLayer);
            }
            FlatRedBall.Graphics.TextManager.AddText(TextInstance3); if(TextInstance3.Font != null) TextInstance3.SetPixelPerfectScale(SpriteManager.Camera);
            if (TextInstance3.Font != null)
            {
                TextInstance3.SetPixelPerfectScale(mLayer);
            }
            FlatRedBall.Graphics.TextManager.AddText(TextInstance4); if(TextInstance4.Font != null) TextInstance4.SetPixelPerfectScale(SpriteManager.Camera);
            if (TextInstance4.Font != null)
            {
                TextInstance4.SetPixelPerfectScale(mLayer);
            }
            FlatRedBall.Graphics.TextManager.AddText(TextInstance5); if(TextInstance5.Font != null) TextInstance5.SetPixelPerfectScale(SpriteManager.Camera);
            if (TextInstance5.Font != null)
            {
                TextInstance5.SetPixelPerfectScale(mLayer);
            }
            FlatRedBall.Graphics.TextManager.AddText(TextInstance6); if(TextInstance6.Font != null) TextInstance6.SetPixelPerfectScale(SpriteManager.Camera);
            if (TextInstance6.Font != null)
            {
                TextInstance6.SetPixelPerfectScale(mLayer);
            }
            FlatRedBall.SpriteManager.AddSprite(SpinningTank);
            FingerInstance.AddToManagers(mLayer);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                for (int i = ComputerNameList.Count - 1; i > -1; i--)
                {
                    if (i < ComputerNameList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        ComputerNameList[i].Activity();
                    }
                }
                FingerInstance.Activity();
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            Factories.ComputerNameFactory.Destroy();
            btnNormal = null;
            btnPressed = null;
            Title = null;
            Revengeance = null;
            font_0 = null;
            tank = null;
            
            ComputerNameList.MakeOneWay();
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpriteInstance);
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance);
            }
            if (TextInstance2 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance2);
            }
            if (TextInstance3 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance3);
            }
            if (TextInstance4 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance4);
            }
            if (TextInstance5 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance5);
            }
            if (TextInstance6 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance6);
            }
            if (SpinningTank != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpinningTank);
            }
            for (int i = ComputerNameList.Count - 1; i > -1; i--)
            {
                ComputerNameList[i].Destroy();
            }
            if (FingerInstance != null)
            {
                FingerInstance.Destroy();
                FingerInstance.Detach();
            }
            ComputerNameList.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.X = -260f;
            }
            else
            {
                SpriteInstance.RelativeX = -260f;
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Y = 128f;
            }
            else
            {
                SpriteInstance.RelativeY = 128f;
            }
            SpriteInstance.Texture = Title;
            SpriteInstance.TextureScale = 1f;
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "Select a computer running Tanks.";
            TextInstance.Font = Revengeance;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = -491.7877f;
            }
            else
            {
                TextInstance.RelativeX = -491.7877f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = 77.84461f;
            }
            else
            {
                TextInstance.RelativeY = 77.84461f;
            }
            TextInstance.TextureScale = 1.2f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
            TextInstance2.NewLineDistance = 25.5f;
            TextInstance2.Scale = 17f;
            TextInstance2.Spacing = 17f;
            TextInstance2.DisplayText = "The computer and this device should";
            TextInstance2.Font = Revengeance;
            if (TextInstance2.Parent == null)
            {
                TextInstance2.X = -492.6595f;
            }
            else
            {
                TextInstance2.RelativeX = -492.6595f;
            }
            if (TextInstance2.Parent == null)
            {
                TextInstance2.Y = 40.84461f;
            }
            else
            {
                TextInstance2.RelativeY = 40.84461f;
            }
            TextInstance2.TextureScale = 1.2f;
            TextInstance2.Red = 0f;
            TextInstance2.Green = 0f;
            TextInstance2.Blue = 0f;
            TextInstance3.NewLineDistance = 25.5f;
            TextInstance3.Scale = 17f;
            TextInstance3.Spacing = 17f;
            TextInstance3.DisplayText = "be connected to the same network;";
            TextInstance3.Font = Revengeance;
            if (TextInstance3.Parent == null)
            {
                TextInstance3.X = -489.7877f;
            }
            else
            {
                TextInstance3.RelativeX = -489.7877f;
            }
            if (TextInstance3.Parent == null)
            {
                TextInstance3.Y = 2.844612f;
            }
            else
            {
                TextInstance3.RelativeY = 2.844612f;
            }
            TextInstance3.TextureScale = 1.2f;
            TextInstance3.Red = 0f;
            TextInstance3.Green = 0f;
            TextInstance3.Blue = 0f;
            TextInstance4.NewLineDistance = 25.5f;
            TextInstance4.Scale = 17f;
            TextInstance4.Spacing = 17f;
            TextInstance4.DisplayText = "on your PC, enable Allow Mobile Controllers";
            TextInstance4.Font = Revengeance;
            if (TextInstance4.Parent == null)
            {
                TextInstance4.X = -489.7877f;
            }
            else
            {
                TextInstance4.RelativeX = -489.7877f;
            }
            if (TextInstance4.Parent == null)
            {
                TextInstance4.Y = -39.15539f;
            }
            else
            {
                TextInstance4.RelativeY = -39.15539f;
            }
            TextInstance4.TextureScale = 1.2f;
            TextInstance4.Red = 0f;
            TextInstance4.Green = 0f;
            TextInstance4.Blue = 0f;
            TextInstance5.NewLineDistance = 25.5f;
            TextInstance5.Scale = 17f;
            TextInstance5.Spacing = 17f;
            TextInstance5.DisplayText = "and start a new game.";
            TextInstance5.Font = Revengeance;
            if (TextInstance5.Parent == null)
            {
                TextInstance5.X = -490f;
            }
            else
            {
                TextInstance5.RelativeX = -490f;
            }
            if (TextInstance5.Parent == null)
            {
                TextInstance5.Y = -81.13326f;
            }
            else
            {
                TextInstance5.RelativeY = -81.13326f;
            }
            TextInstance5.TextureScale = 1.2f;
            TextInstance5.Red = 0f;
            TextInstance5.Green = 0f;
            TextInstance5.Blue = 0f;
            TextInstance6.NewLineDistance = 25.5f;
            TextInstance6.Scale = 17f;
            TextInstance6.Spacing = 17f;
            TextInstance6.DisplayText = "Looking for computers...";
            TextInstance6.Font = Revengeance;
            if (TextInstance6.Parent == null)
            {
                TextInstance6.X = -390.7388f;
            }
            else
            {
                TextInstance6.RelativeX = -390.7388f;
            }
            if (TextInstance6.Parent == null)
            {
                TextInstance6.Y = -227f;
            }
            else
            {
                TextInstance6.RelativeY = -227f;
            }
            TextInstance6.TextureScale = 1.2f;
            TextInstance6.Red = 0f;
            TextInstance6.Green = 0f;
            TextInstance6.Blue = 0f;
            if (SpinningTank.Parent == null)
            {
                SpinningTank.X = -423.374f;
            }
            else
            {
                SpinningTank.RelativeX = -423.374f;
            }
            if (SpinningTank.Parent == null)
            {
                SpinningTank.Y = -229.7457f;
            }
            else
            {
                SpinningTank.RelativeY = -229.7457f;
            }
            SpinningTank.Texture = tank;
            SpinningTank.TextureScale = 2f;
            if (FingerInstance.Parent == null)
            {
                FingerInstance.X = -320.8841f;
            }
            else
            {
                FingerInstance.RelativeX = -320.8841f;
            }
            if (FingerInstance.Parent == null)
            {
                FingerInstance.Y = -137.2754f;
            }
            else
            {
                FingerInstance.RelativeY = -137.2754f;
            }
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
            if (TextInstance2 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance2);
            }
            if (TextInstance3 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance3);
            }
            if (TextInstance4 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance4);
            }
            if (TextInstance5 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance5);
            }
            if (TextInstance6 != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance6);
            }
            if (SpinningTank != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpinningTank);
            }
            for (int i = ComputerNameList.Count - 1; i > -1; i--)
            {
                ComputerNameList[i].Destroy();
            }
            FingerInstance.RemoveFromManagers();
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                FingerInstance.AssignCustomVariables(true);
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.X = -260f;
            }
            else
            {
                SpriteInstance.RelativeX = -260f;
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Y = 128f;
            }
            else
            {
                SpriteInstance.RelativeY = 128f;
            }
            SpriteInstance.Texture = Title;
            SpriteInstance.TextureScale = 1f;
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "Select a computer running Tanks.";
            TextInstance.Font = Revengeance;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = -491.7877f;
            }
            else
            {
                TextInstance.RelativeX = -491.7877f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = 77.84461f;
            }
            else
            {
                TextInstance.RelativeY = 77.84461f;
            }
            TextInstance.TextureScale = 1.2f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
            TextInstance2.NewLineDistance = 25.5f;
            TextInstance2.Scale = 17f;
            TextInstance2.Spacing = 17f;
            TextInstance2.DisplayText = "The computer and this device should";
            TextInstance2.Font = Revengeance;
            if (TextInstance2.Parent == null)
            {
                TextInstance2.X = -492.6595f;
            }
            else
            {
                TextInstance2.RelativeX = -492.6595f;
            }
            if (TextInstance2.Parent == null)
            {
                TextInstance2.Y = 40.84461f;
            }
            else
            {
                TextInstance2.RelativeY = 40.84461f;
            }
            TextInstance2.TextureScale = 1.2f;
            TextInstance2.Red = 0f;
            TextInstance2.Green = 0f;
            TextInstance2.Blue = 0f;
            TextInstance3.NewLineDistance = 25.5f;
            TextInstance3.Scale = 17f;
            TextInstance3.Spacing = 17f;
            TextInstance3.DisplayText = "be connected to the same network;";
            TextInstance3.Font = Revengeance;
            if (TextInstance3.Parent == null)
            {
                TextInstance3.X = -489.7877f;
            }
            else
            {
                TextInstance3.RelativeX = -489.7877f;
            }
            if (TextInstance3.Parent == null)
            {
                TextInstance3.Y = 2.844612f;
            }
            else
            {
                TextInstance3.RelativeY = 2.844612f;
            }
            TextInstance3.TextureScale = 1.2f;
            TextInstance3.Red = 0f;
            TextInstance3.Green = 0f;
            TextInstance3.Blue = 0f;
            TextInstance4.NewLineDistance = 25.5f;
            TextInstance4.Scale = 17f;
            TextInstance4.Spacing = 17f;
            TextInstance4.DisplayText = "on your PC, enable Allow Mobile Controllers";
            TextInstance4.Font = Revengeance;
            if (TextInstance4.Parent == null)
            {
                TextInstance4.X = -489.7877f;
            }
            else
            {
                TextInstance4.RelativeX = -489.7877f;
            }
            if (TextInstance4.Parent == null)
            {
                TextInstance4.Y = -39.15539f;
            }
            else
            {
                TextInstance4.RelativeY = -39.15539f;
            }
            TextInstance4.TextureScale = 1.2f;
            TextInstance4.Red = 0f;
            TextInstance4.Green = 0f;
            TextInstance4.Blue = 0f;
            TextInstance5.NewLineDistance = 25.5f;
            TextInstance5.Scale = 17f;
            TextInstance5.Spacing = 17f;
            TextInstance5.DisplayText = "and start a new game.";
            TextInstance5.Font = Revengeance;
            if (TextInstance5.Parent == null)
            {
                TextInstance5.X = -490f;
            }
            else
            {
                TextInstance5.RelativeX = -490f;
            }
            if (TextInstance5.Parent == null)
            {
                TextInstance5.Y = -81.13326f;
            }
            else
            {
                TextInstance5.RelativeY = -81.13326f;
            }
            TextInstance5.TextureScale = 1.2f;
            TextInstance5.Red = 0f;
            TextInstance5.Green = 0f;
            TextInstance5.Blue = 0f;
            TextInstance6.NewLineDistance = 25.5f;
            TextInstance6.Scale = 17f;
            TextInstance6.Spacing = 17f;
            TextInstance6.DisplayText = "Looking for computers...";
            TextInstance6.Font = Revengeance;
            if (TextInstance6.Parent == null)
            {
                TextInstance6.X = -390.7388f;
            }
            else
            {
                TextInstance6.RelativeX = -390.7388f;
            }
            if (TextInstance6.Parent == null)
            {
                TextInstance6.Y = -227f;
            }
            else
            {
                TextInstance6.RelativeY = -227f;
            }
            TextInstance6.TextureScale = 1.2f;
            TextInstance6.Red = 0f;
            TextInstance6.Green = 0f;
            TextInstance6.Blue = 0f;
            if (SpinningTank.Parent == null)
            {
                SpinningTank.X = -423.374f;
            }
            else
            {
                SpinningTank.RelativeX = -423.374f;
            }
            if (SpinningTank.Parent == null)
            {
                SpinningTank.Y = -229.7457f;
            }
            else
            {
                SpinningTank.RelativeY = -229.7457f;
            }
            SpinningTank.Texture = tank;
            SpinningTank.TextureScale = 2f;
            if (FingerInstance.Parent == null)
            {
                FingerInstance.X = -320.8841f;
            }
            else
            {
                FingerInstance.RelativeX = -320.8841f;
            }
            if (FingerInstance.Parent == null)
            {
                FingerInstance.Y = -137.2754f;
            }
            else
            {
                FingerInstance.RelativeY = -137.2754f;
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance2);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance3);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance4);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance5);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance6);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpinningTank);
            for (int i = 0; i < ComputerNameList.Count; i++)
            {
                ComputerNameList[i].ConvertToManuallyUpdated();
            }
            FingerInstance.ConvertToManuallyUpdated();
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            btnNormal = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/btnnormal.png", contentManagerName);
            btnPressed = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/btnpressed.png", contentManagerName);
            Title = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/title.png", contentManagerName);
            Revengeance = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.BitmapFont>(@"content/screens/startscreen/revengeance.fnt", contentManagerName);
            font_0 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/font_0.png", contentManagerName);
            tank = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/tank.png", contentManagerName);
            TanksController.Entities.Finger.LoadStaticContent(contentManagerName);
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "btnNormal":
                    return btnNormal;
                case  "btnPressed":
                    return btnPressed;
                case  "Title":
                    return Title;
                case  "Revengeance":
                    return Revengeance;
                case  "font_0":
                    return font_0;
                case  "tank":
                    return tank;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "btnNormal":
                    return btnNormal;
                case  "btnPressed":
                    return btnPressed;
                case  "Title":
                    return Title;
                case  "Revengeance":
                    return Revengeance;
                case  "font_0":
                    return font_0;
                case  "tank":
                    return tank;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "btnNormal":
                    return btnNormal;
                case  "btnPressed":
                    return btnPressed;
                case  "Title":
                    return Title;
                case  "Revengeance":
                    return Revengeance;
                case  "font_0":
                    return font_0;
                case  "tank":
                    return tank;
            }
            return null;
        }
    }
}
