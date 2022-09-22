//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IImmInjector
    {
        DynamicDelegate Inject(MethodInfo method, byte imm);
    }

    public interface IImmInjector<D> : IImmInjector
        where D : Delegate
    {
        DynamicDelegate<D> EmbedImmediate(MethodInfo src, byte imm);

        DynamicDelegate IImmInjector.Inject(MethodInfo src, byte imm)
            => EmbedImmediate(src, imm).Untyped;
    }
}