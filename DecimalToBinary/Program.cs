using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DecimalToBinary obj = new DecimalToBinary();
            PrintIEE(obj.convertDemicalToFloatingPointNumber("-0.25"));
            //Small exponent value
            PrintIEE(obj.convertDemicalToFloatingPointNumber("5.3"));
           // Large exponent value.
            PrintIEE(obj.convertDemicalToFloatingPointNumber("456.56"));
            //Negative exponent value.
            PrintIEE(obj.convertDemicalToFloatingPointNumber("10.000003"));
            //Negative significand
            PrintIEE(obj.convertDemicalToFloatingPointNumber("-63.3"));
            

        }

        private static void PrintIEE(IEEfloatingPointNumber Ieeefloatingpoint)
        {
            Console.WriteLine("Floating Decimal Number "+Ieeefloatingpoint.number + ": "+Ieeefloatingpoint.Significant + "|" + new string(Ieeefloatingpoint.Exponent) + "|" + new string(Ieeefloatingpoint.Mantissa));
        }
    }
}
