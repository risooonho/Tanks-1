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
namespace TanksController.Entities
{
    public partial class TextBox : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable
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
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public TextBox () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public TextBox (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public TextBox (string contentManagerName, bool addToManagers) 
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
            mTextInstance = new FlatRedBall.Graphics.Text();
            mTextInstance.Name = "mTextInstance";
            
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
            FlatRedBall.Graphics.TextManager.AddToLayer(mTextInstance, LayerProvidedByContainer);
            if (mTextInstance.Font != null)
            {
                mTextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Graphics.TextManager.AddToLayer(mTextInstance, LayerProvidedByContainer);
            if (mTextInstance.Font != null)
            {
                mTextInstance.SetPixelPerfectScale(LayerProvidedByContainer);
            }
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
            SpriteInstance.Texture = LetterButton;
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.Width = 500f;
            SpriteInstance.Height = 60f;
            if (mTextInstance.Parent == null)
            {
                mTextInstance.CopyAbsoluteToRelative();
                mTextInstance.AttachTo(this, false);
            }
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "";
            TextInstance.Font = Revengeance;
            TextInstance.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = 0f;
            }
            else
            {
                TextInstance.RelativeX = 0f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = -2f;
            }
            else
            {
                TextInstance.RelativeY = -2f;
            }
            TextInstance.TextureScale = 2f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
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
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            SpriteInstance.Texture = LetterButton;
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.Width = 500f;
            SpriteInstance.Height = 60f;
            TextInstance.NewLineDistance = 25.5f;
            TextInstance.Scale = 17f;
            TextInstance.Spacing = 17f;
            TextInstance.DisplayText = "";
            TextInstance.Font = Revengeance;
            TextInstance.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
            if (TextInstance.Parent == null)
            {
                TextInstance.X = 0f;
            }
            else
            {
                TextInstance.RelativeX = 0f;
            }
            if (TextInstance.Parent == null)
            {
                TextInstance.Y = -2f;
            }
            else
            {
                TextInstance.RelativeY = -2f;
            }
            TextInstance.TextureScale = 2f;
            TextInstance.Red = 0f;
            TextInstance.Green = 0f;
            TextInstance.Blue = 0f;
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("TextBoxStaticUnload", UnloadStaticContent);
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("TextBoxStaticUnload", UnloadStaticContent);
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
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
