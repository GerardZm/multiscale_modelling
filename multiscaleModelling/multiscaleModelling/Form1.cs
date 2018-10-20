using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiscaleModelling
{
    public partial class Form1 : Form
    {
        Cell[,] space;

        public Form1()
        {
            InitializeComponent();
            space = null;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            createSpace();
        }

        private void createSpace()
        {
            // first safety check - x, y and nuclei ammount has to be specified
            if (xSizeTextbox.Value > 0 && ySizeTextbox.Value > 0 && nucleonAmmountTextbox.Value > 0)
            {
                // then create array of cells
                space = new Cell[(int)xSizeTextbox.Value, (int)ySizeTextbox.Value];
                for (int i = 1; i <= nucleonAmmountTextbox.Value; i++)
                {
                    // assign initial value to random cells
                    Random rng = new Random();
                    int xLocation = rng.Next(0, (int)xSizeTextbox.Value);
                    int yLocation = rng.Next(0, (int)ySizeTextbox.Value);
                    space[xLocation, yLocation].grainId = i; // TODO: fix null exception here
                }
                // after all is done, gerenate bitmap
                byte[,] imageToBytes = crateByteArray();
                Bitmap bmp = new Bitmap((int)xSizeTextbox.Value, (int)ySizeTextbox.Value, (int)xSizeTextbox.Value, PixelFormat.Format8bppIndexed, Marshal.UnsafeAddrOfPinnedArrayElement(imageToBytes, 0));
                bmp.Save("test.bmp");
            }
        }

        private byte[,] crateByteArray()
        {
            byte[,] res = new byte[(int)xSizeTextbox.Value, (int)ySizeTextbox.Value];
            for (int j = 0; j < ySizeTextbox.Value; j++)
            {
                for (int i = 0; i < xSizeTextbox.Value; i++)
                {
                    if (space[i, j].grainId == 0)
                    {
                        res[i, j] = 0x20;
                    }
                    else
                    {
                        res[i, j] = 0x40;
                    }
                }
            }
            return res;
        }
    }
}
