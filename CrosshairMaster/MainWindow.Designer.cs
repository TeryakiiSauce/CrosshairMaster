namespace CrosshairMaster
{
    partial class MainWindow
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
            label1 = new Label();
            label2 = new Label();
            displayCrosshairCheckBox = new CheckBox();
            monitorsDropDown = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(69, 30);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Monitor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 67);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 1;
            label2.Text = "Display Crosshair:";
            // 
            // displayCrosshairCheckBox
            // 
            displayCrosshairCheckBox.AutoSize = true;
            displayCrosshairCheckBox.ForeColor = Color.White;
            displayCrosshairCheckBox.Location = new Point(141, 65);
            displayCrosshairCheckBox.Name = "displayCrosshairCheckBox";
            displayCrosshairCheckBox.Size = new Size(81, 19);
            displayCrosshairCheckBox.TabIndex = 2;
            displayCrosshairCheckBox.Text = "Turned off";
            displayCrosshairCheckBox.UseVisualStyleBackColor = true;
            displayCrosshairCheckBox.CheckedChanged += displayCrosshairCheckBox_CheckedChanged;
            // 
            // monitorsDropDown
            // 
            monitorsDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            monitorsDropDown.FormattingEnabled = true;
            monitorsDropDown.Location = new Point(141, 27);
            monitorsDropDown.Name = "monitorsDropDown";
            monitorsDropDown.Size = new Size(121, 23);
            monitorsDropDown.TabIndex = 3;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 33, 33);
            ClientSize = new Size(284, 111);
            Controls.Add(monitorsDropDown);
            Controls.Add(displayCrosshairCheckBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainWindow";
            Text = "Crosshair Master";
            Load += MainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox displayCrosshairCheckBox;
        private ComboBox monitorsDropDown;
    }
}
