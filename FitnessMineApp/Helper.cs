using System;

namespace FitnessMineApp
{
    public static class Helper
    {
        public static double CalculateBMI(int ft, int inc, int we, WeightType wt)
        {
            double result = 0;

            if (wt == WeightType.Pounds)
            {
                //Formula for BMI = ( Weight in Pounds / ( Height in inches x Height in inches ) ) x 703
                var height = CnvertToInch(ft, inc);
                result = (we / (height * height)) * 703;
            }

            if (wt == WeightType.Kilograms)
            {
                //Formula for BMI = ( Weight in Kilograms / ( Height in Meters x Height in Meters ) )
                var height = ConvertToMeter(ft, inc);
                result = (we / (height * height));
            }

            return result;
        }

        private static double CnvertToInch(int ft, int inc)
        {
            return (ft * 12) + inc; //1 ft = 12 inch
        }

        private static double ConvertToMeter(int ft, int inc)
        {
            return (ft * 0.3048) + (inc * 0.0254); //1 ft = 0.3048 meter & 1 inch = 0.0254 meter
        }
    }

    public enum WeightType
    {
        Pounds = 0,
        Kilograms = 1
    }
}
