namespace NetworksLab2CSharp
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
            this.startButton = new System.Windows.Forms.Button();
            this.startLabel = new System.Windows.Forms.Label();
            this.finishButton = new System.Windows.Forms.Button();
            this.scenarioListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(30, 0);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(12, 50);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(0, 13);
            this.startLabel.TabIndex = 1;
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(111, 0);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 2;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // scenarioListBox
            // 
            this.scenarioListBox.FormattingEnabled = true;
            this.scenarioListBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.scenarioListBox.Location = new System.Drawing.Point(1, 0);
            this.scenarioListBox.Name = "scenarioListBox";
            this.scenarioListBox.Size = new System.Drawing.Size(23, 43);
            this.scenarioListBox.TabIndex = 4;
            this.scenarioListBox.SelectedIndexChanged += new System.EventHandler(this.scenarioListBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 262);
            this.Controls.Add(this.scenarioListBox);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Tcp Client Lab 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.ListBox scenarioListBox;
    }
}

