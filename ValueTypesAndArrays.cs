using System;

namespace MonteCarlo
{
    public class ValueTypesAndArrays
    {
        public struct Coordinate
        {
            double x;
            double y;
            public Coordinate(int X, int Y)
            {
                x = X;
                y = Y;
            }
            public Coordinate(Random R)
            {
                x = R.NextDouble();
                y = R.NextDouble();
            }
            public double Hypotenuse() => Math.Sqrt((x * x) + (y * y));
        }
        public static int GetNumber()
        {
            int Value = 0;
            bool Exit = false;
            do
            {
                string UserInput = Console.ReadLine();
                bool Check = int.TryParse(UserInput, out _);
                if (Check == true)
                {
                    Value = int.Parse(UserInput);
                    if (Value > 0)
                    {
                        Exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid number, try again: ");
                    }
                }
                else
                {
                    Console.Write("Not a number, try again: ");
                }
            } while (Exit == false);
            return Value;
        }
        public static double GetAnotherNumber(int Number)
        {
            Coordinate[] coordinates = new Coordinate[Number];
            int Counter = 0;
            Random R = new Random();
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = new Coordinate(R);
                //coordinates[i] = new Coordinate(R.Next(), R.Next());
                if (coordinates[i].Hypotenuse() <= 1.0)
                {
                    Counter++;
                }
            }
            double Pi = ((double)Counter / coordinates.Length) * 4;
            Console.WriteLine(Pi);
            return Pi;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Monte Carlo Method");
            //Since the Excersice wants the numbers 10, 100, 1000, and 10000 to be passed I used the for loop
            //and set the length to 4 so that I can pass those 4 numbers.
            for (int i = 0; i < 4; i++)
            {
                Console.Write("\nInput the length ");
                int Number = GetNumber();
                Console.Write("PI is ");
                double Difference = Math.Abs(1 - GetAnotherNumber(Number) / Math.PI);
                Console.WriteLine($"The difference between values is: {Difference}");
            }
        }
    }
}
