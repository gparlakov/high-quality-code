using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Potato
{
    class Expression
    {
        bool isXinRange = IsInRange(x, MinX, MaxX);
        bool isYinRange = IsInRange(y, MinY, MaxY);
        bool shouldVisitCell = ShouldVisitCell(x, y);


        if (isXinRange && isYinRange && shouldVisitCell)
        {
            VisitCell();
        }
        

        ...
            
        bool IsInRange(double value, double min, double max)
        {
            bool isInRange = false;
            if (min <= value && value <= max)
            {
                isInRange = true;
            }

            return isInRange;
        }

    }
}
