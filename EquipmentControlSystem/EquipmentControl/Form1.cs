namespace EquipmentControl
{



    public partial class Form1 : Form
    {

        private readonly EquipmentIO io;
        private readonly ConveyorSequence sequence;
        public Form1()
        {
            InitializeComponent();

            io = new EquipmentIO();
            sequence = new ConveyorSequence(io);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            sequenceTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sequenceTimer.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            sequence.Reset();
        }

        private void sequenceTimer_Tick(object sender, EventArgs e)
        {
            // Virtual INPUT ¡æ EquipmentIO
            io.ProductLoad = chkProductLoad.Checked;
            io.ProductArrival = chkProductArrival.Checked;
            
            // °¡»ó Motor Feedback
            if (io.ConveyorRun && !chkMotorFeedbackFail.Checked)
            {
                io.MotorRunning = true;
            }
            else
            {
                io.MotorRunning = false;
            }

            sequence.Run();

            // EquipmentIO ¡æ UI
            lblConveyorRun.Text = io.ConveyorRun ? "Y01 : ON" : "Y01 : OFF";

            lblCurrentStep.Text =
            $"Current Step : {sequence.CurrentStep}";
        }
    }
}
