using System;
using System.Collections.Generic;

namespace DungeonGenerator
{
    public class Raster
    {
        private int Width;
        private int Height;
        private int[][] Grid;
        private int Seed;
        private Random random;
        private List<GridObject> gridObjects;

        public Raster(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            Grid = InitializeGrid(Width, Height);
            this.random = new Random();
            this.Seed = 0;
            gridObjects = new List<GridObject>();
        }
        /// <summary>
        /// Create Grid and fill it with 0
        /// </summary>
        /// <param name="width">Width of the grid</param>
        /// <param name="height">Height of the grid</param>
        /// <returns></returns>
        private int[][] InitializeGrid(int width, int height)
        {
            int[][] grid = new int[width][];
            for(int i = 0; i< height; i++) 
            {
                grid[i] = new int[width];
            }

            return grid;
        }
        public int GetWidth()
        {
            return Width;
        }
        public int GetHeight()
        {
            return Height;
        }
        public void SetTileID(int ID, int xCoordinate, int yCoordinate)
        {
            Grid[yCoordinate][xCoordinate] = ID;
        }
        /// <summary>
        /// Create image file representing the MAP
        /// </summary>
        public void BufferImage()
        {
            Dictionary<int, byte[]> ColorPallete = new Dictionary<int, byte[]>();
            ColorPallete.Add(0, new byte[] { 0, 0, 0 });
            ImageBuffer image = new ImageBuffer(Width, Height);
            for (int i = 0; i < Height; i++)
            {
                    //Random random = new Random(seed);
                    for (int j = 0; j < Width; j++)
                    {
                        if (ColorPallete.ContainsKey(Grid[i][j]))
                        {
                            byte[] RGB = ColorPallete[Grid[i][j]];
                            image.PlotPixel(j, i, RGB[0], RGB[1], RGB[2]);
                        }
                        else
                        {
                            byte[] RGB = new byte[3];
                            RGB[0] = (byte)random.Next(0, 255);
                            RGB[1] = (byte)random.Next(0, 255);
                            RGB[2] = (byte)random.Next(0, 255);
                            image.PlotPixel(j, i, RGB[0], RGB[1], RGB[2]);
                            ColorPallete.Add(Grid[i][j], RGB);
                        }
                    }
            }
                image.save();
        }
        public int[][] getGrid()
        {
            return Grid;
        }
        public int getSeed()
        {
            return Seed;
        }
        public void setSeed(int seed)
        {
            if(seed == 0)
            {
                Console.WriteLine("Seed 0 is reserved - seed will be set to random value");
                random = new Random();
            }
            else
            {
                this.Seed = seed;
                random = new Random(seed);
            }
        }
        public Random getRandom()
        {
            return random;
        }

        public void addGridObject(GridObject gObject)
        {
            gridObjects.Add(gObject);
        }

        public List<GridObject> getGridObjectList()
        {
            return gridObjects;
        }

    }
}
