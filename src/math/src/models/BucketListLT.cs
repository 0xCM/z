//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class BucketList<L,T>
{
    readonly Index<Bucket<L,T>> Data;

    uint Current;

    public BucketList(uint capacity)
    {
        Data = alloc<Bucket<L,T>>(capacity);
        Current = 0;
    }

    public BucketList(Bucket<L,T>[] src)
    {
        Data = src;
        Current = (uint)src.Length;
    }

    public uint Capacity
    {
        [MethodImpl(Inline)]
        get => Data.Count;
    }

    public uint Count
    {
        [MethodImpl(Inline)]
        get => Current;
    }

    public ref Bucket<L,T> this[int index]
    {
        [MethodImpl(Inline)]
        get => ref Data[index];
    }

    public ref Bucket<L,T> this[uint index]
    {
        [MethodImpl(Inline)]
        get => ref Data[index];
    }

    [MethodImpl(Inline)]
    public BucketList<L,T> Include(params Bucket<L,T>[] src)
    {
        for(var i=0; Current<Capacity && i<src.Length; i++, Current++)
            this[Current] = skip(src,i);
        return this;
    }

    public string Format()
    {
        var dst = new StringBuilder();
        for(var i=0; i<Current; i++)
        {
            dst.Append(this[i].Format());
            dst.Append(Chars.NL);
        }
        return dst.ToString();
    }

    public override string ToString()
        => Format();

}
