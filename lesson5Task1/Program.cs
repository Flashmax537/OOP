using System;

namespace lesson5Task1
{
    class Program
    {
        static void Main()
        {
            var rationalNumberOne = new RationalNumbers(9, 2);
            var rationalNumberTwo = new RationalNumbers(1, 3);
            var duplicateRationalNumberOne = rationalNumberOne;

            Console.WriteLine($"{rationalNumberOne.ToString()} + {rationalNumberTwo.ToString()} = {rationalNumberOne + rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} - {rationalNumberTwo.ToString()} = {rationalNumberOne - rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} * {rationalNumberTwo.ToString()} = {rationalNumberOne * rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} / {rationalNumberTwo.ToString()} = {rationalNumberOne / rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} == {rationalNumberTwo.ToString()} = {rationalNumberOne == rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} != {rationalNumberTwo.ToString()} = {rationalNumberOne != rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} > {rationalNumberTwo.ToString()} = {rationalNumberOne > rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} < {rationalNumberTwo.ToString()} = {rationalNumberOne < rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} >= {rationalNumberTwo.ToString()} = {rationalNumberOne >= rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} <= {rationalNumberTwo.ToString()} = {rationalNumberOne <= rationalNumberTwo}");
            Console.WriteLine($"{rationalNumberOne.ToString()} % {rationalNumberTwo.ToString()} = {rationalNumberOne % rationalNumberTwo}");

            Console.Write(rationalNumberOne.ToString());
            rationalNumberOne++;
            Console.WriteLine($"++ = {rationalNumberOne}");
            Console.Write(rationalNumberOne.ToString());
            rationalNumberOne--;
            Console.WriteLine($"-- = {rationalNumberOne}");
            Console.WriteLine();

            Console.WriteLine($"Значение: {rationalNumberOne}; Тип: {rationalNumberOne.GetType().Name}");
            Console.WriteLine($"Значение: {(float)rationalNumberOne}; Тип: {((float)rationalNumberOne).GetType().Name}");
            Console.WriteLine($"Значение: {(int)rationalNumberOne}; Тип: {((int)rationalNumberOne).GetType().Name}");
            Console.WriteLine();

            Console.WriteLine($"({rationalNumberOne}).Equals({rationalNumberTwo}): {rationalNumberOne.Equals(rationalNumberTwo)}");
            Console.WriteLine($"({rationalNumberOne}).Equals({duplicateRationalNumberOne}): {rationalNumberOne.Equals(duplicateRationalNumberOne)}");
        }
    }

    public class RationalNumbers
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RationalNumbers()
        {

        }

        public RationalNumbers(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public static bool operator ==(RationalNumbers a, RationalNumbers b)
        {
            if ((a.Numerator / (decimal)a.Denominator) == (b.Numerator / (decimal)b.Denominator)) return true;
            return false;
        }
        public static bool operator !=(RationalNumbers a, RationalNumbers b)
        {
            if ((a.Numerator / (decimal)a.Denominator) != (b.Numerator / (decimal)b.Denominator)) return true;
            return false;
        }

        public static bool operator >(RationalNumbers a, RationalNumbers b)
        {
            if ((a.Numerator / (decimal)a.Denominator) > (b.Numerator / (decimal)b.Denominator)) return true;
            return false;
        }
        public static bool operator <(RationalNumbers a, RationalNumbers b)
        {
            if ((a.Numerator / (decimal)a.Denominator) < (b.Numerator / (decimal)b.Denominator)) return true;
            return false;
        }

        public static bool operator >=(RationalNumbers a, RationalNumbers b)
        {
            if ((a.Numerator / (decimal)a.Denominator) >= (b.Numerator / (decimal)b.Denominator)) return true;
            return false;
        }
        public static bool operator <=(RationalNumbers a, RationalNumbers b)
        {
            if ((a.Numerator / (decimal)a.Denominator) <= (b.Numerator / (decimal)b.Denominator)) return true;
            return false;
        }

        public static string operator +(RationalNumbers a, RationalNumbers b)
        {
            if (a.Denominator != b.Denominator)
            {
                return $"{(a.Numerator * b.Denominator) + (b.Numerator * a.Denominator)}/" +
                    $"{(a.Denominator * b.Denominator)}";
            }
            else return $"{a.Numerator + b.Numerator}/{a.Denominator}";
        }

        public static string operator -(RationalNumbers a, RationalNumbers b)
        {
            if (a.Denominator != b.Denominator)
            {
                return new RationalNumbers((a.Numerator * b.Denominator) - (b.Numerator * a.Denominator), 
                    (a.Denominator * b.Denominator)).ToString();
            }
            else return new RationalNumbers(a.Numerator - b.Numerator, a.Denominator).ToString();
        }

        public static string operator *(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a.Numerator * b.Numerator, a.Denominator * b.Denominator).ToString();
        }

        public static string operator /(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers(a.Numerator * b.Denominator, a.Denominator * b.Numerator).ToString();
    }

        public static RationalNumbers operator ++(RationalNumbers a)
        {
            return new RationalNumbers(a.Numerator + a.Denominator, a.Denominator);
        }

        public static RationalNumbers operator --(RationalNumbers a)
        {
            return new RationalNumbers(a.Numerator - a.Denominator, a.Denominator);
        }

        public static string operator %(RationalNumbers a, RationalNumbers b)
        {
            return new RationalNumbers((a.Numerator * b.Denominator) % (a.Denominator * b.Numerator), a.Denominator * b.Numerator).ToString();;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static explicit operator float(RationalNumbers a)
        {
            return (float)a.Numerator / a.Denominator;
        }

        public static explicit operator int(RationalNumbers a)
        {
            return a.Numerator / a.Denominator;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RationalNumbers);
        }

        public bool Equals(RationalNumbers obj)
        {
            return obj.Numerator == this.Numerator && obj.Denominator == this.Denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }
    }
}
