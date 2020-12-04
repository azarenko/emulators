using EmStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmStudio.ECUs
{
    class pic12f675 : IMCU
    {
        public byte[] flash = new byte[1024];
        public byte[] sram = new byte[64];
        public byte[] eeprom = new byte[128];
        public int[] stack = new int[8];
        public int pc = 0;

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

                    short bytesCountInLine = short.Parse(line.Substring(1, 2), NumberStyles.AllowHexSpecifier);
                    int address = int.Parse(line.Substring(3, 4), NumberStyles.AllowHexSpecifier);
                    byte dataType = byte.Parse(line.Substring(7, 2), NumberStyles.AllowHexSpecifier);

                    byte[] data = new byte[bytesCountInLine];

                    for (int i = 0; i < bytesCountInLine; i++)
                    {
                        byte buffer = byte.Parse(line.Substring(9 + (i * 2), 2), NumberStyles.AllowHexSpecifier);
                        data[i] = buffer;
                    }

                    switch (dataType)
                    {
                        case 0x00:
                        {
                            if (0x0000 <= address && address <= 0x4000)
                            {
                                data.CopyTo(flash, address);
                            }
                        }
                            break;
                    }
                }
            }
        }
    }
}
