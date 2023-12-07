//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct DynamicOp<D>
    where D : Delegate
{
    public DynamicMethod Definition {get;}

    public D Delegate {get;}

    [MethodImpl(Inline)]
    public DynamicOp(DynamicMethod src, D @delegate)
    {
        Definition = src;
        Delegate = @delegate;
    }

    [MethodImpl(Inline)]
    public static implicit operator DynamicOp(DynamicOp<D> src)
        => new (src.Definition, src.Delegate, typeof(D));

    [MethodImpl(Inline)]
    public static implicit operator DynamicOp<D>((DynamicMethod def, D @delegate) src)
        => new (src.def, src.@delegate);
}
