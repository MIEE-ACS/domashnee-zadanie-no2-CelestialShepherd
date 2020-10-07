using System;

namespace DZ_OOP_2
{
    class Program
    {
        //Функция, проверяющая ввод на число
        static double InputNumber(string input)
        {
            double num;
            if (double.TryParse(input, out num))
            {
                return num;
            }
            else
            {
                Console.WriteLine("Ошибка. Вы ввели текстовое сообщение. Попробуйте ещё раз");
                Console.Write("Ввод: ");
                return InputNumber(Console.ReadLine());
            }
        }
        //Функция, проверяющая корректный ввод числа X
        static double InputX(double x)
        {
            if (x < -4 || x > 10)
            {
                Console.WriteLine("Ошибка. Вы ввели число, лежащее вне диапазона. Попробуйте ещё раз");
                Console.Write("Ввод: ");
                return InputX(InputNumber(Console.ReadLine()));
            }
            else
                return x;
        }
        //Функция, проверяющая меньше или больше радиус введенный радиуса указанного на графике
        static int RadiusIsLessOrMore(double rInp, double rGiv)
        {
            if (rInp < rGiv)
                return 0;
            else if (rInp > rGiv)
                return 1;
            else
                return 2;
        }
        //Функция, определяющая промежуток функции, в которой лежит аргумент
        static int GetRegion(double x)
        {
            if (-4 <= x && x < -2)
                return 1;
            else if (-2 <= x && x < 4)
                return 2;
            else if (4 <= x && x < 6)
                return 3;
            else if (x == 6)
                return 4;
            else if (6 < x && x < 8)
                return 5;
            else if (x == 8)
                return 6;
            else if (x > 8 && x < 10)
                return 7;
            else
                return 8;
        }
        //Функция считающая значение функции на окружности
        static double CalculateY(double x, double r)
        {
            double y = Math.Sqrt(Math.Abs(Math.Pow(x - 8, 2) - Math.Pow(r, 2))) - 2;
            return y;
        }

        static void Main(string[] args)
        {
            double Y = 0;
            bool YIsInGapOrGetsTwoValues = false;
            Console.Write("Введите число R (R >= 0, в ином случае будет принят модуль полученного числа): ");
            double R = Math.Abs(InputNumber(Console.ReadLine()));
            int RadiusCheck = RadiusIsLessOrMore(R,2);
            Console.Write("Введите число X (-4 <= X <= 10): ");
            double X = InputX(InputNumber(Console.ReadLine()));
            switch (GetRegion(X))
            {
                case 1:
                    Y = X + 3;
                    break;
                case 2:
                    Y = -X / 2;
                    if (X == 0)
                        Y = Math.Abs(Y);
                    break;
                case 3:
                    Y = -2;
                    break;
                case 4:
                    if (RadiusCheck == 1 && X == 6)
                    {
                        YIsInGapOrGetsTwoValues = true;
                        Console.WriteLine("В данном случае, при X = {0:0.00}, функция принимает два значения:\r\nY = -2 и Y = {1:0.00}", X, Y);
                    }
                    else
                        Y = CalculateY(X, R);
                    break;
                case 5:
                    if (RadiusCheck == 0 && X < 8 - R)
                    {
                        YIsInGapOrGetsTwoValues = true;
                        Console.WriteLine("В данном случае, при X = {0:0.00} функция имеет разрыв", X);
                    }
                    else
                        Y = CalculateY(X, R);
                    break;
                case 6:
                    Y = R - 2;
                    break;
                case 7:
                    if (RadiusCheck == 0 && X > 8 + R)
                    {
                        YIsInGapOrGetsTwoValues = true;
                        Console.WriteLine("В данном случае, при X = {0:0.00} функция имеет разрыв", X);
                    }
                    else
                        Y = CalculateY(X, R);
                    break;
                case 8:
                    YIsInGapOrGetsTwoValues = true;
                    Console.WriteLine("X не лежит в указанном диапазоне. Пожалуйста перезапустите программу.");
                    break;
            }
            if (!YIsInGapOrGetsTwoValues)
                Console.WriteLine("Y = {0:0.00}", Y);
            Console.ReadKey();
        }
    }
}
