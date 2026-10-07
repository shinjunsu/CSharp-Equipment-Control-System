namespace EquipmentControl
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
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnStop = new Button();
            btnReset = new Button();
            sequenceTimer = new System.Windows.Forms.Timer(components);
            chkProductLoad = new CheckBox();
            chkProductArrival = new CheckBox();
            chkMotorRunning = new CheckBox();
            lblConveyorRun = new Label();
            Input = new GroupBox();
            Ouput = new GroupBox();
            lblCurrentStep = new Label();
            chkMotorFeedbackFail = new CheckBox();
            Input.SuspendLayout();
            Ouput.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(84, 61);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(117, 100);
            btnStart.TabIndex = 0;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(351, 61);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(117, 100);
            btnStop.TabIndex = 3;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(597, 61);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(117, 100);
            btnReset.TabIndex = 4;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // sequenceTimer
            // 
            sequenceTimer.Tick += sequenceTimer_Tick;
            // 
            // chkProductLoad
            // 
            chkProductLoad.AutoSize = true;
            chkProductLoad.Location = new Point(6, 32);
            chkProductLoad.Name = "chkProductLoad";
            chkProductLoad.Size = new Size(123, 19);
            chkProductLoad.TabIndex = 5;
            chkProductLoad.Text = "X01 Product Load";
            chkProductLoad.UseVisualStyleBackColor = true;
            // 
            // chkProductArrival
            // 
            chkProductArrival.AutoSize = true;
            chkProductArrival.Location = new Point(6, 57);
            chkProductArrival.Name = "chkProductArrival";
            chkProductArrival.Size = new Size(131, 19);
            chkProductArrival.TabIndex = 6;
            chkProductArrival.Text = "X02 Product Arrival";
            chkProductArrival.UseVisualStyleBackColor = true;
            // 
            // chkMotorRunning
            // 
            chkMotorRunning.AutoSize = true;
            chkMotorRunning.Location = new Point(6, 82);
            chkMotorRunning.Name = "chkMotorRunning";
            chkMotorRunning.Size = new Size(133, 19);
            chkMotorRunning.TabIndex = 7;
            chkMotorRunning.Text = "X03 Motor Running";
            chkMotorRunning.UseVisualStyleBackColor = true;
            // 
            // lblConveyorRun
            // 
            lblConveyorRun.AutoSize = true;
            lblConveyorRun.Location = new Point(38, 32);
            lblConveyorRun.Name = "lblConveyorRun";
            lblConveyorRun.Size = new Size(60, 15);
            lblConveyorRun.TabIndex = 8;
            lblConveyorRun.Text = "Y01 : OFF";
            // 
            // Input
            // 
            Input.Controls.Add(chkMotorRunning);
            Input.Controls.Add(chkProductArrival);
            Input.Controls.Add(chkProductLoad);
            Input.Location = new Point(169, 222);
            Input.Name = "Input";
            Input.Size = new Size(136, 104);
            Input.TabIndex = 11;
            Input.TabStop = false;
            Input.Text = "Input";
            // 
            // Ouput
            // 
            Ouput.Controls.Add(lblConveyorRun);
            Ouput.Location = new Point(322, 222);
            Ouput.Name = "Ouput";
            Ouput.Size = new Size(137, 104);
            Ouput.TabIndex = 10;
            Ouput.TabStop = false;
            Ouput.Text = "Ouput";
            // 
            // lblCurrentStep
            // 
            lblCurrentStep.AutoSize = true;
            lblCurrentStep.Location = new Point(476, 222);
            lblCurrentStep.Name = "lblCurrentStep";
            lblCurrentStep.Size = new Size(110, 15);
            lblCurrentStep.TabIndex = 12;
            lblCurrentStep.Text = "Current Step : Wait";
            // 
            // chkMotorFeedbackFail
            // 
            chkMotorFeedbackFail.AutoSize = true;
            chkMotorFeedbackFail.Location = new Point(476, 250);
            chkMotorFeedbackFail.Name = "chkMotorFeedbackFail";
            chkMotorFeedbackFail.Size = new Size(205, 19);
            chkMotorFeedbackFail.TabIndex = 13;
            chkMotorFeedbackFail.Text = "Motor Feedback Fault Simulation";
            chkMotorFeedbackFail.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkMotorFeedbackFail);
            Controls.Add(lblCurrentStep);
            Controls.Add(Ouput);
            Controls.Add(Input);
            Controls.Add(btnReset);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            Input.ResumeLayout(false);
            Input.PerformLayout();
            Ouput.ResumeLayout(false);
            Ouput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private System.Windows.Forms.Timer sequenceTimer;
        private CheckBox chkProductLoad;
        private CheckBox chkProductArrival;
        private CheckBox chkMotorRunning;
        private Label lblConveyorRun;
        private GroupBox Input;
        private GroupBox Ouput;
        private Label lblCurrentStep;
        private CheckBox chkMotorFeedbackFail;
    }
}
