using System;

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

        public static int getGrainIdFromCoords(int x, int y, Cell[,] array)
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

        public static int randomlyDecideGrainId(int grainId1, int grainId2)
        {
            Random rng = new Random();
            int value = rng.Next(0, 1);
            if (value == 0)
                return grainId1;
            return grainId2;
        }
    }
}
