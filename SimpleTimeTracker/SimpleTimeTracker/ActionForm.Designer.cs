namespace SimpleTimeTracker
{
    partial class ActionForm
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
            this.labelStop = new System.Windows.Forms.Label();
            this.labelContinue = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.labelInterruption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelStop
            // 
            this.labelStop.AutoSize = true;
            this.labelStop.Location = new System.Drawing.Point(12, 9);
            this.labelStop.Name = "labelStop";
            this.labelStop.Size = new System.Drawing.Size(40, 15);
            this.labelStop.TabIndex = 0;
            this.labelStop.Text = "(S)top";
            this.labelStop.Click += new System.EventHandler(this.labelStop_Click);
            // 
            // labelContinue
            // 
            this.labelContinue.AutoSize = true;
            this.labelContinue.Location = new System.Drawing.Point(12, 27);
            this.labelContinue.Name = "labelContinue";
            this.labelContinue.Size = new System.Drawing.Size(64, 15);
            this.labelContinue.TabIndex = 0;
            this.labelContinue.Text = "(C)ontinue";
            this.labelContinue.Click += new System.EventHandler(this.labelContinue_Click);
            // 
            // labelMinimize
            // 
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.Location = new System.Drawing.Point(12, 45);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(66, 15);
            this.labelMinimize.TabIndex = 0;
            this.labelMinimize.Text = "(M)inimize";
            this.labelMinimize.Click += new System.EventHandler(this.labelMinimize_Click);
            // 
            // labelInterruption
            // 
            this.labelInterruption.AutoSize = true;
            this.labelInterruption.Location = new System.Drawing.Point(12, 63);
            this.labelInterruption.Name = "labelInterruption";
            this.labelInterruption.Size = new System.Drawing.Size(77, 15);
            this.labelInterruption.TabIndex = 0;
            this.labelInterruption.Text = "(I)nterruption";
            this.labelInterruption.Click += new System.EventHandler(this.labelInterruption_Click);
            // 
            // ActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(96, 88);
            this.Controls.Add(this.labelInterruption);
            this.Controls.Add(this.labelMinimize);
            this.Controls.Add(this.labelContinue);
            this.Controls.Add(this.labelStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actions";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStop;
        private System.Windows.Forms.Label labelContinue;
        private System.Windows.Forms.Label labelMinimize;
        private System.Windows.Forms.Label labelInterruption;
    }
}