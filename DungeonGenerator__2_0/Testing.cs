using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Controls;


namespace DungeonGenerator
{
    public class Testing
    {
        public Testing(bool DebugCanvas)
        {
            this.DebugingCanvasOn = DebugCanvas;
        }        
        public Testing()
        {
            this.DebugingCanvasOn = false;
        }
        public bool DebugingCanvasOn = false;
        public void AproximationsTest()
        {
            Console.WriteLine(" -----------AproximationsTests----------- ");
            int[][] testedValues =
            {
                new int[] {100,100,1,100},
                new int[] {100,100,1,75},
                new int[] {100,100,1,50},
                new int[] {100,100,1,25},
                new int[] {100,100,1,1},
                new int[] {100,100,25,1},
                new int[] {100,100,50,1},
                new int[] {100,100,75,1},
                new int[] {100,100,100,1},
                new int[] {100,100,125,1},
                new int[] {100,100,150,1},
                new int[] {100,100,175,1},
                new int[] {100,100,200,1},
                new int[] {100,100,200,25},
                new int[] {100,100,200,50},
                new int[] {100,100,200,75},
                new int[] {100,100,200,100},
                new int[] {100,100,200,125},
                new int[] {100,100,200,150},
                new int[] {100,100,200,175},
                new int[] {100,100,200,200},
                new int[] {100,100,175,200},
                new int[] {100,100,150,200},
                new int[] {100,100,125,200},
                new int[] {100,100,100,200},
                new int[] {100,100,75,200},
                new int[] {100,100,50,200},
                new int[] {100,100,25,200},
                new int[] {100,100,1,200},
                new int[] {100,100,1,175},
                new int[] {100,100,1,150},
                new int[] {100,100,1,125},
            };

            for (int i = 0; i < testedValues.Length; i++)
            {
                int x0 = testedValues[i][0];
                int y0 = testedValues[i][1];
                int x1 = testedValues[i][2];
                int y1 = testedValues[i][3];
                Console.WriteLine("Tested points : x0:{0} , y0{1}, x1{2}, y1{3} ---- relativeDistance :  {4},   AbsolutDistance ---- {5}",
                    x0, y0, x1, y1,
                    Drawing.CalculateAproxPointDistance(x0, y0, x1, y1),
                    Drawing.CalculateAbsolutePointDistance(x0, y0, x1, y1));
            }

        }
        public void AngleTest()
        {
            Console.WriteLine(" -----------AngleCalculationTest----------- ");
            int[][] testedValues =
            {
                new int[] {100,100,1,100},
                new int[] {100,100,1,75},
                new int[] {100,100,1,50},
                new int[] {100,100,1,25},
                new int[] {100,100,1,1},
                new int[] {100,100,25,1},
                new int[] {100,100,50,1},
                new int[] {100,100,75,1},
                new int[] {100,100,100,1},
                new int[] {100,100,125,1},
                new int[] {100,100,150,1},
                new int[] {100,100,175,1},
                new int[] {100,100,200,1},
                new int[] {100,100,200,25},
                new int[] {100,100,200,50},
                new int[] {100,100,200,75},
                new int[] {100,100,200,100},
                new int[] {100,100,200,125},
                new int[] {100,100,200,150},
                new int[] {100,100,200,175},
                new int[] {100,100,200,200},
                new int[] {100,100,175,200},
                new int[] {100,100,150,200},
                new int[] {100,100,125,200},
                new int[] {100,100,100,200},
                new int[] {100,100,75,200},
                new int[] {100,100,50,200},
                new int[] {100,100,25,200},
                new int[] {100,100,1,200},
                new int[] {100,100,1,175},
                new int[] {100,100,1,150},
                new int[] {100,100,1,125},
            };

            for (int i = 0; i < testedValues.Length; i++)
            {
                int x0 = testedValues[i][0];
                int y0 = testedValues[i][1];
                int x1 = testedValues[i][2];
                int y1 = testedValues[i][3];
                Console.WriteLine("Tested points : x0: {0} , y0: {1}, x1: {2}, y1: {3} ---- Angle :  {4}",
                    x0, y0, x1, y1,
                    Drawing.CalculateCurrantAngle(x0, y0, x1, y1));
            }

        }
        public void DrawTest(Raster grid, int ID)
        {
            Console.WriteLine(" -----------DrawingTest----------- ");
            int[][] testedValues =
            {
                new int[] {100,100,1,100},
                new int[] {100,100,1,75},
                new int[] {100,100,1,50},
                new int[] {100,100,1,25},
                new int[] {100,100,1,1},
                new int[] {100,100,25,1},
                new int[] {100,100,50,1},
                new int[] {100,100,75,1},
                new int[] {100,100,100,1},
                new int[] {100,100,125,1},
                new int[] {100,100,150,1},
                new int[] {100,100,175,1},
                new int[] {100,100,200,1},
                new int[] {100,100,200,25},
                new int[] {100,100,200,50},
                new int[] {100,100,200,75},
                new int[] {100,100,200,100},
                new int[] {100,100,200,125},
                new int[] {100,100,200,150},
                new int[] {100,100,200,175},
                new int[] {100,100,200,200},
                new int[] {100,100,175,200},
                new int[] {100,100,150,200},
                new int[] {100,100,125,200},
                new int[] {100,100,100,200},
                new int[] {100,100,75,200},
                new int[] {100,100,50,200},
                new int[] {100,100,25,200},
                new int[] {100,100,1,200},
                new int[] {100,100,1,175},
                new int[] {100,100,1,150},
                new int[] {100,100,1,125},
            };

            for (int i = 0; i < testedValues.Length; i++)
            {
                int x0 = testedValues[i][0];
                int y0 = testedValues[i][1];
                int x1 = testedValues[i][2];
                int y1 = testedValues[i][3];
                Console.WriteLine("Tested points : x0: {0} , y0: {1}, x1: {2}, y1: {3} ",
                    x0, y0, x1, y1);
                    Drawing.DrawLine(x0, y0, x1, y1, grid, ID);
            }

        }
        public void SearchLineTest(Raster grid)
        {
            int Height = grid.GetHeight();
            int Width = grid.GetWidth();
            byte[][] returnGrid = new byte[Height][];
            for(int i = 0; i< Height; i++)
            {
                returnGrid[i] = new byte[Width];
            }
            for(int i = 0; i<Height; i++)
            {
                int[][] searchResult = Drawing.DrawSearchLine(0, i, Width - 1, i, grid.getGrid(), 1);
                for(int j = 0; j< searchResult.Length; j++)
                {
                    returnGrid[searchResult[j][2]][searchResult[j][1]] = 1;
                }
            }

            ImageBuffer buffer = new ImageBuffer(Width, Height);
            for(int i = 0; i<Height; i++)
            {
                for(int j = 0; j< Width; j++)
                {
                    if(returnGrid[i][j] == 0)
                    {
                        buffer.PlotPixel(j, i, 255, 255, 255);
                    }else if (returnGrid[i][j] == 1)
                    {
                        buffer.PlotPixel(j, i, 0, 0, 0);
                    }else
                    {
                        buffer.PlotPixel(j, i, 255, 0, 0);
                    }
                }
            }
            buffer.saveColor();

        }

        public void FindClosestTest(Raster grid)
        {
            foreach(var v in grid.getGridObjectList())
            {
                int[][] searchResult = v.FindClosestNeighbourt(grid);
                if(searchResult.Length > 0)
                {
                    if(searchResult[0][0] == 0)
                    {
                        Console.WriteLine("Search Failed");
                    }
                    else
                    {
                        for(int i = 0; i< searchResult.Length; i++)
                        {
                            Console.WriteLine("Object with ID : {0} has closest neighbourt {1} on coordinates X:{2}, Y:{3}", v.getID(), searchResult[i][0], searchResult[i][1], searchResult[i][2]);
                            int[] centerPoint = new int[] { 0, 0 };
                            for(int l = 0; l< grid.getGridObjectList().Count; l++)
                            {
                                if(grid.getGridObjectList().ElementAt(l).getID() == searchResult[i][0])
                                {
                                    centerPoint = grid.getGridObjectList().ElementAt(l).getCenterPoint();
                                }
                            }
                            Console.WriteLine("CenterCoordinate : X:{0}, Y:{1}", v.getCenterPoint()[0], v.getCenterPoint()[1]);
                            if (v.getCenterPoint()[0] != 0 && v.getCenterPoint()[1] != 0 && centerPoint[0] != 0 && centerPoint[1] != 0)
                            Drawing.DrawLine(v.getCenterPoint()[0], v.getCenterPoint()[1], centerPoint[0], centerPoint[1], grid.getGrid(), Const.CENTERCONECTION);
                        }
                    }
                }
            }
        }

        public void setDebugungCanvas(bool DebiggingCanvasSetling)
        {
            this.DebugingCanvasOn = DebiggingCanvasSetling;
        }
    }
}
