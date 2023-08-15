//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class NativeSigs
{
    [Free]
    public interface ISigDispenser : IAllocDispenser
    {
        NativeSigRef Sig(string scope, string name, NativeType ret, params Operand[] ops);

        NativeSigRef Sig(NativeSig spec);
    }    
}
