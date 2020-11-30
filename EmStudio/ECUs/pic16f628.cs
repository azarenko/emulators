using EmStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmStudio.ECUs
{
    class pic16f628 : IMCU
    {
        public byte[] FLASH = new byte[2048];
        public byte[] SRAM = new byte[224];
        public byte[] EEPROM = new byte[128];

        void IMCU.LoadFromFile(string filename)
        {
            switch (Path.GetExtension(filename).ToLower())
            {
                case ".hex":
                    LoadFromHEX(filename);
                    return;
            }

            throw new Exception("Unsupported file extension");
        }

        private void LoadFromHEX(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                
            }
        }
    }
}
