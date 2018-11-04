using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiscaleModelling
{
    public partial class Form1 : Form
    {
        Cell[,] space;
        List<byte[]> colorArray;
        int numberOfPoints = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            space = null;
            numberOfPoints = 0;
                createSpace();
            generateAndShowImage();
            while (hasUnassignedElement())
            {
                propagate();
                generateAndShowImage();
            }
        }

        private void createSpace()
        {
            List<int[]> randomPointsCoords = new List<int[]>();
            while (numberOfPoints < nucleonAmmountTextbox.Value)
            { 
                // first safety check - x, y and nuclei ammount has to be specified
                if (xSizeTextbox.Value > 0 && ySizeTextbox.Value > 0 && nucleonAmmountTextbox.Value > 0)
                {
                    // then create array of cells
                    space = new Cell[(int)xSizeTextbox.Value, (int)ySizeTextbox.Value];
                    // initialize each of them
                    for (int i = 0; i < xSizeTextbox.Value; i++)
                    {
                        for (int j = 0; j < ySizeTextbox.Value; j++)
                        {
                            space[i, j].grainId = 0;
                            space[i, j].x = i;
                            space[i, j].y = j;
                        }
                    }
                    // and create nucleis in random places of created space
                    Random rng = new Random();
                    for (int i = 1; i <= nucleonAmmountTextbox.Value; i++)
                    {
                        // assign initial value to random cells
                        int xLocation = rng.Next(0, (int)xSizeTextbox.Value);
                        int yLocation = rng.Next(0, (int)ySizeTextbox.Value);
                        int[] pair = new int[] { xLocation, yLocation };
                        while (randomPointsCoords.IndexOf(pair) >= 0) // generate new pair to make sure they are unique
                        {
                            // assign initial value to random cells
                            xLocation = rng.Next(0, (int)xSizeTextbox.Value);
                            yLocation = rng.Next(0, (int)ySizeTextbox.Value);
                            pair = new int[] { xLocation, yLocation };
                        }
                        randomPointsCoords.Add(pair);
                        space[xLocation, yLocation].grainId = i;
                        numberOfPoints += 1;
                    }
                }
            }
        }

        private void generateAndShowImage()
        {
            colorArray = new List<byte[]>();
            Random rng = new Random();
            for (int i = 0; i < (int)nucleonAmmountTextbox.Value; i++)
            {
                // B G R
                byte blue = (byte)rng.Next(0, 200);
                byte green = (byte)rng.Next(0, 200);
                byte red = (byte)rng.Next(0, 200);
                byte[] singleColorArray = new byte[] { blue, green, red };
                colorArray.Add(singleColorArray);
            }
            // after all is done, gerenate bitmap
            byte[] imageToBytes = crateByteArray();
            // and show it in image box
            this.pictureBox1.Image = ByteToImage(imageToBytes);
        }

        private byte[] crateByteArray()
        {
            byte[] res = new byte[(int)xSizeTextbox.Value * (int)ySizeTextbox.Value * 4];
            int k = 0;
            foreach (Cell c in space)
            {
                // B G R A
                if (c.grainId == 0)
                {
                    res[k] = 255;
                    res[k + 1] = 255;
                    res[k + 2] = 255;
                    res[k + 3] = 255;
                }
                else
                {
                    res[k] = colorArray[c.grainId - 1][0];
                    res[k + 1] = colorArray[c.grainId - 1][1];
                    res[k + 2] = colorArray[c.grainId - 1][2];
                    res[k + 3] = 255;
                }
                k = k + 4;
            }
            return res;
        }
        
        private Bitmap ByteToImage(byte[] blob)
        {
            byte[] data = blob;
            int width = (int)xSizeTextbox.Value;
            int height = (int)ySizeTextbox.Value;
            // src: https://stackoverflow.com/questions/32203347/create-a-png-from-an-array-of-bytes
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
            bmp.UnlockBits(bitmapData);
            return bmp;
        }

        private bool hasUnassignedElement()
        {
            foreach (Cell c in space)
            {
                if (c.grainId == 0)
                    return true;
            }
            return false;
        }

        // TODO: check propagation - usually one of nucleons stays as single cell - probably taking current situation into consideration
        private void propagate()
        {
            Cell[,] previousStepArray = space;
            foreach (Cell c in space)
            {
                if (c.grainId == 0)
                {
                    // create counters for each nucleon
                    List<int> countersOfGrainsSurroundingCell = new List<int>();
                    for (int i = 0; i <= nucleonAmmountTextbox.Value; i++)
                    {
                        countersOfGrainsSurroundingCell.Add(0); // counter initiated with 0
                    }
                    /* Check neighbours:
                     *  -------
                     *  | | | |
                     *  -------
                     *  | |x| |
                     *  -------
                     *  | | | |
                     *  -------
                     */
                    // generate array with coords to be checked
                    List<int[]> valuesToCheck = new List<int[]> {
                        new int[] { c.x - 1, c.y - 1 },
                        new int[] { c.x - 1, c.y + 1 },
                        new int[] { c.x, c.y - 1 },
                        new int[] { c.x, c.y + 1 },
                        new int[] { c.x + 1, c.y - 1 },
                        new int[] { c.x + 1, c.y + 1 },
                    };

                    // check each of coords
                    foreach (var pair in valuesToCheck)
                    {
                        int gainValue = getGrainIdFromCoords(pair[0], pair[1], previousStepArray);
                        if (gainValue != 0)
                        {
                            countersOfGrainsSurroundingCell[gainValue] += 1;
                        }
                    }
                    // check which grainIds are in neighbourhood
                    int highestValue = -1;
                    int mostPopularGrainId = -1;
                    for (int i = 0; i < countersOfGrainsSurroundingCell.Count; i++)
                    {
                        if (countersOfGrainsSurroundingCell[i] > 0)
                        {
                            if (countersOfGrainsSurroundingCell[i] > highestValue)
                            {
                                highestValue = countersOfGrainsSurroundingCell[i];
                                mostPopularGrainId = i;
                            }
                            else if (countersOfGrainsSurroundingCell[i] == highestValue)
                            {
                                // if equal, decide randomly
                                mostPopularGrainId = randomlyDecideGrainId(mostPopularGrainId, i);
                                highestValue = countersOfGrainsSurroundingCell[mostPopularGrainId];
                            }
                        }                        
                    }
                    // change to most popular surrounding if any surrounding found
                    if (mostPopularGrainId > -1)
                        space[c.x, c.y].grainId = mostPopularGrainId;
                }
            }
        }

        private int getGrainIdFromCoords(int x, int y, Cell[,] array)
        {
            try
            {
                return array[x, y].grainId;
            }
            catch
            {
                return 0; // if out of bounds, just return 0
            }
        }

        private int randomlyDecideGrainId(int grainId1, int grainId2)
        {
            Random rng = new Random();
            int value = rng.Next(0, 1);
            if (value == 0)
                return grainId1;
            return grainId2;
        }
    }
}
