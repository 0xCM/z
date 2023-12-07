//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct DynamicOp
{
    public Type DelegateType {get;}

    public DynamicMethod Definition {get;}

    public Delegate Delegate {get;}

    [MethodImpl(Inline)]
    public DynamicOp(DynamicMethod src, Delegate del, Type type)
    {
        DelegateType = type;
        Definition = src;
        Delegate = del;
    }
}
