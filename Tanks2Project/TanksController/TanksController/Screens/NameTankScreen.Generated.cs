#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Graphics;
namespace TanksController.Screens
{
    public partial class NameTankScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static Microsoft.Xna.Framework.Graphics.Texture2D font_0;
        protected static FlatRedBall.Graphics.BitmapFont Revengeance;
        
        private TanksController.Entities.Keyboard KeyboardInstance;
        private TanksController.Entities.Finger FingerInstance;
        private TanksController.Entities.TextBox TextBoxInstance;
        private FlatRedBall.Graphics.Text TextInstance;
        private FlatRedBall.Graphics.Text ErrorText;
        public NameTankScreen () 
        	: base ("NameTankScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            KeyboardInstance = new TanksController.Entities.Keyboard(ContentManagerName, false);
            KeyboardInstance.Name = "KeyboardInstance";
            FingerInstance = new TanksController.Entities.Finger(ContentManagerName, false);
            FingerInstance.Name = "FingerInstance";
            TextBoxInstance = new TanksController.Entities.TextBox(ContentManagerName, false);
            TextBoxInstance.Name = "TextBoxInstance";
            TextInstance = new FlatRedBall.Graphics.Text();
            TextInstance.Name = "TextInstance";
            ErrorText = new FlatRedBall.Graphics.Text();
            ErrorText.Name = "ErrorText";
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            KeyboardInstance.AddToManagers(mLayer);
            FingerInstance.AddToManagers(mLayer);
            TextBoxInstance.AddToManagers(mLayer);
            FlatRedBall.Graphics.TextManager.AddText(TextInstance); if(TextInstance.Font != null) TextInstance.SetPixelPerfectScale(SpriteManager.Camera);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(mLayer);
            }
            FlatRedBall.Graphics.TextManager.AddText(ErrorText); if(ErrorText.Font != null) ErrorText.SetPixelPerfectScale(SpriteManager.Camera);
            if (ErrorText.Font != null)
            {
                ErrorText.SetPixelPerfectScale(mLayer);
            }
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                KeyboardInstance.Activity();
                FingerInstance.Activity();
                TextBoxInstance.Activity();
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
            font_0 = null;
            Revengeance = null;
            
            if (KeyboardInstance != null)
            {
                KeyboardInstance.Destroy();
                KeyboardInstance.Detach();
            }
            if (FingerInstance != null)
            {
                FingerInstance.Destroy();
                FingerInstance.Detach();
            }
            if (TextBoxInstance != null)
            {
                TextBoxInstance.Destroy();
                TextBoxInstance.Detach();
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance);
            }
            if (ErrorText != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(ErrorText);
            }
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (KeyboardInstance.Parent == null)
            {
                KeyboardInstance.X = 0f;
            }
            else
            {
                KeyboardInstance.RelativeX = 0f;
            }
            if (KeyboardInstance.Parent == null)
            {
                KeyboardInstance.Y = 0f;
            }
            else
            {
                KeyboardInstance.RelativeY = 0f;
            }
            if (FingerInstance.Parent == null)
            {
                FingerInstance.X = 110f;
            }
            else
            {
                FingerInstance.RelativeX = 110f;
            }
            if (FingerInstance.Parent == null)
            {
                FingerInstance.Y = 54f;
            }
            else
            {
                FingerInstance.RelativeY = 54f;
            }
            if (TextBoxInstance.Parent == null)
            {
                TextBoxInstance.X = -250f;
            }
            else
            {
                TextBoxInstance.RelativeX = -250f;
            }
            if (TextBoxInstance.Parent == null)
            {
                TextBoxInstance.Y = 30f;
            }
            else
            {
                TextBoxInstance.RelativeY = 30f;
            }
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "Write a meaningful nickname here:";
            TextInstance.Font = Revengeance;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = -493.6076f;
            }
            else
            {
                TextInstance.RelativeX = -493.6076f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = 78.52477f;
            }
            else
            {
                TextInstance.RelativeY = 78.52477f;
            }
            TextInstance.TextureScale = 1f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
            ErrorText.NewLineDistance = 25.5f;
            ErrorText.Scale = 17f;
            ErrorText.Spacing = 17f;
            ErrorText.DisplayText = "There is already a player with this name.";
            ErrorText.Font = Revengeance;
            if (ErrorText.Parent == null)
            {
                ErrorText.X = 0f;
            }
            else
            {
                ErrorText.RelativeX = 0f;
            }
            if (ErrorText.Parent == null)
            {
                ErrorText.Y = 17f;
            }
            else
            {
                ErrorText.RelativeY = 17f;
            }
            ErrorText.Visible = false;
            ErrorText.Green = 0f;
            ErrorText.Blue = 0f;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            KeyboardInstance.RemoveFromManagers();
            FingerInstance.RemoveFromManagers();
            TextBoxInstance.RemoveFromManagers();
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
            if (ErrorText != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(ErrorText);
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                KeyboardInstance.AssignCustomVariables(true);
                FingerInstance.AssignCustomVariables(true);
                TextBoxInstance.AssignCustomVariables(true);
            }
            if (KeyboardInstance.Parent == null)
            {
                KeyboardInstance.X = 0f;
            }
            else
            {
                KeyboardInstance.RelativeX = 0f;
            }
            if (KeyboardInstance.Parent == null)
            {
                KeyboardInstance.Y = 0f;
            }
            else
            {
                KeyboardInstance.RelativeY = 0f;
            }
            if (FingerInstance.Parent == null)
            {
                FingerInstance.X = 110f;
            }
            else
            {
                FingerInstance.RelativeX = 110f;
            }
            if (FingerInstance.Parent == null)
            {
                FingerInstance.Y = 54f;
            }
            else
            {
                FingerInstance.RelativeY = 54f;
            }
            if (TextBoxInstance.Parent == null)
            {
                TextBoxInstance.X = -250f;
            }
            else
            {
                TextBoxInstance.RelativeX = -250f;
            }
            if (TextBoxInstance.Parent == null)
            {
                TextBoxInstance.Y = 30f;
            }
            else
            {
                TextBoxInstance.RelativeY = 30f;
            }
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "Write a meaningful nickname here:";
            TextInstance.Font = Revengeance;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = -493.6076f;
            }
            else
            {
                TextInstance.RelativeX = -493.6076f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = 78.52477f;
            }
            else
            {
                TextInstance.RelativeY = 78.52477f;
            }
            TextInstance.TextureScale = 1f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
            ErrorText.NewLineDistance = 25.5f;
            ErrorText.Scale = 17f;
            ErrorText.Spacing = 17f;
            ErrorText.DisplayText = "There is already a player with this name.";
            ErrorText.Font = Revengeance;
            if (ErrorText.Parent == null)
            {
                ErrorText.X = 0f;
            }
            else
            {
                ErrorText.RelativeX = 0f;
            }
            if (ErrorText.Parent == null)
            {
                ErrorText.Y = 17f;
            }
            else
            {
                ErrorText.RelativeY = 17f;
            }
            ErrorText.Visible = false;
            ErrorText.Green = 0f;
            ErrorText.Blue = 0f;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            KeyboardInstance.ConvertToManuallyUpdated();
            FingerInstance.ConvertToManuallyUpdated();
            TextBoxInstance.ConvertToManuallyUpdated();
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(ErrorText);
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
            font_0 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/font_0.png", contentManagerName);
            Revengeance = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.BitmapFont>(@"content/screens/startscreen/revengeance.fnt", contentManagerName);
            TanksController.Entities.Keyboard.LoadStaticContent(contentManagerName);
            TanksController.Entities.Finger.LoadStaticContent(contentManagerName);
            TanksController.Entities.TextBox.LoadStaticContent(contentManagerName);
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
                case  "font_0":
                    return font_0;
                case  "Revengeance":
                    return Revengeance;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "font_0":
                    return font_0;
                case  "Revengeance":
                    return Revengeance;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "font_0":
                    return font_0;
                case  "Revengeance":
                    return Revengeance;
            }
            return null;
        }
    }
}
