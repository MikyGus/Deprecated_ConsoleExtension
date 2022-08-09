namespace ConsoleExtension.Library.DataModifiers;

public class StringModifier
{
    /// <summary>
    /// Shortens the string to maximum of length
    /// </summary>
    /// <param name="inputString">The string to be transformed</param>
    /// <param name="length">The maximum length of the string. -1 == do not truncate</param>
    /// <returns>The shorter string</returns>
    public string Truncate(string inputString, int length)
    {
        return length >= 0 && inputString.Length >= length ? inputString[..length] : inputString;
    }

    /// <summary>
    /// Adds padding before and after the provided string.
    /// </summary>
    /// <param name="data">Add padding to this string</param>
    /// <param name="alignment">-1 == left, 0 == center, 1 == right</param>
    /// <param name="columnWidth">The width of the final string</param>
    /// <param name="spaceFill">Character to fill with</param>
    /// <returns>A padded string</returns>
    public string Padding(string data, Alignment alignment = Alignment.LEFT, int columnWidth = 15, char spaceFill = '.')
    {
        int widthToFill = columnWidth - data.Length;
        (int left, int right) padding = PaddingWidth(alignment, widthToFill);

        data = new string(spaceFill, padding.left) + data + new string(spaceFill, padding.right);
        data = Truncate(data, columnWidth);

        return data;
    }

    public string Padding<T>(T data, Alignment alignment = Alignment.LEFT, int columnWidth = 15, char spaceFill = '.')
    {
        string value = data?.ToString() ?? string.Empty;
        return Padding(value, alignment, columnWidth, spaceFill);
    }
    private static (int left, int right) PaddingWidth(Alignment alignment, int widthToFill)
    {
        int leftWidth = 0;
        int rightWidth = 0;

        switch (alignment)
        {
            case Alignment.LEFT:
                rightWidth = widthToFill;
                break;
            case Alignment.CENTER:
                leftWidth = widthToFill / 2;
                rightWidth = widthToFill - leftWidth;
                break;
            case Alignment.RIGHT:
                leftWidth = widthToFill;
                break;
            default:
                break;
        }

        leftWidth = leftWidth < 0 ? 0 : leftWidth;
        rightWidth = rightWidth < 0 ? 0 : rightWidth;
        return (leftWidth, rightWidth);
    }
}
