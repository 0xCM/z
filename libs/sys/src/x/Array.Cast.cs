//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {                
        /// <summary>
        /// Populates a target array by casting each elements of a source aray to the target element type
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] Cast<T>(this object[] src)
        {
            var count = src.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                sys.seek(dst,i) = (T)sys.skip(src,i);
            return dst;
        }
    }
}