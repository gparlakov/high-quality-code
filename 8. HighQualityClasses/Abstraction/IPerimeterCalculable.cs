using System;

namespace Abstraction
{
    public interface IPerimeterCalculable : ISurfaceCalculable
    {
        double CalcPerimeter();
    }
}