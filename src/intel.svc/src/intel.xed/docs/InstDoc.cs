//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

public class XedInstDoc
{
    public readonly Index<InstDocPart> Parts;

    public XedInstDoc(InstDocPart[] src)
    {
        Parts = src.Sort();
    }

    public ref InstDocPart this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Parts[i];
    }

    public ref InstDocPart this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Parts[i];
    }

    public string Format()
        => new XedInstDocRender(this).Format();

    public override string ToString()
        => Format();
}

