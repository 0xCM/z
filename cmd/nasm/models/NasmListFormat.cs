//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct NasmListFormat
    {
        /// <summary>
        /// The index at which the entry sequence number begins
        /// </summary>
        public const byte EntrySeqIndex = 0;

        /// <summary>
        /// The number of digits allocated for a list entry number
        /// </summary>
        public const byte EntrySeqWidth = 6;

        /// <summary>
        /// The index at which the list line offset begins = 8
        /// </summary>
        public const byte OffsetIndex = EntrySeqIndex + EntrySeqWidth + 2;

        /// <summary>
        /// The number of digits allocated for a list line offset
        /// </summary>
        public const byte OffsetWidth = 8;

        /// <summary>
        /// The index at which the encoding begins = 8 + 8 + 2 = 18
        /// </summary>
        public const byte EncodingIndex = OffsetIndex + OffsetWidth + 2;

        /// <summary>
        /// The number of hex digits allocated for the encoding of a listed instruction, from nasm/asm/listing.c.
        /// If the encoding exceeds this limit, the encoding will continue on the next line
        /// </summary>
        public const byte EncodingWidth = 18;

        /// <summary>
        ///  The index of the encoding continuation character, if present = 35
        /// </summary>
        public const byte ContinuationIndex = EncodingIndex + EncodingWidth - 1;

        /// <summary>
        /// The number of characters the precede a listed instruction, from nasm/asm/listing.c
        /// </summary>
        public const byte DataWidth = 40;

        /// <summary>
        /// The continuation character
        /// </summary>
        public const char ContinuationMarker = '-';

        [MethodImpl(Inline), Op]
        public static bool @continue(ReadOnlySpan<char> src)
            => src.Length > NasmListFormat.ContinuationIndex && skip(src,NasmListFormat.ContinuationIndex) == NasmListFormat.ContinuationMarker;

        public static Outcome seq(ReadOnlySpan<char> src, out uint dst)
        {
            dst = 0;
            var length = src.Length;
            if(length < EntrySeqWidth)
                return (false,"The data source is of insufficent length");
            else
                return uint.TryParse(slice(src,0, EntrySeqWidth), out dst);
        }

    }


//    10 00000014 4420C0                  and al,r8b
//    11 00000017 4420C8                  and al,r9b
//    12 0000001A 4420D0                  and al,r10b
//    13 0000001D 4420D8                  and al,r11b
//    14 00000020 4420E0                  and al,r12b
//    15 00000023 4420E8                  and al,r13b
//    16 00000026 4420F0                  and al,r14b
//    17 00000029 4420F8                  and al,r15b

//     2 00000000 48B880F33099FA7F00-     mov rax,7ffa9930f380h
//     2 00000009 00
//     3 0000000A 48B980F33099FA7F00-     mov rcx,7ffa9930f380h
//     3 00000013 00
//     4 00000014 48BA80F33099FA7F00-     mov rdx,7ffa9930f380h
//     4 0000001D 00

}