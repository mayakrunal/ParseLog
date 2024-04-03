namespace ParseLog;

public static class StringExtensions
{

    /// <summary>
    /// Helper method to find the Index of the Nth Occurrence of the specific character
    /// </summary>
    /// <param name="str">String to from which to find the index</param>
    /// <param name="value">The character to search</param>
    /// <param name="nth">The nth occurence number</param>
    /// <returns>returns the index of the nth occurence</returns>
    public static int IndexOfNth(this string str, char value, int nth = 1)
    {
        if (nth < 1) throw new ArgumentException("Can not find a negative index of substring in string. Must start with 0");

        int offset = 0;
        for (int i = 1; i <= nth; i++)
        {
            offset = str.IndexOf(value, offset + 1);
            if (offset == -1) return -1;
        }

        return offset;
    }
}
