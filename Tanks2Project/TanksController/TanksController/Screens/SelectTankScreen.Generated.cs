#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math;
namespace TanksController.Screens
{
    public partial class SelectTankScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        
        private FlatRedBall.Math.PositionedObjectList<TanksController.Entities.ComputerName> ComputerNameList;
        private TanksController.Entities.Finger FingerInstance;
        public SelectTankScreen () 
        	: base ("SelectTankScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
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
            
            ComputerNameList.MakeOneWay();
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
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
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
        }
        public virtual void ConvertToManuallyUpdated () 
        {
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
