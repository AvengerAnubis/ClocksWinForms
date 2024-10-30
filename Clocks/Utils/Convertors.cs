using SharpDX.Direct2D1;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clocks.Utils
{
    public static class Convertors
    {
        public static float DegreesToRadians(float degrees)
        {
            return (float)(degrees * (Math.PI / 180.0f));
        }
    }
}
