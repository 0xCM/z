//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Symbols
{
    public static Index<SymKindRow> symkinds<K>()
        where K : unmanaged, Enum
    {
        var src = Symbols.index<K>();
        var count = src.Count;
        var dst = sys.alloc<SymKindRow>(count);
        symkinds(src, dst);
        return dst;
    }

    public static uint symkinds<K>(in Symbols<K> src, Span<SymKindRow> dst)
        where K : unmanaged
    {
        var symbols = src.View;
        var count = (uint)min(symbols.Length, dst.Length);
        var type = typeof(K).Name;
        for(var i=0; i<count; i++)
        {
            ref var target = ref seek(dst,i);
            ref readonly var symbol = ref skip(symbols,i);
            target.Index = symbol.Key;
            target.Value = bw64(symbol.Kind);
            target.Type = type;
            target.Name = symbol.Name;
        }
        return count;
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint kinds<T>(Symbols<T> src, Span<T> dst)
        where T : unmanaged
    {
        var count = (uint)min(src.Length,dst.Length);
        var view = src.Kinds;
        for(var i=0u; i<count; i++)
            seek(dst,i) = skip(view,i);
        return count;
    }

    public static ReadOnlySpan<K> kinds<K>()
        where K : unmanaged, Enum
            => index<K>().Kinds;
}
