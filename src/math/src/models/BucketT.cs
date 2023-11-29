//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class Bucket<T>
{
    readonly Index<T> Data;

    public string Id {get;}

    uint Current;

    public Bucket(uint capacity, string id = null)
    {
        Data = alloc<T>(capacity);
        Id = id ?? EmptyString;
        Current = 0;
    }

    public Bucket(T[] data, string id = null)
    {
        Data = data;
        Id = id ?? EmptyString;
        Current = (uint)data.Length;
    }

    public uint Count
    {
        [MethodImpl(Inline)]
        get => Current;
    }

    public uint Capacity
    {
        [MethodImpl(Inline)]
        get => Data.Count;
    }

    public ref T this[int index]
    {
        [MethodImpl(Inline)]
        get => ref Data[index];
    }

    public ref T this[uint index]
    {
        [MethodImpl(Inline)]
        get => ref Data[index];
    }

    [MethodImpl(Inline)]
    public Bucket<T> Include(params T[] src)
    {
        for(var i=0; Current<Capacity && i<src.Length; i++, Current++)
            this[Current] = skip(src,i);
        return this;
    }

    public string Format(string sep = ", ")
    {
        var dst = new StringBuilder();
        if(nonempty(Id))
            dst.Append(Id);

        dst.Append(Chars.LParen);
        for(var i=0; i<Current; i++)
        {
            if(i != 0)
                dst.Append(sep);
            dst.Append(this[i].ToString());
        }
        dst.Append(Chars.RParen);
        return dst.ToString();
    }

    public override string ToString()
        => Format();
}
