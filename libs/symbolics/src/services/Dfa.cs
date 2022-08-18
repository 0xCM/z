//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct Dfa
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DfaState<T> state<T>(uint key, T src)
            where T : unmanaged
                => new DfaState<T>(key, src);

        [Op]
        public static Index<DfaState<uint>> states(W32 w, uint count)
        {
            var dst = alloc<DfaState<uint>>(count);
            for(var i=0u; i<count; i++)
                seek(dst,i) = state(i, (uint)(i + 1));
            return dst;
        }

        public static Index<DfaState<K>> states<K>()
            where K : unmanaged, Enum
        {
            var syms = Symbols.index<K>();
            var view = syms.View;
            var count = syms.Count;
            var dst = alloc<DfaState<K>>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var s = ref skip(view,i);
                seek(dst,i) = state(i, s.Kind);
            }
            return dst;
        }

        /// <summary>
        /// Creates a sequence of states predicated on a sequence of characters
        /// </summary>
        /// <param name="src"></param>
        public static Index<DfaState<char>> states(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var dst = alloc<DfaState<char>>(count);
            for(var i=0u; i<count; i++)
                seek(dst,i) = state(i, skip(src,i));
            return dst;
        }
    }
}