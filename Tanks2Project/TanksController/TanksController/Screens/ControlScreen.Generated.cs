#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace TanksController.Screens
{
    public partial class ControlScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        
        private TanksController.Entities.Finger FingerInstance;
        private TanksController.Entities.JoyStickBase JoyStickBaseInstance;
        private TanksController.Entities.JoyStickStick JoyStickStickInstance;
        private TanksController.Entities.Button ShootButton;
        private TanksController.Entities.Button ExitButton;
        public ControlScreen () 
        	: base ("ControlScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            FingerInstance = new TanksController.Entities.Finger(ContentManagerName, false);
            FingerInstance.Name = "FingerInstance";
            JoyStickBaseInstance = new TanksController.Entities.JoyStickBase(ContentManagerName, false);
            JoyStickBaseInstance.Name = "JoyStickBaseInstance";
            JoyStickStickInstance = new TanksController.Entities.JoyStickStick(ContentManagerName, false);
            JoyStickStickInstance.Name = "JoyStickStickInstance";
            ShootButton = new TanksController.Entities.Button(ContentManagerName, false);
            ShootButton.Name = "ShootButton";
            ExitButton = new TanksController.Entities.Button(ContentManagerName, false);
            ExitButton.Name = "ExitButton";
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            FingerInstance.AddToManagers(mLayer);
            JoyStickBaseInstance.AddToManagers(mLayer);
            JoyStickStickInstance.AddToManagers(mLayer);
            ShootButton.AddToManagers(mLayer);
            ExitButton.AddToManagers(mLayer);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                FingerInstance.Activity();
                JoyStickBaseInstance.Activity();
                JoyStickStickInstance.Activity();
                ShootButton.Activity();
                ExitButton.Activity();
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
            
            if (FingerInstance != null)
            {
                FingerInstance.Destroy();
                FingerInstance.Detach();
            }
            if (JoyStickBaseInstance != null)
            {
                JoyStickBaseInstance.Destroy();
                JoyStickBaseInstance.Detach();
            }
            if (JoyStickStickInstance != null)
            {
                JoyStickStickInstance.Destroy();
                JoyStickStickInstance.Detach();
            }
            if (ShootButton != null)
            {
                ShootButton.Destroy();
                ShootButton.Detach();
            }
            if (ExitButton != null)
            {
                ExitButton.Destroy();
                ExitButton.Detach();
            }
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (JoyStickBaseInstance.Parent == null)
            {
                JoyStickBaseInstance.X = -260f;
            }
            else
            {
                JoyStickBaseInstance.RelativeX = -260f;
            }
            if (JoyStickBaseInstance.Parent == null)
            {
                JoyStickBaseInstance.Y = 0f;
            }
            else
            {
                JoyStickBaseInstance.RelativeY = 0f;
            }
            if (JoyStickStickInstance.Parent == null)
            {
                JoyStickStickInstance.X = -260f;
            }
            else
            {
                JoyStickStickInstance.RelativeX = -260f;
            }
            if (JoyStickStickInstance.Parent == null)
            {
                JoyStickStickInstance.Y = 0f;
            }
            else
            {
                JoyStickStickInstance.RelativeY = 0f;
            }
            if (JoyStickStickInstance.Parent == null)
            {
                JoyStickStickInstance.Z = 1f;
            }
            else
            {
                JoyStickStickInstance.RelativeZ = 1f;
            }
            if (ShootButton.Parent == null)
            {
                ShootButton.X = 285f;
            }
            else
            {
                ShootButton.RelativeX = 285f;
            }
            if (ShootButton.Parent == null)
            {
                ShootButton.Y = -130f;
            }
            else
            {
                ShootButton.RelativeY = -130f;
            }
            if (ExitButton.Parent == null)
            {
                ExitButton.X = 285f;
            }
            else
            {
                ExitButton.RelativeX = 285f;
            }
            if (ExitButton.Parent == null)
            {
                ExitButton.Y = 230f;
            }
            else
            {
                ExitButton.RelativeY = 230f;
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
            FingerInstance.RemoveFromManagers();
            JoyStickBaseInstance.RemoveFromManagers();
            JoyStickStickInstance.RemoveFromManagers();
            ShootButton.RemoveFromManagers();
            ExitButton.RemoveFromManagers();
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                FingerInstance.AssignCustomVariables(true);
                JoyStickBaseInstance.AssignCustomVariables(true);
                JoyStickStickInstance.AssignCustomVariables(true);
                ShootButton.AssignCustomVariables(true);
                ExitButton.AssignCustomVariables(true);
            }
            if (JoyStickBaseInstance.Parent == null)
            {
                JoyStickBaseInstance.X = -260f;
            }
            else
            {
                JoyStickBaseInstance.RelativeX = -260f;
            }
            if (JoyStickBaseInstance.Parent == null)
            {
                JoyStickBaseInstance.Y = 0f;
            }
            else
            {
                JoyStickBaseInstance.RelativeY = 0f;
            }
            if (JoyStickStickInstance.Parent == null)
            {
                JoyStickStickInstance.X = -260f;
            }
            else
            {
                JoyStickStickInstance.RelativeX = -260f;
            }
            if (JoyStickStickInstance.Parent == null)
            {
                JoyStickStickInstance.Y = 0f;
            }
            else
            {
                JoyStickStickInstance.RelativeY = 0f;
            }
            if (JoyStickStickInstance.Parent == null)
            {
                JoyStickStickInstance.Z = 1f;
            }
            else
            {
                JoyStickStickInstance.RelativeZ = 1f;
            }
            if (ShootButton.Parent == null)
            {
                ShootButton.X = 285f;
            }
            else
            {
                ShootButton.RelativeX = 285f;
            }
            if (ShootButton.Parent == null)
            {
                ShootButton.Y = -130f;
            }
            else
            {
                ShootButton.RelativeY = -130f;
            }
            if (ExitButton.Parent == null)
            {
                ExitButton.X = 285f;
            }
            else
            {
                ExitButton.RelativeX = 285f;
            }
            if (ExitButton.Parent == null)
            {
                ExitButton.Y = 230f;
            }
            else
            {
                ExitButton.RelativeY = 230f;
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            FingerInstance.ConvertToManuallyUpdated();
            JoyStickBaseInstance.ConvertToManuallyUpdated();
            JoyStickStickInstance.ConvertToManuallyUpdated();
            ShootButton.ConvertToManuallyUpdated();
            ExitButton.ConvertToManuallyUpdated();
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
            TanksController.Entities.Finger.LoadStaticContent(contentManagerName);
            TanksController.Entities.JoyStickBase.LoadStaticContent(contentManagerName);
            TanksController.Entities.JoyStickStick.LoadStaticContent(contentManagerName);
            TanksController.Entities.Button.LoadStaticContent(contentManagerName);
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
            return null;
        }
        public static object GetFile (string memberName) 
        {
            return null;
        }
        object GetMember (string memberName) 
        {
            return null;
        }
    }
}
