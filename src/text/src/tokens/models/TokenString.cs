//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a sequence of null-delemited character sequences
    /// </summary>
    public readonly struct TokenString
    {
        [MethodImpl(Inline), Op]
        public static uint count(in TokenString src)
        {
            var counter = 0u;
            var data = src.Data;
            var length = data.Length;
            for(var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(data,i);
                if(SQ.@null(c))
                    counter++;
                else if(i == length-1 && counter != 0)
                    counter++;
            }
            return counter;
        }

        public readonly Index<char> Content;

        public TokenString(char[] src)
        {
            Content = src;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content.View;
        }

        /// <summary>
        /// The subsequence count
        /// </summary>
        public uint TokenCount
        {
            [MethodImpl(Inline)]
            get => count(this);
        }
    }
}