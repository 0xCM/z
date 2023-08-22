//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct NativeUnion
{
    readonly NativeTypeSeq Data;

    public readonly Label Name;

    [MethodImpl(Inline)]
    public NativeUnion(Label name, NativeTypeSeq src)
    {
        Name = name;
        Data = src;
    }

    public uint MemberCount
    {
        [MethodImpl(Inline)]
        get => Data.Count;
    }
}
