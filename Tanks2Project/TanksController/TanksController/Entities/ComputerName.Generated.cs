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
    public partial class ComputerName : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Performance.IPoolable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static FlatRedBall.Graphics.BitmapFont Revengeance;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D font_0;
        
        private FlatRedBall.Graphics.Text mTextInstance;
        public FlatRedBall.Graphics.Text TextInstance
        {
            get
            {
                return mTextInstance;
            }
            private set
            {
                mTextInstance = value;
            }
        }
        private FlatRedBall.Math.Geometry.AxisAlignedRectangle mRectangle;
        public FlatRedBall.Math.Geometry.AxisAlignedRectangle Rectangle
        {
            get
            {
                return mRectangle;
            }
            private set
            {
                mRectangle = value;
            }
        }
        public int Index { get; set; }
        public bool Used { get; set; }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public ComputerName () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public ComputerName (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public ComputerName (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            mTextInstance = new FlatRedBall.Graphics.Text();
            mTextInstance.Name = "mTextInstance";
            mRectangle = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mRectangle.Name = "mRectangle";
            
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
            FlatRedBall.Graphics.TextManager.AddToLayer(mTextInstance, LayerProvidedByContainer);
            if (mTextInstance.Font != null)
            {
                mTextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mRectangle, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.Graphics.TextManager.AddToLayer(mTextInstance, LayerProvidedByContainer);
            if (mTextInstance.Font != null)
            {
                mTextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mRectangle, LayerProvidedByContainer);
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            if (Used)
            {
                Factories.ComputerNameFactory.MakeUnused(this, false);
            }
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
            if (Rectangle != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(Rectangle);
            }
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (mTextInstance.Parent == null)
            {
                mTextInstance.CopyAbsoluteToRelative();
                mTextInstance.AttachTo(this, false);
            }
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "Some Text.";
            TextInstance.Font = Revengeance;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = -15f;
            }
            else
            {
                TextInstance.RelativeX = -15f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = 0f;
            }
            else
            {
                TextInstance.RelativeY = 0f;
            }
            TextInstance.TextureScale = 1.5f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
            if (mRectangle.Parent == null)
            {
                mRectangle.CopyAbsoluteToRelative();
                mRectangle.AttachTo(this, false);
            }
            if (Rectangle.Parent == null)
            {
                Rectangle.X = 85f;
            }
            else
            {
                Rectangle.RelativeX = 85f;
            }
            if (Rectangle.Parent == null)
            {
                Rectangle.Y = 0f;
            }
            else
            {
                Rectangle.RelativeY = 0f;
            }
            Rectangle.Width = 200f;
            Rectangle.Height = 40f;
            Rectangle.Visible = true;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
            if (Rectangle != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(Rectangle);
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "Some Text.";
            TextInstance.Font = Revengeance;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = -15f;
            }
            else
            {
                TextInstance.RelativeX = -15f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = 0f;
            }
            else
            {
                TextInstance.RelativeY = 0f;
            }
            TextInstance.TextureScale = 1.5f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
            if (Rectangle.Parent == null)
            {
                Rectangle.X = 85f;
            }
            else
            {
                Rectangle.RelativeX = 85f;
            }
            if (Rectangle.Parent == null)
            {
                Rectangle.Y = 0f;
            }
            else
            {
                Rectangle.RelativeY = 0f;
            }
            Rectangle.Width = 200f;
            Rectangle.Height = 40f;
            Rectangle.Visible = true;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.Graphics.TextManager.ConvertToManuallyUpdated(TextInstance);
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("ComputerNameStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.BitmapFont>(@"content/screens/startscreen/revengeance.fnt", ContentManagerName))
                {
                    registerUnload = true;
                }
                Revengeance = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.BitmapFont>(@"content/screens/startscreen/revengeance.fnt", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/font_0.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                font_0 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/font_0.png", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("ComputerNameStaticUnload", UnloadStaticContent);
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
                if (Revengeance != null)
                {
                    Revengeance= null;
                }
                if (font_0 != null)
                {
                    font_0= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Revengeance":
                    return Revengeance;
                case  "font_0":
                    return font_0;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "Revengeance":
                    return Revengeance;
                case  "font_0":
                    return font_0;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Revengeance":
                    return Revengeance;
                case  "font_0":
                    return font_0;
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
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(TextInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(Rectangle);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(TextInstance);
            }
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(Rectangle);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(Rectangle, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
