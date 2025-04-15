using System.Collections.Generic;

class ArrayClass
{
    /// <summary>
    /// Private field that stores a list of integers (List<int>).
    /// This field is used to hold the elements in the ArrayClass object.
    /// </summary>
    private List<int> elements;

    /// <summary>
    /// Initializes a new instance of the ArrayClass and creates an empty list.
    /// </summary>
    public ArrayClass()
    {
        elements = new List<int>();
    }

    /// <summary>
    /// Initializes a new instance of the ArrayClass with the provided list of elements.
    /// </summary>
    /// <param name="elements">A list of integers that will be used to initialize the elements field.</param>
    public ArrayClass(List<int> elements)
    {
        this.elements = elements;
    }

    /// <summary>
    /// Gets or sets the full list of elements in the array.
    /// </summary>
    /// <value>The complete list of elements as a List<int>.</value>
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
