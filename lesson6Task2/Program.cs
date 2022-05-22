using System;

namespace lesson6Task2
{
    class Program
    {
        static void Main()
        {
            var point = new Point() { X = 5, Y = 5, Color = ConsoleColor.Red, Hidden = false };
            var circle = new Circle() { X = 7, Y = 7, Radius = 5, Color = ConsoleColor.Green, Hidden = true };
            var rectangle = new Rectangle() { X = 10, Y = 10, Width = 5, Height = 10, Color = ConsoleColor.Blue, Hidden = false };

            point.Draw();
            Console.WriteLine();
            circle.Draw();
            Console.WriteLine($"Площадь окружности: {circle.CircleArea()}\n");
            rectangle.Draw();
            Console.WriteLine($"Площадь прямоугольника: {rectangle.RectangleArea()}\n");

            point.HorizontalShift(2);
            point.VerticalShift(-3);
            point.Draw();
            Console.WriteLine();

            rectangle.EditColor(ConsoleColor.Cyan);
            rectangle.Draw();
        }
    }

    /// <summary>
    /// Геометрические фигуры
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Цвет фигуры
        /// </summary>
        public ConsoleColor Color { get; set; }

        /// <summary>
        /// Состояние «видимое/невидимое»
        /// </summary>
        public bool Hidden { get; set; }

        public virtual void Draw()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Точка" +
                $"\nЦвет: {Color}" +
                $"\nСостояние: {IsHidden()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void EditColor(ConsoleColor color)
        {
            Color = color;
        }

        public string IsHidden()
        {
            return Hidden ? "Невидимое" : "Видимое";
        }
    }

    /// <summary>
    /// Точка
    /// </summary>
    public class Point : Figure
    {
        public int X { get; set; }
        
        public int Y { get; set; }

        public override void Draw()
        {
            Console.ForegroundColor = Color;
            var isHidden = Hidden ? "Невидимое" : "Видимое";
            Console.WriteLine("Точка" +
                $"\nX: {X}; Y: {Y}" +
                $"\nЦвет: {Color}" +
                $"\nСостояние: {isHidden}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void HorizontalShift(int x)
        {
            X += x;
        }

        public void VerticalShift(int y)
        {
            Y += y;
        }
    }

    /// <summary>
    /// Окружность
    /// </summary>
    public class Circle : Point
    {
        public double Radius { get; set; }

        public override void Draw()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Круг" +
                $"\nX: {X}; Y: {Y}" +
                $"\nРадиус: {Radius}" +
                $"\nЦвет: {Color}" +
                $"\nСостояние: {IsHidden()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public double CircleArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    /// <summary>
    /// Прямоугольник
    /// </summary>
    public class Rectangle : Point
    {
        /// <summary>
        /// Ширина
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        public int Height { get; set; }

        public override void Draw()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("Прямоугольник" +
                $"\nX: {X}; Y: {Y}" +
                $"\nШирина: {Width}" +
                $"\nВысота: {Height}" +
                $"\nЦвет: {Color}" +
                $"\nСостояние: {IsHidden()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public int RectangleArea()
        {
            return Width * Height;
        }
    }
}
