namespace _3D_renderer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlDisplay = new Panel();
            TrkXPos = new TrackBar();
            lblXPosition = new RichTextBox();
            lblXPos = new RichTextBox();
            lblYPos = new RichTextBox();
            TrkAlpha = new TrackBar();
            TrkBeta = new TrackBar();
            TrkYPos = new TrackBar();
            TrkGamma = new TrackBar();
            lblGammaRot = new RichTextBox();
            lblAlphaRot = new RichTextBox();
            lblBetaRot = new RichTextBox();
            lblRotation = new RichTextBox();
            txtGammaRot = new RichTextBox();
            txtBetaRot = new RichTextBox();
            txtAlphaRot = new RichTextBox();
            txtYPos = new RichTextBox();
            txtXPos = new RichTextBox();
            btnSpawnCube = new Button();
            button1 = new Button();
            txtObjectType = new RichTextBox();
            txtObjectColour = new RichTextBox();
            txtObjectSize = new RichTextBox();
            txtZPos = new RichTextBox();
            lblZPos = new RichTextBox();
            TrkZPos = new TrackBar();
            btnLoadObject = new Button();
            ((System.ComponentModel.ISupportInitialize)TrkXPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrkAlpha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrkBeta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrkYPos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrkGamma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrkZPos).BeginInit();
            SuspendLayout();
            // 
            // pnlDisplay
            // 
            pnlDisplay.BackColor = Color.Black;
            pnlDisplay.Location = new Point(24, 12);
            pnlDisplay.Name = "pnlDisplay";
            pnlDisplay.Size = new Size(1280, 720);
            pnlDisplay.TabIndex = 0;
            pnlDisplay.Paint += pnlDisplay_Paint;
            pnlDisplay.MouseClick += pnlDisplay_MouseClick;
            // 
            // TrkXPos
            // 
            TrkXPos.Location = new Point(1458, 301);
            TrkXPos.Maximum = 2000;
            TrkXPos.Name = "TrkXPos";
            TrkXPos.Size = new Size(104, 45);
            TrkXPos.TabIndex = 3;
            TrkXPos.TickFrequency = 90;
            TrkXPos.Visible = false;
            // 
            // lblXPosition
            // 
            lblXPosition.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblXPosition.Location = new Point(1342, 254);
            lblXPosition.Name = "lblXPosition";
            lblXPosition.ReadOnly = true;
            lblXPosition.Size = new Size(86, 24);
            lblXPosition.TabIndex = 5;
            lblXPosition.Text = "Position";
            lblXPosition.Visible = false;
            // 
            // lblXPos
            // 
            lblXPos.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblXPos.Location = new Point(1342, 301);
            lblXPos.Name = "lblXPos";
            lblXPos.ReadOnly = true;
            lblXPos.Size = new Size(86, 24);
            lblXPos.TabIndex = 6;
            lblXPos.Text = "X:";
            lblXPos.Visible = false;
            // 
            // lblYPos
            // 
            lblYPos.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblYPos.Location = new Point(1342, 352);
            lblYPos.Name = "lblYPos";
            lblYPos.ReadOnly = true;
            lblYPos.Size = new Size(86, 24);
            lblYPos.TabIndex = 7;
            lblYPos.Text = "Y:";
            lblYPos.Visible = false;
            // 
            // TrkAlpha
            // 
            TrkAlpha.Location = new Point(1458, 489);
            TrkAlpha.Maximum = 360;
            TrkAlpha.Name = "TrkAlpha";
            TrkAlpha.Size = new Size(104, 45);
            TrkAlpha.TabIndex = 0;
            TrkAlpha.TickFrequency = 90;
            TrkAlpha.Visible = false;
            // 
            // TrkBeta
            // 
            TrkBeta.Location = new Point(1458, 540);
            TrkBeta.Maximum = 360;
            TrkBeta.Name = "TrkBeta";
            TrkBeta.Size = new Size(104, 45);
            TrkBeta.TabIndex = 1;
            TrkBeta.TickFrequency = 90;
            TrkBeta.Visible = false;
            // 
            // TrkYPos
            // 
            TrkYPos.Location = new Point(1458, 352);
            TrkYPos.Maximum = 2000;
            TrkYPos.Name = "TrkYPos";
            TrkYPos.Size = new Size(104, 45);
            TrkYPos.TabIndex = 4;
            TrkYPos.Visible = false;
            // 
            // TrkGamma
            // 
            TrkGamma.Location = new Point(1458, 591);
            TrkGamma.Maximum = 360;
            TrkGamma.Name = "TrkGamma";
            TrkGamma.Size = new Size(104, 45);
            TrkGamma.TabIndex = 2;
            TrkGamma.TickFrequency = 90;
            TrkGamma.Visible = false;
            // 
            // lblGammaRot
            // 
            lblGammaRot.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblGammaRot.Location = new Point(1342, 591);
            lblGammaRot.Name = "lblGammaRot";
            lblGammaRot.ReadOnly = true;
            lblGammaRot.Size = new Size(86, 24);
            lblGammaRot.TabIndex = 11;
            lblGammaRot.Text = "Gamma:";
            lblGammaRot.Visible = false;
            // 
            // lblAlphaRot
            // 
            lblAlphaRot.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAlphaRot.Location = new Point(1342, 489);
            lblAlphaRot.Name = "lblAlphaRot";
            lblAlphaRot.ReadOnly = true;
            lblAlphaRot.Size = new Size(86, 24);
            lblAlphaRot.TabIndex = 9;
            lblAlphaRot.Text = "Alpha:";
            lblAlphaRot.Visible = false;
            // 
            // lblBetaRot
            // 
            lblBetaRot.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblBetaRot.Location = new Point(1342, 540);
            lblBetaRot.Name = "lblBetaRot";
            lblBetaRot.ReadOnly = true;
            lblBetaRot.Size = new Size(86, 24);
            lblBetaRot.TabIndex = 10;
            lblBetaRot.Text = "Beta:";
            lblBetaRot.Visible = false;
            // 
            // lblRotation
            // 
            lblRotation.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblRotation.Location = new Point(1342, 442);
            lblRotation.Name = "lblRotation";
            lblRotation.ReadOnly = true;
            lblRotation.Size = new Size(86, 24);
            lblRotation.TabIndex = 8;
            lblRotation.Text = "Rotation";
            lblRotation.Visible = false;
            // 
            // txtGammaRot
            // 
            txtGammaRot.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtGammaRot.Location = new Point(1568, 591);
            txtGammaRot.Name = "txtGammaRot";
            txtGammaRot.Size = new Size(86, 24);
            txtGammaRot.TabIndex = 16;
            txtGammaRot.Text = "";
            txtGammaRot.Visible = false;
            txtGammaRot.TextChanged += txtGammaRot_TextChanged;
            // 
            // txtBetaRot
            // 
            txtBetaRot.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBetaRot.Location = new Point(1568, 540);
            txtBetaRot.Name = "txtBetaRot";
            txtBetaRot.Size = new Size(86, 24);
            txtBetaRot.TabIndex = 15;
            txtBetaRot.Text = "";
            txtBetaRot.Visible = false;
            txtBetaRot.TextChanged += txtBetaRot_TextChanged;
            // 
            // txtAlphaRot
            // 
            txtAlphaRot.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAlphaRot.Location = new Point(1568, 489);
            txtAlphaRot.Name = "txtAlphaRot";
            txtAlphaRot.Size = new Size(86, 24);
            txtAlphaRot.TabIndex = 14;
            txtAlphaRot.Text = "";
            txtAlphaRot.Visible = false;
            txtAlphaRot.TextChanged += txtAlphaRot_TextChanged;
            // 
            // txtYPos
            // 
            txtYPos.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtYPos.Location = new Point(1568, 352);
            txtYPos.Name = "txtYPos";
            txtYPos.Size = new Size(86, 24);
            txtYPos.TabIndex = 13;
            txtYPos.Text = "";
            txtYPos.Visible = false;
            txtYPos.TextChanged += txtYPos_TextChanged;
            // 
            // txtXPos
            // 
            txtXPos.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtXPos.Location = new Point(1568, 301);
            txtXPos.Name = "txtXPos";
            txtXPos.Size = new Size(86, 24);
            txtXPos.TabIndex = 12;
            txtXPos.Text = "";
            txtXPos.Visible = false;
            txtXPos.TextChanged += txtXPos_TextChanged;
            // 
            // btnSpawnCube
            // 
            btnSpawnCube.Location = new Point(1342, 645);
            btnSpawnCube.Name = "btnSpawnCube";
            btnSpawnCube.Size = new Size(75, 42);
            btnSpawnCube.TabIndex = 17;
            btnSpawnCube.Text = "Spawn Cube";
            btnSpawnCube.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(1342, 693);
            button1.Name = "button1";
            button1.Size = new Size(75, 42);
            button1.TabIndex = 18;
            button1.Text = "Spawn Sphere";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtObjectType
            // 
            txtObjectType.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtObjectType.Location = new Point(1342, 80);
            txtObjectType.Name = "txtObjectType";
            txtObjectType.ReadOnly = true;
            txtObjectType.Size = new Size(118, 39);
            txtObjectType.TabIndex = 19;
            txtObjectType.Text = "";
            txtObjectType.Visible = false;
            // 
            // txtObjectColour
            // 
            txtObjectColour.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtObjectColour.Location = new Point(1342, 159);
            txtObjectColour.Name = "txtObjectColour";
            txtObjectColour.Size = new Size(86, 24);
            txtObjectColour.TabIndex = 20;
            txtObjectColour.Text = "";
            txtObjectColour.TextChanged += txtObjectColour_TextChanged;
            // 
            // txtObjectSize
            // 
            txtObjectSize.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtObjectSize.Location = new Point(1342, 198);
            txtObjectSize.Name = "txtObjectSize";
            txtObjectSize.Size = new Size(86, 24);
            txtObjectSize.TabIndex = 21;
            txtObjectSize.Text = "";
            txtObjectSize.TextChanged += txtObjectSize_TextChanged;
            // 
            // txtZPos
            // 
            txtZPos.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtZPos.Location = new Point(1568, 403);
            txtZPos.Name = "txtZPos";
            txtZPos.Size = new Size(86, 24);
            txtZPos.TabIndex = 24;
            txtZPos.Text = "";
            txtZPos.Visible = false;
            // 
            // lblZPos
            // 
            lblZPos.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblZPos.Location = new Point(1342, 403);
            lblZPos.Name = "lblZPos";
            lblZPos.ReadOnly = true;
            lblZPos.Size = new Size(86, 24);
            lblZPos.TabIndex = 23;
            lblZPos.Text = "Z:";
            lblZPos.Visible = false;
            // 
            // TrkZPos
            // 
            TrkZPos.Location = new Point(1458, 403);
            TrkZPos.Maximum = 2000;
            TrkZPos.Minimum = -1000;
            TrkZPos.Name = "TrkZPos";
            TrkZPos.Size = new Size(104, 45);
            TrkZPos.TabIndex = 22;
            TrkZPos.Visible = false;
            // 
            // btnLoadObject
            // 
            btnLoadObject.Location = new Point(1439, 645);
            btnLoadObject.Name = "btnLoadObject";
            btnLoadObject.Size = new Size(75, 42);
            btnLoadObject.TabIndex = 25;
            btnLoadObject.Text = "Load Object";
            btnLoadObject.UseVisualStyleBackColor = true;
            btnLoadObject.Click += btnLoadObject_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1810, 823);
            Controls.Add(btnLoadObject);
            Controls.Add(txtZPos);
            Controls.Add(lblZPos);
            Controls.Add(TrkZPos);
            Controls.Add(txtObjectSize);
            Controls.Add(txtObjectColour);
            Controls.Add(txtObjectType);
            Controls.Add(button1);
            Controls.Add(btnSpawnCube);
            Controls.Add(txtGammaRot);
            Controls.Add(txtBetaRot);
            Controls.Add(txtAlphaRot);
            Controls.Add(txtYPos);
            Controls.Add(txtXPos);
            Controls.Add(lblGammaRot);
            Controls.Add(lblBetaRot);
            Controls.Add(lblAlphaRot);
            Controls.Add(lblRotation);
            Controls.Add(lblYPos);
            Controls.Add(lblXPos);
            Controls.Add(TrkGamma);
            Controls.Add(TrkYPos);
            Controls.Add(TrkBeta);
            Controls.Add(pnlDisplay);
            Controls.Add(TrkAlpha);
            Controls.Add(TrkXPos);
            Controls.Add(lblXPosition);
            Name = "Form1";
            Text = "3DRenderer";
            ((System.ComponentModel.ISupportInitialize)TrkXPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrkAlpha).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrkBeta).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrkYPos).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrkGamma).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrkZPos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlDisplay;
        private TrackBar TrkXPos;
        private RichTextBox lblXPosition;
        private RichTextBox lblXPos;
        private RichTextBox lblYPos;
        private TrackBar TrkAlpha;
        private TrackBar TrkBeta;
        private TrackBar TrkYPos;
        private TrackBar TrkGamma;
        private RichTextBox lblGammaRot;
        private RichTextBox lblAlphaRot;
        private RichTextBox lblBetaRot;
        private RichTextBox lblRotation;
        private RichTextBox txtGammaRot;
        private RichTextBox txtBetaRot;
        private RichTextBox txtAlphaRot;
        private RichTextBox txtYPos;
        private RichTextBox txtXPos;
        private Button btnSpawnCube;
        private Button button1;
        private RichTextBox txtObjectType;
        private RichTextBox txtObjectColour;
        private RichTextBox txtObjectSize;
        private RichTextBox txtZPos;
        private RichTextBox lblZPos;
        private TrackBar TrkZPos;
        private Button btnLoadObject;
    }
}