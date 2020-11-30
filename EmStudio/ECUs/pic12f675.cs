using EmStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmStudio.ECUs
{
    class pic12f675 : IMCU
    {
        public byte[] FLASH = new byte[1024];
        public byte[] SRAM = new byte[64];
        public byte[] EEPROM = new byte[128];
        public int[] Stack = new int[8];
        public int PC = 0;

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
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().ToUpperInvariant();

                    if (string.Compare(line, ":00000001FF", StringComparison.OrdinalIgnoreCase) == 0)
                        break;


                }
            }
        }
    }
}
