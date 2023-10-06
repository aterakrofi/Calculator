using Newtonsoft.Json;
using System;
using System.IO;

namespace CalculatorLibrary
{

    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculator.log");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();

        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }

        public static int count = 0;
        public void Counter()
        {
            count += 1;
            Console.WriteLine("This calculator was used {0} times.", count);
        }

        public string Operation(string operand)
        {
            string value = "";
            string sign = "";
            switch (operand)
            {
                case "a":
                    value = "Addition";
                    sign = "+";
                    break;
                case "m":
                    value = "Multiplication";
                    break;
                case "s":
                    value = "Subtraction";
                    break;
                case "d":
                    value = "Division";
                    break;

            }

            return value;
        }

        public string Sign(string operand)
        {

            string sign = "";
            switch (operand)
            {
                case "a":
                    sign = "+";
                    break;
                case "m":
                    sign = "*";
                    break;
                case "s":
                    sign = "-";
                    break;
                case "d":
                    sign = "/";
                    break;

            }

            return sign;
        }

        //Method to Delete History items



        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");
            // Use a switch statement to do the math.
            string answer, firstNumber, secondNumber, number;
            //Create a list to store history 

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    //convert numbers to string               
                    answer = result.ToString();
                    firstNumber = num1.ToString();
                    secondNumber = num2.ToString();
                    number = count.ToString();
                    //store data in list
                    string record = number + "." + "Addition :" + firstNumber + " + " + secondNumber + " = " + answer;

                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    answer = result.ToString();
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        writer.WriteValue("Divide");
                    }
                    break;
                case "h":

                // Return text for an incorrect option entry.
                default:
                    break;

            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }
    }
}
