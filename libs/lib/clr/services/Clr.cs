//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct Clr
    {
        const NumericKind Closure = UnsignedInts;

        const BindingFlags BF = ReflectionFlags.BF_All;

        [Op, Closures(Closure)]
        public static void values<T>(in T src, ReadOnlySpan<ClrFieldAdapter> fields, Span<ClrFieldValue> dst)
            where T : struct
        {
            ref var target = ref first(dst);
            var tRef = __makeref(edit(src));
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(target,i) = new ClrFieldValue(f, f.GetValueDirect(tRef));
            }
        }
    }
}