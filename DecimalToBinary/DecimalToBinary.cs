using System;
using System.Collections.Generic;
using System.Text;

namespace DecimalToBinary
{
   public class DecimalToBinary
    {
       
        public IEEfloatingPointNumber convertDemicalToFloatingPointNumber(String number)
        {
            IEEfloatingPointNumber f_number = new IEEfloatingPointNumber();
            f_number.number = float.Parse(number);
            f_number.Significant = '0';
            //if negative number mark flag and remove the symbol
            if (number.Contains('-'))
            {
                number = number.Replace("-", "");
                f_number.Significant = '1';
            }
            var components = number.Split(".");
            var num = components[0];
            var bin_dem = returnDecimalToBinary(num);
            var frac = components[1];
            var bin_frc = returnfractionToBinary("."+frac);
            f_number.scientificNotation = bin_dem + "." + bin_frc;
            f_number.Mantissa = f_number.scientificNotation.Replace(".", "").Substring(1, f_number.scientificNotation.Replace(".", "").Length - 1).ToString().ToCharArray();
            //moving the decimal point to right of mostsignificantbit
            var shiftexponentComponent = f_number.scientificNotation.IndexOf(".") - 1;
            var expbiasvalue = Math.Pow(2, shiftexponentComponent-1) - 1; //2Pow(k-1) - 1
            if (expbiasvalue < 0)
                expbiasvalue = 0;
            var biasedComponent = returnDecimalToBinary((expbiasvalue + shiftexponentComponent).ToString());
            f_number.Exponent = biasedComponent.ToCharArray();
            f_number.Exponent= Addzeros(f_number.Exponent, 8);
            f_number.Mantissa= Addzeros(f_number.Mantissa, 23);
            return f_number;
        }
        private string returnDecimalToBinary(string decimalnumber)
        {
            var binary = string.Empty;
            var num = int.Parse(decimalnumber); 
            bool flag = true;
            while(flag)
            {
                var d = num % 2; 
                binary += d;
                num = num / 2;
                if (num == 0)
                    flag = false;
            }
            char[] charArray = binary.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private char[] Addzeros(char[] chararry, int length)
        {
            char[] newarray = new char[length];
            for (int i = 0; i < length; i++)
            {
                if(i< chararry.Length)
                {
                    newarray[i] = chararry[i];
                }
                else
                newarray[i] = '0';
            }
            return newarray;
        }

        private string returnfractionToBinary(string fractionnumber)
        {
            var binary = string.Empty;
            int count = 0;
            float fraction = float.Parse(fractionnumber);
            while(count<15)
            {
                fraction = fraction * 2;
                if(fraction >= 1)
                {
                    binary += '1';
                    fraction--;
                }
                else
                {
                    binary += '0';
                }
                count++;
            }
            return binary;
        }

    }
   public class IEEfloatingPointNumber
    {
        public char Significant { get; set; }
        public char[] Exponent = new char[8];
        public char[] Mantissa = new char[23];
        public string scientificNotation { get; set; }
        public float number { get; set; }
    }


  
}
