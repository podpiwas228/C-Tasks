using System.Collections.Generic;

class ArrayClass
{
    // Private field for storing array elements
    private List<int> elements;

    // Constructor initializes empty array
    public ArrayClass()
    {
        elements = new List<int>();
    }

    // Constructor initializes array with given elements
    public ArrayClass(List<int> elements)
    {
        this.elements = elements;
    }

    // Property for accessing all array elements
    public List<int> Elements
    {
        get { return elements; }
        set { elements = value; }
    }

    // Method to calculate special value (negative numbers at odd indices after the first positive)
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
