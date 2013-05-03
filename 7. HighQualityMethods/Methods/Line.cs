using System;
using System.Linq;

namespace Methods
{
    public struct Line
    {
        public Line(Point start, Point end) : this()
        {
            this.Start = start;
            this.End = end;
        }

        public Point Start { get; set; }

        public Point End { get; set; }
    }
}