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
        int xSize; // rows
        int ySize; // columns
        int nucleonAmmount;
        bool forceBreak = false;
        Random rng = new Random();

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
                    else if (line == lines[1])
                    {
                        // second line contains information about inclusions
                        string[] values = line.Split(',');
                        if (values.Length == 4)
                        {
                            precipitatesTextbox.Value = Int32.Parse(values[0]);
                            precipitatesRadiusFromTextbox.Value = Int32.Parse(values[1]);
                            precipitatesRadiusToTextbox.Value = Int32.Parse(values[2]);
                            if (Int32.Parse(values[3]) == 1)
                                gbPositionRadio.Checked = true;
                            else
                                randomPositionRadio.Checked = true;
                        }
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
                if ((int)precipitatesTextbox.Value > 0) // if inclusions were used, show them on the drawing as black color
                {
                    colorArray[colorArray.Count - 1] = new byte[] { 0, 0, 0, 255 };
                    // also decrease nucleon ammount by 1
                    nucleonAmmountTextbox.Value = nucleonAmmount -= 1;
                }
                // once finished, create only single, last step image and show it
                stepsAsBytes.Add(createByteArray());
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
            if (ySizeTextbox.Value > 0 && xSizeTextbox.Value > 0 && nucleonAmmountTextbox.Value > 0 && !(precipitatesRadiusToTextbox.Value < precipitatesRadiusFromTextbox.Value) && precipitatesRadiusToTextbox.Value > 0 && precipitatesRadiusFromTextbox.Value > 0)
            {
                progressBar.Visible = true;
                stepShowPanel.Visible = false;
                simulateButton.Enabled = false;
                breakButton.Enabled = true;
                xSizeTextbox.Enabled = false;
                ySizeTextbox.Enabled = false;
                nucleonAmmountTextbox.Enabled = false;
                precipitatesTextbox.Enabled = false;
                precipitatesPanel.Enabled = false;
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
                    stepsAsBytes.Add(createByteArray());
                    // now inclusions
                    if ((int)precipitatesTextbox.Value > 0)
                    {
                        addInclusios();
                    }
                    // then propagate until all cells are assigned to grains
                    while (hasUnassignedElement() && !forceBreak)
                    {
                        propagate();
                        // once finished, add to array of steps
                        Thread.Sleep(5);
                        byte[] currentStepByteArray = createByteArray();
                        if (currentStepByteArray != stepsAsBytes.Last())
                        {
                            stepsAsBytes.Add(currentStepByteArray);
                            this.Invoke(new Action(() => {
                                showImage(stepsAsBytes.Count - 1);
                            }));
                        }
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
                    stepSlider.Visible = true;
                    stepSlider.Maximum = stepsAsBytes.Count;
                    stepSlider.Value = stepsAsBytes.Count;
                }
                exportToolStripMenuItem.Enabled = true;
                progressBar.Visible = false;
                simulateButton.Enabled = true;
                xSizeTextbox.Enabled = true;
                ySizeTextbox.Enabled = true;
                nucleonAmmountTextbox.Enabled = true;
                precipitatesTextbox.Enabled = true;
                precipitatesPanel.Enabled = true;
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
                //Random rng = new Random();
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
            for (int i = 0; i < (int)nucleonAmmountTextbox.Value; i++)
            {
                byte[] newColor = createNewColor();
                // make sure that this color does not already exist in the palette
                while(Utils.colorAlreadyExistsInColorPalette(newColor, colorArray))
                    newColor = createNewColor();
                colorArray.Add(newColor);
            }
        }

        private byte[] createNewColor()
        {
            //Random rng = new Random();
            // B G R
            byte blue = (byte)rng.Next(0, 200);
            byte green = (byte)rng.Next(0, 200);
            byte red = (byte)rng.Next(0, 200);
            byte[] singleColorArray = new byte[] { blue, green, red };
            return singleColorArray;
        }

        private void showImage(int step)
        {
            // show image of given step number in image box
            this.pictureBox1.Image = ByteToImage(stepsAsBytes[step]);
            // adapt step navigation panel
            this.currentStepLabel.Text = step.ToString();
            this.stepCountLabel.Text = (stepsAsBytes.Count-1).ToString();
        }

        private byte[] createByteArray()
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

        private void propagate()
        {
            // iterate through whole array and propagate nucleon growth
            Cell[,] previousStepArray = Utils.Copy(space); // first create independent copy of Cell array struct
            foreach (Cell c in space)
            {
                if (c.grainId == 0) // value change will occur only in currently independent cells
                {
                    if (grainBoundaryShapeControlCheckbox.Checked == false)
                    {
                        Dictionary<int, int> countersOfGrainsSurroundingCell = neighboursInRange(previousStepArray, 1, c);
                        if (countersOfGrainsSurroundingCell.Count > 0)
                        {
                            int k = countersOfGrainsSurroundingCell.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                            space[c.row, c.column].grainId = k;
                        }
                    }
                    else
                    {
                        if (!fulfillsControlRule1(ref previousStepArray, c))
                        {
                            if (!fulfillsControlRule2(ref previousStepArray, c))
                            {
                                if (!fulfillsControlRule3(ref previousStepArray, c))
                                {
                                    fulfillsControlRule4(ref previousStepArray, c);
                                }
                            }
                        }
                    }
                    // create counters for each color
                    //List<int> countersOfGrainsSurroundingCell = new List<int>();
                    //Dictionary<int, int> countersOfGrainsSurroundingCell = new Dictionary<int, int>();
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
                    /*List<int[]> valuesToCheck = new List<int[]> {
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
                    if (precipitatesTextbox.Value > 0)
                        countersOfGrainsSurroundingCell.Remove(nucleonAmmount);
                    if (countersOfGrainsSurroundingCell.Count > 0)
                    {
                        space[c.row, c.column].grainId = countersOfGrainsSurroundingCell.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                    }*/
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
            // add new color, same for all inclusions
            colorArray.Add(new byte[] { 0, 0, 0, 255});
            // create each inclustion
            //Random rng = new Random();
            for (int i = 0; i < precipitatesTextbox.Value; i++)
            {
                int Nmax = 0;
                int grainRadius = rng.Next((int)precipitatesRadiusFromTextbox.Value, (int)precipitatesRadiusToTextbox.Value);
                int xLocation = rng.Next(0, (int)xSize);
                int yLocation = rng.Next(0, (int)ySize);
                if (randomPositionRadio.Checked == true && stepsAsBytes.Count == 1) // random in the begining
                {
                    while (neighboursInRange(space, grainRadius + 2, space[xLocation, yLocation], nucleonAmmount + 1).Count > 0 && Nmax < Math.Pow(xSize + ySize, 2.0))
                    {
                        xLocation = rng.Next(0, (int)xSize);
                        yLocation = rng.Next(0, (int)ySize);
                        Nmax += 1;
                    }
                    if (Nmax < Math.Pow(xSize + ySize, 2.0))
                        forceGrainIdInRange(grainRadius, space[xLocation, yLocation]);
                }
                else if (gbPositionRadio.Checked == true) // grain boundary in the end
                {
                    while ((!isGrainBoundary(space[xLocation, yLocation]) || neighboursInRange(space, grainRadius + 2, space[xLocation, yLocation], nucleonAmmount + 1).Count > 0) && Nmax < Math.Pow(xSize + ySize, 2.0))
                    {
                        xLocation = rng.Next(0, (int)xSize);
                        yLocation = rng.Next(0, (int)ySize);
                        Nmax += 1;
                    }
                    if (Nmax < Math.Pow(xSize + ySize, 2.0))
                        forceGrainIdInRange(grainRadius, space[xLocation, yLocation]);
                }
            }
            nucleonAmmount += 1;
            // once finished, add to array of steps
            stepsAsBytes.Add(createByteArray());
            this.Invoke(new Action(() => {
                showImage(stepsAsBytes.Count - 1);
            }));
        }

        private bool matchesShape(int _centerRow, int _centerCol, int _row, int _col, int range)
        {
            bool res = false;
            if (this.circleShapeRadio.Checked == true)
            {
                if ((Math.Pow((_row - _centerRow), 2.0) + Math.Pow((_col - _centerCol), 2.0)) <= Math.Pow(range, 2.0))
                    return true;
            }
            else if (this.squareShapeRadio.Checked == true)
            {
                if ((Math.Abs(_row - _centerRow) < range) && (Math.Abs(_col - _centerCol) < range))
                    return true;
            }
            return res;
        }

        private bool isGrainBoundary(Cell localCell)
        {
            // check if more than 1 grain color is in range of 1
            Dictionary<int, int> neighboursList = neighboursInRange(space, 1, localCell);
            if (neighboursList.Count > 1 && !neighboursList.ContainsKey(nucleonAmmount + 1))
                return true;
            return false;
        }

        private Dictionary<int, int> neighboursInRange(Cell[,] _space, int range, Cell checkedCell, int searchedGrainId=-1, bool nearestNeighbours = false, bool furtherNeighbours = false)
        {
            // first initiate function variables
            Dictionary<int, int> neighbourList = new Dictionary<int, int>();
            int checkedLocationRow = checkedCell.row;
            int checkedLocationColumn = checkedCell.column;
            // now search space for neighbour colors
            // look only in cells +- range from cell
            for (int _col = checkedLocationColumn - range; _col <= checkedLocationColumn + range; _col++)
            {
                for (int _row = checkedLocationRow - range; _row <= checkedLocationRow + range; _row++)
                {
                    if (_row >= 0 && _col >= 0 && _row < xSize && _col < ySize)
                    {
                        if (_row == checkedLocationRow && _col == checkedLocationColumn)
                            continue;
                        if (nearestNeighbours == true && furtherNeighbours == false)
                        {
                            /* if nearest, search in cross:
                             *  -------
                             *  | |o| |
                             *  -------
                             *  |o|x|o|
                             *  -------
                             *  | |o| |
                             *  -------
                             *  If entry not one of circles, skip further part
                             */
                            if (_col != checkedLocationColumn || _row != checkedLocationRow)
                                continue;
                        }
                        if (nearestNeighbours == false && furtherNeighbours == true)
                        {
                            /* if further, search in rotated cross:
                             *  -------
                             *  |o| |o|
                             *  -------
                             *  | |x| |
                             *  -------
                             *  |o| |o|
                             *  -------
                             *  If entry not one of circles, skip further part
                             */
                            if (_col == checkedLocationColumn || _row == checkedLocationRow)
                                continue;
                        }
                        if (searchedGrainId == -1)
                        {
                            if (_space[_row, _col].grainId > 0)
                            {
                                if (neighbourList.ContainsKey(_space[_row, _col].grainId))
                                    neighbourList[_space[_row, _col].grainId] += 1;
                                else
                                    neighbourList.Add(_space[_row, _col].grainId, 1);
                            }
                        }
                        else
                        {
                            if (_space[_row, _col].grainId == searchedGrainId)
                            {
                                if (neighbourList.ContainsKey(_space[_row, _col].grainId))
                                    neighbourList[_space[_row, _col].grainId] += 1;
                                else
                                    neighbourList.Add(_space[_row, _col].grainId, 1);
                            }
                        }
                    }
                }
            }
            if (precipitatesTextbox.Value > 0)
                neighbourList.Remove(nucleonAmmount);
            return neighbourList;
        }

        private void forceGrainIdInRange(int range, Cell checkedCell)
        {
            int checkedLocationRow = checkedCell.row;
            int checkedLocationColumn = checkedCell.column;
            //Random rng = new Random();
            // now search space for neighbour colors
            // look only in cells +- range from cell
            for (int _col = checkedLocationColumn - range; _col <= checkedLocationColumn + range; _col++)
            {
                for (int _row = checkedLocationRow - range; _row <= checkedLocationRow + range; _row++)
                {
                    if (_row > 0 && _col > 0 && _row < xSize && _col < ySize && (matchesShape(checkedLocationRow, checkedLocationColumn, _row, _col, range)))
                        space[_row, _col].grainId = nucleonAmmount + 1;
                }
            }
        }

        private void saveToFile(string _filename = null)
        {
            string delimeter = ",";
            string endOfLine = "\n";
            // save content of space to file
            string fileContent = xSize.ToString() + delimeter + ySize.ToString() + delimeter + nucleonAmmount + endOfLine; // first line is width, height and number of nucleons
            fileContent += precipitatesTextbox.Value.ToString() + delimeter + precipitatesRadiusFromTextbox.Value.ToString() + delimeter + precipitatesRadiusToTextbox.Value.ToString() + delimeter + (gbPositionRadio.Checked ? 1 : 0) + endOfLine; // second line is number of inclusions and their min and max range and mode (random/grain boundary)
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
                filename = "CA-export-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            File.WriteAllText(filename + ".csv", fileContent);
        }

        private bool fulfillsControlRule1(ref Cell[,] _space, Cell c)
        {
            Dictionary<int, int> coloredNeighbourDict = neighboursInRange(_space, 1, c);
            if (coloredNeighbourDict.Count > 0)
            {
                KeyValuePair<int, int> highestNeighboursCountEntry = coloredNeighbourDict.Aggregate((a, b) => a.Value > b.Value ? a : b);
                if (highestNeighboursCountEntry.Value >= 5)
                {
                    space[c.row, c.column].grainId = highestNeighboursCountEntry.Key;
                    return true;
                }
            }
            return false;
        }

        private bool fulfillsControlRule2(ref Cell[,] _space, Cell c)
        {
            Dictionary<int, int> coloredNeighbourDict = neighboursInRange(_space, 1, c, -1, true, false);
            if (coloredNeighbourDict.Count > 0)
            {
                KeyValuePair<int, int> highestNeighboursCountEntry = coloredNeighbourDict.Aggregate((a, b) => a.Value > b.Value ? a : b);
                if (highestNeighboursCountEntry.Value >= 3)
                {
                    space[c.row, c.column].grainId = highestNeighboursCountEntry.Key;
                    return true;
                }
            }
            return false;
        }

        private bool fulfillsControlRule3(ref Cell[,] _space, Cell c)
        {
            Dictionary<int, int> coloredNeighbourDict = neighboursInRange(_space, 1, c, -1, false, true);
            if (coloredNeighbourDict.Count > 0)
            {
                KeyValuePair<int, int> highestNeighboursCountEntry = coloredNeighbourDict.Aggregate((a, b) => a.Value > b.Value ? a : b);
                if (highestNeighboursCountEntry.Value >= 3)
                {
                    space[c.row, c.column].grainId = highestNeighboursCountEntry.Key;
                    return true;
                }
            }
            return false;
        }

        private bool fulfillsControlRule4(ref Cell[,] _space, Cell c)
        {
            //Random rng = new Random();
            int randomPercent = rng.Next(0, 100);
            if (randomPercent > grainBoundaryShapeControlTextbox.Value)
                return false;
            Dictionary<int, int> countersOfGrainsSurroundingCell = neighboursInRange(_space, 1, c);
            if (countersOfGrainsSurroundingCell.Count > 0)
            {
                int k = countersOfGrainsSurroundingCell.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                space[c.row, c.column].grainId = k;
                return true;
            }
            /*Dictionary<int, int> neighbours = neighboursInRange(_space, 1, _space[_row, _col]);
            if (neighbours.Count > 0)
            {
                List<int> grainIdsInRange = new List<int>();
                foreach (KeyValuePair<int, int> keyValPair in neighbours)
                    grainIdsInRange.Add(keyValPair.Key);
                _space[_row, _col].grainId = Utils.randomlyDecideGrainId(grainIdsInRange.Count) + 1;
                return true;
            }*/
            return false;
        }

        private List<Cell> getAllCellsOfSameId(int id)
        {
            List<Cell> cellsWithSameId = new List<Cell>();
            foreach (Cell c in space)
            {
                if (c.grainId == id)
                    cellsWithSameId.Add(c);
            }
            return cellsWithSameId;
        }

        private void breakButton_Click(object sender, EventArgs e)
        {
            forceBreak = true;
        }

        private void precipiratesRadiusFromTextbox_ValueChanged(object sender, EventArgs e)
        {
            if (precipitatesRadiusToTextbox.Value < precipitatesRadiusFromTextbox.Value)
                precipitatesRadiusToTextbox.Value = precipitatesRadiusFromTextbox.Value;
        }

        private void precipitatesRadiusToTextbox_ValueChanged(object sender, EventArgs e)
        {
            if (precipitatesRadiusFromTextbox.Value > precipitatesRadiusToTextbox.Value)
                precipitatesRadiusFromTextbox.Value = precipitatesRadiusToTextbox.Value;
        }

        private void precipitatesTextbox_ValueChanged(object sender, EventArgs e)
        {
            if ((int)precipitatesTextbox.Value > 0)
                precipitatesPanel.Visible = true;
            else
                precipitatesPanel.Visible = false;
        }

        private void stepSlider_Scroll(object sender, EventArgs e)
        {
            showImage(stepSlider.Value - 1);
        }

        private void grainBoundaryShapeControlCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (grainBoundaryShapeControlCheckbox.Checked)
                grainBoundaryShapeControlPanel.Visible = true;
            else
                grainBoundaryShapeControlPanel.Visible = false;
        }
    }
}
