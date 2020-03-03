using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    interface GridObjectTemplate
    {
        /// <summary>
        /// Create GridObject baset on given boundaries
        /// </summary>
        GridObject GenerateGridObject(int ID, Random random);
        GridObject GenerateGridObject(int ID);
        void setRandomAngle(int MinAngle, int MaxAngle);
        void setFixedAngle(int Angle);
        void ResetAngle();
        void setInfill(bool Infill);
        void setFixedBorderSize(int BorderSize);
        void setRandomBorderSize(int MinBorderSize, int MaxBorderSize);
        void ResetBorderSize();
    }
}
