
namespace SpriteAnimation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.spriteCanvas1 = new SpriteCanvas.SpriteCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // spriteCanvas1
            // 
            this.spriteCanvas1.Location = new System.Drawing.Point(0, -1);
            this.spriteCanvas1.Name = "spriteCanvas1";
            this.spriteCanvas1.ResizeImage = SpriteCanvas.SpriteCanvas.ResizeType.KeepWidth;
            this.spriteCanvas1.Size = new System.Drawing.Size(120, 448);
            this.spriteCanvas1.SpriteSwitchInterval = 200;
            this.spriteCanvas1.TabIndex = 0;
            this.spriteCanvas1.Text = "spriteCanvas1";
            this.spriteCanvas1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spriteCanvas1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.spriteCanvas1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private SpriteCanvas.SpriteCanvas spriteCanvas1;
    }
}