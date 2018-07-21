#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math.Geometry;
namespace TanksController.Entities
{
    public partial class JoyStickBase : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static Microsoft.Xna.Framework.Graphics.Texture2D JoyBack;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D Joystick;
        
        private FlatRedBall.Sprite Background;
        private FlatRedBall.Math.Geometry.Polygon mUpPolygon;
        public FlatRedBall.Math.Geometry.Polygon UpPolygon
        {
            get
            {
                return mUpPolygon;
            }
            private set
            {
                mUpPolygon = value;
            }
        }
        private FlatRedBall.Math.Geometry.Polygon mUpLeftPolygon;
        public FlatRedBall.Math.Geometry.Polygon UpLeftPolygon
        {
            get
            {
                return mUpLeftPolygon;
            }
            private set
            {
                mUpLeftPolygon = value;
            }
        }
        private FlatRedBall.Math.Geometry.Polygon mUpRightPolygon;
        public FlatRedBall.Math.Geometry.Polygon UpRightPolygon
        {
            get
            {
                return mUpRightPolygon;
            }
            private set
            {
                mUpRightPolygon = value;
            }
        }
        private FlatRedBall.Math.Geometry.Polygon mLeftPolygon;
        public FlatRedBall.Math.Geometry.Polygon LeftPolygon
        {
            get
            {
                return mLeftPolygon;
            }
            private set
            {
                mLeftPolygon = value;
            }
        }
        private FlatRedBall.Math.Geometry.Polygon mRightPolygon;
        public FlatRedBall.Math.Geometry.Polygon RightPolygon
        {
            get
            {
                return mRightPolygon;
            }
            private set
            {
                mRightPolygon = value;
            }
        }
        private FlatRedBall.Math.Geometry.Polygon mDownPolygon;
        public FlatRedBall.Math.Geometry.Polygon DownPolygon
        {
            get
            {
                return mDownPolygon;
            }
            private set
            {
                mDownPolygon = value;
            }
        }
        private FlatRedBall.Math.Geometry.Polygon mDownLeftPolygon;
        public FlatRedBall.Math.Geometry.Polygon DownLeftPolygon
        {
            get
            {
                return mDownLeftPolygon;
            }
            private set
            {
                mDownLeftPolygon = value;
            }
        }
        private FlatRedBall.Math.Geometry.Polygon mDownRightPolygon;
        public FlatRedBall.Math.Geometry.Polygon DownRightPolygon
        {
            get
            {
                return mDownRightPolygon;
            }
            private set
            {
                mDownRightPolygon = value;
            }
        }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public JoyStickBase () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public JoyStickBase (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public JoyStickBase (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            Background = new FlatRedBall.Sprite();
            Background.Name = "Background";
            mUpPolygon = new FlatRedBall.Math.Geometry.Polygon();
            mUpPolygon.Name = "mUpPolygon";
            mUpLeftPolygon = new FlatRedBall.Math.Geometry.Polygon();
            mUpLeftPolygon.Name = "mUpLeftPolygon";
            mUpRightPolygon = new FlatRedBall.Math.Geometry.Polygon();
            mUpRightPolygon.Name = "mUpRightPolygon";
            mLeftPolygon = new FlatRedBall.Math.Geometry.Polygon();
            mLeftPolygon.Name = "mLeftPolygon";
            mRightPolygon = new FlatRedBall.Math.Geometry.Polygon();
            mRightPolygon.Name = "mRightPolygon";
            mDownPolygon = new FlatRedBall.Math.Geometry.Polygon();
            mDownPolygon.Name = "mDownPolygon";
            mDownLeftPolygon = new FlatRedBall.Math.Geometry.Polygon();
            mDownLeftPolygon.Name = "mDownLeftPolygon";
            mDownRightPolygon = new FlatRedBall.Math.Geometry.Polygon();
            mDownRightPolygon.Name = "mDownRightPolygon";
            
            PostInitialize();
            if (addToManagers)
            {
                AddToManagers(null);
            }
        }
        public virtual void ReAddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(Background, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mUpPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mUpLeftPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mUpRightPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mLeftPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mRightPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mDownPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mDownLeftPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mDownRightPolygon, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(Background, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mUpPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mUpLeftPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mUpRightPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mLeftPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mRightPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mDownPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mDownLeftPolygon, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mDownRightPolygon, LayerProvidedByContainer);
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            if (Background != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(Background);
            }
            if (UpPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(UpPolygon);
            }
            if (UpLeftPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(UpLeftPolygon);
            }
            if (UpRightPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(UpRightPolygon);
            }
            if (LeftPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(LeftPolygon);
            }
            if (RightPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(RightPolygon);
            }
            if (DownPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(DownPolygon);
            }
            if (DownLeftPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(DownLeftPolygon);
            }
            if (DownRightPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(DownRightPolygon);
            }
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (Background.Parent == null)
            {
                Background.CopyAbsoluteToRelative();
                Background.AttachTo(this, false);
            }
            if (Background.Parent == null)
            {
                Background.X = 0f;
            }
            else
            {
                Background.RelativeX = 0f;
            }
            if (Background.Parent == null)
            {
                Background.Y = 0f;
            }
            else
            {
                Background.RelativeY = 0f;
            }
            Background.Texture = JoyBack;
            Background.TextureScale = 1f;
            if (mUpPolygon.Parent == null)
            {
                mUpPolygon.CopyAbsoluteToRelative();
                mUpPolygon.AttachTo(this, false);
            }
            UpPolygon.Visible = false;
            FlatRedBall.Math.Geometry.Point[] UpPolygonPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(0, 9), new FlatRedBall.Math.Geometry.Point(-75, 190), new FlatRedBall.Math.Geometry.Point(0, 210), new FlatRedBall.Math.Geometry.Point(75, 190), new FlatRedBall.Math.Geometry.Point(0, 9) };
            UpPolygon.Points = UpPolygonPoints;
            if (mUpLeftPolygon.Parent == null)
            {
                mUpLeftPolygon.CopyAbsoluteToRelative();
                mUpLeftPolygon.AttachTo(this, false);
            }
            UpLeftPolygon.Visible = false;
            FlatRedBall.Math.Geometry.Point[] UpLeftPolygonPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(-8, 6), new FlatRedBall.Math.Geometry.Point(-185, 80), new FlatRedBall.Math.Geometry.Point(-150, 150), new FlatRedBall.Math.Geometry.Point(-81, 186), new FlatRedBall.Math.Geometry.Point(-8, 6) };
            UpLeftPolygon.Points = UpLeftPolygonPoints;
            if (mUpRightPolygon.Parent == null)
            {
                mUpRightPolygon.CopyAbsoluteToRelative();
                mUpRightPolygon.AttachTo(this, false);
            }
            UpRightPolygon.Visible = false;
            FlatRedBall.Math.Geometry.Point[] UpRightPolygonPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(7, 7), new FlatRedBall.Math.Geometry.Point(186, 81), new FlatRedBall.Math.Geometry.Point(150, 150), new FlatRedBall.Math.Geometry.Point(81, 186), new FlatRedBall.Math.Geometry.Point(7, 7) };
            UpRightPolygon.Points = UpRightPolygonPoints;
            if (mLeftPolygon.Parent == null)
            {
                mLeftPolygon.CopyAbsoluteToRelative();
                mLeftPolygon.AttachTo(this, false);
            }
            LeftPolygon.Visible = false;
            FlatRedBall.Math.Geometry.Point[] LeftPolygonPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(-11, 0), new FlatRedBall.Math.Geometry.Point(-189, 73), new FlatRedBall.Math.Geometry.Point(-210, 0), new FlatRedBall.Math.Geometry.Point(-189, -73), new FlatRedBall.Math.Geometry.Point(-11, 0) };
            LeftPolygon.Points = LeftPolygonPoints;
            if (mRightPolygon.Parent == null)
            {
                mRightPolygon.CopyAbsoluteToRelative();
                mRightPolygon.AttachTo(this, false);
            }
            RightPolygon.Visible = false;
            FlatRedBall.Math.Geometry.Point[] RightPolygonPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(9, -1), new FlatRedBall.Math.Geometry.Point(189, -75), new FlatRedBall.Math.Geometry.Point(210, 0), new FlatRedBall.Math.Geometry.Point(189, 75), new FlatRedBall.Math.Geometry.Point(9, -1) };
            RightPolygon.Points = RightPolygonPoints;
            if (mDownPolygon.Parent == null)
            {
                mDownPolygon.CopyAbsoluteToRelative();
                mDownPolygon.AttachTo(this, false);
            }
            DownPolygon.Visible = false;
            FlatRedBall.Math.Geometry.Point[] DownPolygonPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(-1, -11), new FlatRedBall.Math.Geometry.Point(-75, -189), new FlatRedBall.Math.Geometry.Point(0, -210), new FlatRedBall.Math.Geometry.Point(75, -189), new FlatRedBall.Math.Geometry.Point(-1, -11) };
            DownPolygon.Points = DownPolygonPoints;
            if (mDownLeftPolygon.Parent == null)
            {
                mDownLeftPolygon.CopyAbsoluteToRelative();
                mDownLeftPolygon.AttachTo(this, false);
            }
            DownLeftPolygon.Visible = false;
            FlatRedBall.Math.Geometry.Point[] DownLeftPolygonPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(-7, -7), new FlatRedBall.Math.Geometry.Point(-186, -81), new FlatRedBall.Math.Geometry.Point(-150, -150), new FlatRedBall.Math.Geometry.Point(-80, -186), new FlatRedBall.Math.Geometry.Point(-7, -7) };
            DownLeftPolygon.Points = DownLeftPolygonPoints;
            if (mDownRightPolygon.Parent == null)
            {
                mDownRightPolygon.CopyAbsoluteToRelative();
                mDownRightPolygon.AttachTo(this, false);
            }
            DownRightPolygon.Visible = false;
            FlatRedBall.Math.Geometry.Point[] DownRightPolygonPoints = new FlatRedBall.Math.Geometry.Point[] {new FlatRedBall.Math.Geometry.Point(6, -7), new FlatRedBall.Math.Geometry.Point(186, -81), new FlatRedBall.Math.Geometry.Point(150, -150), new FlatRedBall.Math.Geometry.Point(80, -186), new FlatRedBall.Math.Geometry.Point(6, -7) };
            DownRightPolygon.Points = DownRightPolygonPoints;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (Background != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(Background);
            }
            if (UpPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(UpPolygon);
            }
            if (UpLeftPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(UpLeftPolygon);
            }
            if (UpRightPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(UpRightPolygon);
            }
            if (LeftPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(LeftPolygon);
            }
            if (RightPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(RightPolygon);
            }
            if (DownPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(DownPolygon);
            }
            if (DownLeftPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(DownLeftPolygon);
            }
            if (DownRightPolygon != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(DownRightPolygon);
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            if (Background.Parent == null)
            {
                Background.X = 0f;
            }
            else
            {
                Background.RelativeX = 0f;
            }
            if (Background.Parent == null)
            {
                Background.Y = 0f;
            }
            else
            {
                Background.RelativeY = 0f;
            }
            Background.Texture = JoyBack;
            Background.TextureScale = 1f;
            UpPolygon.Visible = false;
            UpLeftPolygon.Visible = false;
            UpRightPolygon.Visible = false;
            LeftPolygon.Visible = false;
            RightPolygon.Visible = false;
            DownPolygon.Visible = false;
            DownLeftPolygon.Visible = false;
            DownRightPolygon.Visible = false;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(Background);
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            ContentManagerName = contentManagerName;
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
            bool registerUnload = false;
            if (LoadedContentManagers.Contains(contentManagerName) == false)
            {
                LoadedContentManagers.Add(contentManagerName);
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("JoyStickBaseStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/joystick/joyback.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                JoyBack = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/joystick/joyback.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/joystick/joystick.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                Joystick = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/joystick/joystick.png", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("JoyStickBaseStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
            }
            CustomLoadStaticContent(contentManagerName);
        }
        public static void UnloadStaticContent () 
        {
            if (LoadedContentManagers.Count != 0)
            {
                LoadedContentManagers.RemoveAt(0);
                mRegisteredUnloads.RemoveAt(0);
            }
            if (LoadedContentManagers.Count == 0)
            {
                if (JoyBack != null)
                {
                    JoyBack= null;
                }
                if (Joystick != null)
                {
                    Joystick= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "JoyBack":
                    return JoyBack;
                case  "Joystick":
                    return Joystick;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "JoyBack":
                    return JoyBack;
                case  "Joystick":
                    return Joystick;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "JoyBack":
                    return JoyBack;
                case  "Joystick":
                    return Joystick;
            }
            return null;
        }
        protected bool mIsPaused;
        public override void Pause (FlatRedBall.Instructions.InstructionList instructions) 
        {
            base.Pause(instructions);
            mIsPaused = true;
        }
        public virtual void SetToIgnorePausing () 
        {
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(this);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(Background);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(UpPolygon);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(UpLeftPolygon);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(UpRightPolygon);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(LeftPolygon);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(RightPolygon);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(DownPolygon);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(DownLeftPolygon);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(DownRightPolygon);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(Background);
            }
            FlatRedBall.SpriteManager.AddToLayer(Background, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(UpPolygon);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(UpPolygon, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(UpLeftPolygon);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(UpLeftPolygon, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(UpRightPolygon);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(UpRightPolygon, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(LeftPolygon);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(LeftPolygon, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(RightPolygon);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(RightPolygon, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(DownPolygon);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(DownPolygon, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(DownLeftPolygon);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(DownLeftPolygon, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(DownRightPolygon);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(DownRightPolygon, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
