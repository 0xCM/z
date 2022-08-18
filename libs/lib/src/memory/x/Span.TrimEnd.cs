//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        /// <summary>
        /// Eliminates trailing zeros in the source span
        /// </summary>
        /// <param name="src">The source span</param>
        [Op]
        public static Span<byte> TrimEnd(this Span<byte> src)
        {
            var length = src.Length;
            for(var i= length - 1; i>=0; i--)
            {
                if(skip(src,(uint)i) != 0)
                    return slice(src, 0, length);
            }
            return default;
        }
    }
}