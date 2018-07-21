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
    public partial class KeyboardKey : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Math.Geometry.ICollidable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static Microsoft.Xna.Framework.Graphics.Texture2D LetterButton;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D font_0;
        protected static FlatRedBall.Graphics.BitmapFont Revengeance;
        
        private FlatRedBall.Sprite SpriteInstance;
        protected FlatRedBall.Graphics.Text TextInstance;
        private FlatRedBall.Math.Geometry.AxisAlignedRectangle mAxisAlignedRectangleInstance;
        public FlatRedBall.Math.Geometry.AxisAlignedRectangle AxisAlignedRectangleInstance
        {
            get
            {
                return mAxisAlignedRectangleInstance;
            }
            private set
            {
                mAxisAlignedRectangleInstance = value;
            }
        }
        public string Text;
        private FlatRedBall.Math.Geometry.ShapeCollection mGeneratedCollision;
        public FlatRedBall.Math.Geometry.ShapeCollection Collision
        {
            get
            {
                return mGeneratedCollision;
            }
        }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public KeyboardKey () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public KeyboardKey (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public KeyboardKey (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            TextInstance = new FlatRedBall.Graphics.Text();
            TextInstance.Name = "TextInstance";
            mAxisAlignedRectangleInstance = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mAxisAlignedRectangleInstance.Name = "mAxisAlignedRectangleInstance";
            
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
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, LayerProvidedByContainer);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mAxisAlignedRectangleInstance, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, LayerProvidedByContainer);
            if (TextInstance.Font != null)
            {
                TextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mAxisAlignedRectangleInstance, LayerProvidedByContainer);
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
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpriteInstance);
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveText(TextInstance);
            }
            if (AxisAlignedRectangleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(AxisAlignedRectangleInstance);
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.CopyAbsoluteToRelative();
                SpriteInstance.AttachTo(this, false);
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.X = 0f;
            }
            else
            {
                SpriteInstance.RelativeX = 0f;
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Y = 0f;
            }
            else
            {
                SpriteInstance.RelativeY = 0f;
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Z = 1f;
            }
            else
            {
                SpriteInstance.RelativeZ = 1f;
            }
            SpriteInstance.Texture = LetterButton;
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.Height = 70f;
            if (TextInstance.Parent == null)
            {
                TextInstance.CopyAbsoluteToRelative();
                TextInstance.AttachTo(this, false);
            }
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "A";
            TextInstance.Font = Revengeance;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = -20f;
            }
            else
            {
                TextInstance.RelativeX = -20f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = -3f;
            }
            else
            {
                TextInstance.RelativeY = -3f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Z = 2f;
            }
            else
            {
                TextInstance.RelativeZ = 2f;
            }
            TextInstance.TextureScale = 2.7f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
            if (mAxisAlignedRectangleInstance.Parent == null)
            {
                mAxisAlignedRectangleInstance.CopyAbsoluteToRelative();
                mAxisAlignedRectangleInstance.AttachTo(this, false);
            }
            if (AxisAlignedRectangleInstance.Parent == null)
            {
                AxisAlignedRectangleInstance.X = 0f;
            }
            else
            {
                AxisAlignedRectangleInstance.RelativeX = 0f;
            }
            if (AxisAlignedRectangleInstance.Parent == null)
            {
                AxisAlignedRectangleInstance.Y = 0f;
            }
            else
            {
                AxisAlignedRectangleInstance.RelativeY = 0f;
            }
            AxisAlignedRectangleInstance.Width = 72f;
            AxisAlignedRectangleInstance.Height = 65f;
            AxisAlignedRectangleInstance.Visible = false;
            AxisAlignedRectangleInstance.Color = Microsoft.Xna.Framework.Color.SpringGreen;
            mGeneratedCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
            mGeneratedCollision.AxisAlignedRectangles.AddOneWay(mAxisAlignedRectangleInstance);
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (TextInstance != null)
            {
                FlatRedBall.Graphics.TextManager.RemoveTextOneWay(TextInstance);
            }
            if (AxisAlignedRectangleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(AxisAlignedRectangleInstance);
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.X = 0f;
            }
            else
            {
                SpriteInstance.RelativeX = 0f;
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Y = 0f;
            }
            else
            {
                SpriteInstance.RelativeY = 0f;
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Z = 1f;
            }
            else
            {
                SpriteInstance.RelativeZ = 1f;
            }
            SpriteInstance.Texture = LetterButton;
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.Height = 70f;
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "A";
            TextInstance.Font = Revengeance;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = -20f;
            }
            else
            {
                TextInstance.RelativeX = -20f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = -3f;
            }
            else
            {
                TextInstance.RelativeY = -3f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Z = 2f;
            }
            else
            {
                TextInstance.RelativeZ = 2f;
            }
            TextInstance.TextureScale = 2.7f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
            if (AxisAlignedRectangleInstance.Parent == null)
            {
                AxisAlignedRectangleInstance.X = 0f;
            }
            else
            {
                AxisAlignedRectangleInstance.RelativeX = 0f;
            }
            if (AxisAlignedRectangleInstance.Parent == null)
            {
                AxisAlignedRectangleInstance.Y = 0f;
            }
            else
            {
                AxisAlignedRectangleInstance.RelativeY = 0f;
            }
            AxisAlignedRectangleInstance.Width = 72f;
            AxisAlignedRectangleInstance.Height = 65f;
            AxisAlignedRectangleInstance.Visible = false;
            AxisAlignedRectangleInstance.Color = Microsoft.Xna.Framework.Color.SpringGreen;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("KeyboardKeyStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/keyboard/letterbutton.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                LetterButton = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/keyboard/letterbutton.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/font_0.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                font_0 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/startscreen/font_0.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.BitmapFont>(@"content/screens/startscreen/revengeance.fnt", ContentManagerName))
                {
                    registerUnload = true;
                }
                Revengeance = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.BitmapFont>(@"content/screens/startscreen/revengeance.fnt", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("KeyboardKeyStaticUnload", UnloadStaticContent);
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
                if (LetterButton != null)
                {
                    LetterButton= null;
                }
                if (font_0 != null)
                {
                    font_0= null;
                }
                if (Revengeance != null)
                {
                    Revengeance= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "LetterButton":
                    return LetterButton;
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
                case  "LetterButton":
                    return LetterButton;
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
                case  "LetterButton":
                    return LetterButton;
                case  "font_0":
                    return font_0;
                case  "Revengeance":
                    return Revengeance;
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
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(SpriteInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(TextInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(AxisAlignedRectangleInstance);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(SpriteInstance);
            }
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(TextInstance);
            }
            FlatRedBall.Graphics.TextManager.AddToLayer(TextInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(AxisAlignedRectangleInstance);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(AxisAlignedRectangleInstance, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
