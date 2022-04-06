using System;

namespace lesson5Task2
{
    class Program
    {
        static void Main()
        {
            var complexNumberOne = new ComplexNumbers(3, -2);
            var complexNumberTwo = new ComplexNumbers(4, 1);
            var complexNumberThree = new ComplexNumbers(4, 1);

            var plusResult = complexNumberOne + complexNumberTwo;
            var minusResult = complexNumberOne - complexNumberTwo;
            var multiplyResult = complexNumberOne * complexNumberTwo;

            Console.WriteLine($"({complexNumberOne.ToString()}) + ({complexNumberTwo.ToString()}) = {plusResult.ToString()}");
            Console.WriteLine($"({complexNumberOne.ToString()}) - ({complexNumberTwo.ToString()}) = {minusResult.ToString()}");
            Console.WriteLine($"({complexNumberOne.ToString()}) * ({complexNumberTwo.ToString()}) = {multiplyResult.ToString()}");
            Console.WriteLine();
            Console.WriteLine($"({complexNumberOne.ToString()}) == ({complexNumberThree.ToString()}): {complexNumberOne == complexNumberThree}");
            Console.WriteLine($"({complexNumberTwo.ToString()}) == ({complexNumberThree.ToString()}): {complexNumberTwo == complexNumberThree}");
            Console.WriteLine();
            Console.WriteLine($"({complexNumberOne.ToString()}) != ({complexNumberThree.ToString()}): {complexNumberOne != complexNumberThree}");
            Console.WriteLine($"({complexNumberTwo.ToString()}) != ({complexNumberThree.ToString()}): {complexNumberTwo != complexNumberThree}");
        }
    }

    public class ComplexNumbers
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ComplexNumbers()
        {

        }

        public ComplexNumbers(int a, int b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Действительное число A
        /// </summary>
        public int A { get; set; }

        /// <summary>
        /// Действительное число B
        /// </summary>
        public int B { get; set; }

        public override string ToString()
        {
            return B > 0 ? $"{A} + {B}i" : $"{A} - {Math.Abs(B)}i";
        }

        public static string operator +(ComplexNumbers numberOne, ComplexNumbers numberTwo)
        {
            return new ComplexNumbers(numberOne.A + numberTwo.A, numberOne.B + numberTwo.B).ToString();
        }

        public static string operator -(ComplexNumbers numberOne, ComplexNumbers numberTwo)
        {
            return new ComplexNumbers(numberOne.A - numberTwo.A, numberOne.B - numberTwo.B).ToString();
        }

        public static string operator *(ComplexNumbers numberOne, ComplexNumbers numberTwo)
        {
            return new ComplexNumbers((numberOne.A * numberTwo.A) + (numberOne.B * numberTwo.B * -1),
                (numberOne.A * numberTwo.B) + (numberOne.B * numberTwo.A)).ToString();
        }

        public static bool operator ==(ComplexNumbers numberOne, ComplexNumbers numberTwo)
        {
            return numberOne.A == numberTwo.A && numberOne.B == numberTwo.B;
        }

        public static bool operator !=(ComplexNumbers numberOne, ComplexNumbers numberTwo)
        {
            return numberOne.A != numberTwo.A && numberOne.B != numberTwo.B;
        }
    }
}
