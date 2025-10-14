using System;

namespace EllipseTask
{
    // 🔹 Базовий клас: крива другого порядку
    // Загальне рівняння: a11*x^2 + 2*a12*x*y + a22*y^2 + b1*x + b2*y + c = 0
    class QuadraticCurve
    {
        protected double a11, a12, a22, b1, b2, c;

        // Метод для задання коефіцієнтів
        public virtual void SetCoefficients()
        {
            Console.WriteLine("Введіть коефіцієнти для кривої другого порядку:");
            Console.Write("a11 = ");
            a11 = double.Parse(Console.ReadLine());
            Console.Write("a12 = ");
            a12 = double.Parse(Console.ReadLine());
            Console.Write("a22 = ");
            a22 = double.Parse(Console.ReadLine());
            Console.Write("b1 = ");
            b1 = double.Parse(Console.ReadLine());
            Console.Write("b2 = ");
            b2 = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            c = double.Parse(Console.ReadLine());
        }

        // Метод для виведення коефіцієнтів
        public virtual void DisplayCoefficients()
        {
            Console.WriteLine("\nКоефіцієнти кривої другого порядку:");
            Console.WriteLine($"a11 = {a11}, a12 = {a12}, a22 = {a22}, b1 = {b1}, b2 = {b2}, c = {c}");
        }

        // Метод для перевірки, чи належить точка кривій
        public virtual bool IsPointOnCurve(double x, double y)
        {
            double value = a11 * x * x + 2 * a12 * x * y + a22 * y * y + b1 * x + b2 * y + c;
            return Math.Abs(value) < 1e-6;
        }
    }

    // 🔹 Похідний клас: еліпс
    // Рівняння: (x² / a²) + (y² / b²) = 1
    class Ellipse : QuadraticCurve
    {
        private double a, b; // півосі еліпса

        // Перевизначення методу для введення коефіцієнтів
        public override void SetCoefficients()
        {
            Console.WriteLine("\nВведіть параметри еліпса:");
            Console.Write("a (піввісь по осі X) = ");
            a = double.Parse(Console.ReadLine());
            Console.Write("b (піввісь по осі Y) = ");
            b = double.Parse(Console.ReadLine());

            // Перетворення рівняння еліпса у загальне рівняння кривої другого порядку:
            // (x² / a²) + (y² / b²) = 1 → (1/a²)x² + (1/b²)y² - 1 = 0
            a11 = 1 / (a * a);
            a12 = 0;
            a22 = 1 / (b * b);
            b1 = 0;
            b2 = 0;
            c = -1;
        }

        // Перевизначення методу для виведення коефіцієнтів
        public override void DisplayCoefficients()
        {
            Console.WriteLine("\nПараметри еліпса:");
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"Рівняння еліпса: (x^2 / {a * a}) + (y^2 / {b * b}) = 1");
            base.DisplayCoefficients(); // викликає виведення коефіцієнтів із базового класу
        }

        // Перевизначення методу для перевірки належності точки
        public override bool IsPointOnCurve(double x, double y)
        {
            double value = (x * x) / (a * a) + (y * y) / (b * b);
            return Math.Abs(value - 1) < 1e-6;
        }
    }

    // 🔹 Основна програма
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ПРОГРАМА: Еліпс як крива другого порядку ===");

            // Створення об’єкта еліпса
            Ellipse ellipse = new Ellipse();

            // Введення параметрів еліпса
            ellipse.SetCoefficients();

            // Виведення коефіцієнтів
            ellipse.DisplayCoefficients();

            // Введення координат точки
            Console.WriteLine("\nВведіть координати точки (x, y):");
            Console.Write("x = ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y = ");
            double y = double.Parse(Console.ReadLine());

            // Перевірка належності точки
            if (ellipse.IsPointOnCurve(x, y))
                Console.WriteLine($"\nТочка ({x}, {y}) належить даному еліпсу.");
            else
                Console.WriteLine($"\nТочка ({x}, {y}) не належить даному еліпсу.");

            Console.WriteLine("\n=== Кінець роботи програми ===");
        }
    }
}
