using System.Collections.Generic;

class ArrayClass
{
    private List<int> elements;

    public ArrayClass()
    {
        elements = new List<int>();
    }

    public ArrayClass(List<int> elements)
    {
        this.elements = elements;
    }

    /// <summary>
    /// Gets or sets the full list of elements in the array.
    /// </summary>
    public List<int> Elements
    {
        get => elements;
        set => elements = value;
    }

    /// <summary>
    /// Calculates how many negative numbers are at odd indices
    /// after the first positive number is encountered.
    /// </summary>
    public int CalculateSpecialValue()
    {
        bool foundFirstPositive = false;
        int count = 0;

        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i] > 0)
            {
                foundFirstPositive = true;
            }
            else if (foundFirstPositive && i % 2 != 0 && elements[i] < 0)
            {
                count++;
            }
        }

        return count;
    }
}
