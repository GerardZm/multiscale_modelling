using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiscaleModelling
{
    public partial class mainForm : Form
    {
        Cell[,] space;
        List<byte[]> colorArray;
        int numberOfPoints = 0;
        List<byte[]> stepsAsBytes = new List<byte[]>();
        int xSize;
        int ySize;
        int nucleonAmmount;
        bool forceBreak = false;

        public mainForm()
        {
            InitializeComponent();
        }

        private async void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.OpenFile()); // open file given by user
                string[] lines = (await sr.ReadToEndAsync()).Split('\n');
                sr.Close(); // be polite with file handling
                if (lines[lines.Count()-1].Length == 0)
                    lines = lines.Take(lines.Count() - 1).ToArray(); // cut out last row if empty
                int row = 0;
                foreach (string line in lines)
                {
                    if (line == lines[0])
                    {
                        // if first line, fill all controls with data about with, height and nucleons count
                        string[] values = line.Split(',');
                        if (values.Length == 3)
                        {
                            // assign values to controls
                            ySizeTextbox.Value = xSize = Int32.Parse(values[0]);
                            xSizeTextbox.Value = ySize = Int32.Parse(values[1]);
                            nucleonAmmountTextbox.Value = nucleonAmmount = Int32.Parse(values[2]);
                            space = new Cell[xSize, ySize]; // also create space
                        }
                        else
                            break; // something is wrong with file, break reading it
                    }
                    else
                    {
                        int column = 0;
                        foreach (string value in line.Split(','))
                        {
                            space[row, column].row = row;
                            space[row, column].column = column;
                            space[row, column].grainId = Int32.Parse(value);
                            column += 1;
                        }
                        row += 1;
                    }
                }
                // re-initiate all necessary variables
                stepShowPanel.Visible = false;
                stepsAsBytes = new List<byte[]>();
                numberOfPoints = 0;
                createColorPalette();
                // once finished, create only single, last step image and show it
                stepsAsBytes.Add(crateByteArray());
                showImage(0);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.Filter = "CSV (*.csv)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "CA-export-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveToFile(saveFileDialog1.FileName);
            }
        }

        private async void simulateButton_Click(object sender, EventArgs e)
        {
            // first safety check - x, y and nuclei ammount has to be specified
            if (ySizeTextbox.Value > 0 && xSizeTextbox.Value > 0 && nucleonAmmountTextbox.Value > 0)
            {
                progressBar.Visible = true;
                simulateButton.Enabled = false;
                breakButton.Enabled = true;
                xSizeTextbox.Enabled = false;
                ySizeTextbox.Enabled = false;
                nucleonAmmountTextbox.Enabled = false;
                await Task.Run(() => {
                    xSize = (int)ySizeTextbox.Value;
                    ySize = (int)xSizeTextbox.Value;
                    nucleonAmmount = (int)nucleonAmmountTextbox.Value;
                    // prepare required variables
                    stepsAsBytes = new List<byte[]>();
                    space = null;
                    numberOfPoints = 0;
                    // create space and colors
                    createSpace();
                    createColorPalette();
                    // save intial state
                    stepsAsBytes.Add(crateByteArray());
                    // then propagate until all cells are assigned to grains
                    while (hasUnassignedElement() && !forceBreak)
                    {
                        propagate();
                        // once finished, add to array of steps
                        Thread.Sleep(10);
                        stepsAsBytes.Add(crateByteArray());
                        this.Invoke(new Action(() => {
                            showImage(stepsAsBytes.Count - 1);
                        }));
                    }
                    // now inclusions
                    if ((int)precipitatesTextbox.Value > 0)
                    {
                        addInclusios();
                    }
                    forceBreak = false;
                });
                breakButton.Enabled = false;
                showImage(stepsAsBytes.Count - 1); // show last image
                if (stepsAsBytes.Count > 1)
                {
                    stepShowPanel.Visible = true;
                }
                exportToolStripMenuItem.Enabled = true;
                progressBar.Visible = false;
                simulateButton.Enabled = true;
                xSizeTextbox.Enabled = true;
                ySizeTextbox.Enabled = true;
                nucleonAmmountTextbox.Enabled = true;
            }
        }

        private void createSpace()
        {
            List<int[]> randomPointsCoords = new List<int[]>();
            while (numberOfPoints < nucleonAmmountTextbox.Value)
            { 
                // first create array of cells
                space = new Cell[(int)ySizeTextbox.Value, (int)xSizeTextbox.Value];
                // initialize each of them
                for (int i = 0; i < ySizeTextbox.Value; i++)
                {
                    for (int j = 0; j < xSizeTextbox.Value; j++)
                    {
                        space[i, j].grainId = 0;
                        space[i, j].row = i;
                        space[i, j].column = j;
                    }
                }
                // and create nucleons in random places of created space
                Random rng = new Random();
                for (int i = 1; i <= nucleonAmmountTextbox.Value; i++)
                {
                    // assign initial value to random cells
                    int xLocation = rng.Next(0, (int)ySizeTextbox.Value);
                    int yLocation = rng.Next(0, (int)xSizeTextbox.Value);
                    int[] pair = new int[] { xLocation, yLocation };
                    while (randomPointsCoords.IndexOf(pair) >= 0) // generate new location within space to make sure it is unique
                    {
                        xLocation = rng.Next(0, (int)ySizeTextbox.Value);
                        yLocation = rng.Next(0, (int)xSizeTextbox.Value);
                        pair = new int[] { xLocation, yLocation };
                    }
                    randomPointsCoords.Add(pair); // add acquired location to already used coords
                    space[xLocation, yLocation].grainId = i; // assign new grain value to acquired unique location
                    numberOfPoints += 1;
                }
            }
        }

        private void createColorPalette()
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
        }

        private void addNewColorToPalette()
        {

        }

        private void showImage(int step)
        {
            // show image of given step number in image box
            this.pictureBox1.Image = ByteToImage(stepsAsBytes[step]);
            // adapt step navigation panel
            this.currentStepLabel.Text = step.ToString();
            this.stepCountLabel.Text = (stepsAsBytes.Count-1).ToString();
            this.nextStepButton.Enabled = true;
            this.lastStepButton.Enabled = true;
            this.previousStepButton.Enabled = true;
            this.firstStepButton.Enabled = true;
            if (step == 1)
            {
                this.previousStepButton.Enabled = false;
                this.firstStepButton.Enabled = false;
            }
            else if (step == stepsAsBytes.Count - 1)
            {
                this.nextStepButton.Enabled = false;
                this.lastStepButton.Enabled = false;
            }
        }

        private byte[] crateByteArray()
        {
            // create BGRA palette image from current state of space
            // each cell of space is described by 4 values representing color value of RGBA palette (with different color sequence, thus BGRA)
            byte[] res = new byte[(int)ySizeTextbox.Value * (int)xSizeTextbox.Value * 4];
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
        
        private Bitmap ByteToImage(byte[] byteArray)
        {
            // create bitmap image from byte array (BGRA palette-adapted array)
            int width = (int)ySizeTextbox.Value;
            int height = (int)xSizeTextbox.Value;
            // src: https://stackoverflow.com/questions/32203347/create-a-png-from-an-array-of-bytes
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(byteArray, 0, bitmapData.Scan0, byteArray.Length);
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
        
        private async void propagate()
        {
            // iterate through whole array and propagate nucleon growth
            Cell[,] previousStepArray = Utils.Copy(space); // first create independent copy of Cell array struct
            foreach (Cell c in space)
            {
                if (c.grainId == 0) // value change will occur only in currently independent cells
                {
                    // create counters for each color
                    //List<int> countersOfGrainsSurroundingCell = new List<int>();
                    Dictionary<int, int> countersOfGrainsSurroundingCell = new Dictionary<int, int>();
                    /*for (int i = 0; i <= nucleonAmmountTextbox.Value; i++)
                    {
                        countersOfGrainsSurroundingCell.Add(0); // counter initiated with 0
                    }*/
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
                        new int[] { c.row - 1, c.column - 1 },
                        new int[] { c.row - 1, c.column },
                        new int[] { c.row - 1, c.column + 1 },
                        new int[] { c.row, c.column - 1 },
                        new int[] { c.row, c.column + 1 },
                        new int[] { c.row + 1, c.column - 1 },
                        new int[] { c.row + 1, c.column },
                        new int[] { c.row + 1, c.column + 1 },
                    };

                    // check each of coords
                    for (int i = 0; i < valuesToCheck.Count; i++)
                    {
                        if (valuesToCheck[i][0] >= 0 && valuesToCheck[i][0] < xSize && valuesToCheck[i][1] >= 0 && valuesToCheck[i][1] < ySize)
                        {
                            int gainValue = Utils.getGrainIdFromCoords(valuesToCheck[i][0], valuesToCheck[i][1], ref previousStepArray);
                            if (gainValue != 0)
                            {
                                //countersOfGrainsSurroundingCell[gainValue] += 1;
                                if (countersOfGrainsSurroundingCell.ContainsKey(gainValue))
                                    countersOfGrainsSurroundingCell[gainValue] += 1;
                                else
                                    countersOfGrainsSurroundingCell.Add(gainValue, 1);
                            }
                        }
                    }
                    // check which grainIds are in neighbourhood
                    //int highestValue = -1;
                    //int mostPopularGrainId = -1;
                    if (countersOfGrainsSurroundingCell.Count > 0)
                    {
                        space[c.row, c.column].grainId = countersOfGrainsSurroundingCell.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                    }
                    /*for (int i = 0; i < countersOfGrainsSurroundingCell.Count; i++)
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
                                mostPopularGrainId = Utils.randomlyDecideGrainId(mostPopularGrainId, i);
                                highestValue = countersOfGrainsSurroundingCell[mostPopularGrainId];
                            }
                        }                        
                    }*/
                    // change to most popular surrounding if any surrounding found
                    //if (mostPopularGrainId > -1)
                    //    space[c.row, c.column].grainId = mostPopularGrainId;
                }
            }
        }

        private void addInclusios()
        {
            for(int i = 0; i < precipitatesTextbox.Value; i++)
            {
                Cell newInclusionCell;
                if (randomPositionRadio.Checked == true)
                {

                }
                else if (gbPositionRadio.Checked == true)
                {

                }
            }

            // once finished, add to array of steps
            stepsAsBytes.Add(crateByteArray());
            this.Invoke(new Action(() => {
                showImage(stepsAsBytes.Count - 1);
            }));
        }

        private bool isGrainBoundary(Cell localCell)
        {
            // check if more than 1 grain color is in range of 1
            if (neighboursInRange(1, localCell).Count > 1)
                return true;
            return false;
        }

        private List<Cell> neighboursInRange(int range, Cell checkedCell)
        {
            // first initiate function variables
            List<Cell> neighbourList = new List<Cell>();
            int checkedLocationRow = checkedCell.row;
            int checkedLocationColumn = checkedCell.column;

            // now search space for neighbour colors
            // look only in cells +- range from cell
            for (int _col=range-3; _col <= range+3; _col++)
            {
                for (int _row = range - 3; _row <= range + 3; _row++)
                {
                    if (space[_row, _col].grainId > 0 && ((_row - checkedLocationRow) ^ 2 + (_col - checkedLocationColumn) ^ 2) < (range^2))
                        neighbourList.Add(space[_row, _col]);
                }
            }
            return neighbourList;
        }

        private void saveToFile(string _filename = null)
        {
            string delimeter = ",";
            string endOfLine = "\n";
            // save content of space to file
            string fileContent = xSize.ToString() + delimeter + ySize.ToString() + delimeter + nucleonAmmount + endOfLine; // first line is width, height and number of nucleons
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    fileContent += space[i, j].grainId.ToString();
                    if (j < (int)ySize - 1)
                        fileContent += delimeter;
                }
                fileContent += endOfLine;
            }
            string filename;
            if (_filename != null)
                filename = _filename;
            else
                filename = "CA-export-"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            File.WriteAllText(filename + ".csv", fileContent);
        }

        private void firstStepButton_Click(object sender, EventArgs e)
        {
            showImage(1);
        }

        private void previousStepButton_Click(object sender, EventArgs e)
        {
            showImage(Int32.Parse(currentStepLabel.Text) - 1);
        }

        private void nextStepButton_Click(object sender, EventArgs e)
        {
            showImage(Int32.Parse(currentStepLabel.Text) + 1);
        }

        private void lastStepButton_Click(object sender, EventArgs e)
        {
            showImage(stepsAsBytes.Count - 1);
        }

        private void breakButton_Click(object sender, EventArgs e)
        {
            forceBreak = true;
        }

        private void precipiratesRadiusFromTextbox_ValueChanged(object sender, EventArgs e)
        {
            if (precipiratesRadiusToTextbox.Value < precipiratesRadiusFromTextbox.Value)
                precipiratesRadiusToTextbox.Value = precipiratesRadiusFromTextbox.Value;
        }

        private void precipitatesTextbox_ValueChanged(object sender, EventArgs e)
        {
            if ((int)precipitatesTextbox.Value > 0)
                precipitatesPanel.Visible = true;
            else
                precipitatesPanel.Visible = false;
        }
    }
}
