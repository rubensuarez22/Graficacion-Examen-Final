using System;

namespace PLAYGROUND
{
    partial class MyForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PNL_MAIN = new System.Windows.Forms.Panel();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LBL_ESCALADOZ = new System.Windows.Forms.Label();
            this.labelLBL_ESCALADOY = new System.Windows.Forms.Label();
            this.LBL_ESCALADOX = new System.Windows.Forms.Label();
            this.LBL_ESCALADO = new System.Windows.Forms.Label();
            this.txtScaleZ = new System.Windows.Forms.TextBox();
            this.txtScaleY = new System.Windows.Forms.TextBox();
            this.BTN_Scale = new System.Windows.Forms.Button();
            this.txtScaleX = new System.Windows.Forms.TextBox();
            this.BTN_MOVERABAJO = new System.Windows.Forms.Button();
            this.BTN_MOVERARRIBA = new System.Windows.Forms.Button();
            this.BTN_MOVERIZQUIERDA = new System.Windows.Forms.Button();
            this.BTN_MOVEDERECHA = new System.Windows.Forms.Button();
            this.CHECKBOX_RotacionZ = new System.Windows.Forms.CheckBox();
            this.CHECKBOX_RotacionY = new System.Windows.Forms.CheckBox();
            this.CHECKBOX_RotacionX = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxModels = new System.Windows.Forms.ListBox();
            this.BTN_SELECT = new System.Windows.Forms.Button();
            this.BTN_2 = new System.Windows.Forms.Button();
            this.BTN_Rotate = new System.Windows.Forms.Button();
            this.PNL_BOTTOM = new System.Windows.Forms.Panel();
            this.LBL_KEYFRAMECOUNT = new System.Windows.Forms.Label();
            this.TRACKBAR_KEYFRAME = new System.Windows.Forms.TrackBar();
            this.BTN_PLAY = new System.Windows.Forms.Button();
            this.BTN_KEYFRAME = new System.Windows.Forms.Button();
            this.LBL_STATUS = new System.Windows.Forms.Label();
            this.PNL_HEADER = new System.Windows.Forms.Panel();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.BTN_ClearKeyFrames = new System.Windows.Forms.Button();
            this.PNL_MAIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PNL_BOTTOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRACKBAR_KEYFRAME)).BeginInit();
            this.SuspendLayout();
            // 
            // PNL_MAIN
            // 
            this.PNL_MAIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PNL_MAIN.Controls.Add(this.PCT_CANVAS);
            this.PNL_MAIN.Controls.Add(this.panel2);
            this.PNL_MAIN.Controls.Add(this.panel1);
            this.PNL_MAIN.Controls.Add(this.PNL_BOTTOM);
            this.PNL_MAIN.Controls.Add(this.LBL_STATUS);
            this.PNL_MAIN.Controls.Add(this.PNL_HEADER);
            this.PNL_MAIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_MAIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PNL_MAIN.ForeColor = System.Drawing.Color.Silver;
            this.PNL_MAIN.Location = new System.Drawing.Point(0, 0);
            this.PNL_MAIN.Name = "PNL_MAIN";
            this.PNL_MAIN.Size = new System.Drawing.Size(1283, 682);
            this.PNL_MAIN.TabIndex = 0;
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCT_CANVAS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.PCT_CANVAS.Location = new System.Drawing.Point(206, 106);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(871, 447);
            this.PCT_CANVAS.TabIndex = 6;
            this.PCT_CANVAS.TabStop = false;
            this.PCT_CANVAS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCT_CANVAS_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel2.Controls.Add(this.LBL_ESCALADOZ);
            this.panel2.Controls.Add(this.labelLBL_ESCALADOY);
            this.panel2.Controls.Add(this.LBL_ESCALADOX);
            this.panel2.Controls.Add(this.LBL_ESCALADO);
            this.panel2.Controls.Add(this.txtScaleZ);
            this.panel2.Controls.Add(this.txtScaleY);
            this.panel2.Controls.Add(this.BTN_Scale);
            this.panel2.Controls.Add(this.txtScaleX);
            this.panel2.Controls.Add(this.BTN_MOVERABAJO);
            this.panel2.Controls.Add(this.BTN_MOVERARRIBA);
            this.panel2.Controls.Add(this.BTN_MOVERIZQUIERDA);
            this.panel2.Controls.Add(this.BTN_MOVEDERECHA);
            this.panel2.Controls.Add(this.CHECKBOX_RotacionZ);
            this.panel2.Controls.Add(this.CHECKBOX_RotacionY);
            this.panel2.Controls.Add(this.CHECKBOX_RotacionX);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1083, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 459);
            this.panel2.TabIndex = 5;
            // 
            // LBL_ESCALADOZ
            // 
            this.LBL_ESCALADOZ.AutoSize = true;
            this.LBL_ESCALADOZ.Location = new System.Drawing.Point(19, 298);
            this.LBL_ESCALADOZ.Name = "LBL_ESCALADOZ";
            this.LBL_ESCALADOZ.Size = new System.Drawing.Size(22, 24);
            this.LBL_ESCALADOZ.TabIndex = 14;
            this.LBL_ESCALADOZ.Text = "Z";
            // 
            // labelLBL_ESCALADOY
            // 
            this.labelLBL_ESCALADOY.AutoSize = true;
            this.labelLBL_ESCALADOY.Location = new System.Drawing.Point(19, 262);
            this.labelLBL_ESCALADOY.Name = "labelLBL_ESCALADOY";
            this.labelLBL_ESCALADOY.Size = new System.Drawing.Size(22, 24);
            this.labelLBL_ESCALADOY.TabIndex = 13;
            this.labelLBL_ESCALADOY.Text = "Y";
            // 
            // LBL_ESCALADOX
            // 
            this.LBL_ESCALADOX.AutoSize = true;
            this.LBL_ESCALADOX.Location = new System.Drawing.Point(17, 230);
            this.LBL_ESCALADOX.Name = "LBL_ESCALADOX";
            this.LBL_ESCALADOX.Size = new System.Drawing.Size(24, 24);
            this.LBL_ESCALADOX.TabIndex = 12;
            this.LBL_ESCALADOX.Text = "X";
            // 
            // LBL_ESCALADO
            // 
            this.LBL_ESCALADO.AutoSize = true;
            this.LBL_ESCALADO.Location = new System.Drawing.Point(43, 200);
            this.LBL_ESCALADO.Name = "LBL_ESCALADO";
            this.LBL_ESCALADO.Size = new System.Drawing.Size(112, 24);
            this.LBL_ESCALADO.TabIndex = 11;
            this.LBL_ESCALADO.Text = "ESCALADO";
            // 
            // txtScaleZ
            // 
            this.txtScaleZ.Location = new System.Drawing.Point(47, 298);
            this.txtScaleZ.Name = "txtScaleZ";
            this.txtScaleZ.Size = new System.Drawing.Size(100, 29);
            this.txtScaleZ.TabIndex = 10;
            this.txtScaleZ.Text = "1";
            // 
            // txtScaleY
            // 
            this.txtScaleY.Location = new System.Drawing.Point(47, 262);
            this.txtScaleY.Name = "txtScaleY";
            this.txtScaleY.Size = new System.Drawing.Size(100, 29);
            this.txtScaleY.TabIndex = 9;
            this.txtScaleY.Text = "1";
            // 
            // BTN_Scale
            // 
            this.BTN_Scale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Scale.Location = new System.Drawing.Point(47, 333);
            this.BTN_Scale.Name = "BTN_Scale";
            this.BTN_Scale.Size = new System.Drawing.Size(100, 23);
            this.BTN_Scale.TabIndex = 8;
            this.BTN_Scale.Text = "ESCALAR";
            this.BTN_Scale.UseVisualStyleBackColor = true;
            this.BTN_Scale.Click += new System.EventHandler(this.BTN_Scale_Click);
            // 
            // txtScaleX
            // 
            this.txtScaleX.Location = new System.Drawing.Point(47, 227);
            this.txtScaleX.Name = "txtScaleX";
            this.txtScaleX.Size = new System.Drawing.Size(100, 29);
            this.txtScaleX.TabIndex = 7;
            this.txtScaleX.Text = "1";
            // 
            // BTN_MOVERABAJO
            // 
            this.BTN_MOVERABAJO.Location = new System.Drawing.Point(89, 153);
            this.BTN_MOVERABAJO.Name = "BTN_MOVERABAJO";
            this.BTN_MOVERABAJO.Size = new System.Drawing.Size(37, 29);
            this.BTN_MOVERABAJO.TabIndex = 6;
            this.BTN_MOVERABAJO.Text = "V";
            this.BTN_MOVERABAJO.UseVisualStyleBackColor = true;
            this.BTN_MOVERABAJO.Click += new System.EventHandler(this.BTN_MOVERABAJO_Click);
            // 
            // BTN_MOVERARRIBA
            // 
            this.BTN_MOVERARRIBA.Location = new System.Drawing.Point(89, 108);
            this.BTN_MOVERARRIBA.Name = "BTN_MOVERARRIBA";
            this.BTN_MOVERARRIBA.Size = new System.Drawing.Size(34, 29);
            this.BTN_MOVERARRIBA.TabIndex = 5;
            this.BTN_MOVERARRIBA.Text = "^";
            this.BTN_MOVERARRIBA.UseVisualStyleBackColor = true;
            this.BTN_MOVERARRIBA.Click += new System.EventHandler(this.BTN_MOVERARRIBA_Click);
            // 
            // BTN_MOVERIZQUIERDA
            // 
            this.BTN_MOVERIZQUIERDA.Location = new System.Drawing.Point(59, 153);
            this.BTN_MOVERIZQUIERDA.Name = "BTN_MOVERIZQUIERDA";
            this.BTN_MOVERIZQUIERDA.Size = new System.Drawing.Size(27, 29);
            this.BTN_MOVERIZQUIERDA.TabIndex = 4;
            this.BTN_MOVERIZQUIERDA.Text = "<";
            this.BTN_MOVERIZQUIERDA.UseVisualStyleBackColor = true;
            this.BTN_MOVERIZQUIERDA.Click += new System.EventHandler(this.BTN_MOVERIZQUIERDA_Click);
            // 
            // BTN_MOVEDERECHA
            // 
            this.BTN_MOVEDERECHA.Location = new System.Drawing.Point(132, 153);
            this.BTN_MOVEDERECHA.Name = "BTN_MOVEDERECHA";
            this.BTN_MOVEDERECHA.Size = new System.Drawing.Size(30, 29);
            this.BTN_MOVEDERECHA.TabIndex = 3;
            this.BTN_MOVEDERECHA.Text = ">";
            this.BTN_MOVEDERECHA.UseVisualStyleBackColor = true;
            this.BTN_MOVEDERECHA.Click += new System.EventHandler(this.BTN_MOVERDERECHA_Click);
            // 
            // CHECKBOX_RotacionZ
            // 
            this.CHECKBOX_RotacionZ.AutoSize = true;
            this.CHECKBOX_RotacionZ.Location = new System.Drawing.Point(13, 68);
            this.CHECKBOX_RotacionZ.Name = "CHECKBOX_RotacionZ";
            this.CHECKBOX_RotacionZ.Size = new System.Drawing.Size(147, 28);
            this.CHECKBOX_RotacionZ.TabIndex = 2;
            this.CHECKBOX_RotacionZ.Text = "Rotacion en Z";
            this.CHECKBOX_RotacionZ.UseVisualStyleBackColor = true;
            // 
            // CHECKBOX_RotacionY
            // 
            this.CHECKBOX_RotacionY.AutoSize = true;
            this.CHECKBOX_RotacionY.Location = new System.Drawing.Point(13, 40);
            this.CHECKBOX_RotacionY.Name = "CHECKBOX_RotacionY";
            this.CHECKBOX_RotacionY.Size = new System.Drawing.Size(147, 28);
            this.CHECKBOX_RotacionY.TabIndex = 1;
            this.CHECKBOX_RotacionY.Text = "Rotacion en Y";
            this.CHECKBOX_RotacionY.UseVisualStyleBackColor = true;
            // 
            // CHECKBOX_RotacionX
            // 
            this.CHECKBOX_RotacionX.AutoSize = true;
            this.CHECKBOX_RotacionX.Location = new System.Drawing.Point(13, 6);
            this.CHECKBOX_RotacionX.Name = "CHECKBOX_RotacionX";
            this.CHECKBOX_RotacionX.Size = new System.Drawing.Size(149, 28);
            this.CHECKBOX_RotacionX.TabIndex = 0;
            this.CHECKBOX_RotacionX.Text = "Rotacion en X";
            this.CHECKBOX_RotacionX.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.BTN_ClearKeyFrames);
            this.panel1.Controls.Add(this.listBoxModels);
            this.panel1.Controls.Add(this.BTN_SELECT);
            this.panel1.Controls.Add(this.BTN_2);
            this.panel1.Controls.Add(this.BTN_Rotate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 459);
            this.panel1.TabIndex = 4;
            // 
            // listBoxModels
            // 
            this.listBoxModels.FormattingEnabled = true;
            this.listBoxModels.ItemHeight = 24;
            this.listBoxModels.Location = new System.Drawing.Point(23, 230);
            this.listBoxModels.Name = "listBoxModels";
            this.listBoxModels.Size = new System.Drawing.Size(120, 76);
            this.listBoxModels.TabIndex = 4;
            this.listBoxModels.SelectedIndexChanged += new System.EventHandler(this.listBoxModels_SelectedIndexChanged);
            // 
            // BTN_SELECT
            // 
            this.BTN_SELECT.Location = new System.Drawing.Point(23, 58);
            this.BTN_SELECT.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_SELECT.Name = "BTN_SELECT";
            this.BTN_SELECT.Size = new System.Drawing.Size(128, 38);
            this.BTN_SELECT.TabIndex = 2;
            this.BTN_SELECT.Text = "SELECT";
            this.BTN_SELECT.UseVisualStyleBackColor = true;
            this.BTN_SELECT.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTN_2
            // 
            this.BTN_2.Location = new System.Drawing.Point(23, 153);
            this.BTN_2.Name = "BTN_2";
            this.BTN_2.Size = new System.Drawing.Size(128, 60);
            this.BTN_2.TabIndex = 1;
            this.BTN_2.Text = "LIGHT CHANGE";
            this.BTN_2.UseVisualStyleBackColor = true;
            this.BTN_2.Click += new System.EventHandler(this.BTN_2_Click);
            // 
            // BTN_Rotate
            // 
            this.BTN_Rotate.Location = new System.Drawing.Point(23, 108);
            this.BTN_Rotate.Name = "BTN_Rotate";
            this.BTN_Rotate.Size = new System.Drawing.Size(128, 29);
            this.BTN_Rotate.TabIndex = 0;
            this.BTN_Rotate.Text = "PLAY/STOP";
            this.BTN_Rotate.UseVisualStyleBackColor = true;
            this.BTN_Rotate.Click += new System.EventHandler(this.BTN_Rotate_Click);
            // 
            // PNL_BOTTOM
            // 
            this.PNL_BOTTOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PNL_BOTTOM.Controls.Add(this.LBL_KEYFRAMECOUNT);
            this.PNL_BOTTOM.Controls.Add(this.TRACKBAR_KEYFRAME);
            this.PNL_BOTTOM.Controls.Add(this.BTN_PLAY);
            this.PNL_BOTTOM.Controls.Add(this.BTN_KEYFRAME);
            this.PNL_BOTTOM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PNL_BOTTOM.Location = new System.Drawing.Point(0, 559);
            this.PNL_BOTTOM.Name = "PNL_BOTTOM";
            this.PNL_BOTTOM.Size = new System.Drawing.Size(1283, 100);
            this.PNL_BOTTOM.TabIndex = 3;
            // 
            // LBL_KEYFRAMECOUNT
            // 
            this.LBL_KEYFRAMECOUNT.AutoSize = true;
            this.LBL_KEYFRAMECOUNT.Location = new System.Drawing.Point(3, 14);
            this.LBL_KEYFRAMECOUNT.Name = "LBL_KEYFRAMECOUNT";
            this.LBL_KEYFRAMECOUNT.Size = new System.Drawing.Size(160, 24);
            this.LBL_KEYFRAMECOUNT.TabIndex = 41;
            this.LBL_KEYFRAMECOUNT.Text = "Key frames count:";
            // 
            // TRACKBAR_KEYFRAME
            // 
            this.TRACKBAR_KEYFRAME.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TRACKBAR_KEYFRAME.Location = new System.Drawing.Point(206, 41);
            this.TRACKBAR_KEYFRAME.Name = "TRACKBAR_KEYFRAME";
            this.TRACKBAR_KEYFRAME.Size = new System.Drawing.Size(871, 45);
            this.TRACKBAR_KEYFRAME.TabIndex = 40;
            // 
            // BTN_PLAY
            // 
            this.BTN_PLAY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_PLAY.Location = new System.Drawing.Point(1130, 29);
            this.BTN_PLAY.Name = "BTN_PLAY";
            this.BTN_PLAY.Size = new System.Drawing.Size(100, 40);
            this.BTN_PLAY.TabIndex = 1;
            this.BTN_PLAY.Text = "PLAY";
            this.BTN_PLAY.UseVisualStyleBackColor = true;
            this.BTN_PLAY.Click += new System.EventHandler(this.BTN_PLAY_Click);
            // 
            // BTN_KEYFRAME
            // 
            this.BTN_KEYFRAME.Location = new System.Drawing.Point(41, 41);
            this.BTN_KEYFRAME.Name = "BTN_KEYFRAME";
            this.BTN_KEYFRAME.Size = new System.Drawing.Size(110, 40);
            this.BTN_KEYFRAME.TabIndex = 0;
            this.BTN_KEYFRAME.Text = "KEY";
            this.BTN_KEYFRAME.UseVisualStyleBackColor = true;
            this.BTN_KEYFRAME.Click += new System.EventHandler(this.BTN_KEYFRAME_Click);
            // 
            // LBL_STATUS
            // 
            this.LBL_STATUS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LBL_STATUS.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_STATUS.Location = new System.Drawing.Point(0, 659);
            this.LBL_STATUS.Name = "LBL_STATUS";
            this.LBL_STATUS.Size = new System.Drawing.Size(1283, 23);
            this.LBL_STATUS.TabIndex = 2;
            this.LBL_STATUS.Text = "WELCOME !!!";
            // 
            // PNL_HEADER
            // 
            this.PNL_HEADER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PNL_HEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_HEADER.Location = new System.Drawing.Point(0, 0);
            this.PNL_HEADER.Name = "PNL_HEADER";
            this.PNL_HEADER.Size = new System.Drawing.Size(1283, 100);
            this.PNL_HEADER.TabIndex = 0;
            // 
            // TIMER
            // 
            this.TIMER.Interval = 10;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // BTN_ClearKeyFrames
            // 
            this.BTN_ClearKeyFrames.Location = new System.Drawing.Point(12, 390);
            this.BTN_ClearKeyFrames.Name = "BTN_ClearKeyFrames";
            this.BTN_ClearKeyFrames.Size = new System.Drawing.Size(164, 63);
            this.BTN_ClearKeyFrames.TabIndex = 5;
            this.BTN_ClearKeyFrames.Text = "Limpiar keyframes";
            this.BTN_ClearKeyFrames.UseVisualStyleBackColor = true;
            this.BTN_ClearKeyFrames.Click += new System.EventHandler(this.BTN_ClearKeyFrames_Click);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 682);
            this.Controls.Add(this.PNL_MAIN);
            this.Name = "MyForm";
            this.Text = "PLAYGROUND || VERLETS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.MyForm_SizeChanged);
            this.PNL_MAIN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.PNL_BOTTOM.ResumeLayout(false);
            this.PNL_BOTTOM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRACKBAR_KEYFRAME)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_MAIN;
        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PNL_BOTTOM;
        private System.Windows.Forms.Label LBL_STATUS;
        private System.Windows.Forms.Panel PNL_HEADER;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Button BTN_Rotate;
        private System.Windows.Forms.Button BTN_2;
        private System.Windows.Forms.Button BTN_SELECT;
        private System.Windows.Forms.Button BTN_PLAY;
        private System.Windows.Forms.Button BTN_KEYFRAME;
        private System.Windows.Forms.TrackBar TRACKBAR_KEYFRAME;
        private System.Windows.Forms.CheckBox CHECKBOX_RotacionZ;
        private System.Windows.Forms.CheckBox CHECKBOX_RotacionY;
        private System.Windows.Forms.CheckBox CHECKBOX_RotacionX;
        private System.Windows.Forms.Button BTN_MOVEDERECHA;
        private System.Windows.Forms.Button BTN_MOVERIZQUIERDA;
        private System.Windows.Forms.Button BTN_MOVERARRIBA;
        private System.Windows.Forms.Button BTN_MOVERABAJO;
        private System.Windows.Forms.Button BTN_Scale;
        private System.Windows.Forms.TextBox txtScaleX;
        private System.Windows.Forms.TextBox txtScaleZ;
        private System.Windows.Forms.TextBox txtScaleY;
        private System.Windows.Forms.Label LBL_ESCALADOZ;
        private System.Windows.Forms.Label labelLBL_ESCALADOY;
        private System.Windows.Forms.Label LBL_ESCALADOX;
        private System.Windows.Forms.Label LBL_ESCALADO;
        private System.Windows.Forms.ListBox listBoxModels;
        private System.Windows.Forms.Label LBL_KEYFRAMECOUNT;
        private System.Windows.Forms.Button BTN_ClearKeyFrames;
    }
}

