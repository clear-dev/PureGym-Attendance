namespace PureGym_Attendance_Tracker
{
    partial class MainForm
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
            emailTextBox = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            pinTextBox = new TextBox();
            submitButton = new Button();
            notifyLabel = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // emailTextBox
            // 
            emailTextBox.Dock = DockStyle.Fill;
            emailTextBox.Location = new Point(3, 19);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "username@website.com";
            emailTextBox.Size = new Size(194, 23);
            emailTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(emailTextBox);
            groupBox1.Location = new Point(14, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 49);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Email";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pinTextBox);
            groupBox2.Location = new Point(14, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 49);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pin";
            // 
            // pinTextBox
            // 
            pinTextBox.Dock = DockStyle.Fill;
            pinTextBox.Location = new Point(3, 19);
            pinTextBox.Name = "pinTextBox";
            pinTextBox.PlaceholderText = "12345678";
            pinTextBox.Size = new Size(194, 23);
            pinTextBox.TabIndex = 0;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(17, 125);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(194, 23);
            submitButton.TabIndex = 1;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // notifyLabel
            // 
            notifyLabel.Location = new Point(17, 151);
            notifyLabel.Name = "notifyLabel";
            notifyLabel.Size = new Size(194, 15);
            notifyLabel.TabIndex = 3;
            notifyLabel.Text = "Notify Label";
            notifyLabel.TextAlign = ContentAlignment.MiddleCenter;
            notifyLabel.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(238, 171);
            Controls.Add(notifyLabel);
            Controls.Add(submitButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Login";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox emailTextBox;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox pinTextBox;
        private Button submitButton;
        private Label notifyLabel;
    }
}
