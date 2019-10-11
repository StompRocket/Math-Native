using System;
namespace StompRocket.Math
{
    public class Calc
    {
        public double Result;
        public string Calculation;
        public Calc(double result, string calculation)
        {
            Result = result;
            Calculation = calculation;
        }

        public override string ToString()
        {
            return $"{Calculation} = {Result.ToString()}";
        }
    }
}
