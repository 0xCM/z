//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using XF = ExprPatterns;

    [ApiHost]
    public class Atomics
    {
        const NumericKind Closure = UnsignedInts;


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Atom<K> atom<K>(K value)
            => new Atom<K>(value);

        [Op, Closures(Closure)]
        public static Atoms<K> concat<K>(Atoms<K> a, Atoms<K> b)
        {
            var ka = a.Count;
            var kb = b.Count;
            var k=0u;
            var length = a.Count + b.Count;
            var dst = alloc<K>(length);
            for(var i=0; i<ka; i++)
                seek(dst,k++) = a[i];
            for(var i=0; i<kb; i++)
                seek(dst,k++) = b[i];
            return default;
        }

        public static string format<K>(Atoms<K> src)
        {
            var dst = text.buffer();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(" | ");
                dst.Append(src[i].Format());
            }
            return dst.Emit();
        }
    }
}
