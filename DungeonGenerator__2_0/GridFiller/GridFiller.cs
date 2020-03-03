using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    public interface GridFiller
    {
        void FillGrid(Raster Grid, GridObjectTemplate objectTemplate, int NumberOfObject);
    }
}
