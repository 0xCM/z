//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;

    partial class SRM
    {
        unsafe partial struct MemoryBlock
        {
            [MethodImpl(Inline), Op]
            public int Utf8NullTerminatedOffsetOfAsciiChar(int startOffset, char asciiChar)
            {
                //Available(startOffset, 0);

                Debug.Assert(asciiChar != 0 && asciiChar <= 0x7f);

                for (int i = startOffset; i < Length; i++)
                {
                    byte b = Pointer[i];

                    if (b == 0)
                        break;

                    if (b == asciiChar)
                        return i;
                }

                return -1;
            }

            /// <summary>
            /// Get number of bytes from offset to given terminator, null terminator, or end-of-block (whichever comes first).
            /// Returned length does not include the terminator, but numberOfBytesRead out parameter does.
            /// </summary>
            /// <param name="offset">Offset in to the block where the UTF8 bytes start.</param>
            /// <param name="terminator">A character in the ASCII range that marks the end of the string.
            /// If a value other than '\0' is passed we still stop at the null terminator if encountered first.</param>
            /// <param name="numberOfBytesRead">The number of bytes read, which includes the terminator if we did not hit the end of the block.</param>
            /// <returns>Length (byte count) not including terminator.</returns>
            [MethodImpl(Inline), Op]
            public int GetUtf8NullTerminatedLength(int offset, out int numberOfBytesRead, char terminator = '\0')
            {
                byte* start = Pointer + offset;
                byte* end = Pointer + Length;
                byte* current = start;

                while (current < end)
                {
                    byte b = *current;
                    if (b == 0 || b == terminator)
                        break;

                    current++;
                }

                int length = (int)(current - start);
                numberOfBytesRead = length;
                if (current < end)
                {
                    // we also read the terminator
                    numberOfBytesRead++;
                }

                return length;
            }


            public int CompareUtf8NullTerminatedStringWithAsciiString(int offset, string asciiString)
            {
                // Assumes stringAscii only contains ASCII characters and no nil characters.

                Available(offset, 0);

                byte* p = Pointer + offset;
                int limit = Length - offset;

                for (int i = 0; i < asciiString.Length; i++)
                {
                    Debug.Assert(asciiString[i] > 0 && asciiString[i] <= 0x7f);

                    if (i > limit)
                    {
                        // Heap value is shorter.
                        return -1;
                    }

                    if (*p != asciiString[i])
                    {
                        // If we hit the end of the heap value (*p == 0)
                        // the heap value is shorter than the string, so we return negative value.
                        return *p - asciiString[i];
                    }

                    p++;
                }

                // Either the heap value name matches exactly the given string or
                // it is longer so it is considered "greater".
                return (*p == 0) ? 0 : +1;
            }

            /// <summary>
            /// Read UTF8 at the given offset up to the given terminator, null terminator, or end-of-block.
            /// </summary>
            /// <param name="offset">Offset in to the block where the UTF8 bytes start.</param>
            /// <param name="prefix">UTF8 encoded prefix to prepend to the bytes at the offset before decoding.</param>
            /// <param name="utf8Decoder">The UTF8 decoder to use that allows user to adjust fallback and/or reuse existing strings without allocating a new one.</param>
            /// <param name="numberOfBytesRead">The number of bytes read, which includes the terminator if we did not hit the end of the block.</param>
            /// <param name="terminator">A character in the ASCII range that marks the end of the string.
            /// If a value other than '\0' is passed we still stop at the null terminator if encountered first.</param>
            /// <returns>The decoded string.</returns>
            [Op]
            public string PeekUtf8NullTerminated(int offset, byte[]? prefix, MetadataStringDecoder utf8Decoder, out int numberOfBytesRead, char terminator = '\0')
            {
                Debug.Assert(terminator <= 0x7F);
                Available(offset, 0);
                int length = GetUtf8NullTerminatedLength(offset, out numberOfBytesRead, terminator);
                return EncodingHelper.DecodeUtf8(Pointer + offset, length, prefix, utf8Decoder);
            }

            // comparison stops at null terminator, terminator parameter, or end-of-block -- whichever comes first.
            [Op]
            public bool Utf8NullTerminatedEquals(int offset, string text, MetadataStringDecoder utf8Decoder, char terminator, bool ignoreCase)
            {
                int firstDifference;
                FastComparisonResult result = Utf8NullTerminatedFastCompare(offset, text, 0, out firstDifference, terminator, ignoreCase);

                if (result == FastComparisonResult.Inconclusive)
                {
                    int bytesRead;
                    string decoded = PeekUtf8NullTerminated(offset, null, utf8Decoder, out bytesRead, terminator);
                    return decoded.Equals(text, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                }

                return result == FastComparisonResult.Equal;
            }

            // comparison stops at null terminator, terminator parameter, or end-of-block -- whichever comes first.
            public bool Utf8NullTerminatedStartsWith(int offset, string text, MetadataStringDecoder utf8Decoder, char terminator, bool ignoreCase)
            {
                int endIndex;
                FastComparisonResult result = Utf8NullTerminatedFastCompare(offset, text, 0, out endIndex, terminator, ignoreCase);

                switch (result)
                {
                    case FastComparisonResult.Equal:
                    case FastComparisonResult.BytesStartWithText:
                        return true;

                    case FastComparisonResult.Unequal:
                    case FastComparisonResult.TextStartsWithBytes:
                        return false;

                    default:
                        Debug.Assert(result == FastComparisonResult.Inconclusive);
                        int bytesRead;
                        string decoded = PeekUtf8NullTerminated(offset, null, utf8Decoder, out bytesRead, terminator);
                        return decoded.StartsWith(text, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                }
            }

            public enum FastComparisonResult
            {
                Equal,

                BytesStartWithText,

                TextStartsWithBytes,

                Unequal,

                Inconclusive
            }

            // comparison stops at null terminator, terminator parameter, or end-of-block -- whichever comes first.
            public FastComparisonResult Utf8NullTerminatedFastCompare(int offset, string text, int textStart, out int firstDifferenceIndex, char terminator, bool ignoreCase)
            {
                Available(offset, 0);

                Debug.Assert(terminator <= 0x7F);

                byte* startPointer = Pointer + offset;
                byte* endPointer = Pointer + Length;
                byte* currentPointer = startPointer;

                int ignoreCaseMask = StringUtils.IgnoreCaseMask(ignoreCase);
                int currentIndex = textStart;
                while (currentIndex < text.Length && currentPointer != endPointer)
                {
                    byte currentByte = *currentPointer;

                    // note that terminator is not compared case-insensitively even if ignore case is true
                    if (currentByte == 0 || currentByte == terminator)
                    {
                        break;
                    }

                    char currentChar = text[currentIndex];
                    if ((currentByte & 0x80) == 0 && StringUtils.IsEqualAscii(currentChar, currentByte, ignoreCaseMask))
                    {
                        currentIndex++;
                        currentPointer++;
                    }
                    else
                    {
                        firstDifferenceIndex = currentIndex;

                        // uncommon non-ascii case --> fall back to slow allocating comparison.
                        return (currentChar > 0x7F) ? FastComparisonResult.Inconclusive : FastComparisonResult.Unequal;
                    }
                }

                firstDifferenceIndex = currentIndex;

                bool textTerminated = currentIndex == text.Length;
                bool bytesTerminated = currentPointer == endPointer || *currentPointer == 0 || *currentPointer == terminator;

                if (textTerminated && bytesTerminated)
                {
                    return FastComparisonResult.Equal;
                }

                return textTerminated ? FastComparisonResult.BytesStartWithText : FastComparisonResult.TextStartsWithBytes;
            }

            // comparison stops at null terminator, terminator parameter, or end-of-block -- whichever comes first.
            [Op]
            public bool Utf8NullTerminatedStringStartsWithAsciiPrefix(int offset, string asciiPrefix)
            {
                // Assumes stringAscii only contains ASCII characters and no nil characters.

                Available(offset, 0);

                // Make sure that we won't read beyond the block even if the block doesn't end with 0 byte.
                if (asciiPrefix.Length > Length - offset)
                {
                    return false;
                }

                byte* p = Pointer + offset;

                for (int i = 0; i < asciiPrefix.Length; i++)
                {
                    Debug.Assert(asciiPrefix[i] > 0 && asciiPrefix[i] <= 0x7f);

                    if (asciiPrefix[i] != *p)
                    {
                        return false;
                    }

                    p++;
                }

                return true;
            }


            string GetDebuggerDisplay()
            {
                if (Pointer == null)
                {
                    return "<null>";
                }

                int displayedBytes;
                return GetDebuggerDisplay(out displayedBytes);
            }

            public string GetDebuggerDisplay(out int displayedBytes)
            {
                displayedBytes = Math.Min(Length, 64);
                string result = BitConverter.ToString(PeekBytes(0, displayedBytes));
                if (displayedBytes < Length)
                    result += "-...";
                return result;
            }

            public string GetDebuggerDisplay(int offset)
            {
                if (Pointer == null)
                {
                    return "<null>";
                }

                int displayedBytes;
                string display = GetDebuggerDisplay(out displayedBytes);
                if (offset < displayedBytes)
                {
                    display = display.Insert(offset * 3, "*");
                }
                else if (displayedBytes == Length)
                {
                    display += "*";
                }
                else
                {
                    display += "*...";
                }

                return display;
            }
        }
    }
}