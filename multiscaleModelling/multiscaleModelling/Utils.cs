using System;
using System.Collections.Generic;

namespace multiscaleModelling
{
    class Utils
    {
        public static Cell[,] Copy(Cell[,] copiedArray)
        {
            int maxXvalue = 0;
            int maxYvalue = 0;
            foreach (Cell cell in copiedArray)
            {
                if (cell.row > maxXvalue)
                    maxXvalue = cell.row;
                if (cell.column > maxYvalue)
                    maxYvalue = cell.column;
            }
            Cell[,] newArray = new Cell[maxXvalue+1, maxYvalue+1];
            foreach (Cell cell in copiedArray)
            {
                newArray[cell.row, cell.column].grainId = cell.grainId;
            }
            return newArray;
        }

        public static int getGrainIdFromCoords(int x, int y, ref Cell[,] array)
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

        public static int randomlyDecideGrainId(int grainIdsCount)
        {
            Random rng = new Random();
            int value = rng.Next(0, grainIdsCount - 1);
            return value;
        }

        public static bool isColorSimilar(byte[] sourceColor, byte[] destColor)
        {
            double max_dist = 30;
            double dst_red = Math.Pow(Convert.ToDouble(sourceColor[2]) - Convert.ToDouble(destColor[2]), 2.0);
            double dst_green = Math.Pow(Convert.ToDouble(sourceColor[1]) - Convert.ToDouble(destColor[1]), 2.0);
            double dst_blue = Math.Pow(Convert.ToDouble(sourceColor[0]) - Convert.ToDouble(destColor[0]), 2.0);
            double dst_between_colors = Math.Sqrt(dst_red + dst_green + dst_blue);
            if (dst_between_colors < max_dist)
                return true;
            return false;
        }

        public static bool colorAlreadyExistsInColorPalette(byte[] newColor, List<byte[]> colorPalette)
        {
            foreach (byte[] color in colorPalette)
                if (isColorSimilar(color, newColor))
                    return true;
            return false;
        }
    }
}
