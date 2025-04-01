using System;
using Task1;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            try
            {
                MyArray arrayA = new MyArray();
                MyArray arrayB = new MyArray();

                Console.WriteLine("Enter elements for Array A:");
                arrayA.InputFromKeyboard();
                Console.WriteLine("Enter elements for Array B:");
                arrayB.InputFromKeyboard();

                int variantNumber = 8;

                MyArray arrayC = arrayA.FormArrayC(arrayB, variantNumber);
                Console.Write("Array C: ");
                arrayC.Print();

                Console.WriteLine("Task 1:");
                int negativeCount = arrayA.CountNegativeOnOddPositionsAfterFirstPositive();
                Console.WriteLine($"Count of negative numbers on odd positions after first positive in Array A: {negativeCount}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
// 12 -5 7 -2 4 -8 9 -3 15 numbers to check
// 5 8 - 6 - 9 10 3 - 7 - 4 2 numbers to check
