using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DungeonGenerator
{
    public class CloseObjectConnector : ObjectConnector
    {
        public void Connect(Raster Grid)
        {
            List<GridObject> ObjectsToConnect = Grid.getGridObjectList();
            GridObject nextObject = new SquareRoom(Const.CurrentID, 20);
            if (ObjectsToConnect.Count != 0)
            {
                nextObject = ObjectsToConnect.First();
            }
            else
            {
                Console.WriteLine("Grid do not contains any objects");
                
            }



            //while(ObjectsToConnect.Count != 0)
            for (int i = 0; i < 60; i++)
            {
                //find closes 
                bool DidNotFound = true;
                int closestId = 0;
                int distance = 1;
                int indicator = 0;
                int x = nextObject.getCenterPoint()[0] - distance;
                int y = nextObject.getCenterPoint()[1] - distance;
                while (DidNotFound)
                {
                    if(indicator == 0)
                    {
                        Console.WriteLine("Condition 1");
                        if (x > Grid.GetWidth() && x < 0 && y > Grid.GetHeight() && y < 0)
                        {
                            Console.WriteLine(indicator + "1");
                            x++;
                            break;
                        }
                        if (x == nextObject.getCenterPoint()[0] + distance)
                        {
                            Console.WriteLine(indicator + "4");
                            indicator++;
                            break;
                        }
                        if (Grid.getGrid()[y][x] != Const.EMPTY && Grid.getGrid()[y][x] != nextObject.getID())
                        {
                            Console.WriteLine(indicator + "2");
                            closestId = Grid.getGrid()[y][x];
                            DidNotFound = false;
                            break;
                        }
                        else if (Grid.getGrid()[y][x] == Const.EMPTY) 
                        {
                            Console.WriteLine(indicator + "3");
                            Console.WriteLine(x);
                            x++;
                        }

                    }else if(indicator == 1)
                    {
                        if (x > Grid.GetWidth() && x < 0 && y > Grid.GetHeight() && y < 0)
                        {
                            y++;
                            break;
                        }
                        if (y == nextObject.getCenterPoint()[0] + distance)
                        {
                            indicator++;
                            break;
                        }
                        if (Grid.getGrid()[y][x] != Const.EMPTY && Grid.getGrid()[y][x] != nextObject.getID())
                        {
                            closestId = Grid.getGrid()[y][x];
                            DidNotFound = false;
                            break;
                        }
                        else if (Grid.getGrid()[y][x] == Const.EMPTY)
                        {
                            y++;
                        }
                        
                    }else if(indicator == 2)
                    {
                        if (x > Grid.GetWidth() || x < 0 || y > Grid.GetHeight() || y < 0)
                        {
                            x--;
                            break;
                        }
                        if (x == nextObject.getCenterPoint()[0] - distance) { 
                            indicator++;
                            break;
                        }
                        if (Grid.getGrid()[y][x] != Const.EMPTY && Grid.getGrid()[y][x] != nextObject.getID())
                        {
                            closestId = Grid.getGrid()[y][x];
                            DidNotFound = false;
                            break;
                        }
                        else if (Grid.getGrid()[y][x] == Const.EMPTY)
                        {
                            x--;
                        }
                        

                    }
                    else if(indicator == 3)
                    {
                        if (x > Grid.GetWidth() || x < 0 || y > Grid.GetHeight() || y < 0)
                        {
                            y--;
                            break;
                        }
                        if (y == nextObject.getCenterPoint()[0] - distance)
                        {
                            distance++;
                            indicator = 0;
                            break;
                        }
                        if (Grid.getGrid()[y][x] != Const.EMPTY && Grid.getGrid()[y][x] != nextObject.getID())
                        {
                            closestId = Grid.getGrid()[y][x];
                            DidNotFound = false;
                            break;
                        }
                        else if (Grid.getGrid()[y][x] == Const.EMPTY)
                        {
                            y--;
                        }


                    }
                    
                    
                    
                }
                Console.WriteLine("Closest ID = {0}", closestId);
                ObjectsToConnect.Remove(nextObject);
                nextObject = ObjectsToConnect.First();
            }


        }
    }
}
