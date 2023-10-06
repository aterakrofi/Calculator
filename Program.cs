using System;
using CalculatorLibrary;
using System.Collections.Generic;
namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");
            Calculator calculator = new Calculator();
            var rec = new List<string>();
            int number = -1;
            string sign = " ";
            while (!endApp)
            {

                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");

                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");

                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
                Console.WriteLine("------------------------------------------------------------------------------\n");
                calculator.Counter();
                Console.WriteLine("------------------------------------------------------------------------------\n");

                Console.WriteLine(" History of Operation : (Y/N) ? ");
                string answer = result.ToString();
                number++;

                string selectedOp = calculator.Operation(op);
                string symbol = calculator.Sign(op);
                string record = number + " . " + selectedOp + " => " + numInput1 + " " + symbol + " " + numInput2 + " = " + answer;

                rec.Add(record);
                for (int i = 0; i < rec.Count; i++) { Console.WriteLine(rec[i]); }

                //Perform Deletions

                //Delete At any position 
                Console.WriteLine(" Select Number to perform Delete Operation : ");
                Console.Write(" 1. Index of record to Delete :  \n");
                Console.Write(" 2. Delete All records ):  \n");
                Console.Write(" 3. Index of recod to use to perform new operation :  \n");

                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        for (int i = 0; i < rec.Count; i++)
                        {
                            rec.RemoveAt(record.Length - 1);
                            Console.WriteLine(rec[i]);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < rec.Count; i++)
                        {
                            rec.Clear();
                            Console.WriteLine(rec[i]);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < rec.Count; i++)
                        {


                            Console.WriteLine(rec[userInput]);
                        }
                        break;


                        Console.WriteLine("-----------------------------END OF DELETE OPERATIONS-----------------------------------\n");
                        // Wait for the user to respond before closing.
                        Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");


                        Console.WriteLine("------------------------------------------------------------------------------\n");


                        //Delete All, 
                        //Selection operation to perform
                        //Back to regular flow==> Press 'n'

                }

                //Print answer print.
                Console.WriteLine("------------------------------------------------------------------------------\n");

                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            //Add call to close the JSON writer before return

            calculator.Finish();
            return;
        }
    }
}
