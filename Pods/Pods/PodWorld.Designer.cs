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
            this.SuspendLayout();
            // 
            // tmrLife
            // 
            this.tmrLife.Enabled = true;
            this.tmrLife.Interval = 20;
            this.tmrLife.Tick += new System.EventHandler(this.tmrLife_Tick);
            // 
            // chkShowHubStats
            // 
            this.chkShowHubStats.AutoSize = true;
            this.chkShowHubStats.Location = new System.Drawing.Point(12, 12);
            this.chkShowHubStats.Name = "chkShowHubStats";
            this.chkShowHubStats.Size = new System.Drawing.Size(89, 24);
            this.chkShowHubStats.TabIndex = 0;
            this.chkShowHubStats.Text = "Hub info";
            this.chkShowHubStats.UseVisualStyleBackColor = true;
            // 
            // PodWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 800);
            this.Controls.Add(this.chkShowHubStats);
            this.Name = "PodWorld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PodWorld";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrLife;
        private CheckBox chkShowHubStats;
    }
}