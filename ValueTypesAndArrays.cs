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
        public static double UseNumber(int Number)
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
            Console.WriteLine($"PI is {Math.PI}");
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
                Console.Write("My estimated PI is ");
                double Difference = Math.Abs(1 - UseNumber(Number) / Math.PI);
                Console.WriteLine($"The difference between values is: {Difference}");
            }
        }
    }
}
// 1. Why do we multiply the value from step 5 above by 4?
//    Answer: You are only using 1/4th of the circle. By multiplying by four you approximate it better.

// 2. What do you observe in the output when running your program with parameters of increasing size?
//    Answer: When I would input larger numbers my estimate of PI became closer to the actual value of PI.

// 3. If you run the program multiple times with the same parameter, does the output remain the same? Why or why not?
//    Answer: No it doesnt because of the random numbers used.

// 4. Find a parameter that requires multiple seconds of run time.What is that parameter? How accurate is the estimated value of ?
//    Answer: When I input 3,000,000 the difference between my estimated PI and PI because much smaller. 0.000165313096722963.

// 5. Research one other use of Monte-Carlo methods. Record it in your exercise submission and be prepared to discuss it in class.
//    Another use for the MonteCarlo method could be by randomly generate numbers, apply a constraint to them to then estimate the probability of an event occuring.