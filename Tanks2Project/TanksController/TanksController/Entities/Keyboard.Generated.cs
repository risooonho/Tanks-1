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
    public partial class Keyboard : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static Microsoft.Xna.Framework.Graphics.Texture2D KBDBack;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D LetterButton;
        
        private FlatRedBall.Sprite Background;
        private FlatRedBall.Math.PositionedObjectList<TanksController.Entities.KeyboardKey> mKeyboardKeyList;
        public FlatRedBall.Math.PositionedObjectList<TanksController.Entities.KeyboardKey> KeyboardKeyList
        {
            get
            {
                return mKeyboardKeyList;
            }
            private set
            {
                mKeyboardKeyList = value;
            }
        }
        private TanksController.Entities.KeyboardKey KeyboardKey1;
        private TanksController.Entities.KeyboardKey KeyboardKey2;
        private TanksController.Entities.KeyboardKey KeyboardKey3;
        private TanksController.Entities.KeyboardKey KeyboardKey4;
        private TanksController.Entities.KeyboardKey KeyboardKey5;
        private TanksController.Entities.KeyboardKey KeyboardKey6;
        private TanksController.Entities.KeyboardKey KeyboardKey7;
        private TanksController.Entities.KeyboardKey KeyboardKey8;
        private TanksController.Entities.KeyboardKey KeyboardKey9;
        private TanksController.Entities.KeyboardKey KeyboardKey10;
        private TanksController.Entities.KeyboardKey KeyboardKey11;
        private TanksController.Entities.KeyboardKey KeyboardKey12;
        private TanksController.Entities.KeyboardKey KeyboardKey13;
        private TanksController.Entities.KeyboardKey KeyboardKey14;
        private TanksController.Entities.KeyboardKey KeyboardKey15;
        private TanksController.Entities.KeyboardKey KeyboardKey16;
        private TanksController.Entities.KeyboardKey KeyboardKey17;
        private TanksController.Entities.KeyboardKey KeyboardKey18;
        private TanksController.Entities.KeyboardKey KeyboardKey19;
        private TanksController.Entities.KeyboardKey KeyboardKey20;
        private TanksController.Entities.KeyboardKey KeyboardKey21;
        private TanksController.Entities.KeyboardKey KeyboardKey22;
        private TanksController.Entities.KeyboardKey KeyboardKey23;
        private TanksController.Entities.KeyboardKey KeyboardKey24;
        private TanksController.Entities.KeyboardKey KeyboardKey25;
        private TanksController.Entities.KeyboardKey KeyboardKey26;
        private TanksController.Entities.KeyboardKey KeyboardKey27;
        private TanksController.Entities.KeyboardKey KeyboardKey28;
        private TanksController.Entities.KeyboardKey KeyboardKey29;
        private TanksController.Entities.KeyboardKey KeyboardKey37;
        private TanksController.Entities.KeyboardKey KeyboardKey30;
        private TanksController.Entities.KeyboardKey KeyboardKey31;
        private TanksController.Entities.KeyboardKey KeyboardKey32;
        private TanksController.Entities.KeyboardKey KeyboardKey33;
        private TanksController.Entities.KeyboardKey KeyboardKey34;
        private TanksController.Entities.KeyboardKey KeyboardKey35;
        private TanksController.Entities.KeyboardKey KeyboardKey36;
        private TanksController.Entities.DeleteKey mDeleteKeyInstance;
        public TanksController.Entities.DeleteKey DeleteKeyInstance
        {
            get
            {
                return mDeleteKeyInstance;
            }
            private set
            {
                mDeleteKeyInstance = value;
            }
        }
        private TanksController.Entities.GoButton mGoButtonInstance;
        public TanksController.Entities.GoButton GoButtonInstance
        {
            get
            {
                return mGoButtonInstance;
            }
            private set
            {
                mGoButtonInstance = value;
            }
        }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public Keyboard () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Keyboard (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Keyboard (string contentManagerName, bool addToManagers) 
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
            mKeyboardKeyList = new FlatRedBall.Math.PositionedObjectList<TanksController.Entities.KeyboardKey>();
            mKeyboardKeyList.Name = "mKeyboardKeyList";
            KeyboardKey1 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey1.Name = "KeyboardKey1";
            KeyboardKey2 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey2.Name = "KeyboardKey2";
            KeyboardKey3 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey3.Name = "KeyboardKey3";
            KeyboardKey4 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey4.Name = "KeyboardKey4";
            KeyboardKey5 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey5.Name = "KeyboardKey5";
            KeyboardKey6 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey6.Name = "KeyboardKey6";
            KeyboardKey7 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey7.Name = "KeyboardKey7";
            KeyboardKey8 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey8.Name = "KeyboardKey8";
            KeyboardKey9 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey9.Name = "KeyboardKey9";
            KeyboardKey10 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey10.Name = "KeyboardKey10";
            KeyboardKey11 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey11.Name = "KeyboardKey11";
            KeyboardKey12 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey12.Name = "KeyboardKey12";
            KeyboardKey13 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey13.Name = "KeyboardKey13";
            KeyboardKey14 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey14.Name = "KeyboardKey14";
            KeyboardKey15 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey15.Name = "KeyboardKey15";
            KeyboardKey16 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey16.Name = "KeyboardKey16";
            KeyboardKey17 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey17.Name = "KeyboardKey17";
            KeyboardKey18 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey18.Name = "KeyboardKey18";
            KeyboardKey19 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey19.Name = "KeyboardKey19";
            KeyboardKey20 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey20.Name = "KeyboardKey20";
            KeyboardKey21 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey21.Name = "KeyboardKey21";
            KeyboardKey22 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey22.Name = "KeyboardKey22";
            KeyboardKey23 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey23.Name = "KeyboardKey23";
            KeyboardKey24 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey24.Name = "KeyboardKey24";
            KeyboardKey25 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey25.Name = "KeyboardKey25";
            KeyboardKey26 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey26.Name = "KeyboardKey26";
            KeyboardKey27 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey27.Name = "KeyboardKey27";
            KeyboardKey28 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey28.Name = "KeyboardKey28";
            KeyboardKey29 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey29.Name = "KeyboardKey29";
            KeyboardKey37 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey37.Name = "KeyboardKey37";
            KeyboardKey30 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey30.Name = "KeyboardKey30";
            KeyboardKey31 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey31.Name = "KeyboardKey31";
            KeyboardKey32 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey32.Name = "KeyboardKey32";
            KeyboardKey33 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey33.Name = "KeyboardKey33";
            KeyboardKey34 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey34.Name = "KeyboardKey34";
            KeyboardKey35 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey35.Name = "KeyboardKey35";
            KeyboardKey36 = new TanksController.Entities.KeyboardKey(ContentManagerName, false);
            KeyboardKey36.Name = "KeyboardKey36";
            mDeleteKeyInstance = new TanksController.Entities.DeleteKey(ContentManagerName, false);
            mDeleteKeyInstance.Name = "mDeleteKeyInstance";
            mGoButtonInstance = new TanksController.Entities.GoButton(ContentManagerName, false);
            mGoButtonInstance.Name = "mGoButtonInstance";
            
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
            mDeleteKeyInstance.ReAddToManagers(LayerProvidedByContainer);
            mGoButtonInstance.ReAddToManagers(LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(Background, LayerProvidedByContainer);
            KeyboardKey1.AddToManagers(LayerProvidedByContainer);
            KeyboardKey2.AddToManagers(LayerProvidedByContainer);
            KeyboardKey3.AddToManagers(LayerProvidedByContainer);
            KeyboardKey4.AddToManagers(LayerProvidedByContainer);
            KeyboardKey5.AddToManagers(LayerProvidedByContainer);
            KeyboardKey6.AddToManagers(LayerProvidedByContainer);
            KeyboardKey7.AddToManagers(LayerProvidedByContainer);
            KeyboardKey8.AddToManagers(LayerProvidedByContainer);
            KeyboardKey9.AddToManagers(LayerProvidedByContainer);
            KeyboardKey10.AddToManagers(LayerProvidedByContainer);
            KeyboardKey11.AddToManagers(LayerProvidedByContainer);
            KeyboardKey12.AddToManagers(LayerProvidedByContainer);
            KeyboardKey13.AddToManagers(LayerProvidedByContainer);
            KeyboardKey14.AddToManagers(LayerProvidedByContainer);
            KeyboardKey15.AddToManagers(LayerProvidedByContainer);
            KeyboardKey16.AddToManagers(LayerProvidedByContainer);
            KeyboardKey17.AddToManagers(LayerProvidedByContainer);
            KeyboardKey18.AddToManagers(LayerProvidedByContainer);
            KeyboardKey19.AddToManagers(LayerProvidedByContainer);
            KeyboardKey20.AddToManagers(LayerProvidedByContainer);
            KeyboardKey21.AddToManagers(LayerProvidedByContainer);
            KeyboardKey22.AddToManagers(LayerProvidedByContainer);
            KeyboardKey23.AddToManagers(LayerProvidedByContainer);
            KeyboardKey24.AddToManagers(LayerProvidedByContainer);
            KeyboardKey25.AddToManagers(LayerProvidedByContainer);
            KeyboardKey26.AddToManagers(LayerProvidedByContainer);
            KeyboardKey27.AddToManagers(LayerProvidedByContainer);
            KeyboardKey28.AddToManagers(LayerProvidedByContainer);
            KeyboardKey29.AddToManagers(LayerProvidedByContainer);
            KeyboardKey37.AddToManagers(LayerProvidedByContainer);
            KeyboardKey30.AddToManagers(LayerProvidedByContainer);
            KeyboardKey31.AddToManagers(LayerProvidedByContainer);
            KeyboardKey32.AddToManagers(LayerProvidedByContainer);
            KeyboardKey33.AddToManagers(LayerProvidedByContainer);
            KeyboardKey34.AddToManagers(LayerProvidedByContainer);
            KeyboardKey35.AddToManagers(LayerProvidedByContainer);
            KeyboardKey36.AddToManagers(LayerProvidedByContainer);
            mDeleteKeyInstance.AddToManagers(LayerProvidedByContainer);
            mGoButtonInstance.AddToManagers(LayerProvidedByContainer);
            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            
            for (int i = KeyboardKeyList.Count - 1; i > -1; i--)
            {
                if (i < KeyboardKeyList.Count)
                {
                    // We do the extra if-check because activity could destroy any number of entities
                    KeyboardKeyList[i].Activity();
                }
            }
            DeleteKeyInstance.Activity();
            GoButtonInstance.Activity();
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            KeyboardKeyList.MakeOneWay();
            if (Background != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(Background);
            }
            for (int i = KeyboardKeyList.Count - 1; i > -1; i--)
            {
                KeyboardKeyList[i].Destroy();
            }
            if (DeleteKeyInstance != null)
            {
                DeleteKeyInstance.Destroy();
                DeleteKeyInstance.Detach();
            }
            if (GoButtonInstance != null)
            {
                GoButtonInstance.Destroy();
                GoButtonInstance.Detach();
            }
            KeyboardKeyList.MakeTwoWay();
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
                Background.Y = -150f;
            }
            else
            {
                Background.RelativeY = -150f;
            }
            Background.Texture = KBDBack;
            Background.TextureScale = 1f;
            Background.Width = 1000f;
            KeyboardKeyList.Add(KeyboardKey1);
            if (KeyboardKey1.Parent == null)
            {
                KeyboardKey1.CopyAbsoluteToRelative();
                KeyboardKey1.AttachTo(this, false);
            }
            if (KeyboardKey1.Parent == null)
            {
                KeyboardKey1.X = -450f;
            }
            else
            {
                KeyboardKey1.RelativeX = -450f;
            }
            if (KeyboardKey1.Parent == null)
            {
                KeyboardKey1.Y = -40f;
            }
            else
            {
                KeyboardKey1.RelativeY = -40f;
            }
            KeyboardKey1.Text = "1";
            KeyboardKeyList.Add(KeyboardKey2);
            if (KeyboardKey2.Parent == null)
            {
                KeyboardKey2.CopyAbsoluteToRelative();
                KeyboardKey2.AttachTo(this, false);
            }
            if (KeyboardKey2.Parent == null)
            {
                KeyboardKey2.X = -350f;
            }
            else
            {
                KeyboardKey2.RelativeX = -350f;
            }
            if (KeyboardKey2.Parent == null)
            {
                KeyboardKey2.Y = -40f;
            }
            else
            {
                KeyboardKey2.RelativeY = -40f;
            }
            KeyboardKey2.Text = "2";
            KeyboardKeyList.Add(KeyboardKey3);
            if (KeyboardKey3.Parent == null)
            {
                KeyboardKey3.CopyAbsoluteToRelative();
                KeyboardKey3.AttachTo(this, false);
            }
            if (KeyboardKey3.Parent == null)
            {
                KeyboardKey3.X = -250f;
            }
            else
            {
                KeyboardKey3.RelativeX = -250f;
            }
            if (KeyboardKey3.Parent == null)
            {
                KeyboardKey3.Y = -40f;
            }
            else
            {
                KeyboardKey3.RelativeY = -40f;
            }
            KeyboardKey3.Text = "3";
            KeyboardKeyList.Add(KeyboardKey4);
            if (KeyboardKey4.Parent == null)
            {
                KeyboardKey4.CopyAbsoluteToRelative();
                KeyboardKey4.AttachTo(this, false);
            }
            if (KeyboardKey4.Parent == null)
            {
                KeyboardKey4.X = -150f;
            }
            else
            {
                KeyboardKey4.RelativeX = -150f;
            }
            if (KeyboardKey4.Parent == null)
            {
                KeyboardKey4.Y = -40f;
            }
            else
            {
                KeyboardKey4.RelativeY = -40f;
            }
            KeyboardKey4.Text = "4";
            KeyboardKeyList.Add(KeyboardKey5);
            if (KeyboardKey5.Parent == null)
            {
                KeyboardKey5.CopyAbsoluteToRelative();
                KeyboardKey5.AttachTo(this, false);
            }
            if (KeyboardKey5.Parent == null)
            {
                KeyboardKey5.X = -50f;
            }
            else
            {
                KeyboardKey5.RelativeX = -50f;
            }
            if (KeyboardKey5.Parent == null)
            {
                KeyboardKey5.Y = -40f;
            }
            else
            {
                KeyboardKey5.RelativeY = -40f;
            }
            KeyboardKey5.Text = "5";
            KeyboardKeyList.Add(KeyboardKey6);
            if (KeyboardKey6.Parent == null)
            {
                KeyboardKey6.CopyAbsoluteToRelative();
                KeyboardKey6.AttachTo(this, false);
            }
            if (KeyboardKey6.Parent == null)
            {
                KeyboardKey6.X = 50f;
            }
            else
            {
                KeyboardKey6.RelativeX = 50f;
            }
            if (KeyboardKey6.Parent == null)
            {
                KeyboardKey6.Y = -40f;
            }
            else
            {
                KeyboardKey6.RelativeY = -40f;
            }
            KeyboardKey6.Text = "6";
            KeyboardKeyList.Add(KeyboardKey7);
            if (KeyboardKey7.Parent == null)
            {
                KeyboardKey7.CopyAbsoluteToRelative();
                KeyboardKey7.AttachTo(this, false);
            }
            if (KeyboardKey7.Parent == null)
            {
                KeyboardKey7.X = 150f;
            }
            else
            {
                KeyboardKey7.RelativeX = 150f;
            }
            if (KeyboardKey7.Parent == null)
            {
                KeyboardKey7.Y = -40f;
            }
            else
            {
                KeyboardKey7.RelativeY = -40f;
            }
            KeyboardKey7.Text = "7";
            KeyboardKeyList.Add(KeyboardKey8);
            if (KeyboardKey8.Parent == null)
            {
                KeyboardKey8.CopyAbsoluteToRelative();
                KeyboardKey8.AttachTo(this, false);
            }
            if (KeyboardKey8.Parent == null)
            {
                KeyboardKey8.X = 250f;
            }
            else
            {
                KeyboardKey8.RelativeX = 250f;
            }
            if (KeyboardKey8.Parent == null)
            {
                KeyboardKey8.Y = -40f;
            }
            else
            {
                KeyboardKey8.RelativeY = -40f;
            }
            KeyboardKey8.Text = "8";
            KeyboardKeyList.Add(KeyboardKey9);
            if (KeyboardKey9.Parent == null)
            {
                KeyboardKey9.CopyAbsoluteToRelative();
                KeyboardKey9.AttachTo(this, false);
            }
            if (KeyboardKey9.Parent == null)
            {
                KeyboardKey9.X = 350f;
            }
            else
            {
                KeyboardKey9.RelativeX = 350f;
            }
            if (KeyboardKey9.Parent == null)
            {
                KeyboardKey9.Y = -40f;
            }
            else
            {
                KeyboardKey9.RelativeY = -40f;
            }
            KeyboardKey9.Text = "9";
            KeyboardKeyList.Add(KeyboardKey10);
            if (KeyboardKey10.Parent == null)
            {
                KeyboardKey10.CopyAbsoluteToRelative();
                KeyboardKey10.AttachTo(this, false);
            }
            if (KeyboardKey10.Parent == null)
            {
                KeyboardKey10.X = 450f;
            }
            else
            {
                KeyboardKey10.RelativeX = 450f;
            }
            if (KeyboardKey10.Parent == null)
            {
                KeyboardKey10.Y = -40f;
            }
            else
            {
                KeyboardKey10.RelativeY = -40f;
            }
            KeyboardKey10.Text = "0";
            KeyboardKeyList.Add(KeyboardKey11);
            if (KeyboardKey11.Parent == null)
            {
                KeyboardKey11.CopyAbsoluteToRelative();
                KeyboardKey11.AttachTo(this, false);
            }
            if (KeyboardKey11.Parent == null)
            {
                KeyboardKey11.X = -450f;
            }
            else
            {
                KeyboardKey11.RelativeX = -450f;
            }
            if (KeyboardKey11.Parent == null)
            {
                KeyboardKey11.Y = -112f;
            }
            else
            {
                KeyboardKey11.RelativeY = -112f;
            }
            KeyboardKey11.Text = "Q";
            KeyboardKeyList.Add(KeyboardKey12);
            if (KeyboardKey12.Parent == null)
            {
                KeyboardKey12.CopyAbsoluteToRelative();
                KeyboardKey12.AttachTo(this, false);
            }
            if (KeyboardKey12.Parent == null)
            {
                KeyboardKey12.X = -350f;
            }
            else
            {
                KeyboardKey12.RelativeX = -350f;
            }
            if (KeyboardKey12.Parent == null)
            {
                KeyboardKey12.Y = -112f;
            }
            else
            {
                KeyboardKey12.RelativeY = -112f;
            }
            KeyboardKey12.Text = "W";
            KeyboardKeyList.Add(KeyboardKey13);
            if (KeyboardKey13.Parent == null)
            {
                KeyboardKey13.CopyAbsoluteToRelative();
                KeyboardKey13.AttachTo(this, false);
            }
            if (KeyboardKey13.Parent == null)
            {
                KeyboardKey13.X = -250f;
            }
            else
            {
                KeyboardKey13.RelativeX = -250f;
            }
            if (KeyboardKey13.Parent == null)
            {
                KeyboardKey13.Y = -112f;
            }
            else
            {
                KeyboardKey13.RelativeY = -112f;
            }
            KeyboardKey13.Text = "E";
            KeyboardKeyList.Add(KeyboardKey14);
            if (KeyboardKey14.Parent == null)
            {
                KeyboardKey14.CopyAbsoluteToRelative();
                KeyboardKey14.AttachTo(this, false);
            }
            if (KeyboardKey14.Parent == null)
            {
                KeyboardKey14.X = -150f;
            }
            else
            {
                KeyboardKey14.RelativeX = -150f;
            }
            if (KeyboardKey14.Parent == null)
            {
                KeyboardKey14.Y = -112f;
            }
            else
            {
                KeyboardKey14.RelativeY = -112f;
            }
            KeyboardKey14.Text = "R";
            KeyboardKeyList.Add(KeyboardKey15);
            if (KeyboardKey15.Parent == null)
            {
                KeyboardKey15.CopyAbsoluteToRelative();
                KeyboardKey15.AttachTo(this, false);
            }
            if (KeyboardKey15.Parent == null)
            {
                KeyboardKey15.X = -50f;
            }
            else
            {
                KeyboardKey15.RelativeX = -50f;
            }
            if (KeyboardKey15.Parent == null)
            {
                KeyboardKey15.Y = -112f;
            }
            else
            {
                KeyboardKey15.RelativeY = -112f;
            }
            KeyboardKey15.Text = "T";
            KeyboardKeyList.Add(KeyboardKey16);
            if (KeyboardKey16.Parent == null)
            {
                KeyboardKey16.CopyAbsoluteToRelative();
                KeyboardKey16.AttachTo(this, false);
            }
            if (KeyboardKey16.Parent == null)
            {
                KeyboardKey16.X = 50f;
            }
            else
            {
                KeyboardKey16.RelativeX = 50f;
            }
            if (KeyboardKey16.Parent == null)
            {
                KeyboardKey16.Y = -112f;
            }
            else
            {
                KeyboardKey16.RelativeY = -112f;
            }
            KeyboardKey16.Text = "Y";
            KeyboardKeyList.Add(KeyboardKey17);
            if (KeyboardKey17.Parent == null)
            {
                KeyboardKey17.CopyAbsoluteToRelative();
                KeyboardKey17.AttachTo(this, false);
            }
            if (KeyboardKey17.Parent == null)
            {
                KeyboardKey17.X = 150f;
            }
            else
            {
                KeyboardKey17.RelativeX = 150f;
            }
            if (KeyboardKey17.Parent == null)
            {
                KeyboardKey17.Y = -112f;
            }
            else
            {
                KeyboardKey17.RelativeY = -112f;
            }
            KeyboardKey17.Text = "U";
            KeyboardKeyList.Add(KeyboardKey18);
            if (KeyboardKey18.Parent == null)
            {
                KeyboardKey18.CopyAbsoluteToRelative();
                KeyboardKey18.AttachTo(this, false);
            }
            if (KeyboardKey18.Parent == null)
            {
                KeyboardKey18.X = 250f;
            }
            else
            {
                KeyboardKey18.RelativeX = 250f;
            }
            if (KeyboardKey18.Parent == null)
            {
                KeyboardKey18.Y = -112f;
            }
            else
            {
                KeyboardKey18.RelativeY = -112f;
            }
            KeyboardKey18.Text = "I";
            KeyboardKeyList.Add(KeyboardKey19);
            if (KeyboardKey19.Parent == null)
            {
                KeyboardKey19.CopyAbsoluteToRelative();
                KeyboardKey19.AttachTo(this, false);
            }
            if (KeyboardKey19.Parent == null)
            {
                KeyboardKey19.X = 350f;
            }
            else
            {
                KeyboardKey19.RelativeX = 350f;
            }
            if (KeyboardKey19.Parent == null)
            {
                KeyboardKey19.Y = -112f;
            }
            else
            {
                KeyboardKey19.RelativeY = -112f;
            }
            KeyboardKey19.Text = "O";
            KeyboardKeyList.Add(KeyboardKey20);
            if (KeyboardKey20.Parent == null)
            {
                KeyboardKey20.CopyAbsoluteToRelative();
                KeyboardKey20.AttachTo(this, false);
            }
            if (KeyboardKey20.Parent == null)
            {
                KeyboardKey20.X = 450f;
            }
            else
            {
                KeyboardKey20.RelativeX = 450f;
            }
            if (KeyboardKey20.Parent == null)
            {
                KeyboardKey20.Y = -112f;
            }
            else
            {
                KeyboardKey20.RelativeY = -112f;
            }
            KeyboardKey20.Text = "P";
            KeyboardKeyList.Add(KeyboardKey21);
            if (KeyboardKey21.Parent == null)
            {
                KeyboardKey21.CopyAbsoluteToRelative();
                KeyboardKey21.AttachTo(this, false);
            }
            if (KeyboardKey21.Parent == null)
            {
                KeyboardKey21.X = -450f;
            }
            else
            {
                KeyboardKey21.RelativeX = -450f;
            }
            if (KeyboardKey21.Parent == null)
            {
                KeyboardKey21.Y = -184f;
            }
            else
            {
                KeyboardKey21.RelativeY = -184f;
            }
            KeyboardKey21.Text = "A";
            KeyboardKeyList.Add(KeyboardKey22);
            if (KeyboardKey22.Parent == null)
            {
                KeyboardKey22.CopyAbsoluteToRelative();
                KeyboardKey22.AttachTo(this, false);
            }
            if (KeyboardKey22.Parent == null)
            {
                KeyboardKey22.X = -350f;
            }
            else
            {
                KeyboardKey22.RelativeX = -350f;
            }
            if (KeyboardKey22.Parent == null)
            {
                KeyboardKey22.Y = -184f;
            }
            else
            {
                KeyboardKey22.RelativeY = -184f;
            }
            KeyboardKey22.Text = "S";
            KeyboardKeyList.Add(KeyboardKey23);
            if (KeyboardKey23.Parent == null)
            {
                KeyboardKey23.CopyAbsoluteToRelative();
                KeyboardKey23.AttachTo(this, false);
            }
            if (KeyboardKey23.Parent == null)
            {
                KeyboardKey23.X = -250f;
            }
            else
            {
                KeyboardKey23.RelativeX = -250f;
            }
            if (KeyboardKey23.Parent == null)
            {
                KeyboardKey23.Y = -184f;
            }
            else
            {
                KeyboardKey23.RelativeY = -184f;
            }
            KeyboardKey23.Text = "D";
            KeyboardKeyList.Add(KeyboardKey24);
            if (KeyboardKey24.Parent == null)
            {
                KeyboardKey24.CopyAbsoluteToRelative();
                KeyboardKey24.AttachTo(this, false);
            }
            if (KeyboardKey24.Parent == null)
            {
                KeyboardKey24.X = -150f;
            }
            else
            {
                KeyboardKey24.RelativeX = -150f;
            }
            if (KeyboardKey24.Parent == null)
            {
                KeyboardKey24.Y = -184f;
            }
            else
            {
                KeyboardKey24.RelativeY = -184f;
            }
            KeyboardKey24.Text = "F";
            KeyboardKeyList.Add(KeyboardKey25);
            if (KeyboardKey25.Parent == null)
            {
                KeyboardKey25.CopyAbsoluteToRelative();
                KeyboardKey25.AttachTo(this, false);
            }
            if (KeyboardKey25.Parent == null)
            {
                KeyboardKey25.X = -50f;
            }
            else
            {
                KeyboardKey25.RelativeX = -50f;
            }
            if (KeyboardKey25.Parent == null)
            {
                KeyboardKey25.Y = -184f;
            }
            else
            {
                KeyboardKey25.RelativeY = -184f;
            }
            KeyboardKey25.Text = "G";
            KeyboardKeyList.Add(KeyboardKey26);
            if (KeyboardKey26.Parent == null)
            {
                KeyboardKey26.CopyAbsoluteToRelative();
                KeyboardKey26.AttachTo(this, false);
            }
            if (KeyboardKey26.Parent == null)
            {
                KeyboardKey26.X = 50f;
            }
            else
            {
                KeyboardKey26.RelativeX = 50f;
            }
            if (KeyboardKey26.Parent == null)
            {
                KeyboardKey26.Y = -184f;
            }
            else
            {
                KeyboardKey26.RelativeY = -184f;
            }
            KeyboardKey26.Text = "H";
            KeyboardKeyList.Add(KeyboardKey27);
            if (KeyboardKey27.Parent == null)
            {
                KeyboardKey27.CopyAbsoluteToRelative();
                KeyboardKey27.AttachTo(this, false);
            }
            if (KeyboardKey27.Parent == null)
            {
                KeyboardKey27.X = 150f;
            }
            else
            {
                KeyboardKey27.RelativeX = 150f;
            }
            if (KeyboardKey27.Parent == null)
            {
                KeyboardKey27.Y = -184f;
            }
            else
            {
                KeyboardKey27.RelativeY = -184f;
            }
            KeyboardKey27.Text = "J";
            KeyboardKeyList.Add(KeyboardKey28);
            if (KeyboardKey28.Parent == null)
            {
                KeyboardKey28.CopyAbsoluteToRelative();
                KeyboardKey28.AttachTo(this, false);
            }
            if (KeyboardKey28.Parent == null)
            {
                KeyboardKey28.X = 250f;
            }
            else
            {
                KeyboardKey28.RelativeX = 250f;
            }
            if (KeyboardKey28.Parent == null)
            {
                KeyboardKey28.Y = -184f;
            }
            else
            {
                KeyboardKey28.RelativeY = -184f;
            }
            KeyboardKey28.Text = "K";
            KeyboardKeyList.Add(KeyboardKey29);
            if (KeyboardKey29.Parent == null)
            {
                KeyboardKey29.CopyAbsoluteToRelative();
                KeyboardKey29.AttachTo(this, false);
            }
            if (KeyboardKey29.Parent == null)
            {
                KeyboardKey29.X = 350f;
            }
            else
            {
                KeyboardKey29.RelativeX = 350f;
            }
            if (KeyboardKey29.Parent == null)
            {
                KeyboardKey29.Y = -184f;
            }
            else
            {
                KeyboardKey29.RelativeY = -184f;
            }
            KeyboardKey29.Text = "L";
            KeyboardKeyList.Add(KeyboardKey37);
            if (KeyboardKey37.Parent == null)
            {
                KeyboardKey37.CopyAbsoluteToRelative();
                KeyboardKey37.AttachTo(this, false);
            }
            if (KeyboardKey37.Parent == null)
            {
                KeyboardKey37.X = 450f;
            }
            else
            {
                KeyboardKey37.RelativeX = 450f;
            }
            if (KeyboardKey37.Parent == null)
            {
                KeyboardKey37.Y = -184f;
            }
            else
            {
                KeyboardKey37.RelativeY = -184f;
            }
            KeyboardKey37.Text = "SP";
            KeyboardKeyList.Add(KeyboardKey30);
            if (KeyboardKey30.Parent == null)
            {
                KeyboardKey30.CopyAbsoluteToRelative();
                KeyboardKey30.AttachTo(this, false);
            }
            if (KeyboardKey30.Parent == null)
            {
                KeyboardKey30.X = -450f;
            }
            else
            {
                KeyboardKey30.RelativeX = -450f;
            }
            if (KeyboardKey30.Parent == null)
            {
                KeyboardKey30.Y = -256f;
            }
            else
            {
                KeyboardKey30.RelativeY = -256f;
            }
            KeyboardKey30.Text = "Z";
            KeyboardKeyList.Add(KeyboardKey31);
            if (KeyboardKey31.Parent == null)
            {
                KeyboardKey31.CopyAbsoluteToRelative();
                KeyboardKey31.AttachTo(this, false);
            }
            if (KeyboardKey31.Parent == null)
            {
                KeyboardKey31.X = -350f;
            }
            else
            {
                KeyboardKey31.RelativeX = -350f;
            }
            if (KeyboardKey31.Parent == null)
            {
                KeyboardKey31.Y = -256f;
            }
            else
            {
                KeyboardKey31.RelativeY = -256f;
            }
            KeyboardKey31.Text = "X";
            KeyboardKeyList.Add(KeyboardKey32);
            if (KeyboardKey32.Parent == null)
            {
                KeyboardKey32.CopyAbsoluteToRelative();
                KeyboardKey32.AttachTo(this, false);
            }
            if (KeyboardKey32.Parent == null)
            {
                KeyboardKey32.X = -250f;
            }
            else
            {
                KeyboardKey32.RelativeX = -250f;
            }
            if (KeyboardKey32.Parent == null)
            {
                KeyboardKey32.Y = -256f;
            }
            else
            {
                KeyboardKey32.RelativeY = -256f;
            }
            KeyboardKey32.Text = "C";
            KeyboardKeyList.Add(KeyboardKey33);
            if (KeyboardKey33.Parent == null)
            {
                KeyboardKey33.CopyAbsoluteToRelative();
                KeyboardKey33.AttachTo(this, false);
            }
            if (KeyboardKey33.Parent == null)
            {
                KeyboardKey33.X = -150f;
            }
            else
            {
                KeyboardKey33.RelativeX = -150f;
            }
            if (KeyboardKey33.Parent == null)
            {
                KeyboardKey33.Y = -256f;
            }
            else
            {
                KeyboardKey33.RelativeY = -256f;
            }
            KeyboardKey33.Text = "V";
            KeyboardKeyList.Add(KeyboardKey34);
            if (KeyboardKey34.Parent == null)
            {
                KeyboardKey34.CopyAbsoluteToRelative();
                KeyboardKey34.AttachTo(this, false);
            }
            if (KeyboardKey34.Parent == null)
            {
                KeyboardKey34.X = -50f;
            }
            else
            {
                KeyboardKey34.RelativeX = -50f;
            }
            if (KeyboardKey34.Parent == null)
            {
                KeyboardKey34.Y = -256f;
            }
            else
            {
                KeyboardKey34.RelativeY = -256f;
            }
            KeyboardKey34.Text = "B";
            KeyboardKeyList.Add(KeyboardKey35);
            if (KeyboardKey35.Parent == null)
            {
                KeyboardKey35.CopyAbsoluteToRelative();
                KeyboardKey35.AttachTo(this, false);
            }
            if (KeyboardKey35.Parent == null)
            {
                KeyboardKey35.X = 50f;
            }
            else
            {
                KeyboardKey35.RelativeX = 50f;
            }
            if (KeyboardKey35.Parent == null)
            {
                KeyboardKey35.Y = -256f;
            }
            else
            {
                KeyboardKey35.RelativeY = -256f;
            }
            KeyboardKey35.Text = "N";
            KeyboardKeyList.Add(KeyboardKey36);
            if (KeyboardKey36.Parent == null)
            {
                KeyboardKey36.CopyAbsoluteToRelative();
                KeyboardKey36.AttachTo(this, false);
            }
            if (KeyboardKey36.Parent == null)
            {
                KeyboardKey36.X = 150f;
            }
            else
            {
                KeyboardKey36.RelativeX = 150f;
            }
            if (KeyboardKey36.Parent == null)
            {
                KeyboardKey36.Y = -256f;
            }
            else
            {
                KeyboardKey36.RelativeY = -256f;
            }
            KeyboardKey36.Text = "M";
            if (mDeleteKeyInstance.Parent == null)
            {
                mDeleteKeyInstance.CopyAbsoluteToRelative();
                mDeleteKeyInstance.AttachTo(this, false);
            }
            if (DeleteKeyInstance.Parent == null)
            {
                DeleteKeyInstance.X = 300f;
            }
            else
            {
                DeleteKeyInstance.RelativeX = 300f;
            }
            if (DeleteKeyInstance.Parent == null)
            {
                DeleteKeyInstance.Y = -256f;
            }
            else
            {
                DeleteKeyInstance.RelativeY = -256f;
            }
            if (DeleteKeyInstance.Parent == null)
            {
                DeleteKeyInstance.Z = 2f;
            }
            else
            {
                DeleteKeyInstance.RelativeZ = 2f;
            }
            if (mGoButtonInstance.Parent == null)
            {
                mGoButtonInstance.CopyAbsoluteToRelative();
                mGoButtonInstance.AttachTo(this, false);
            }
            if (GoButtonInstance.Parent == null)
            {
                GoButtonInstance.X = 446f;
            }
            else
            {
                GoButtonInstance.RelativeX = 446f;
            }
            if (GoButtonInstance.Parent == null)
            {
                GoButtonInstance.Y = -256f;
            }
            else
            {
                GoButtonInstance.RelativeY = -256f;
            }
            if (GoButtonInstance.Parent == null)
            {
                GoButtonInstance.Z = 2f;
            }
            else
            {
                GoButtonInstance.RelativeZ = 2f;
            }
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
            for (int i = KeyboardKeyList.Count - 1; i > -1; i--)
            {
                KeyboardKeyList[i].Destroy();
            }
            DeleteKeyInstance.RemoveFromManagers();
            GoButtonInstance.RemoveFromManagers();
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                KeyboardKey1.AssignCustomVariables(true);
                KeyboardKey2.AssignCustomVariables(true);
                KeyboardKey3.AssignCustomVariables(true);
                KeyboardKey4.AssignCustomVariables(true);
                KeyboardKey5.AssignCustomVariables(true);
                KeyboardKey6.AssignCustomVariables(true);
                KeyboardKey7.AssignCustomVariables(true);
                KeyboardKey8.AssignCustomVariables(true);
                KeyboardKey9.AssignCustomVariables(true);
                KeyboardKey10.AssignCustomVariables(true);
                KeyboardKey11.AssignCustomVariables(true);
                KeyboardKey12.AssignCustomVariables(true);
                KeyboardKey13.AssignCustomVariables(true);
                KeyboardKey14.AssignCustomVariables(true);
                KeyboardKey15.AssignCustomVariables(true);
                KeyboardKey16.AssignCustomVariables(true);
                KeyboardKey17.AssignCustomVariables(true);
                KeyboardKey18.AssignCustomVariables(true);
                KeyboardKey19.AssignCustomVariables(true);
                KeyboardKey20.AssignCustomVariables(true);
                KeyboardKey21.AssignCustomVariables(true);
                KeyboardKey22.AssignCustomVariables(true);
                KeyboardKey23.AssignCustomVariables(true);
                KeyboardKey24.AssignCustomVariables(true);
                KeyboardKey25.AssignCustomVariables(true);
                KeyboardKey26.AssignCustomVariables(true);
                KeyboardKey27.AssignCustomVariables(true);
                KeyboardKey28.AssignCustomVariables(true);
                KeyboardKey29.AssignCustomVariables(true);
                KeyboardKey37.AssignCustomVariables(true);
                KeyboardKey30.AssignCustomVariables(true);
                KeyboardKey31.AssignCustomVariables(true);
                KeyboardKey32.AssignCustomVariables(true);
                KeyboardKey33.AssignCustomVariables(true);
                KeyboardKey34.AssignCustomVariables(true);
                KeyboardKey35.AssignCustomVariables(true);
                KeyboardKey36.AssignCustomVariables(true);
                DeleteKeyInstance.AssignCustomVariables(true);
                GoButtonInstance.AssignCustomVariables(true);
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
                Background.Y = -150f;
            }
            else
            {
                Background.RelativeY = -150f;
            }
            Background.Texture = KBDBack;
            Background.TextureScale = 1f;
            Background.Width = 1000f;
            if (KeyboardKey1.Parent == null)
            {
                KeyboardKey1.X = -450f;
            }
            else
            {
                KeyboardKey1.RelativeX = -450f;
            }
            if (KeyboardKey1.Parent == null)
            {
                KeyboardKey1.Y = -40f;
            }
            else
            {
                KeyboardKey1.RelativeY = -40f;
            }
            KeyboardKey1.Text = "1";
            if (KeyboardKey2.Parent == null)
            {
                KeyboardKey2.X = -350f;
            }
            else
            {
                KeyboardKey2.RelativeX = -350f;
            }
            if (KeyboardKey2.Parent == null)
            {
                KeyboardKey2.Y = -40f;
            }
            else
            {
                KeyboardKey2.RelativeY = -40f;
            }
            KeyboardKey2.Text = "2";
            if (KeyboardKey3.Parent == null)
            {
                KeyboardKey3.X = -250f;
            }
            else
            {
                KeyboardKey3.RelativeX = -250f;
            }
            if (KeyboardKey3.Parent == null)
            {
                KeyboardKey3.Y = -40f;
            }
            else
            {
                KeyboardKey3.RelativeY = -40f;
            }
            KeyboardKey3.Text = "3";
            if (KeyboardKey4.Parent == null)
            {
                KeyboardKey4.X = -150f;
            }
            else
            {
                KeyboardKey4.RelativeX = -150f;
            }
            if (KeyboardKey4.Parent == null)
            {
                KeyboardKey4.Y = -40f;
            }
            else
            {
                KeyboardKey4.RelativeY = -40f;
            }
            KeyboardKey4.Text = "4";
            if (KeyboardKey5.Parent == null)
            {
                KeyboardKey5.X = -50f;
            }
            else
            {
                KeyboardKey5.RelativeX = -50f;
            }
            if (KeyboardKey5.Parent == null)
            {
                KeyboardKey5.Y = -40f;
            }
            else
            {
                KeyboardKey5.RelativeY = -40f;
            }
            KeyboardKey5.Text = "5";
            if (KeyboardKey6.Parent == null)
            {
                KeyboardKey6.X = 50f;
            }
            else
            {
                KeyboardKey6.RelativeX = 50f;
            }
            if (KeyboardKey6.Parent == null)
            {
                KeyboardKey6.Y = -40f;
            }
            else
            {
                KeyboardKey6.RelativeY = -40f;
            }
            KeyboardKey6.Text = "6";
            if (KeyboardKey7.Parent == null)
            {
                KeyboardKey7.X = 150f;
            }
            else
            {
                KeyboardKey7.RelativeX = 150f;
            }
            if (KeyboardKey7.Parent == null)
            {
                KeyboardKey7.Y = -40f;
            }
            else
            {
                KeyboardKey7.RelativeY = -40f;
            }
            KeyboardKey7.Text = "7";
            if (KeyboardKey8.Parent == null)
            {
                KeyboardKey8.X = 250f;
            }
            else
            {
                KeyboardKey8.RelativeX = 250f;
            }
            if (KeyboardKey8.Parent == null)
            {
                KeyboardKey8.Y = -40f;
            }
            else
            {
                KeyboardKey8.RelativeY = -40f;
            }
            KeyboardKey8.Text = "8";
            if (KeyboardKey9.Parent == null)
            {
                KeyboardKey9.X = 350f;
            }
            else
            {
                KeyboardKey9.RelativeX = 350f;
            }
            if (KeyboardKey9.Parent == null)
            {
                KeyboardKey9.Y = -40f;
            }
            else
            {
                KeyboardKey9.RelativeY = -40f;
            }
            KeyboardKey9.Text = "9";
            if (KeyboardKey10.Parent == null)
            {
                KeyboardKey10.X = 450f;
            }
            else
            {
                KeyboardKey10.RelativeX = 450f;
            }
            if (KeyboardKey10.Parent == null)
            {
                KeyboardKey10.Y = -40f;
            }
            else
            {
                KeyboardKey10.RelativeY = -40f;
            }
            KeyboardKey10.Text = "0";
            if (KeyboardKey11.Parent == null)
            {
                KeyboardKey11.X = -450f;
            }
            else
            {
                KeyboardKey11.RelativeX = -450f;
            }
            if (KeyboardKey11.Parent == null)
            {
                KeyboardKey11.Y = -112f;
            }
            else
            {
                KeyboardKey11.RelativeY = -112f;
            }
            KeyboardKey11.Text = "Q";
            if (KeyboardKey12.Parent == null)
            {
                KeyboardKey12.X = -350f;
            }
            else
            {
                KeyboardKey12.RelativeX = -350f;
            }
            if (KeyboardKey12.Parent == null)
            {
                KeyboardKey12.Y = -112f;
            }
            else
            {
                KeyboardKey12.RelativeY = -112f;
            }
            KeyboardKey12.Text = "W";
            if (KeyboardKey13.Parent == null)
            {
                KeyboardKey13.X = -250f;
            }
            else
            {
                KeyboardKey13.RelativeX = -250f;
            }
            if (KeyboardKey13.Parent == null)
            {
                KeyboardKey13.Y = -112f;
            }
            else
            {
                KeyboardKey13.RelativeY = -112f;
            }
            KeyboardKey13.Text = "E";
            if (KeyboardKey14.Parent == null)
            {
                KeyboardKey14.X = -150f;
            }
            else
            {
                KeyboardKey14.RelativeX = -150f;
            }
            if (KeyboardKey14.Parent == null)
            {
                KeyboardKey14.Y = -112f;
            }
            else
            {
                KeyboardKey14.RelativeY = -112f;
            }
            KeyboardKey14.Text = "R";
            if (KeyboardKey15.Parent == null)
            {
                KeyboardKey15.X = -50f;
            }
            else
            {
                KeyboardKey15.RelativeX = -50f;
            }
            if (KeyboardKey15.Parent == null)
            {
                KeyboardKey15.Y = -112f;
            }
            else
            {
                KeyboardKey15.RelativeY = -112f;
            }
            KeyboardKey15.Text = "T";
            if (KeyboardKey16.Parent == null)
            {
                KeyboardKey16.X = 50f;
            }
            else
            {
                KeyboardKey16.RelativeX = 50f;
            }
            if (KeyboardKey16.Parent == null)
            {
                KeyboardKey16.Y = -112f;
            }
            else
            {
                KeyboardKey16.RelativeY = -112f;
            }
            KeyboardKey16.Text = "Y";
            if (KeyboardKey17.Parent == null)
            {
                KeyboardKey17.X = 150f;
            }
            else
            {
                KeyboardKey17.RelativeX = 150f;
            }
            if (KeyboardKey17.Parent == null)
            {
                KeyboardKey17.Y = -112f;
            }
            else
            {
                KeyboardKey17.RelativeY = -112f;
            }
            KeyboardKey17.Text = "U";
            if (KeyboardKey18.Parent == null)
            {
                KeyboardKey18.X = 250f;
            }
            else
            {
                KeyboardKey18.RelativeX = 250f;
            }
            if (KeyboardKey18.Parent == null)
            {
                KeyboardKey18.Y = -112f;
            }
            else
            {
                KeyboardKey18.RelativeY = -112f;
            }
            KeyboardKey18.Text = "I";
            if (KeyboardKey19.Parent == null)
            {
                KeyboardKey19.X = 350f;
            }
            else
            {
                KeyboardKey19.RelativeX = 350f;
            }
            if (KeyboardKey19.Parent == null)
            {
                KeyboardKey19.Y = -112f;
            }
            else
            {
                KeyboardKey19.RelativeY = -112f;
            }
            KeyboardKey19.Text = "O";
            if (KeyboardKey20.Parent == null)
            {
                KeyboardKey20.X = 450f;
            }
            else
            {
                KeyboardKey20.RelativeX = 450f;
            }
            if (KeyboardKey20.Parent == null)
            {
                KeyboardKey20.Y = -112f;
            }
            else
            {
                KeyboardKey20.RelativeY = -112f;
            }
            KeyboardKey20.Text = "P";
            if (KeyboardKey21.Parent == null)
            {
                KeyboardKey21.X = -450f;
            }
            else
            {
                KeyboardKey21.RelativeX = -450f;
            }
            if (KeyboardKey21.Parent == null)
            {
                KeyboardKey21.Y = -184f;
            }
            else
            {
                KeyboardKey21.RelativeY = -184f;
            }
            KeyboardKey21.Text = "A";
            if (KeyboardKey22.Parent == null)
            {
                KeyboardKey22.X = -350f;
            }
            else
            {
                KeyboardKey22.RelativeX = -350f;
            }
            if (KeyboardKey22.Parent == null)
            {
                KeyboardKey22.Y = -184f;
            }
            else
            {
                KeyboardKey22.RelativeY = -184f;
            }
            KeyboardKey22.Text = "S";
            if (KeyboardKey23.Parent == null)
            {
                KeyboardKey23.X = -250f;
            }
            else
            {
                KeyboardKey23.RelativeX = -250f;
            }
            if (KeyboardKey23.Parent == null)
            {
                KeyboardKey23.Y = -184f;
            }
            else
            {
                KeyboardKey23.RelativeY = -184f;
            }
            KeyboardKey23.Text = "D";
            if (KeyboardKey24.Parent == null)
            {
                KeyboardKey24.X = -150f;
            }
            else
            {
                KeyboardKey24.RelativeX = -150f;
            }
            if (KeyboardKey24.Parent == null)
            {
                KeyboardKey24.Y = -184f;
            }
            else
            {
                KeyboardKey24.RelativeY = -184f;
            }
            KeyboardKey24.Text = "F";
            if (KeyboardKey25.Parent == null)
            {
                KeyboardKey25.X = -50f;
            }
            else
            {
                KeyboardKey25.RelativeX = -50f;
            }
            if (KeyboardKey25.Parent == null)
            {
                KeyboardKey25.Y = -184f;
            }
            else
            {
                KeyboardKey25.RelativeY = -184f;
            }
            KeyboardKey25.Text = "G";
            if (KeyboardKey26.Parent == null)
            {
                KeyboardKey26.X = 50f;
            }
            else
            {
                KeyboardKey26.RelativeX = 50f;
            }
            if (KeyboardKey26.Parent == null)
            {
                KeyboardKey26.Y = -184f;
            }
            else
            {
                KeyboardKey26.RelativeY = -184f;
            }
            KeyboardKey26.Text = "H";
            if (KeyboardKey27.Parent == null)
            {
                KeyboardKey27.X = 150f;
            }
            else
            {
                KeyboardKey27.RelativeX = 150f;
            }
            if (KeyboardKey27.Parent == null)
            {
                KeyboardKey27.Y = -184f;
            }
            else
            {
                KeyboardKey27.RelativeY = -184f;
            }
            KeyboardKey27.Text = "J";
            if (KeyboardKey28.Parent == null)
            {
                KeyboardKey28.X = 250f;
            }
            else
            {
                KeyboardKey28.RelativeX = 250f;
            }
            if (KeyboardKey28.Parent == null)
            {
                KeyboardKey28.Y = -184f;
            }
            else
            {
                KeyboardKey28.RelativeY = -184f;
            }
            KeyboardKey28.Text = "K";
            if (KeyboardKey29.Parent == null)
            {
                KeyboardKey29.X = 350f;
            }
            else
            {
                KeyboardKey29.RelativeX = 350f;
            }
            if (KeyboardKey29.Parent == null)
            {
                KeyboardKey29.Y = -184f;
            }
            else
            {
                KeyboardKey29.RelativeY = -184f;
            }
            KeyboardKey29.Text = "L";
            if (KeyboardKey37.Parent == null)
            {
                KeyboardKey37.X = 450f;
            }
            else
            {
                KeyboardKey37.RelativeX = 450f;
            }
            if (KeyboardKey37.Parent == null)
            {
                KeyboardKey37.Y = -184f;
            }
            else
            {
                KeyboardKey37.RelativeY = -184f;
            }
            KeyboardKey37.Text = "SP";
            if (KeyboardKey30.Parent == null)
            {
                KeyboardKey30.X = -450f;
            }
            else
            {
                KeyboardKey30.RelativeX = -450f;
            }
            if (KeyboardKey30.Parent == null)
            {
                KeyboardKey30.Y = -256f;
            }
            else
            {
                KeyboardKey30.RelativeY = -256f;
            }
            KeyboardKey30.Text = "Z";
            if (KeyboardKey31.Parent == null)
            {
                KeyboardKey31.X = -350f;
            }
            else
            {
                KeyboardKey31.RelativeX = -350f;
            }
            if (KeyboardKey31.Parent == null)
            {
                KeyboardKey31.Y = -256f;
            }
            else
            {
                KeyboardKey31.RelativeY = -256f;
            }
            KeyboardKey31.Text = "X";
            if (KeyboardKey32.Parent == null)
            {
                KeyboardKey32.X = -250f;
            }
            else
            {
                KeyboardKey32.RelativeX = -250f;
            }
            if (KeyboardKey32.Parent == null)
            {
                KeyboardKey32.Y = -256f;
            }
            else
            {
                KeyboardKey32.RelativeY = -256f;
            }
            KeyboardKey32.Text = "C";
            if (KeyboardKey33.Parent == null)
            {
                KeyboardKey33.X = -150f;
            }
            else
            {
                KeyboardKey33.RelativeX = -150f;
            }
            if (KeyboardKey33.Parent == null)
            {
                KeyboardKey33.Y = -256f;
            }
            else
            {
                KeyboardKey33.RelativeY = -256f;
            }
            KeyboardKey33.Text = "V";
            if (KeyboardKey34.Parent == null)
            {
                KeyboardKey34.X = -50f;
            }
            else
            {
                KeyboardKey34.RelativeX = -50f;
            }
            if (KeyboardKey34.Parent == null)
            {
                KeyboardKey34.Y = -256f;
            }
            else
            {
                KeyboardKey34.RelativeY = -256f;
            }
            KeyboardKey34.Text = "B";
            if (KeyboardKey35.Parent == null)
            {
                KeyboardKey35.X = 50f;
            }
            else
            {
                KeyboardKey35.RelativeX = 50f;
            }
            if (KeyboardKey35.Parent == null)
            {
                KeyboardKey35.Y = -256f;
            }
            else
            {
                KeyboardKey35.RelativeY = -256f;
            }
            KeyboardKey35.Text = "N";
            if (KeyboardKey36.Parent == null)
            {
                KeyboardKey36.X = 150f;
            }
            else
            {
                KeyboardKey36.RelativeX = 150f;
            }
            if (KeyboardKey36.Parent == null)
            {
                KeyboardKey36.Y = -256f;
            }
            else
            {
                KeyboardKey36.RelativeY = -256f;
            }
            KeyboardKey36.Text = "M";
            if (DeleteKeyInstance.Parent == null)
            {
                DeleteKeyInstance.X = 300f;
            }
            else
            {
                DeleteKeyInstance.RelativeX = 300f;
            }
            if (DeleteKeyInstance.Parent == null)
            {
                DeleteKeyInstance.Y = -256f;
            }
            else
            {
                DeleteKeyInstance.RelativeY = -256f;
            }
            if (DeleteKeyInstance.Parent == null)
            {
                DeleteKeyInstance.Z = 2f;
            }
            else
            {
                DeleteKeyInstance.RelativeZ = 2f;
            }
            if (GoButtonInstance.Parent == null)
            {
                GoButtonInstance.X = 446f;
            }
            else
            {
                GoButtonInstance.RelativeX = 446f;
            }
            if (GoButtonInstance.Parent == null)
            {
                GoButtonInstance.Y = -256f;
            }
            else
            {
                GoButtonInstance.RelativeY = -256f;
            }
            if (GoButtonInstance.Parent == null)
            {
                GoButtonInstance.Z = 2f;
            }
            else
            {
                GoButtonInstance.RelativeZ = 2f;
            }
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(Background);
            for (int i = 0; i < KeyboardKeyList.Count; i++)
            {
                KeyboardKeyList[i].ConvertToManuallyUpdated();
            }
            DeleteKeyInstance.ConvertToManuallyUpdated();
            GoButtonInstance.ConvertToManuallyUpdated();
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("KeyboardStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/keyboard/kbdback.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                KBDBack = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/keyboard/kbdback.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/keyboard/letterbutton.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                LetterButton = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/keyboard/letterbutton.png", ContentManagerName);
            }
            TanksController.Entities.DeleteKey.LoadStaticContent(contentManagerName);
            TanksController.Entities.GoButton.LoadStaticContent(contentManagerName);
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("KeyboardStaticUnload", UnloadStaticContent);
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
                if (KBDBack != null)
                {
                    KBDBack= null;
                }
                if (LetterButton != null)
                {
                    LetterButton= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "KBDBack":
                    return KBDBack;
                case  "LetterButton":
                    return LetterButton;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "KBDBack":
                    return KBDBack;
                case  "LetterButton":
                    return LetterButton;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "KBDBack":
                    return KBDBack;
                case  "LetterButton":
                    return LetterButton;
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
            KeyboardKey1.SetToIgnorePausing();
            KeyboardKey2.SetToIgnorePausing();
            KeyboardKey3.SetToIgnorePausing();
            KeyboardKey4.SetToIgnorePausing();
            KeyboardKey5.SetToIgnorePausing();
            KeyboardKey6.SetToIgnorePausing();
            KeyboardKey7.SetToIgnorePausing();
            KeyboardKey8.SetToIgnorePausing();
            KeyboardKey9.SetToIgnorePausing();
            KeyboardKey10.SetToIgnorePausing();
            KeyboardKey11.SetToIgnorePausing();
            KeyboardKey12.SetToIgnorePausing();
            KeyboardKey13.SetToIgnorePausing();
            KeyboardKey14.SetToIgnorePausing();
            KeyboardKey15.SetToIgnorePausing();
            KeyboardKey16.SetToIgnorePausing();
            KeyboardKey17.SetToIgnorePausing();
            KeyboardKey18.SetToIgnorePausing();
            KeyboardKey19.SetToIgnorePausing();
            KeyboardKey20.SetToIgnorePausing();
            KeyboardKey21.SetToIgnorePausing();
            KeyboardKey22.SetToIgnorePausing();
            KeyboardKey23.SetToIgnorePausing();
            KeyboardKey24.SetToIgnorePausing();
            KeyboardKey25.SetToIgnorePausing();
            KeyboardKey26.SetToIgnorePausing();
            KeyboardKey27.SetToIgnorePausing();
            KeyboardKey28.SetToIgnorePausing();
            KeyboardKey29.SetToIgnorePausing();
            KeyboardKey37.SetToIgnorePausing();
            KeyboardKey30.SetToIgnorePausing();
            KeyboardKey31.SetToIgnorePausing();
            KeyboardKey32.SetToIgnorePausing();
            KeyboardKey33.SetToIgnorePausing();
            KeyboardKey34.SetToIgnorePausing();
            KeyboardKey35.SetToIgnorePausing();
            KeyboardKey36.SetToIgnorePausing();
            DeleteKeyInstance.SetToIgnorePausing();
            GoButtonInstance.SetToIgnorePausing();
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(Background);
            }
            FlatRedBall.SpriteManager.AddToLayer(Background, layerToMoveTo);
            DeleteKeyInstance.MoveToLayer(layerToMoveTo);
            GoButtonInstance.MoveToLayer(layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
