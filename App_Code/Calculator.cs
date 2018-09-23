using System;
using System.Collections.Generic;
using System.Web;

public class Calculator
{
    public static string Calculate(string a, string b, string c)
    {
        string result = "";
        double number;
        if (double.TryParse(a, out number) && double.TryParse(b, out number) && double.TryParse(c, out number))
        {
            double A = Convert.ToDouble(a);
            double B = Convert.ToDouble(b);
            double C = Convert.ToDouble(c);

            double D = (B * B) - (4 * A * C);

            double x1;
            double x2;
            string bSign = B > 0 ? "+" : "";
            string cSign = C > 0 ? "+" : "";

            if (D >= 0)
            {
                x1 = ((-1) * B + Math.Sqrt(D)) / 2 / A;
                x2 = ((-1) * B - Math.Sqrt(D)) / 2 / A;

                result = string.Format("Square equation: {0}x&sup2;{1}{2}x{3}{4}=0 <br> First value: {5} <br> Second value: {6} ", A, bSign, B, cSign, C, x1, x2);
            }
            else
            {
                // TODO complex numbers
                result = "D < 0";
            }
        }
        else
        {
            result = "Wrong parametrs";
        }
        return result;
    }
}