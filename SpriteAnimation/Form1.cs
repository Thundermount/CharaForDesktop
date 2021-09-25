using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SpriteAnimation
{
    public partial class Form1 : Form
    {

        Dictionary<string,SpriteCanvas.SpriteAnimation> animations;
        Image red_eyesImage;
        Image wide_eyesImage;

        Timer randomAction;

        public Form1()
        {
            InitializeComponent();

            TopMost = true;

            assembly = Assembly.GetExecutingAssembly();
            Image[] images = { LoadImage("Sprites.Walk_d.0.png") };
            var idleAnimation = new SpriteCanvas.SpriteAnimation("idle",images);

            images = new Image[] { LoadImage("Sprites.Walk_d.0.png"), LoadImage("Sprites.Walk_d.1.png"), LoadImage("Sprites.Walk_d.2.png"), LoadImage("Sprites.Walk_d.3.png") };
            var walk_dAnimation = new SpriteCanvas.SpriteAnimation("walk_d", images);

            images = new Image[] { LoadImage("Sprites.Walk_d.0.png"), LoadImage("Sprites.Walk_up.1.png"), LoadImage("Sprites.Walk_up.2.png"), LoadImage("Sprites.Walk_up.3.png") };
            var walk_uAnimation = new SpriteCanvas.SpriteAnimation("walk_u", images);

            images = new Image[] { LoadImage("Sprites.Walk_r.0.png"), LoadImage("Sprites.Walk_r.1.png")};
            var walk_rAnimation = new SpriteCanvas.SpriteAnimation("walk_r", images);

            images = new Image[] { LoadImage("Sprites.Walk_l.0.png"), LoadImage("Sprites.Walk_l.1.png") };
            var walk_lAnimation = new SpriteCanvas.SpriteAnimation("walk_l", images);

            images = new Image[] { LoadImage("Sprites.Laugh.0.png"), LoadImage("Sprites.Laugh.1.png"), LoadImage("Sprites.Laugh.2.png") };
            var laughAnimation = new SpriteCanvas.SpriteAnimation("laugh", images);

            red_eyesImage = LoadImage("Sprites.red_eyes.png");
            wide_eyesImage = LoadImage("Sprites.wide_eyes.png");

            animations = new Dictionary<string, SpriteCanvas.SpriteAnimation>();
            animations.Add(idleAnimation.Name,idleAnimation);
            animations.Add(walk_dAnimation.Name, walk_dAnimation);
            animations.Add(walk_lAnimation.Name, walk_lAnimation);
            animations.Add(walk_rAnimation.Name, walk_rAnimation);
            animations.Add(walk_uAnimation.Name, walk_uAnimation);
            animations.Add(laughAnimation.Name, laughAnimation);

            spriteCanvas1.SpriteSwitchInterval = 200;

            //spriteCanvas1.AnimationStart(walk_dAnimation);
            spriteCanvas1.DrawImage(animations["walk_d"][0]);


            mouseChecker = new Timer();
            mouseChecker.Interval = 100;
            mouseChecker.Tick += CharaMotion;

            randomAction = new Timer();
            randomAction.Interval = 4000;
            randomAction.Tick += RandomAction;
            randomAction.Start();
            
        }

        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        public static extern int timeEndPeriod(int msec);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_Shown(object sender, EventArgs e)
        {
            TransparencyKey = BackColor;
        }

        Assembly assembly;
        /// <summary>
        /// Path seperated by .
        /// </summary>
        private Image LoadImage(string path)
        {
            return Image.FromStream(assembly.GetManifestResourceStream($"SpriteAnimation.{path}"));
        }

        private void spriteCanvas1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseChecker.Start();
                //moving = true;

                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                //moving = false;
                mouseChecker.Stop();
                spriteCanvas1.DrawImage(animations["walk_d"][0]);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            spriteCanvas1.Dispose();
        }

        private void RandomAction(object sender, EventArgs e)
        {
            if (mouseChecker.Enabled) return;

            spriteCanvas1.DrawImage(animations["walk_d"][0]);

            Random rnd = new Random();
            var result = rnd.Next(0, 11);

            if (result == 5)
            {
                result = rnd.Next(3);

                switch (result)
                {
                    case 0:
                        spriteCanvas1.DrawImage(red_eyesImage);
                        break;
                    case 1:
                        spriteCanvas1.DrawImage(wide_eyesImage);
                        break;
                    case 2:
                        spriteCanvas1.AnimationStart(animations["laugh"]);
                        break;
                }
            }
        }

        Timer mouseChecker;
        Point old_pos;
        private void CharaMotion(object sender, EventArgs e)
        {
            if (old_pos == null) old_pos = MousePosition;

            var new_pos = MousePosition;
            if (new_pos != old_pos)
            {
                var xx = new_pos.X - old_pos.X;
                var yy = new_pos.Y - old_pos.Y;

                if (Math.Abs(xx) > Math.Abs(yy))
                {
                    if (xx > 0)
                    {
                        if (spriteCanvas1.animation.Name != "walk_r")
                            spriteCanvas1.AnimationStart(animations["walk_r"]);
                    }
                    else
                    {
                        if (spriteCanvas1.animation.Name != "walk_l")
                            spriteCanvas1.AnimationStart(animations["walk_l"]);
                    }
                }
                else
                {
                    if (yy < 0)
                    {
                        if (spriteCanvas1.animation.Name != "walk_u")
                            spriteCanvas1.AnimationStart(animations["walk_u"]);
                    }
                    else
                    {
                        if (spriteCanvas1.animation.Name != "walk_d")
                            spriteCanvas1.AnimationStart(animations["walk_d"]);
                    }
                }
                old_pos = new_pos;
            }
            else
            {
                spriteCanvas1.DrawImage(animations["walk_d"][0]);
            }
        }

    }
}
