using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EquipmentControl
{
    internal class ConveyorSequence
    {
        private enum Step
        {
            Wait,
            Transfer,
            Unload,
            Error
        }

        private Step currentStep = Step.Wait;
        public string CurrentStep => currentStep.ToString();

        private readonly EquipmentIO io;
        private readonly Stopwatch motorStartTimer = new Stopwatch();

        public ConveyorSequence(EquipmentIO io)
        {
            this.io = io;
        }

        public void Run()
        {
            switch (currentStep)
            {
                case Step.Wait:
                    io.ConveyorRun = false;
                    if (io.ProductLoad)
                    {
                        motorStartTimer.Restart();
                        currentStep = Step.Transfer;
                    }
                    break;

                case Step.Transfer:
                    io.ConveyorRun = true;
                    
                    if (io.MotorRunning)
                    {
                        motorStartTimer.Stop();
                    }
                    else if (motorStartTimer.ElapsedMilliseconds >= 2000)
                    {
                        currentStep = Step.Error;
                        break;
                    }
                    if (io.ProductArrival)
                    {
                        motorStartTimer.Stop();
                        currentStep = Step.Unload;
                    }                
                    break;

                case Step.Unload:
                    io.ConveyorRun = false;

                    if (!io.ProductLoad &&
                        !io.ProductArrival &&
                        !io.MotorRunning)
                    {
                        currentStep = Step.Wait;
                    }
                    break;


                case Step.Error:
                    io.ConveyorRun = false;
                    break;
            }
        }
        public void Reset()
        {
            motorStartTimer.Reset();
            io.ConveyorRun = false;
            currentStep = Step.Wait;
        }
    }


}
