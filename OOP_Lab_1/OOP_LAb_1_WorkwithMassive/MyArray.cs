using System;
using System.Linq;

namespace Task1
{
    public class MyArray
    {
        private int[] array;

        public MyArray()
        {
            array = new int[0];
        }

        public MyArray(int[] arr)
        {
            array = arr;
        }

        public int[] Array => (int[])array.Clone();

        public void InputFromKeyboard()
        {
            Console.WriteLine("Enter elements separated by spaces:");
            string input = Console.ReadLine() ?? throw new ArgumentException("Input cannot be null.");
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("Input cannot be empty.");

            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            array = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out int num))
                    throw new FormatException($"Invalid element: {parts[i]}");
                array[i] = num;
            }
        }

        public void Print()
        {
            Console.WriteLine(string.Join(" ", array));
        }

        public int FindMinIndex()
        {
            if (array.Length == 0) throw new InvalidOperationException("Array is empty.");
            return System.Array.IndexOf(array, array.Min());
        }

        public int FindMaxIndex()
        {
            if (array.Length == 0) throw new InvalidOperationException("Array is empty.");
            return System.Array.IndexOf(array, array.Max());
        }

        public MyArray FormArrayC(MyArray arrayB, int givenIndex)
        {
            int leftMinB = arrayB.FindMinIndex();
            int[] partB = arrayB.Array[(leftMinB + 1)..];

            int rightMinA = this.FindMinIndex();
            if (givenIndex < 0 || givenIndex >= this.Array.Length)
                throw new IndexOutOfRangeException("Given index is out of range for array A.");

            int start = Math.Min(rightMinA, givenIndex) + 1;
            int end = Math.Max(rightMinA, givenIndex) - 1;
            int[] partA = start <= end ? this.Array[start..(end + 1)] : new int[0];

            return new MyArray(partB.Concat(partA).ToArray());
        }

        public int CountNegativeOnOddPositionsAfterFirstPositive()
        {
            int firstPositiveIndex = System.Array.IndexOf(array, array.FirstOrDefault(x => x > 0));
            if (firstPositiveIndex == -1)
                throw new InvalidOperationException("No positive numbers in the array.");

            int count = 0;
            for (int i = firstPositiveIndex + 1; i < array.Length; i++)
            {
                if (i % 2 != 0 && array[i] < 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
