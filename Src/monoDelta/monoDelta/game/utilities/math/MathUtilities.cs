using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.model.utilities.math
{
    public static class MathUtilities
    {
        public static int Clamp(int toClamp, int minValue, int maxValue)
        {
            if (toClamp > maxValue)
                return maxValue;
            else if (toClamp < minValue)
                return minValue;

            return toClamp;
        }
    }
}
