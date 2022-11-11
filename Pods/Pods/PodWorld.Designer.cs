namespace Pods
{
    partial class PodWorld
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
            this.components = new System.ComponentModel.Container();
            this.tmrLife = new System.Windows.Forms.Timer(this.components);
            this.chkShowHubStats = new System.Windows.Forms.CheckBox();
            this.numSpeedFactor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrLife
            // 
            this.tmrLife.Enabled = true;
            this.tmrLife.Tick += new System.EventHandler(this.tmrLife_Tick);
            // 
            // chkShowHubStats
            // 
            this.chkShowHubStats.AutoSize = true;
            this.chkShowHubStats.Location = new System.Drawing.Point(12, 41);
            this.chkShowHubStats.Name = "chkShowHubStats";
            this.chkShowHubStats.Size = new System.Drawing.Size(89, 24);
            this.chkShowHubStats.TabIndex = 0;
            this.chkShowHubStats.Text = "Hub info";
            this.chkShowHubStats.UseVisualStyleBackColor = true;
            // 
            // numSpeedFactor
            // 
            this.numSpeedFactor.Location = new System.Drawing.Point(134, 7);
            this.numSpeedFactor.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numSpeedFactor.Name = "numSpeedFactor";
            this.numSpeedFactor.Size = new System.Drawing.Size(63, 27);
            this.numSpeedFactor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "La simulation est";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "fois plus rapide que la réalité";
            // 
            // PodWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 800);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSpeedFactor);
            this.Controls.Add(this.chkShowHubStats);
            this.Name = "PodWorld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Podzerland";
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrLife;
        private CheckBox chkShowHubStats;
        private NumericUpDown numSpeedFactor;
        private Label label1;
        private Label label2;
    }
}