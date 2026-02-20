using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoCap.CapturedData
{
    public interface IBoundingRectProvider
    {
        (int X, int Y, int Width, int Height) GetBoundingRectangleOfSinglePointFrame();  
    }
}
