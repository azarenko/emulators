using EmStudio.ECUs;
using EmStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmStudio
{
    static class EntityService
    {
        public static IMCU GetMCU(MCUType type)
        {
            switch (type)
            {
                case MCUType.PIC16F628:
                    return new pic16f628();
                case MCUType.PIC12F675:
                    return new pic12f675();
            }

            throw new Exception("Unknown MCU type");
        }
    }
}
