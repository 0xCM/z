//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public struct CellEmitter<F> : IValueSource<F>
    where F : struct, IDataCell
{
    readonly ISource DataSource;

    [MethodImpl(Inline)]
    public CellEmitter(ISource source)
        => DataSource = source;

    [MethodImpl(Inline)]
    public F Next()
        => select(w8);

    public ByteSize Fill(Span<F> dst)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next();
        return size;
    }

    public bool Next(out F dst)
    {
        dst = Next();
        return true;
    }

    [MethodImpl(Inline)]
    F select(W8 w)
    {
        if(typeof(F) == typeof(Cell8))
            return pull(w8);
        else if(typeof(F) == typeof(Cell16))
            return pull(w16);
        else if(typeof(F) == typeof(Cell32))
            return pull(w32);
        else if(typeof(F) == typeof(Cell64))
            return pull(w64);
        else
            return select(w128);
    }

    [MethodImpl(Inline)]
    F select(W128 w)
    {
        if(typeof(F) == typeof(Cell128))
            return pull(w128);
        else if(typeof(F) == typeof(Cell256))
            return pull(w256);
        else if(typeof(F) == typeof(Cell512))
            return pull(w512);
        else
            throw no<F>();
    }

    [MethodImpl(Inline)]
    F pull(W8 w)
        => cell(PolyCells.cell(DataSource, w));

    [MethodImpl(Inline)]
    F pull(W16 w)
        => cell(PolyCells.cell(DataSource, w));

    [MethodImpl(Inline)]
    F pull(W32 w)
        => cell(PolyCells.cell(DataSource, w));

    [MethodImpl(Inline)]
    F pull(W64 w)
        => cell(PolyCells.cell(DataSource, w));

    [MethodImpl(Inline)]
    F pull(W128 w)
        => cell(PolyCells.cell(DataSource, w));

    [MethodImpl(Inline)]
    F pull(W256 w)
        => cell(PolyCells.cell(DataSource, w));

    [MethodImpl(Inline)]
    F pull(W512 w)
        => cell(PolyCells.cell(DataSource, w));

    [MethodImpl(Inline)]
    static F cell<K>(in K x)
        where K : struct
            => @as<K,F>(x);
}
