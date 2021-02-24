using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcusticDetector.DataService
{
    static class FilterTools
    {
        private static double B_0 = 0.995383;
        private static double B_1 = -1.990770;
        private static double B_2 = 0.995383;
        private static double A_1 = -1.990740;
        private static double A_2 = 0.990787;

        private static readonly double[] _x = new double[3];
        private static readonly double[] _y = new double[3];

        public static double HightPassFilter(double inputSIgnal)
        {
            _x[2] = _x[1];
            _x[1] = _x[0];
            _x[0] = inputSIgnal;

            _y[2] = _y[1];
            _y[1] = _y[0];

            _y[0] = B_0 * _x[0] + B_1 * _x[1] + B_2 * _x[2] - A_1 * _y[1] - A_2 * _y[2];

            return _y[0];
        }
    }
}
