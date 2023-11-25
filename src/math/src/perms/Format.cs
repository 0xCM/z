//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XTend
{
    /// <summary>
    /// Formats the terms of a permutation
    /// </summary>
    /// <param name="terms">The permutation terms</param>
    /// <param name="colwidth">The width of each column</param>
    /// <typeparam name="T">The term type</typeparam>
    public static string FormatAsPerm<T>(this Span<T> terms,  int? colwidth = null)
        => terms.ReadOnly().FormatAsPerm(colwidth);

    /// <summary>
    /// Formats the terms of a permutation
    /// </summary>
    /// <param name="terms">The permutation terms</param>
    /// <param name="colwidth">The width of each column</param>
    /// <typeparam name="T">The term type</typeparam>
    public static string FormatAsPerm<T>(this ReadOnlySpan<T> terms, int? colwidth = null)
    {
        var line1 = text.build();
        var line2 = text.build();
        var pad = colwidth ?? 3;
        var leftBoundary = $"{Chars.Pipe}";
        var rightBoundary = $"{Chars.Pipe}".PadLeft(2);

        line1.Append(leftBoundary);
        line2.Append(leftBoundary);
        for(var i=0; i < terms.Length; i++)
        {
            line1.Append($"{i}".PadLeft(pad));
            line2.Append($"{terms[i]}".PadLeft(pad));
        }
        line1.Append(rightBoundary);
        line2.Append(rightBoundary);

        return line1.ToString() + Eol + line2.ToString();
    }
}
