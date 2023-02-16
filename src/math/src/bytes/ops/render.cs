//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    unsafe partial class Bytes
    {
        /// <summary>
        /// Renders a value as a sequence of hex bytes
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target buffer</param>
        /// <param name="sep">The delimiter</param>
        /// <typeparam name="T">The source value type</typeparam>
        public static uint render<T>(T src, ITextEmitter dst, string sep = ", ")
            where T : unmanaged
        {
            var data = bytes(src);
            var count = data.Length;
            for(var i=count-1; i>= 0; i--)
            {
                ref readonly var @byte = ref skip(data,i);
                if(i != count-1)
                    dst.Append(sep);
                dst.Append(skip(data,i).FormatHex());
            }
            return (uint)count;
        }
    }
}