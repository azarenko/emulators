using EmStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmStudio
{
    public partial class MainForm : Form
    {
        private IMCU mcu;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mcu.LoadFromFile(openFileDialog1.FileName);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _MCUType.Items.AddRange(Enum.GetNames(typeof(MCUType)));

            if (_MCUType.Items.Count > 0)
            {
                _MCUType.SelectedIndex = 0;
            }
        }

        private void _MCUType_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcu = EntityService.GetMCU((MCUType)Enum.Parse(typeof(MCUType), (string)_MCUType.SelectedItem));
        }
    }
}
