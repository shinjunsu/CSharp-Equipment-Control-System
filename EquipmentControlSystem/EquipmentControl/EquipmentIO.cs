using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControl
{
    internal class EquipmentIO
    {
        // INPUT
        public bool ProductLoad { get; set; }      // X01 : 제품 투입 감지
        public bool ProductArrival { get; set; }   // X02 : 제품 도착 감지
        public bool MotorRunning { get; set; }     // X03 : 컨베이어 실제 운전 상태

        // OUTPUT
        public bool ConveyorRun { get; set; }      // Y01 : 컨베이어 운전 명령

    }
}
