//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class text
    {
        /// <summary>
        /// Computes the total length of the source strings
        /// </summary>
        /// <param name="src">The source strings</param>
        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<string> src)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
                counter += (uint)skip(src,i).Length;
            return counter;
        }

        /// <summary>
        /// Returns the number of characters that precede a null-terminator, if any; otherwise returns the lenght of the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<char> src)
            => UQ.length(src);

        /// <summary>
        /// Determines the length of a specified <see cref='string'/>
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static int length(string src)
            => src?.Length ?? 0;

        /// <summary>
        /// Computes the number of pointer-identified characters that precede a null-terminator
        /// </summary>
        /// <param name="pSrc">The location of the first character</param>
        [MethodImpl(Inline), Op]
        public static unsafe int length(char* pSrc)
        {
            if(pSrc == null)
                return 0;

            var p = pSrc;
            while(*p != Chars.Null)
                p++;
            return (int)(p - pSrc);
        }

        /// <summary>
        /// Computes the number of pointer-identified (asci) characters that precede a null-terminator
        /// </summary>
        /// <param name="pSrc">The location of the first character</param>
        [MethodImpl(Inline), Op]
        public static unsafe int length(byte* pSrc)
        {
            if(pSrc == null)
                return 0;

            var p = pSrc;
            while(*p != Chars.Null)
                p++;

            return (int)(p - pSrc);
        }
    }
}