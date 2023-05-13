//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISigDispenser : IAllocDispenser
    {
        NativeSigRef Sig(string scope, string name, NativeType ret, params NativeOpDef[] ops);

        NativeSigRef Sig(NativeSigSpec spec);
    }
}