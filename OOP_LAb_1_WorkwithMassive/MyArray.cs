using System;
using System.Collections.Generic;
using System.Linq;

class ArrayClass
{
    private List<int> _elements; /// Private field to store data

    /// <summary>
    /// Constructor
    /// </summary>
    public ArrayClass()
    {
        _elements = new List<int>();
    }

    public ArrayClass(List<int> elements)
    {
        _elements = elements;
    }

    /// <summary>
    /// Property to access private field
    /// </summary>
    public List<int> Elements
    {
        get { return _elements; }
        set { _elements = value; }
    }

    /// <summary>
    /// Method to input array elements
    /// </summary>
    /// <exception cref="Exception"></exception>
    public void InputElements()
    {
        Console.WriteLine("Enter array elements separated by spaces:");
        try
        {
            string input = Console.ReadLine();
            _elements = input.Split(' ').Select(int.Parse).ToList();
        }
        catch (FormatException)
        {
            throw new Exception("Input error: elements must be numbers.");
        }
    }

    /// <summary>
    /// Method to output array elements
    /// </summary>
    public void OutputElements()
    {
        Console.WriteLine("Array elements: " + string.Join(" ", _elements));
    }

    /// <summary>
    /// Method to calculate the special value (negative numbers at odd indices after the first positive)
    /// </summary>
    /// <returns></returns>
    public int CalculateSpecialValue()
    {
        bool foundFirstPositive = false;
        int count = 0;

        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i] > 0)
            {
                foundFirstPositive = true;
            }
            else if (foundFirstPositive && i % 2 != 0 && _elements[i] < 0)
            {
                count++;
            }
        }
        return count;
    }
}